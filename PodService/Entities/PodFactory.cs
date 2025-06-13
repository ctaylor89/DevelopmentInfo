using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevelopmentInfo.Abstract;
using System.Configuration;

namespace DevelopmentInfo.Entities
{
    public static class PodFactory 
    {
        static int podSelectValue = 0;

        public static IPod CreatePod()
        {
            IPod pod = null;
            
            try
            {
                string podSelection = ConfigurationManager.AppSettings["podSelection"];
                podSelectValue = int.Parse(podSelection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Consumer - Error getting pod selection: {0}", ex.Message);
                return null;
            }

            switch (podSelectValue)
            {
                case 1:
                    pod = new Pod();
                    pod.Name = "PodSelected";
                break;
                case 2:
                    pod = new PodSubscriber();
                    pod.Name = "PodSubscriberSelected";
                break;
                case 3:
                    pod = new PodPublisher();
                    pod.Name = "PodPublisherSelected";
                break;
            }

            return pod;
        }
    }
}
