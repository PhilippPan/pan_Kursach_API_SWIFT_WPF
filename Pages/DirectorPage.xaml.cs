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
    /// Логика взаимодействия для DirectorPage.xaml
    /// </summary>
    public partial class DirectorPage : Page
    {
        public DirectorPage()
        {
            InitializeComponent();
            UsersList.ItemsSource = Fclass.Ent.User.ToList();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(UsersList.SelectedItems.Count > 0)
            {
                var res = MessageBox.Show("Удалить данные о выбранных сотрудниках?", "Deleting member", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.OK)
                {
                    for (int i = 0; i < UsersList.SelectedItems.Count; i++)
                    {
                        User userObj = UsersList.SelectedItems[i] as User;
                        Fclass.Ent.User.Remove(userObj);
                    }
                    Fclass.Ent.SaveChanges();
                    //MessageBox.Show("Данные о выбранных пользователях удалены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    UsersList.ItemsSource = Fclass.Ent.User.ToList();
                }

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Fclass.Frame.Navigate(new EditPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Fclass.Frame.Navigate(new AddPage());

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            UsersList.ItemsSource = Fclass.Ent.User.ToList();
        }
    }
}
