using STUDENT_GUI.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.ViewModel
{
    class GroupViewModel
    {
        EFGroupRepository efGroupRepository = new EFGroupRepository();

        List<int> groupNumbers = new List<int>();
        List<int> courseNumbers = new List<int>();
        List<int> subgroupNumbers = new List<int>();

        public GroupViewModel()
        {
            GetGroupNumbers();
            GetCourseNumbers();
            GetSubroupNumbers();
        }

        public List<int> GroupNumbers
        {
            get { return groupNumbers; }
        }

        public List<int> CourseNumbers
        {
            get { return courseNumbers; }
        }

        public List<int> SubgroupNumbers
        {
            get { return subgroupNumbers; }
        }

        public void GetGroupNumbers()
        {
            foreach (var item in efGroupRepository.GetGroups())
            {
                groupNumbers.Add(Convert.ToInt32(item));
            }
        }

        public void GetCourseNumbers()
        {
            foreach (var item in efGroupRepository.GetCourses())
            {
                courseNumbers.Add(Convert.ToInt32(item));
            }
        }

        public void GetSubroupNumbers()
        {
            foreach (var item in efGroupRepository.GetSubgroups())
            {
                subgroupNumbers.Add(Convert.ToInt32(item));
            }
        }
    }
}
