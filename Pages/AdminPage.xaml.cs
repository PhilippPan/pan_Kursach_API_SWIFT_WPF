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
using HRApplicationWPF.Classes;
using HRApplicationWPF.Pages;

namespace HRApplicationWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            UsersList.ItemsSource = Fclass.Ent.User.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Fclass.Frame.Navigate(new AddPage());
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Fclass.Frame.Navigate(new EditAdminPage());
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            UsersList.ItemsSource = Fclass.Ent.User.ToList();
        }
    }
}
