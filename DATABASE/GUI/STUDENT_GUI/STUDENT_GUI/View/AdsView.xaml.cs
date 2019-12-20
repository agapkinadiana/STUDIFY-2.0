using STUDENT_GUI.ErrorMessage;
using STUDENT_GUI.Model;
using STUDENT_GUI.ViewModel;
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

namespace STUDENT_GUI.View
{
    /// <summary>
    /// Логика взаимодействия для AdsView.xaml
    /// </summary>
    public partial class AdsView : Page
    {
        STUDENT currentStudent = STUDENT.CurrentUser;
        StudentViewModel studentViewModel = new StudentViewModel();
        AdsViewModel adsViewModel;

        public AdsView()
        {
            InitializeComponent();
            ConfigurateControlsIfNotHeadman();
            adsViewModel = new AdsViewModel();
            DataContext = adsViewModel;
        }

        private void ConfigurateControlsIfNotHeadman()
        {
            if (!studentViewModel.IsHeadman(currentStudent.ID))
            {
                Message_Content.Foreground = Brushes.Red;
                Message_Content.Text = "U can't leave messages :с";
                Message_Content.FontSize = 18;
                Message_Content.TextAlignment = TextAlignment.Center;
                Message_Content.IsReadOnly = true;
                Message_Content.Cursor = Cursors.Arrow;
                //Send_message.Visibility = Visibility.Collapsed;
                Delete_Message.IsEnabled = false;
            }
        }

        public void SendMessage()
        {
            if (studentViewModel.IsHeadman(currentStudent.ID))
            {
                adsViewModel.SendMessage(Message_Content.Text);
                ClearTextArea();
            }
        }

        private void Message_Content_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                SendMessage();
                adsViewModel.UpdateView();
            }
        }

        private void Message_Content_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ClearTextArea();
        }

        public void ClearTextArea()
        {
            Message_Content.Text = "";
        }

        private void Delete_Message_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ADS m = (Messages.SelectedItem as ADS);
            if (m.STUDENT_ID == currentStudent.ID)
            {
                adsViewModel.RemoveMessageById(m.ID);
                adsViewModel.UpdateView();
            }
            else MyMessageBox.Show("U can delete only ur posts!", MessageBoxButton.OK);
        }
    }
}
