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
    class GroupViewModel
    {
        EFGroupRepository efGroupRepository = new EFGroupRepository();
        List<int> groupNumbers = new List<int>();
        List<int> courseNumbers = new List<int>();
        List<int> subgroupNumbers = new List<int>();

        ObservableCollection<GROUP> groupsForProfession = new ObservableCollection<GROUP>();

        public GroupViewModel()
        {
            GetGroupNumbers();
            GetCourseNumbers();
            GetSubroupNumbers();
        }

        public ObservableCollection<GROUP> GroupsForProfession
        {
            get { return groupsForProfession; }
        }

        public void GetGroupsForFaculty(string name)
        {
            groupsForProfession.Clear();
            foreach (GROUP item in efGroupRepository.GetGroupsByProfessionName(name))
            {
                groupsForProfession.Add(item);
            }
        }

        public void DeleteGroup(int group_id)
        {
            efGroupRepository.DeleteGroup(group_id);
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

        public void AddGoup(string faculty_name, string profession_name, int course, int group)
        {
            efGroupRepository.AddGoup(faculty_name, profession_name, course, group);
        }
    }
}
