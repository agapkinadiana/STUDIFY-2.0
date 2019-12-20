using ADMIN_GUI.DB;
using ADMIN_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN_GUI.ViewModel
{
    class StudentViewModel
    {
        STUDENT currentStudent = STUDENT.CurrentUser;
        EFStudentRepository eFStudentRepository = new EFStudentRepository();
        EFAdminRepository eFAdminRepository = new EFAdminRepository();

        public StudentViewModel()
        {
            //tmpStudents.Clear();
            GetStudents();
        }

        ObservableCollection<STUDENT> tmpStudents = new ObservableCollection<STUDENT>();

        public ObservableCollection<STUDENT> Students
        {
            get { return tmpStudents; }
        }

        STUDENT selectedItem;

        public STUDENT SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
            }
        }

        public void GetStudents()
        {
            tmpStudents.Clear();
            foreach (STUDENT item in eFStudentRepository.GetStudents())
            {
                tmpStudents.Add(item);
            }
        }

        public void SetHedman(int student_id)
        {
            eFAdminRepository.SetHedman(student_id);
            GetStudents();
        }

        public void DeleteStudent(int student_id)
        {
            eFStudentRepository.DeleteStudent(student_id);
            GetStudents();
        }
    }
}
