using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PodService.Abstract;

namespace PodService.Concrete
{
    public class PodTasks : IPodTasks
    {
        public string GetDateFromNow(int numberOfDays)
        {
            string dateFromNow = DateTime.Now.AddDays(numberOfDays).ToShortDateString();
            return dateFromNow;
        }
    }
}