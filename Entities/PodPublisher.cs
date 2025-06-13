using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevelopmentInfo.Abstract;

namespace DevelopmentInfo.Entities
{
    public enum PodProperty { Qty = 1, Price = 2, ValueList = 3, StartDate = 4 };

    // This class holds event parameters
    public class PropertyChangedResultEventArgs : EventArgs, IPropertyChangedResultEventArgs
    {
        public PodProperty PropertyChanged {get; private set;}
        public object ValueChanged { get; set; }

        /// <summary>
        /// Holder for the event arguments to notify the subscriber of the properties that were changed
        /// </summary>
        public PropertyChangedResultEventArgs(PodProperty podPropertyChanged, object valueChanged)
        {
            PropertyChanged = podPropertyChanged;
            ValueChanged = valueChanged;
        }
    }

    public class PodPublisher : Pod
    {
        private int qty = 0;
        private decimal price = 0.0M;
        private List<int> values = new List<int>() {33, 44, 55, 66};
        private DateTime startDate = new DateTime(2008, 11, 15, 6, 30, 0);

        public override int Qty
        {
            get { return qty;}
            set 
            { 
                qty = value;
                NotifyPodPropertyChanged(PodProperty.Qty, qty);
            }
        }
        
        public override decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                NotifyPodPropertyChanged(PodProperty.Price, price);
            }
        }
        
        public override List<int> Values
        {
            get { return values; }
            set
            {
                values = value;
                NotifyPodPropertyChanged(PodProperty.ValueList, values);
            }
        }

        public override DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                NotifyPodPropertyChanged(PodProperty.StartDate, startDate);
            }
        }

        // Can only be read from by the subscriber versus if you were to use a mulit cast delegate.
        public new event EventHandler<IPropertyChangedResultEventArgs> PodPropertyChangedEvent = null;

        private void NotifyPodPropertyChanged(PodProperty property, object value)
        {
            // Check if we have subscribers
            if (PodPropertyChangedEvent != null)
            {
                PodPropertyChangedEvent(this, new PropertyChangedResultEventArgs(property, value));
            }
        }

        public override void PrintPodName() { Console.WriteLine($"Pod Name is {Name} in a {this.GetType().Name} class"); }
    }
}






