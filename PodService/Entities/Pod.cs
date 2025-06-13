using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevelopmentInfo.Abstract;

namespace DevelopmentInfo.Entities
{
    public class Pod : IPod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual DateTime StartDate { get; set; }
        public int Size { get; set; }
        public virtual int Qty { get; set; }
        public virtual decimal Price { get; set; }
        public virtual List<int> Values { get; set; }
        public Guid FamilyKey { get; set;}
        // Method must have public access to properly implement interface
        public virtual void PrintPodName() { Console.WriteLine("Pod Name is {0} in a {1} class", Name, this.GetType().Name); }
        public event EventHandler<IPropertyChangedResultEventArgs> PodPropertyChangedEvent;
    }
}
