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
    /// Логика взаимодействия для StudentInfo.xaml
    /// </summary>
    public partial class StudentInfo : Page
    {
        StudentInfoViewModel studentInfoViewModel = new StudentInfoViewModel();

        public StudentInfo()
        {
            InitializeComponent();
            DataContext = studentInfoViewModel;
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            studentInfoViewModel.LoadImageFromFS();
            DataContext = studentInfoViewModel;
        }
    }
}
