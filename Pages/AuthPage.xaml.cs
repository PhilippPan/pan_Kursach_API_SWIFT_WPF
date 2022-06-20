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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            txtLogin.Focus();
        }


        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var user = Fclass.Ent.User.FirstOrDefault(x => x.Login == txtLogin.Text && x.Password == txtPass.Password);
            if (user != null)
            {
                if (user.RoleID == 1)
                {
                    Fclass.Frame.Navigate(new DirectorPage());
                }
                if (user.RoleID == 2)
                {
                    Fclass.Frame.Navigate(new AdminPage());
                }
            } else { MessageBox.Show("Введите корректные данные"); txtLogin.Focus(); }
            txtLogin.Text = "";
            txtPass.Password = "";            
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                var user = Fclass.Ent.User.FirstOrDefault(x => x.Login == txtLogin.Text && x.Password == txtPass.Password);
                if (user != null)
                {
                    if (user.RoleID == 1)
                    {
                        Fclass.Frame.Navigate(new DirectorPage());
                    }
                    if (user.RoleID == 2)
                    {
                        Fclass.Frame.Navigate(new AdminPage());
                    }
                }
                else { MessageBox.Show("Введите корректные данные"); txtLogin.Focus(); }
                txtLogin.Text = "";
                txtPass.Password = "";
            }
        }
    }
}
