namespace AdventOfCode2021
{
    public sealed class AdventOfCode2021
    {
        public static int Main(string[] args)
        {
            // Test if input arguments were supplied.
            if (args.Length != 3)
            {
                Console.WriteLine("Please enter the day, part and input file path.");
                Console.WriteLine("Usage: <day> <part> <filePath>");
                return 1;
            }

            if (int.TryParse(args[0], out int day) && int.TryParse(args[1], out int part))
            {
                if (day <= 0 || day >= 26)
                {
                    Console.WriteLine("Pleas input a day from 1 to 25");
                    return 1;
                }
                if (part <= 0 || part >= 3)
                {
                    Console.WriteLine("Pleas input part 1 or 2");
                    return 1;
                }

                try
                {
                    Day? selectedDay = day switch
                    {
                        1 => new Day1(),
                        2 => new Day2(),
                        3 => new Day3(),
                        4 => new Day4(),
                        5 => new Day5(),
                        6 => new Day6(),
                        7 => new Day7(),
                        8 => new Day8(),
                        9 => new Day9(),
                        _ => null,
                    };
                    if (selectedDay == null)
                    {
                        Console.WriteLine("Day {0} not supported yet", day);
                        return 1;
                    }

                    long result = selectedDay.Action(part, args[2]);

                    Console.WriteLine("Result for day {0}, part {1} ===> {2}", day, part, result);
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Day {0}, part {1} not supported yet", day, part);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    return 1;
                }
            }

            return 0;
        }
    }
}