using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevelopmentInfo.Entities;
using DevelopmentInfo.Abstract;

namespace DevelopmentInfo.Entities
{
    public class PodSubscriber : Pod
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public DateTime StartDate { get; set; }
        //public int Size { get; set; }
        //public int Qty { get; set; }
        //public decimal Price { get; set; }
        //public List<int> Values { get; set; }
        //public Guid FamilyKey { get; set; }
        
        // Method must have public access to properly implement interface
        // public void PrintPodName() { Console.WriteLine("Pod Name is {0}", Name); }

        public PodSubscriber()
        {         
        }

        public PodSubscriber(IPod podPublisher, int podId)
        {
            RegisterPod(podPublisher, podId);
        }

        public void RegisterPod(IPod podPublisher, int podId)
        {
            PodPublisher pod = (PodPublisher)podPublisher;
            pod.PodPropertyChangedEvent += HandlePodDataChange;
            Id = podId;
        }

        private void HandlePodDataChange(object publisher, IPropertyChangedResultEventArgs eventargs)
        {
            PropertyChangedResultEventArgs eventArguments = (PropertyChangedResultEventArgs)eventargs;

            if (eventArguments.PropertyChanged == PodProperty.ValueList)
            // if (eventargs.ValueChanged.GetType() == typeof(List<int>))
            {
                List<int> changedValues = (List<int>)(eventArguments.ValueChanged);
                Console.WriteLine("Pod ID: {0}  Property changed: {0}", Id, eventArguments.PropertyChanged);
                changedValues.ForEach(v => Console.WriteLine("\tValue = : {0}", v));
            }
            else
            {
                Console.WriteLine("Pod ID: {0}  Property changed: {1}  Value changed: {2}", Id, eventArguments.PropertyChanged, eventArguments.ValueChanged);
            }
            
        }

        public override void PrintPodName() { Console.WriteLine("Pod Name is {0} in a {1} class", Name, this.GetType().Name); }
    }
}
