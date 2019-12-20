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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADMIN_GUI.View
{
    /// <summary>
    /// Логика взаимодействия для StudentsListView.xaml
    /// </summary>
    public partial class StudentsListView : Page
    {
        StudentViewModel studentViewModel = new StudentViewModel();

        public StudentsListView()
        {
            InitializeComponent();
            DataContext = studentViewModel;
            Students_Grid.ItemsSource = studentViewModel.Students;
        }

        private void Students_Grid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count == 0) return;
            var currentCell = e.AddedCells[0];
            if (currentCell.Column == Students_Grid.Columns[2])
            {
                Students_Grid.BeginEdit();
            }
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            studentViewModel.SetHedman(studentViewModel.SelectedItem.ID);
            Students_Grid.ItemsSource = studentViewModel.Students;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            studentViewModel.DeleteStudent(studentViewModel.SelectedItem.ID);
            Students_Grid.ItemsSource = studentViewModel.Students;
        }
    }
}
