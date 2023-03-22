using System;
using System.Collections.Generic;
using DevelopmentInfo.Abstract;

namespace DevelopmentInfo.Entities
{
    public enum Phases { OnHold = 0, PowerOn = 1, Hibernate = 2 }   // Outside of class and in the namespace

    public class Pod : IPod
    {
        private int weight = 0;
        private Phases mode;
        
        public Phases PodState { get; set; } = Phases.OnHold;   // Only auto-implemented properties can have initializers
        public Phases PodMode                       // Expression Bodied Property
        {
            get => mode;
            set => mode = value;
        }

        public Pod() => Name = "default";           // Expression Bodied Constructor.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; } = "Black";
        public virtual DateTime StartDate { get; set; } = DateTime.Now;
        public int Size { get; set; } = 0;          // Set a default size on a property
        public double PodTemp { get; set; } = 0.0;
        public virtual int Qty { get; set; } = 0;
        public virtual decimal Price { get; set; } = 0.00M;
        public virtual List<int> Values { get; set; }
        public Guid FamilyKey { get; set; }

        public int Weight                           // Expression Bodied Property
        {
            get => weight;
            set => weight = value;
        }

        // Expression Bodied Property
        public decimal TotalValue => (Qty * Price);

        // Expression Bodied Property
        public string Description => $"Name: {Name}  Identifier: {Id}";

        // Expression Bodied Method
        public string GetDescription() => $"Name: {Name}  Identifier: {Id}";

        // Expression Bodied method
        public void PrintPodWeight() => Console.WriteLine(value: $"Pod {Name} weighs {weight} lbs");

        // Method must have public access to properly implement interface
        public virtual void PrintPodName() { Console.WriteLine($"Pod Name is {Name} in a {(this.GetType().Name)} class"); }
        public event EventHandler<IPropertyChangedResultEventArgs> PodPropertyChangedEvent;

        // Expression Bodied Destructor
        ~Pod() => Console.WriteLine("Pod destructor is called");
    }
}
