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
    /// Логика взаимодействия для AdminMainPageView.xaml
    /// </summary>
    public partial class AdminMainPageView : Window
    {
        public AdminMainPageView()
        {
            InitializeComponent();

            Choose_Theme_Unchecked(this, new RoutedEventArgs());
        }

        private void MaxsizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.MaxHeight = SystemParameters.WorkArea.Height;
            if (WindowState != WindowState.Maximized)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void Roll_Up_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Choose_Theme_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,/Themes/Dark.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void Choose_Theme_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,/Themes/Light.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void Exit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
            AuthorizationView authorization = new AuthorizationView();
            authorization.Show();
        }

        private void Add_info_List_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new AddInfoView();
        }

        private void Group_list_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new StudentsListView();
        }

        private void TimeTable_List_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new TimeTableView();
        }
    }
}
