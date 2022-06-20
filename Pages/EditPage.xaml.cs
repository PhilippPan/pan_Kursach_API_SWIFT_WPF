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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public EditPage()
        {
            InitializeComponent();

            // НАПОЛНЕНИЕ КОМБОБОКСОВ ДАННЫМИ
            cmbLogin.DisplayMemberPath = "Login";
            cmbLogin.SelectedValuePath = "ID";
            cmbLogin.ItemsSource = Fclass.Ent.User.ToList();

            cmbRole.DisplayMemberPath = "RoleName";
            cmbRole.SelectedValuePath = "ID";
            cmbRole.ItemsSource = Fclass.Ent.Roles.ToList();

            cmbStatus.DisplayMemberPath = "EmployeeStatus";
            cmbStatus.SelectedValuePath = "ID";
            cmbStatus.ItemsSource = Fclass.Ent.Status.ToList();
        }

        private void cmbLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ПОДСТАНОВКА ДАННЫХ В ПОЛЯ В СООТВЕТСВИИ С ВЫБРАННЫМ ЛОГИНОМ
            int dataUser = (int)cmbLogin.SelectedValue;
            var usr = Fclass.Ent.User.FirstOrDefault(p => p.ID == dataUser);
            txtPass.Text = usr.Password;
            txtEmail.Text = usr.UserEmail;
            txtName.Text = usr.UserName;
            txtDate.SelectedDate = usr.UserDateOfBirth;
            cmbRole.SelectedValue = usr.RoleID;
            cmbStatus.SelectedValue = usr.StatusID;
        }

        private void btnSetUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // РЕДАКТИРОВАНИЕ ДАННЫХ
                var user = Fclass.Ent.User.Where(x => x.Login == cmbLogin.Text).FirstOrDefault();
                user.Password = txtPass.Text;
                user.UserName = txtName.Text;
                user.UserEmail = txtEmail.Text;
                user.UserDateOfBirth = txtDate.SelectedDate;
                user.StatusID = (int)cmbStatus.SelectedValue;
                user.RoleID = (int)cmbRole.SelectedValue; 

                Fclass.Ent.SaveChanges();
                MessageBox.Show("Данные обновлены");
            }
            catch { MessageBox.Show("Произошла ошибка"); }
        }
    }
}
