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
    /// Логика взаимодействия для ProgressView.xaml
    /// </summary>
    public partial class ProgressView : Page
    {
        ProgressViewModel progressViewModel = new ProgressViewModel();

        public ProgressView()
        {
            InitializeComponent();
            DataContext = progressViewModel;
        }

        private void LessonsBox_Loaded(object sender, RoutedEventArgs e)
        {
            LessonsBox.ItemsSource = progressViewModel.Subjects;
            LessonsBox.SelectedIndex = -1;
        }

        private void SetExistElementNotification()
        {
            NotificationMessgeToProgress.Content = "U have already selected this item! :)";
        }

        private void ClearNotification()
        {
            NotificationMessgeToProgress.Content = "";
        }

        private void AddProgress_Click(object sender, RoutedEventArgs e)
        {
            ClearNotification();
            if (LessonsBox.SelectedIndex != -1)
            {
                progressViewModel.AddProgress(LessonsBox.SelectedValue.ToString());
            }
            else NotificationMessgeToProgress.Content = "Choose subject!";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            progressViewModel.RemoveById();
        }

        private void NeededTasksMinus_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            progressViewModel.minusNeededTasks();
        }

        private void CompletedTasksPlus_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            progressViewModel.addComplitedTasks();
        }

        private void CompletedTasksMinus_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            progressViewModel.minusComplitedTasks();
        }

        private void NeededTasksPlus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            progressViewModel.addNeededTasks();
        }
    }
}
