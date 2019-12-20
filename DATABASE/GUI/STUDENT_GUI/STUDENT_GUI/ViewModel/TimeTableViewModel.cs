using STUDENT_GUI.DB;
using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.ViewModel
{
    class TimeTableViewModel : INotifyPropertyChanged
    {
        STUDENT currentStudent = STUDENT.CurrentUser;

        EFTimeTableRepository efTimeTable = new EFTimeTableRepository();
        EFSubjectRepository eFSubject = new EFSubjectRepository();

        private LESSON selectedTimeTable;
        private ObservableCollection<LESSON> timeTables = new ObservableCollection<LESSON>();
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
            subjects.Add("CLEAR");
        }

        public TimeTableViewModel()
        {
            GetSubjects();
        }

        public ObservableCollection<LESSON> TimeTables
        {
            get { return timeTables; }
            set { timeTables = value; }
        }

        public LESSON SelectedTimeTable
        {
            get
            {
                return selectedTimeTable;
            }
            set
            {
                if (value != null)
                {

                    selectedTimeTable = value;
                    Save();
                    OnPropertyChanged("SelectedTimeTable");
                }

            }
        }

        public ObservableCollection<LESSON> GetByWeekAdmin(string week, int course, int group, int subgroup)
        {
            TimeTables.Clear();
            foreach (LESSON tt in efTimeTable.GetByWeekAdmin(week, group, subgroup, course))
            {
                TimeTables.Add(tt);
            }
            return TimeTables;
        }

        public ObservableCollection<LESSON> GetByWeek(string week, int group, int subgroup)
        {
            TimeTables.Clear();
            foreach (LESSON tt in efTimeTable.GetByWeek(week, group, subgroup))
            {
                TimeTables.Add(tt);
            }
            return TimeTables;
        }

        public void LoadTT()
        {
            if (currentStudent.GROUP_ID != null)
            {
                if (efTimeTable.CheckTimeTableByIdGroup((int)currentStudent.GROUP_ID))
                {
                    for (int k = 1; k <= 2; k++)
                    {
                        for (int i = 1; i < 7; i++)
                        {
                            for (int j = 1; j < 5; j++)
                            {
                                LESSON t1 = new LESSON { LESSON_DAY = i, LESSON_NUMBER = j, GROUP_ID = (int)currentStudent.GROUP_ID, SUBGROUP_ID = k, LESSON_WEEK = "First" };
                                LESSON t2 = new LESSON { LESSON_DAY = i, LESSON_NUMBER = j, GROUP_ID = (int)currentStudent.GROUP_ID, SUBGROUP_ID = k, LESSON_WEEK = "Second" };
                                efTimeTable.AddTimetable(i, j, "First", (int)currentStudent.GROUP_ID, k);
                                efTimeTable.AddTimetable(i, j, "Second", (int)currentStudent.GROUP_ID, k);
                                TimeTables.Add(t1);
                                TimeTables.Add(t2);
                            }
                        }
                    }
                }
            }
        }
        public TimeTableViewModel(int id, int subgroup_id, string week)
        {
            efTimeTable.Clear();
            efTimeTable.getTimeTableByIdGroupAndWeek(id, subgroup_id, week);
            TimeTables = efTimeTable.getTimeTableLocal();
        }

        public TimeTableViewModel(int course, int group, int subgroup, string week)
        {
            efTimeTable.Clear();
            efTimeTable.getTimeTableByIdGroupAndWeekAdmin(course, group, subgroup, week);
            TimeTables = efTimeTable.getTimeTableLocal();
        }

        public void Save()
        {
            efTimeTable.Save();
        }

        public void UpdateSubject(string subject_name, int lesson_id)
        {
            efTimeTable.UpdateSubject(subject_name, lesson_id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public string CurrentWeek()
        {
            int dayStart = FirstSeptDay().DayOfYear - (int)FirstSeptDay().DayOfWeek + 1; //Номер понедельника в году в неделе с первым сентября
            if ((DaysSinceStart(dayStart) / 7) % 2 == 0)
            {
                return "First";
            }
            else return "Second";
        }

        private int DaysSinceStart(int dayStart)
        {
            if (DateTime.Now.Month > 8)
                return DateTime.Now.DayOfYear - dayStart;
            else
                if (DateTime.IsLeapYear(FirstSeptDay().Year))
                return 366 - dayStart + DateTime.Now.DayOfYear;
            else
                return 365 - dayStart + DateTime.Now.DayOfYear;
        }

        private DateTime FirstSeptDay()
        {
            DateTime d = DateTime.Now;
            DateTime ds;
            if (d.Month < 9)
                ds = new DateTime(DateTime.Now.Year - 1, 9, 1);
            else
                ds = new DateTime(DateTime.Now.Year, 9, 1);
            return ds;
        }
    }
}
