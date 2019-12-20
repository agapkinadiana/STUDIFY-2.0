using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.DB
{
    class EFAdsRepository
    {
        STUDIFY2Entities context;

        public EFAdsRepository()
        {
            context = new STUDIFY2Entities();
        }

        public ObjectResult<ADS> GetAds()
        {
            return context.getMessage();
        }

        public void AddMessage(string content, int id)
        {
            context.sendMessage(content, DateTime.Now, id);
        }

        public void DeleteMessage(int id)
        {
            context.deleteMessage(id);
        }

        public int CountMessage()
        {
            return context.countMessage().FirstOrDefault().Value;
        }
    }
}
