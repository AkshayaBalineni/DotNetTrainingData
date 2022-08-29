using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenAndOdd_TheaterPattern
{
    public class EvenOddSquares
    {
        int i = 0, j = 0, z = 0;
        public void Main()
        {
            List<int> even = new List<int> { 2, 4, 6, 8, 10 };
            List<int> odd = new List<int> { 1,3,5,7,9 };
            List<int> square = new List<int> {2,4,16,256};
            bool loop = true;
            Console.WriteLine("1.Display All Lists");
            Console.WriteLine("2.Display Even List");
            Console.WriteLine("3.Display Odd List");
            Console.WriteLine("4.Display square List");
            while (loop)
            {
                Console.WriteLine("Enter Your Choice:");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch(ch)
                {
                    case 1: DisplayAll(even,odd,square);
                        break;
                    case 2: DisplayEven(even);
                        break;
                    case 3: DisplayOdd(odd);
                        break;
                    case 4: DisplaySquare(square);
                        break;
                    default: loop = false; Console.WriteLine("finished Writing");
                        break;
                }
            }
        }

        private void DisplayAll(List<int> even, List<int> odd, List<int> square)
        {
            Console.WriteLine("Even");
            foreach (var e in even)
                Console.Write(e + " ");
            Console.WriteLine();
            Console.WriteLine("Odd");
            foreach (var o in odd)
                Console.Write(o + " ");
            Console.WriteLine();
            Console.WriteLine("Square");
            foreach (var s in square)
                Console.Write(s + " ");
            Console.WriteLine();
        }

        private void DisplaySquare(List<int> square)
        {
            Console.WriteLine("Element from square = " + square[z++]);
            if (z == square.Count)
                z = 0;
        }
        private void DisplayOdd(List<int> odd)
        {
            Console.WriteLine("Element from odd = "+odd[i++]);
            if (i == odd.Count)
                i = 0;
        }
        private void DisplayEven(List<int> even)
        {
            Console.WriteLine("Element from even = "+even[j++]);
            if (j == even.Count)
                j = 0;
        }
    }
}
