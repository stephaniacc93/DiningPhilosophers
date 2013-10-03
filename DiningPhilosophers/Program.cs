using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numPhilosophers = 5;

            var utencils = new List<Utencil>();
            for (int i = 0; i < numPhilosophers; ++i)
            {
                utencils.Add(new Utencil(i % 2 == 0 ? "Fork" : "Knife"));
            }

            Task[] tasks = new Task[numPhilosophers];
            var philoshopers = new List<Philoshoper>();
            for (int i = 0; i < numPhilosophers; ++i)
            {
                philoshopers.Add(new Philoshoper(i + 1, utencils[i], utencils[(i + 1) == numPhilosophers ? 0 : i + 1]));

                int ix = i;
                tasks[ix] = new Task(() => philoshopers[ix].Eat());
            }

            Parallel.ForEach(tasks, t =>
            {
                t.Start();
            });


            Task.WaitAll(tasks);

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey(false);
        }

    }
}