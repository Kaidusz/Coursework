using Microsoft.VisualBasic;
using System.Transactions;
using System.IO;
using System.Collections.Specialized;
using System.Linq;
using System.Globalization;
using System.ComponentModel;
using System.Data.Common;

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
            double discriminant = 4 * (b * b) - 12 * a * c;


            // Check if there are roots with discriminant

            if (discriminant > 0)
            {
                // Roots
                double xroot1 = (-2 * b + Math.Sqrt(discriminant)) / (deno);
                double xroot2 = (-2 * b - Math.Sqrt(discriminant)) / (deno);

                // Corresponding y coordinates
                double y1 = a * Math.Pow(xroot1, 3) + b * Math.Pow(xroot1, 2) + c * xroot1 + d;
                double y2 = a * Math.Pow(xroot2, 3) + b * Math.Pow(xroot2, 2) + c * xroot2 + d;

                // Differentiation for first root
                double df1 = 3 * xroot1 * xroot1 + 2 * b * xroot1 + c;
                double dff1 = 6 * a * xroot1 + 2 * b;

                // Differentiation for second root
                double df2 = 3 * a * xroot2 * xroot2 + 2 * b * xroot2 + c;
                double dff2 = 6 * a * xroot2 + 2 * b;

                // Finding the maximum or minimum for the first root
                if (df1 == 0 && dff1 < 0)
                {
                    Console.WriteLine("The maximum is at (X =" + Math.Round(xroot1, 2) + " f(x) =" + Math.Round(y1, 2));
                }
                else if (df1 == 0 && dff1 > 0)
                {
                    Console.WriteLine("The minimum is at (X =" + Math.Round(xroot1, 2) + " f(x) =" + Math.Round(y1, 2));
                }
                else if (df1 == 0 && dff1 == 0)
                {
                    Console.WriteLine("There may be an inflection in your function");
                }

                // Finding the maximim or minimum for the second root
                if (df2 == 0 && dff2 < 0)
                {
                    Console.WriteLine("The maximum is at (X =" + Math.Round(xroot2, 2) + " f(x) =" + Math.Round(y2, 2));
                }
                else if (df2 == 0 && dff2 > 0)
                {
                    Console.WriteLine("The minimum is at (X =" + Math.Round(xroot2, 2) + " f(x) =" + Math.Round(y2, 2));
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
            string[] lines = File.ReadAllLines(@"C:\Users\guran\Downloads\AMD.csv");

            // Creating lists for each field within the file
 
            var dates = new List<DateOnly>();
            var open_prices = new List<Double>();
            var high_prices = new List<Double>();
            var low_prices = new List<Double>();
            var close_prices = new List<Double>();
            var volumes = new List<int>();
            var datesasstrings = new List<String>();
            var months = new List<int>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] rows = lines[i].Split(',');

                // Converting the data from strings to the correct data type so I need to convert them all
                DateOnly d = DateOnly.FromDateTime(Convert.ToDateTime(rows[0])); // This is DateOnly because if we used DateTime, it would include hh:mm:ss
                String datestring = Convert.ToString(rows[0]);
                double op = Convert.ToDouble(rows[1]);
                double hp = Convert.ToDouble(rows[2]);
                double lp = Convert.ToDouble(rows[3]);
                double cp = Convert.ToDouble(rows[4]);
                int v = Convert.ToInt32(rows[5]);


                // Adding fields from our CSV file to my lists, I will be working entirely with indexes
                dates.Add(d);
                open_prices.Add(op);
                high_prices.Add(hp);
                low_prices.Add(lp);
                close_prices.Add(cp);
                volumes.Add(v);
                datesasstrings.Add(datestring);

                String[] date = datesasstrings[i].Split('/');
                for (int j = 0; j < date.Length; j++)
                {
                    months.Add(Convert.ToInt32(date[j]));
                    Console.WriteLine(months);
                }

                
            }
            Console.WriteLine("\t\t Stocks Menu \n\t Please select an option from below:\n1) Yearly Data Analysis\n2) Monthly Data Analysis\n3) Back to Main Menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            while (choice != 3)
            {
                if (choice == 1)
                {
                    yearly(dates, open_prices, high_prices, low_prices, close_prices, volumes);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("This feature has not been implemented.");
                    monthly(open_prices, high_prices, low_prices, close_prices, volumes, months);
                }
                else if (choice == 3)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                Console.WriteLine("\t\tStocks Menu \n\t Please select an option from below:\n1) Yearly Data Analysis\n2) Monthly Data Analysis\n3) Back to Main Menu");
                choice = Convert.ToInt32(Console.ReadLine());
            }
        }

        private static void monthly(List<double> open_prices, List<double> high_prices, List<double> low_prices, List<double> close_prices, List<int> volumes, List<int> months)
        {
        }

        static void yearly(List<DateOnly> dates, List<double> open_prices, List<double> high_prices, List<double> low_prices, List<double> close_prices, List<int> volumes)
        {
            String datemaxvolume = Convert.ToString(dates[volumes.IndexOf(volumes.Max())]);
            double firstprice = close_prices[volumes.IndexOf(volumes.Max())];
            double lastprice = close_prices[volumes.IndexOf(volumes.Max()) - 1];
            double changeprice = ((lastprice - firstprice) / lastprice) * 100;

            Console.WriteLine("Total number of trading days: " + dates.Count);
            Console.WriteLine("Opening price on the first day: " + Math.Round(open_prices[0]), 2);
            Console.WriteLine("Closing price on last trading day: " + Math.Round(close_prices[close_prices.Count - 1]), 2);
            Console.WriteLine("Highest trading price of the year: " + Math.Round(high_prices.Max()), 2);
            Console.WriteLine("Lowest trading price of the year: " + Math.Round(low_prices.Min()), 2);
            Console.WriteLine("Date with the highest trading volume: " + datemaxvolume + ", closing price change from the previous day: " + changeprice + "%");
        }
    }
}
