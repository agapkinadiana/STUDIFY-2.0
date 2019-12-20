using STUDENT_GUI.DB;
using STUDENT_GUI.ErrorMessage;
using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace STUDENT_GUI.ViewModel
{
    class ProgressViewModel
    {
        STUDENT currentStudent = STUDENT.CurrentUser;

        EFTimeTableRepository efTimeTable = new EFTimeTableRepository();
        EFProgressRepository efProgress = new EFProgressRepository();
        EFSubjectRepository eFSubject = new EFSubjectRepository();

        int allTasks = 1;
        int complitedTasks = 0;
        int countProgress = 0;

        public ProgressViewModel()
        {
            GetSubjects();
            UpdateProgress();
        }

        public int COMPLITED_TASKS
        {
            get { return complitedTasks; }
            set
            {
                if (value >= 0)
                    complitedTasks = value;
            }
        }

        public int NEEDED_TASKS
        {
            get { return allTasks; }
            set
            {
                if (value > 0)
                    allTasks = value;
                UpdateProgress();
            }
        }

        public int PROGRESS_COUNT
        {
            get { return countProgress; }
            set
            {
                countProgress = value;
            }
        }

        public void UpdateProgress()
        {
            progresses.Clear();
            foreach (PROGRESS item in efProgress.GetProgress(currentStudent.ID))
            {
                progresses.Add(item);
            }

            if (SelectedItem != null)
            {
                PROGRESS_COUNT = (int)(SelectedItem.COMPLITED_TASKS * 100 / SelectedItem.NEEDED_TASKS);
                efProgress.UpdateProgress(SelectedItem.COMPLITED_TASKS, SelectedItem.NEEDED_TASKS, SelectedItem.ID);
                SelectedItem.PROGRESS_COUNT = PROGRESS_COUNT;
            }
        }

        public void AddProgress(string subject_name)
        {
            efProgress.AddProgress(currentStudent.ID, subject_name);
            UpdateProgress();
        }

        public void RemoveById()
        {
            efProgress.DeleteProgress(SelectedItem.ID);
            Progresses.Remove(SelectedItem);
        }

        public void addComplitedTasks()
        {
            if (SelectedItem != null)
            {
                if (SelectedItem.COMPLITED_TASKS < SelectedItem.NEEDED_TASKS)
                {
                    SelectedItem.COMPLITED_TASKS += 1;
                    UpdateProgress();
                }
            }
            else MyMessageBox.Show("Choose element!", MessageBoxButton.OK);
        }

        public void minusComplitedTasks()
        {
            if (SelectedItem != null)
            {
                if (SelectedItem.COMPLITED_TASKS > 0)
                {
                    SelectedItem.COMPLITED_TASKS -= 1;
                    UpdateProgress();
                }
            }
            else MyMessageBox.Show("Choose element!", MessageBoxButton.OK);
        }

        public void addNeededTasks()
        {
            if (SelectedItem != null)
            {
                SelectedItem.NEEDED_TASKS += 1;
                UpdateProgress();
            }
            else MyMessageBox.Show("Choose element!", MessageBoxButton.OK);
        }

        public void minusNeededTasks()
        {
            if (SelectedItem != null)
            {
                if (SelectedItem.NEEDED_TASKS > 1)
                {
                    SelectedItem.NEEDED_TASKS -= 1;
                    if (SelectedItem.COMPLITED_TASKS > SelectedItem.NEEDED_TASKS)
                    {
                        SelectedItem.COMPLITED_TASKS -= 1;
                        UpdateProgress();
                    }
                }
            }
            else MyMessageBox.Show("Choose element!", MessageBoxButton.OK);
        }

        PROGRESS selectedItem;
        ObservableCollection<PROGRESS> progresses = new ObservableCollection<PROGRESS>();

        public ObservableCollection<PROGRESS> Progresses
        {
            get { return progresses; }
            set { progresses = value; }
        }

        public PROGRESS SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value != null)
                    selectedItem = value;
            }
        }

        List<string> subjects = new List<string>();

        public List<string> Subjects
        {
            get { return subjects; }
        }

        public void GetSubjects()
        {
            foreach (var item in eFSubject.GetSubjects(currentStudent.GROUP.PROFESSION.PROFESSION_NAME))
            {
                subjects.Add(item.SUBJECT_NAME);
            }
        }
    }
}
