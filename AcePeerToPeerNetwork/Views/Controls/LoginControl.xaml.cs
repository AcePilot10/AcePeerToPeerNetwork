using AcePeerToPeerNetwork.Managers;
using AcePeerToPeerNetwork.Models;
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

namespace AcePeerToPeerNetwork.Views.Controls
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void btnLoginLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtLoginEmail.Text;
            string password = txtLoginPassword.Text;

            User user = UserManager.Instance.GetUser(email);

            if (user != null)
            {
                if (user.Password == password)
                {
                    UserManager.Instance.LoginUser(user);
                    return;
                }
            }
            MessageBox.Show("Email or password is incorrect!");
        }

        private void ResetFields()
        {
            txtLoginEmail.Clear();
            txtLoginPassword.Clear();
            txtLoginEmail.Focus();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ShowScreen(MainWindow.ScreenType.REGISTER);
        }
    }
}