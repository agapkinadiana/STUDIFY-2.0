using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.DB
{
    class EFGroupRepository
    {
        STUDIFY2Entities context;

        public EFGroupRepository()
        {
            context = new STUDIFY2Entities();
        }

        public ObjectResult<int?> GetGroups()
        {
            return context.getGroup();
        }

        public ObjectResult<int?> GetCourses()
        {
            return context.getCourse();
        }

        public ObjectResult<int?> GetSubgroups()
        {
            return context.getSubgroup();
        }

        public int GetIdGroup(int course, int group, int faculty_id, int profession_id)
        {
            return context.getGroupId(course, group, faculty_id, profession_id).FirstOrDefault().Value;
        }

        public int GetIdSubroup(int subgroup)
        {
            return context.getSubgroupId(subgroup).FirstOrDefault().Value;
        }
    }
}
