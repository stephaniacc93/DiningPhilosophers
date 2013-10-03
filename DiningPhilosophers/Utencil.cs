using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    public class Utencil
    {
        public string Name { get; private set; }

        public Utencil(string name)
        {
            Name = name;
        }
    }
}
