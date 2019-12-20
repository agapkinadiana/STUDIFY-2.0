using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.DB
{
    class EFTimeTableRepository
    {
        private STUDIFY2Entities context;

        public EFTimeTableRepository()
        {
            context = new STUDIFY2Entities();
        }

        public ObjectResult<LESSON> GetTimeTable()
        {
            return context.getTimetable();
        }

        public ObjectResult<LESSON> GetByWeek(string week, int group, int subgroup)
        {
            return context.getTimetableByWeek(week, group, subgroup);
        }

        public ObjectResult<LESSON> GetByWeekAdmin(string week, int group, int subgroup, int course)
        {
            return context.getTimetableByWeekAdmin(week, group, subgroup, course);
        }

        public bool CheckTimeTableByIdGroup(int group_id)
        {
            if (context.checkTimetableByIdGroup(group_id).FirstOrDefault().Value == 0)
                return true;
            else return false;
        }

        public void AddTimetable(int day, int number, string week, int group_id, int subgroup_id)
        {
            context.insertTimetable(day, number, week, group_id, subgroup_id);
        }

        public void UpdateSubject(string subject_name, int lesson_id)
        {
            context.updateTimetable(subject_name, lesson_id);
        }

        ///////////////////

        public ObservableCollection<LESSON> getTimeTableLocal()
        {
            return context.LESSON.Local;
        }

        public void Clear()
        {
            context.LESSON.Local.Clear();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void getTimeTableByIdGroupAndWeek(int id, int subgroup_id, string week)
        {
            context.LESSON.Where(p => p.GROUP_ID == id && p.SUBGROUP_ID == subgroup_id && p.LESSON_WEEK == week).Load();
        }

        public void getTimeTableByIdGroupAndWeekAdmin(int course, int group, int subgroup, string week)
        {
            context.LESSON.Where(p => p.GROUP.COURSE == course && p.LESSON_WEEK == week && p.GROUP.GROUP_NUMBER == group && p.SUBGROUP.SUBGROUP_NUMBER == subgroup).Load();
        }
    }
}
