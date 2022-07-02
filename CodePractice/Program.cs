using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Main Starting - " + DateTime.Now.ToLongTimeString());
            var lf = new LINQFiddle();
            lf.RunQuerys();
        }

        public class LINQFiddle
        {
            const int PodCount = 5;
            List<Pod> Podlist = new List<Pod>();
            List<PodInfoItem> PodInfolist = new List<PodInfoItem>();
            public void RunQuerys()
            {
                Console.WriteLine("RunQuerys");
                var podSubset = Podlist
                    .Where(p => p.Id > 2)
                    .Select(n => new { PodName = n.Name, Identity = n.Id });

                foreach (var podItem in podSubset)
                    Console.WriteLine("PodName: {0}  Identity: {1}", podItem.PodName, podItem.Identity);

            }

            private void GeneratePodlist()
            {
                var podNames = new List<string>()
            {
                "Mercury3", "AtomX", "Baskar", "Triton", "Alamo", "Caltrax", "Heron", "Rover", "Rifter3", "Rifter4", "Rifter5", "Rever", "Locus",
                "Boxcar", "Halvar", "Tilde", "Mavid", "Mixer", "Crisper", "Cruton", "Dolittle", "Dwarf", "Dayton", "Eagle", "Edge", "Evinrude", "Johnson"
            };

                Guid familyKey = Guid.NewGuid();

                for (int i = 0; i < PodCount; i++)
                {
                    Podlist.Add(
                        new Pod
                        {
                            Id = i,
                            Name = podNames[i],
                            StartDate = DateTime.Now.AddDays(-new Random().Next(0, 365)),
                            Size = new Random().Next(30, 35)
                        }
                    );

                    PodInfolist.Add(new PodInfoItem
                    {
                        Id = i,
                        PodId = Podlist[i].Id,
                        ManufactoringDate = DateTime.Now
                    });
                }
            }

            public class Pod
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Color { get; set; }
                public virtual DateTime StartDate { get; set; }
                public int Size { get; set; }          // Set a default size on a property			
            }

            public class PodInfoItem
            {
                public int Id { get; set; }
                public int PodId { get; set; }
                public DateTime ManufactoringDate { get; set; }
            }
        }
    }
}
