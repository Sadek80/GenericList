using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_List
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make an instance ov the GenericList
            var test = new GenericList<int>();

            // Adding 9 Values
            test.Add(30);
            test.Add(40);
            test.Add(50);
            test.Add(60);
            test.Add(70);
            test.Add(80);
            test.Add(90);
            test.Add(100);
            test.Add(110);
            
            // Basic list operations
            Console.WriteLine("Capacity after adding 9 values: " + test.Capacity);
            Console.WriteLine("Using count property: " + test.Count);

            Console.WriteLine("Printing value of index 4: " + test[4]);

            Console.WriteLine("Removing at index 4...");
            test.RemoveAt(4);

            Console.WriteLine("Printing value of index 4:" + test[4]);

            Console.WriteLine("Removing value 100...");
            test.Remove(100);

            Console.WriteLine("Check if value 100 is in the list: "+test.Contains(100));

            Console.WriteLine("Clearing the List...");
            test.clear();

            Console.WriteLine("Capacity after clearing: " + test.Capacity);
            Console.WriteLine("Using count after clearing: " + test.Count);

            // Testing Exception
            Console.WriteLine(test[-1]);
        }
    }
}
