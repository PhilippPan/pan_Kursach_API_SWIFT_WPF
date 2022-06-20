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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
            cmbRole.DisplayMemberPath = "RoleName";
            cmbRole.SelectedValuePath = "ID";
            cmbRole.ItemsSource = Fclass.Ent.Roles.ToList();
            cmbStatus.DisplayMemberPath = "EmployeeStatus";
            cmbStatus.SelectedValuePath = "ID";
            cmbStatus.ItemsSource = Fclass.Ent.Status.ToList();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User usr = new User()
                {
                    Login = txtLogin.Text,
                    Password = txtPass.Text,
                    RoleID = Convert.ToInt32(cmbRole.SelectedValue),
                    StatusID = Convert.ToInt32(cmbStatus.SelectedValue),
                    UserName = txtName.Text,
                    UserEmail = txtEmail.Text,
                    UserDateOfBirth = txtDate.SelectedDate
                };
                Fclass.Ent.User.Add(usr);
                Fclass.Ent.SaveChanges();
                MessageBox.Show("Новый сотрудник был успешно добавлен в систему!");
                //Fclass.Frame.GoBack();
            } catch { MessageBox.Show("Введите корректные данные! Логин должен состоять из заглавных и строчных латинских букв и цифр. Пароль должен содержать прописные и строчные латинские буквы, цифры и символы ! № @ % и тд. Почта должна быть введена корректно, роль и статус выбрать обязательно"); }
        }
    }
}
