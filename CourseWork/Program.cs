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
                } else if (choice == 2)
                {
                    stock_analysis();
                } else
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
            double a= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the value of b");
            double b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the value of c");
            double c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the value of d");
            double d = Convert.ToInt32(Console.ReadLine());

            // First differentiation - Values of A, B and C
            double fx1a = Math.Pow((a * 3), 2);
            double fx1b = Math.Pow((b * 2), 1);
            double fx1c = c;

            double fx1 = fx1a + fx1b + fx1c;
            if(fx1 != 0)
            {
                Console.WriteLine("No minimum or maximum found.");
            }

            // Second differentiation - Values of A and B
            double fx2a = 6 * a;
            double fx2b = 2 * b;
            double fx2 = fx2a + fx2b;

            // Quadratic Equation for roots
            double deno = 3 * a * 2;
            double numo = Math.Pow((2 * b), 2) - 4 * (3 * a + c);
            double xroot1 = ((-2 * b) + Math.Sqrt(numo)) / deno;
            double xroot2 = ((-2 * b) - Math.Sqrt(numo)) / deno;
            
            // F(xroot)
        }
        static void stock_analysis()
        {
            Console.WriteLine("THIS ALSO EXISTS");
        }
    }
}
