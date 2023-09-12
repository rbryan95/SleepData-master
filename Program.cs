// See https://aka.ms/new-console-template for more information
// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // TODO: create data file
        using (StreamWriter writer = new StreamWriter("sleep_data.csv"))
    
        // Write the CSV header
        writer.WriteLine("Date,Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Total,Average");
        // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
        // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    Console.WriteLine("Week of {0:MMM}, {0:dd}, {0:yyyy}", dataDate);
        // random number generator
    Random rnd = new Random();

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        
        }
        int sum = hours.Sum();
        int avg = sum/7;
        // M/d/yyyy,#|#|#|#|#|#|#
        Console.WriteLine($"{dataDate:MMMM/dd/yyyy} ");
        Console.WriteLine("Su Mo Tu We Th Fr Sa Tot Avg");
        Console.WriteLine("-- -- -- -- -- -- -- --  --" );
        Console.WriteLine($"{string.Join("  ", hours)} {sum} {avg}");
        //Console.Write($"{string.Join("  ", hours)}");
        //average hours
        //Console.Write(avg);
        //Total hours
        
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    
}
else if (resp == "2")
{
    // TODO: parse data file
 Console.WriteLine("Enter the path of the data file to parse:");
    string filePath = Console.ReadLine();

    if (File.Exists(filePath))
    {
        // Read all lines from the CSV file
        string[] lines = File.ReadAllLines(filePath);

        // Display header
        Console.WriteLine("Date Su Mo Tu We Th Fr Sa Tot Avg");
        Console.WriteLine("--------------------------------");

        foreach (string line in lines)
        {
            // Split the CSV line into individual data elements
            string[] dataElements = line.Split(',');

            if (dataElements.Length >= 10)
            {
                string date = dataElements[0];
                string[] hours = dataElements.Skip(1).Take(7).ToArray();
                string totalHours = dataElements[8];
                string averageHours = dataElements[9];

                // Display the parsed data
                Console.WriteLine($"{date} {string.Join(" ", hours)} {totalHours} {averageHours}");
            }
            else
            {
                Console.WriteLine("Invalid data format in the file.");
            }
        }
    }
    else
    {
        Console.WriteLine("File not found. Please check the file path.");
    }

    // create data file


}
    
