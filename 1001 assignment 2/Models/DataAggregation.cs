using System.Text.RegularExpressions;

namespace Assi2_Data_Transmission.Models
{
    internal class DataAggregation
    {
        public void PerformDataAggregation(string outputGetList)
        {
            string[] tokens = outputGetList.Split("\r\n"); //using new line as delimiter
            int[] numbers = Regex.Matches(outputGetList, "(-?[0-9]+)").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();
            int count = numbers.Count();
            Console.Write("\nThe total number of directories in FTP = {0}.\n", count);
            // find maximum, minimum of student ID in the Redirect.txt file
            int j, maximum, minimum, average;
            Console.Write("\n\nFinding maximum, minimum and average of the IDs: \n\n");
            maximum = numbers[0];
            minimum = numbers[0];
            average = numbers[0];
            for (j = 1; j < count; j++)
            {
                if (numbers[j] > maximum)
                    maximum = numbers[j];  //find maximum
                if (numbers[j] < minimum)
                    minimum = numbers[j];  // find maximum
                numbers[j] += numbers[j];
                average = numbers[j] / count;
            }
            Console.Write("Maximum of Student ID is : {0}\n", maximum);
            Console.Write("Minimum of Student ID is : {0}\n", minimum);
            Console.Write("Average of Student ID is : {0}\n", average);
            //finding directory name(s) that begin with letter(s) entered by the user
            Console.Write("\n\nFinding directory name : Starts With letter=>");
            string startletter = Console.ReadLine().ToUpper(); //reads starting letters entered by the user
            Match namematch;
            int counter = 0;
            for (j = 0; j < count; j++)
            {
                string namesearch = tokens[j];
                namematch = Regex.Match(namesearch, @"\b[A-Za-z ]+\b");
                string search = namematch.Value;
                string fullname = Regex.Replace(search, @"^ ", ""); //removes blank space infront of each name
                if (fullname.StartsWith(startletter))
                {
                    counter++;
                    Console.Write("\n{0}", fullname);
                }
            }
            Console.WriteLine("\n\nTotal Count Starts with letter : {0} = {1}", startletter, counter);
            Console.Write("\n\nFinding directory name : Contain  letter=>");
            string containletter = Console.ReadLine(); //reads starting letters entered by the user
            Match namematch2;
            int counter2 = 0;
            for (j = 0; j < count; j++)
            {
                string namesearch = tokens[j];
                namematch2 = Regex.Match(namesearch, @"\b[A-Za-z ]+\b");
                string search = namematch2.Value;
                string fullname = Regex.Replace(search, @"^ ", ""); //removes blank space infront of each name
                if (fullname.Contains(containletter))
                {
                    counter2++;
                    Console.Write("\n{0}", fullname);
                }
            }
            Console.WriteLine("\n\nTotal Count Starts with letter : {0} = {1}", containletter, counter2);
        }
    }
}
