using System;

class DiceSimulator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");

        Console.Write("How many dice rolls would you like to simulate? ");
        int numberOfRolls = int.Parse(Console.ReadLine());

        // Create an instance of the DiceRoller class
        DiceRoller diceRoller = new DiceRoller();

        // Simulate dice rolls and get the results array
        int[] results = diceRoller.SimulateDiceRolls(numberOfRolls);

        // Display the histogram
        DisplayHistogram(results, numberOfRolls);

        Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
    }

    static void DisplayHistogram(int[] results, int totalRolls)
    {
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {totalRolls}.\n");

        for (int i = 2; i <= 12; i++)
        {
            int percentage = results[i] * 100 / totalRolls;
            string stars = new string('*', percentage);

            Console.WriteLine($"{i}: {stars}");
        }
    }
}

class DiceRoller
{
    private Random random;

    public DiceRoller()
    {
        random = new Random();
    }

    public int[] SimulateDiceRolls(int numberOfRolls)
    {
        int[] results = new int[13]; // Index 0 is not used, indices 2 to 12 represent the possible combinations

        for (int i = 0; i < numberOfRolls; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;

            results[sum]++;
        }

        return results;
    }
}
