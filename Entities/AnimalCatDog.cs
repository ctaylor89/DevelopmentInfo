using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentInfo.Entities
{
    // Interface sample isx5
    public interface IAnimal
    {
        int Feet { get; set; }
        void Feed();
        string[] GetCommunicationMethod();
    }

    public class Cat : IAnimal
    {
        public int Feet { get; set; }
        public string Tail { get; set; }
        public string Name { get; set; }
        
        public void Feed()
        {
            string str = "Kitty eat this";
        }

        public string[] GetCommunicationMethod()
        {
            return new string[] { "Meow", "Pur", "Bite" };
        }
    }

    public class Dog : IAnimal
    {
        public int Feet { get; set; }
        public string Name { get; set; }

        public void Feed()
        {
            string str = "Hound eat this";
        }

        public string[] GetCommunicationMethod()
        {
            return new string[] { "Bark", "Yelp", "Howel" };
        }
    }

}
