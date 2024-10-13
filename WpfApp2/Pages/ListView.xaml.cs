using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListView.xaml
    /// </summary>
    public partial class ListView : Page
    {
        public ListView()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            ProductListView.ItemsSource = Data.KT4Entities.GetContext().Worckers.ToList();
            var item = Data.KT4Entities.GetContext().Worckers.FirstOrDefault();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
        public List<Data.Worckers> _currentWorkers = Data.KT4Entities.GetContext().Worckers.ToList();
        public void Update()
        {
            _currentWorkers = Data.KT4Entities.GetContext().Worckers.ToList();
            _currentWorkers = (from item in Data.KT4Entities.GetContext().Worckers
                               where item.UserName.ToLower().Contains(SearchTextBox.Text) ||
                               item.UserSurname.ToLower().Contains(SearchTextBox.Text) ||
                               item.UserPastname.ToLower().Contains(SearchTextBox.Text)
                               select item).ToList();

            ProductListView.ItemsSource = _currentWorkers;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
