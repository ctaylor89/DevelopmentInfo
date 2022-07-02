// http://en.wikipedia.org/wiki/Abstract_factory_pattern

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevelopmentInfo.Entities;
using DevelopmentInfo.Abstract;

namespace DevelopmentInfo.CodeSamples
{
    public class DesignPatterns
    {
        public void RunPatterns()
        {
            Console.WriteLine("*** Publisher/Subscriber Pattern");
            var publisherPod = new PodPublisher();
            var subscriberPod300 = new PodSubscriber(publisherPod, 300);
            var subscriberPod600 = new PodSubscriber(publisherPod, 600);

            publisherPod.Qty = 500;
            publisherPod.Price = 75.88M;
            publisherPod.StartDate = new DateTime(2013, 7, 12, 14, 45, 36);
            var newValues = new List<int>(){88, 77, 53, 2000};
            publisherPod.Values = newValues;
            
            Console.WriteLine("*** Factory Pattern. Class created based on configuration");

            IConsumer consumer = new Consumer();
            consumer.DisplayPodDescription();

            Console.ReadLine();


            // fork/join parallelism pattern

        }
    }
}
