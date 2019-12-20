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
    class TaskViewModel
    {
        STUDENT currentStudent = STUDENT.CurrentUser;

        EFTimeTableRepository efTimeTable = new EFTimeTableRepository();
        EFTaskRepository eFTask = new EFTaskRepository();
        EFSubjectRepository eFSubject = new EFSubjectRepository();

        public TaskViewModel()
        {
            GetSubjectsFilter();
            GetSubjects();
        }

        public void AddTask(DateTime deadline, string subject, string content)
        {
            eFTask.AddTask(currentStudent.ID, deadline, subject, content);
        }

        public void OrderTasks(string subject)
        {
            AllTasks.Clear();
            if (subject.Equals("ALL"))
            {
                foreach (TASK item in eFTask.GetTasks(currentStudent.ID))
                {
                    allTasks.Add(item);
                }
            }
            else
            {
                foreach (TASK item in eFTask.GetTasksBySubject(currentStudent.ID, subject))
                {
                    allTasks.Add(item);
                }
            }

        }

        public void ChangeTrue()
        {
            if (SelectedTask != null)
            {
                SelectedTask.IS_COMPLITE = true;
                eFTask.ChangeTrue(SelectedTask.ID);
                UpdateFalse();
            }
        }

        public void ChangeFalse()
        {
            if (SelectedTask != null)
            {
                SelectedTask.IS_COMPLITE = false;
                eFTask.ChangeFalse(SelectedTask.ID);
                UpdateTrue();
            }
        }

        public void UpdateTrue()
        {
            AllTasks.Clear();
            foreach (TASK item in eFTask.GetSatisfiedTasks(currentStudent.ID))
            {
                allTasks.Add(item);
            }
        }

        public void UpdateFalse()
        {
            AllTasks.Clear();
            foreach (TASK item in eFTask.GetUnsatisfiedTasks(currentStudent.ID))
            {
                allTasks.Add(item);
            }
        }

        public void RemoveTask()
        {
            eFTask.RemoveTaskById(SelectedTask.ID);
            allTasks.Remove(SelectedTask);
        }

        private TASK selectedTask;
        private ObservableCollection<TASK> allTasks = new ObservableCollection<TASK>();

        public ObservableCollection<TASK> AllTasks
        {
            get { return allTasks; }
            set
            {
                allTasks = value;
            }
        }

        public TASK SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
            }
        }

        List<string> subjectsFilter = new List<string>();

        public List<string> SubjectsFilter
        {
            get { return subjectsFilter; }
        }

        List<string> subjects = new List<string>();

        public List<string> Subjects
        {
            get { return subjects; }
        }

        public void GetSubjectsFilter()
        {
            foreach (var item in eFSubject.GetSubjects(currentStudent.GROUP.PROFESSION.PROFESSION_NAME))
            {
                subjectsFilter.Add(item.SUBJECT_NAME);
            }
            subjectsFilter.Add("ALL");
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
