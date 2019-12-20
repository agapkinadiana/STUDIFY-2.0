using STUDENT_GUI.DB;
using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.ViewModel
{
    class StudentViewModel
    {
        STUDENT currentStudent = STUDENT.CurrentUser;
        EFStudentRepository eFStudentRepository = new EFStudentRepository();

        public StudentViewModel()
        {
            GetStudentsHeadman();
        }

        public bool IsHeadman(int student_id)
        {
            if (eFStudentRepository.IsHeadman(student_id) == "Headman")
                return true;
            else return false;
        }

        ObservableCollection<STUDENT> tmpStudentsHeadman = new ObservableCollection<STUDENT>();

        public ObservableCollection<STUDENT> StudentsHeadman
        {
            get { return tmpStudentsHeadman; }
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

        public void GetStudentsHeadman()
        {
            tmpStudentsHeadman.Clear();
            foreach (STUDENT item in eFStudentRepository.GetStudentsForHeadman(currentStudent.GROUP.COURSE, currentStudent.GROUP.GROUP_NUMBER, currentStudent.GROUP.FACULTY_ID, currentStudent.GROUP.PROFESSION_ID))
            {
                tmpStudentsHeadman.Add(item);
            }
        }
    }
}
