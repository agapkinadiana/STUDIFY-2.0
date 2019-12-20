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
    class AdsViewModel
    {
        STUDENT currentStudent = STUDENT.CurrentUser;
        EFAdsRepository eFAdsRepository = new EFAdsRepository();

        ObservableCollection<ADS> tmpMessages = new ObservableCollection<ADS>();

        public ObservableCollection<ADS> Messages
        {
            get { return tmpMessages; }
        }

        public AdsViewModel()
        {
            UpdateView();
        }

        public void RemoveMessageById(int id)
        {
            eFAdsRepository.DeleteMessage(id);
        }

        public void UpdateView()
        {
            tmpMessages.Clear();
            foreach (ADS item in eFAdsRepository.GetAds())
            {
                tmpMessages.Add(item);
            }
        }

        public void SendMessage(string content)
        {
            if (!content.Equals(String.Empty))
            {
                eFAdsRepository.AddMessage(content, currentStudent.ID);
            }
        }
    }
}
