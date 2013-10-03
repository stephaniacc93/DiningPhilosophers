using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    public class Philoshoper
    {
        public int Id { get; private set; }
        public Utencil LeftUtencil { get; private set; }
        public Utencil RightUtencil { get; private set; }

        public Philoshoper(int id, Utencil leftUtencil, Utencil rightUtencil)
        {
            Id = id;
            LeftUtencil = leftUtencil;
            RightUtencil = rightUtencil;
        }

        public void Eat()
        {

            lock (LeftUtencil)
            {
                Console.WriteLine("   Philosopher {0} picked {1}.", Id, LeftUtencil.Name);
                lock (RightUtencil)
                {
                    // Eat here
                    Console.WriteLine("   Philosopher {0} picked {1}.", Id, RightUtencil.Name);
                    Console.WriteLine("Philosopher {0} eats.", Id);

                    Task.Delay(5000);
                }
                Console.WriteLine("   Philosopher {0} released {1}.", Id, RightUtencil.Name);
            }
            Console.WriteLine("   Philosopher {0} released {1}.", Id, LeftUtencil.Name);
        }
    }
}
