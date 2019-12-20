using ADMIN_GUI.Model;
using ADMIN_GUI.ViewModel;
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
using System.Windows.Shapes;

namespace ADMIN_GUI.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationView.xaml
    /// </summary>
    public partial class AuthorizationView : Window
    {
        AuthorizationViewModel authorizationViewModel;

        public AuthorizationView()
        {
            InitializeComponent();

            authorizationViewModel = new AuthorizationViewModel();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Roll_Up_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            if (authorizationViewModel.СompareDataOfAdmin(Login.Text, Password.Password))
            {
                Hide();
                STUDENT currentUser = authorizationViewModel.SetAdmin();
                STUDENT.CurrentUser = currentUser;
                AdminMainPageView adminMainPageView = new AdminMainPageView();
                adminMainPageView.Show();
            }
        }
    }
}
