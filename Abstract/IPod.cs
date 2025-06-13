using System;
using System.Collections.Generic;

namespace DevelopmentInfo.Abstract
{
    public interface IPod
    {
        int Id { get; set; }
        //Id => Id;
        string Name { get; set; }
        DateTime StartDate { get; set; }
        int Size { get; set; }
        int Qty { get; set; }
        decimal Price { get; set; }
        List<int> Values { get; set; }
        Guid FamilyKey { get; set; }
        // Method must have public access to properly implement interface
        void PrintPodName();
        event EventHandler<IPropertyChangedResultEventArgs> PodPropertyChangedEvent;
        
    }
}
