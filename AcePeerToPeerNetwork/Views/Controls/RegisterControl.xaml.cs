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
    /// Interaction logic for RegisterControl.xaml
    /// </summary>
    public partial class RegisterControl : UserControl
    {
        public RegisterControl()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ShowScreen(MainWindow.ScreenType.LOGIN);
        }

        private void btnRegisterRegister_Click(object sender, RoutedEventArgs e)
        {
            string email = txtRegisterEmail.Text;
            string username = txtRegisterUsername.Text;
            string password = txtRegisterPassword.Text;
            int uid = UserManager.Instance.GenerateUID();
            User user = new User()
            {
                Email = email,
                Password = password,
                UID = uid,
                Username = username
            };
            UserManager.Instance.RegisterUser(user);
        }
    }
}
