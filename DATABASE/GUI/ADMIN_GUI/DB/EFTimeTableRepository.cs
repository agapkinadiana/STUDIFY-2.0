using ADMIN_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN_GUI.DB
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

        public ObjectResult<LESSON> GetByWeekAdmin(string week, int group, int subgroup, int course)
        {
            return context.getTimetableByWeekAdmin(week, group, subgroup, course);
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
