using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevelopmentInfo.Abstract;

namespace DevelopmentInfo.Entities
{
    public class Consumer : IConsumer
    {
        IPod pod = null;

        public Consumer()
        {
            pod = PodFactory.CreatePod();
        }

        public void DisplayPodDescription()
        {
            if(pod != null)
                pod.PrintPodName();
            else
                Console.WriteLine("Null pod type returned from factory");
        }
    }
}
