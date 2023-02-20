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
            Console.WriteLine("THIS EXISTS");
        }
        static void stock_analysis()
        {
            Console.WriteLine("THIS ALSO EXISTS");
        }
    }
}