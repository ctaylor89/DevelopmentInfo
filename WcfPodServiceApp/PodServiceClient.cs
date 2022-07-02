using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfPodServiceLibrary;

namespace DevelopmentInfo.Entities
{
    public class PodServiceClient : Pod
    {
        PodService podService = new PodService();

        public override DateTime StartDate { get; set; }

        public PodServiceClient()
        {
            StartDate = podService.GetDateDaysAgo(5);
        }
    }
}
