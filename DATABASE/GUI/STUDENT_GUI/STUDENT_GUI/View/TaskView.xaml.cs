using STUDENT_GUI.ErrorMessage;
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
    /// Логика взаимодействия для TaskView.xaml
    /// </summary>
    public partial class TaskView : Page
    {
        TaskViewModel taskViewModel = new TaskViewModel();

        public TaskView()
        {
            InitializeComponent();
            DataContext = taskViewModel;
        }

        private void ToNewTask_Click(object sender, RoutedEventArgs e)
        {
            ToNewTask.Visibility = Visibility.Hidden;
            NewTask.Visibility = Visibility.Visible;
        }

        private void FilterBySubject_Loaded(object sender, RoutedEventArgs e)
        {
            FilterBySubject.ItemsSource = taskViewModel.SubjectsFilter;
            FilterBySubject.SelectedItem = "ALL";
            if (TaskComplite.SelectedIndex == 0)
            {
                taskViewModel.UpdateFalse();
            }
            else taskViewModel.UpdateTrue();
        }

        private void LessonsBox_Loaded(object sender, RoutedEventArgs e)
        {
            LessonsBox.ItemsSource = taskViewModel.Subjects;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ToNewTask.Visibility = Visibility.Visible;
            NewTask.Visibility = Visibility.Hidden;
            Clear();
        }

        private void Clear()
        {
            //Title.Text = "";
            Content.Text = "";
            LessonsBox.SelectedIndex = -1;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Deadline.Text != String.Empty && Content.Text != String.Empty)
            {
                taskViewModel.AddTask(Convert.ToDateTime(Deadline.SelectedDate), LessonsBox.SelectedValue.ToString(), Content.Text);
                Clear();
                taskViewModel.OrderTasks(FilterBySubject.SelectedValue.ToString());
                if (TaskComplite.SelectedIndex == 0)
                {
                    taskViewModel.UpdateFalse();
                }
                else taskViewModel.UpdateTrue();
                //taskViewModel.OrderTasks(TaskComplite.SelectedValue.ToString());
            }
            else MyMessageBox.Show("Fill in all the fields", MessageBoxButton.OK);
        }

        private void FilterBySubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            taskViewModel.OrderTasks(FilterBySubject.SelectedValue.ToString());
        }

        private void Is_complite_Checked(object sender, RoutedEventArgs e)
        {
            taskViewModel.ChangeTrue();
        }

        private void Is_complite_Unchecked(object sender, RoutedEventArgs e)
        {
            taskViewModel.ChangeFalse();
        }

        private void TaskComplite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TaskComplite.SelectedIndex == 0)
            {
                taskViewModel.UpdateFalse();
            }
            else taskViewModel.UpdateTrue();
        }

        private void Delete_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            taskViewModel.RemoveTask();
        }
    }
}
