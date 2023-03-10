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
            /*
             * 
             * Main Menu creation
             * Checks the users input to make sure that they select a valid option.
             * Invalid options will cause the menu to pop back up until the input is 3
             * Valid options will trigger other methods to be used via the appropriate input
             * 
             */

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

        /*
         * 
         * Takes the value of a, b, c and d in the form: ax^3 + bx^2 + cx + d
         * 
         * Uses those values to calculate the roots and the values for differential equations for each of the roots.
         * Discriminant is checked whether it is larger than 0, if it is not, it does not have a maximum or a minimum.
         * 
         * Differential equations are used for each root in order to find maximum and minimums for the equation and displayed correctly.
         * 
         */
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

        /*
         * 
         * Create a lines variable that reads all the lines individually from the given path for the file
         * 
         * Create a list for each of the required fields in order to differentiate each of them
         * Using a for loop, we can split the line up using .Split()
         * For each of the lines, each index will correspond to a different field within the file, add each of these to a variable.
         * DateOnly is used instead of DateTime as I do not want to display the time.
         * Use the variable containing the data and use the .Add() function in order to add the data into respective lists
         * 
         * Display the final menu to go from monthly stock analysis, yearly stock analysis or exit back to the main menu.
         * 
         */
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

            for (int i = 0; i < lines.Length; i++)
            {
                string[] rows = lines[i].Split(',');

                // Converting the data from strings to the correct data type so I need to convert them all
                DateOnly d = DateOnly.FromDateTime(Convert.ToDateTime(rows[0])); // This is DateOnly because if we used DateTime, it would include hh:mm:ss
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
                    monthly(open_prices, high_prices, low_prices, close_prices, volumes, dates);
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

        /*
         * 
         * Adding all the lists as parameters as I will be working with all of them.
         * 
         * First we create a new array called datefull which will just be the dates list as an array so we can work with it
         * Creating a new month list which will store all the month values so we can work with indexes.
         * Split the datefull array by the / as the format is dd/mm/yyyy so we can now extract the first index value per date which will be mm
         * Create a new list of indexes, these are the indexes we will be using on our main set of lists in order to get the correct values,
         * It takes the input of month as three letters and gets an integer value and compares it to the months list, if the values match, it will take the index and add it to the indexes list.
         * 
         * Adds all volumes within the list using appropriate indexes, compares the highest prices and lowest prices
         * Checks the Opening and Closing price and prints everything appropriately
         * 
         */
        static void monthly(List<double> open_prices, List<double> high_prices, List<double> low_prices, List<double> close_prices, List<int> volumes, List<DateOnly> dates)
        {

            // Creating a new list of months so we can compare to it.
            DateOnly[] datefull = dates.ToArray();
            var months = new List<int>();
            for (int i = 0; i < datefull.Length; i++)
            {

                String[] date = datefull[i].ToString().Split('/');
                int month = Convert.ToInt32(date[1]);
                months.Add(month);
            }

            // Find the month as an integer 
            int requiredmonth = 0;
            var indexes = new List<int>();
            Console.WriteLine("Enter a month as three letters: ");
            string monthstring = Console.ReadLine();
            switch (monthstring.ToUpper())
            {
                case "JAN":
                    requiredmonth = 1;
                    break;
                case "FEB":
                    requiredmonth = 2;
                    break;
                case "MAR":
                    requiredmonth = 3;
                    break;
                case "APR":
                    requiredmonth = 4;
                    break;
                case "MAY":
                    requiredmonth = 5;
                    break;
                case "JUN":
                    requiredmonth = 6;
                    break;
                case "JUL":
                    requiredmonth = 7;
                    break;
                case "AUG":
                    requiredmonth = 8;
                    break;
                case "SEP":
                    requiredmonth = 9;
                    break;
                case "OCT":
                    requiredmonth = 10;
                    break;
                case "NOV":
                    requiredmonth = 11;
                    break;
                case "DEC":
                    requiredmonth = 12;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

            // Find index of the selected month and add it to a list.
            for (int j = 0; j < months.Count; j++)
            {
                if (requiredmonth == months[j])
                {
                    indexes.Add(j);
                }
            }
            int volume = 0;
            double highest_price = 0;
            double lowhighest_price = 1;
            double lowest_price = 1;
            double highlowest_price = 0;

            for (int k = 0; k < indexes.Count; k++)
            {
                volume = volume + volumes[indexes[k]];
            }

            for (int l = 0; l < indexes.Count; l++)
            {
                if (highest_price < lowhighest_price)
                {
                    highest_price = lowhighest_price;
                    lowhighest_price = high_prices[indexes[l]];

                }
            }

            for (int p = 0; p < indexes.Count; p++)
            {
                if (lowest_price > low_prices[indexes[p]])
                {
                    lowest_price = low_prices[indexes[p]];
                }
            }



            Console.WriteLine("Selected Month:" + monthstring);
            Console.WriteLine("Opening Price: " + open_prices[indexes[0]]);
            Console.WriteLine("Closing Price: " + close_prices[indexes[indexes.Count - 1]]);
            Console.WriteLine("Highest Trading Price: " + highest_price);
            Console.WriteLine("Lowest Trading Price: " + lowest_price);
            Console.WriteLine("Total Trading Volume: " + volume);

        }


        /*
         * 
         * Converts the date where there is maximum volume into a string
         * Finds the price where the Volume is at the max
         * Finds the price a day before the volume is at max
         * Calculated the percentage change
         * Prints out all data accordingly, primarily using indexes.
         * 
         */
        static void yearly(List<DateOnly> dates, List<double> open_prices, List<double> high_prices, List<double> low_prices, List<double> close_prices, List<int> volumes)
        {
            String datemaxvolume = Convert.ToString(dates[volumes.IndexOf(volumes.Max())]);
            double firstprice = close_prices[volumes.IndexOf(volumes.Max())];
            double lastprice = close_prices[volumes.IndexOf(volumes.Max()) - 1];
            double changeprice = ((firstprice - lastprice) / lastprice) * 100;

            Console.WriteLine("Total number of trading days: " + dates.Count);
            Console.WriteLine("Opening price on the first day: " + open_prices[0]);
            Console.WriteLine("Closing price on last trading day: " + close_prices[close_prices.Count - 1]);
            Console.WriteLine("Highest trading price of the year: " + high_prices.Max());
            Console.WriteLine("Lowest trading price of the year: " + low_prices.Min());
            Console.WriteLine("Date with the highest trading volume: " + datemaxvolume + ", closing price change from the previous day: " + Math.Round(changeprice, 2) + "%");
        }
    }
}
