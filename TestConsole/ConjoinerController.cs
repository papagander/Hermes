using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public static class ConjoinerController
    {
        private void Run()
        {
            Console.Write("Conjoiner.");
            string? input = Console.ReadLine().ToLower();
            while (true)
            {
                Console.Write("Conjoiner.");
                switch (input)
                {
                    case "add":
                        CreateConjoiner();
                        break;
                    case "get":
                        GetConjoiners();
                        break;
                    case "help":
                        ConjoinerHelp();
                        break;
                }
                input = Console.ReadLine().ToLower();
                Console.WriteLine();
            }
        }

        private void GetConjoiners()
        {
            var Conjoiners = S.GetAllConjoiners();
            foreach (var item in Conjoiners)
            {
                Console.WriteLine($"{item.ConjoinerId}. {item.ConjoinerName}");
            }
        }

        private void ConjoinerHelp()
        {
            throw new NotImplementedException();
        }

        public void CreateConjoiner()
        {
            int output;
            Console.WriteLine("Please provide a conjoiner name");
            string name = Console.ReadLine();
            if (name is null)
            {
                Console.Clear();
                CreateConjoiner();
                return;
            }
            output = S.CreateConjoiner(name);
            if (output == 0) Console.WriteLine("Failed to create conjoiner.");
            if (output == 1) Console.WriteLine($"Created conjoiner {name}");
            else Console.WriteLine($"Service returned: {output}");
            Pause(2);
            Console.Clear();
        }
        internal void CreateConjoiner(string v)
        {
            S.CreateConjoiner(v);
        }
    }
}
