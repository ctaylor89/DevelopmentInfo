using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfPodServiceLibrary
{
    public class PodService : IPodServices
    {
        public DateTime GetDateDaysAgo(int numberOfDaysAgo)
        {
            return DateTime.Now;
        }

        public string AddSpaceBetweenChars(string input)
        {
            //TODO: Implement method
            return "Not Implemented";
        }
    }
}
