using Microsoft.VisualBasic;
using System.Transactions;

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

            // Quadratic Equation simplifying
            double deno = 3 * a * 2;
            double numo = 4 * (b * b) - 12 * a * c;


            // Check if there are roots with discriminant

            if (numo > 0)
            {
                // Roots
                double xroot1 = (-2 * b + Math.Sqrt(numo)) / (deno);
                double xroot2 = (-2 * b - Math.Sqrt(numo)) / (deno);

                // Corresponding y coordinates
                double y1 = a * Math.Pow(xroot1, 3) + b * Math.Pow(xroot1, 2) + c * xroot1 + d;
                double y2 = a * Math.Pow(xroot2, 3) + b * Math.Pow(xroot2, 2) + c * xroot2 + d;

                // Differentiation for first root
                double df1 = 3 * xroot1 * xroot1 + 2 * b * xroot1 + c;
                double dff1 = 6 * a * xroot1 + 2 * b;

                // Differentiation for second root
                double df2 = 3 * a * xroot2 * xroot2 + 2 * b * xroot2 + c;
                double dff2 = 6 * a * xroot2 + 2 * b;

                // For the first root
                if (df1 == 0 && dff1 < 0)
                {
                    Console.WriteLine($"The maximum is at (X = {xroot1}, f(x) = {y1}");
                }
                else if (df1 == 0 && dff1 > 0)
                {
                    Console.WriteLine($"The minimum is at (X = {xroot1}, f(x) = {y1}");
                } else if (df1 == 0 && dff1 == 0)
                {
                    Console.WriteLine("There may be an inflection in your function");
                }

                // For the second root
                if (df2 == 0 && dff2 < 0)
                {
                    Console.WriteLine($"The maximum is at (X = {xroot2}, f(x) = {y2})");
                }
                else if (df2 == 0 && dff2 > 0)
                {
                    Console.WriteLine($"The minimum is at (X = {xroot2}, f(x) = {y2})");
                }
                else if (df2 == 0 && dff2 == 0)
                {
                    Console.WriteLine("There may be an inflection in your function");
                }
            }
            else
            {
                Console.WriteLine("No minimum or maximum found");
            }

        }
        static void stock_analysis()
        {
            Console.WriteLine("THIS ALSO EXISTS");
        }
    }
}
