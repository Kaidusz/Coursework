using Microsoft.VisualBasic;

namespace CourseWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tMain Menu \n\t Please select an option from below:\n1) Find the local minimum and maximum of a cubic function\n2) Stock analysis\n3) Exit Program");
            int choice = Convert.ToInt32(Console.ReadLine());
            while (choice != 3)
            {
                if (choice == 1)
                {
                    cubic_max_min_finder();
                }
                else if (choice == 2)
                {
                    stock_analysis();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                Console.WriteLine("\t\tCoursework Menu \n\t Please select an option from below:\n1) Find the local minimum and maximum of a cubic function\n2) Stock analysis\n3) Exit Program");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Have a great day");
        }
        static void cubic_max_min_finder()
        {
            // Initialise the values of a, b, c and d
            Console.WriteLine("In the form of ax^3 + bx^2 + cx + d");
            Console.WriteLine("Input the value of a");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the value of b");
            double b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the value of c");
            double c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the value of d");
            double d = Convert.ToInt32(Console.ReadLine());

            // Quadratic Equation for roots
            double deno = 3 * a * 2;
            double numo = Math.Pow((2 * b), 2) - 4 * (3 * a + c);
            double xroot1 = ((-2 * b) + Math.Sqrt(numo)) / deno;
            double xroot2 = ((-2 * b) - Math.Sqrt(numo)) / deno;

            // First differentiation - Values of A, B and C
            double fx1a1 = 3 * a * Math.Pow(xroot1, 2);
            double fx1b1 = 2 * b * Math.Pow(xroot1, 1);
            double fx1c1 = c;
            double fx11 = fx1a1 + fx1b1 + fx1c1;

            double fx1a2 = 3 * a * Math.Pow(xroot2, 2);
            double fx1b2= 2 * b * Math.Pow(xroot2, 1);
            double fx1c2 = c;
            double fx12 = fx1a2 + fx1b2 + fx1c2;

            double fx2a = 6 * a * xroot1;
            double fx2b = 2 * b;
            double fx2 = fx2a + fx2b;

            double fy1 = a * Math.Pow(xroot1, 3) + b * Math.Pow(xroot1, 2) + c * xroot2 + d;
            if (fx1a1 != 0)
            {
                Console.WriteLine("No maximum or Minimum root found");
            } else if ((fx2 < 0) && fx11 == 0)  {
                Console.WriteLine($"Maximum at X:{xroot1}, Y:{fy1}");
            } else if ((fx2 > 0) && (fx11 == 0)) {
                Console.WriteLine($"Minimum at X:{xroot1}, Y:{fy1}");
            }
        }
        static void stock_analysis()
        {
            Console.WriteLine("THIS ALSO EXISTS");
        }
    }
}
