using ADMIN_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN_GUI.DB
{
    class EFGroupRepository
    {
        STUDIFY2Entities context;

        EFFacultyRepository efFacultyRepository = new EFFacultyRepository();

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

        public ObjectResult<GROUP> GetGroupsByProfessionName(string profession_name)
        {
            return context.getGroupByProfessionName(profession_name);
        }

        public ObjectResult<int?> GetSubgroups()
        {
            return context.getSubgroup();
        }

        public void AddGoup(string faculty_name, string profession_name, int course, int group)
        {
            context.insertGroup(efFacultyRepository.GetIdProfession(profession_name), efFacultyRepository.GetIdFaculty(faculty_name), course, group);
        }

        public void DeleteGroup(int group_id)
        {
            context.deleteGroup(group_id);
        }
    }
}
