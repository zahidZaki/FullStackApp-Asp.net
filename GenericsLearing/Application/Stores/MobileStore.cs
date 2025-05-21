using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLearing.Application.Models;

namespace GenericsLearing.Application.Stores
{
    internal class MobileStore
    {
        List<Mobile> mobiles = new List<Mobile>();
        Dictionary<string, Mobile> mobileDict = new Dictionary<string, Mobile>();
        internal void AddMobile(Mobile mobile)
        {
            mobiles.Add(mobile);
            mobileDict.Add(mobile.ID, mobile);
        }
        internal List<Mobile> GetAllMobiles()
        {
            return mobiles;
        }
        internal Mobile GetMobileById(string id)
        {
            if (mobileDict.ContainsKey(id))
            {
                return mobileDict[id];
            }
            else
            {
                return null;
            }
        }
        internal void RemoveMobile(string id)
        {
            if (mobileDict.ContainsKey(id))
            {
                mobiles.Remove(mobileDict[id]);
                mobileDict.Remove(id);
            }
        }
    }
}
