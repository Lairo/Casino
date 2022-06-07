namespace Casino
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            double odds = .75;
            Player player = new Player() { Cash = 100, Name = "The Player"};

            Console.WriteLine($"Welcome to the casino. The standard odds are {odds}");

            while (true)
            {
                Console.Write("Would you like to change the odds?\n(to exit type Exit at any moment)\nEnter Yes or No Please: ");
                string decision = Console.ReadLine();
                if(decision == "yes" || decision =="Yes")
                {
                    Console.WriteLine($"Enter your new odds percentage (1-100)");
                    int.TryParse(Console.ReadLine(), out int newOdds);
                    double Odds = newOdds * 0.01;
                    Console.Clear();
                    Console.WriteLine($"Your odds have been set to {Odds}.");

                }
                else if(decision == "no" || decision == "No")
                {
                    Console.Clear();
                    while (player.Cash > 0)
                    {
                        player.WriteMyInfo();
                        Console.Write("How much would you like to bet: ");
                        string howMuch = Console.ReadLine();
                        if (howMuch == "") return;
                        if (int.TryParse(howMuch, out int amount))
                        {
                            int pot = amount * 2;
                            if (random.NextDouble() > odds)
                            {
                                Console.WriteLine($"You win {pot}.");
                                player.ReceiveCash(pot);
                            }
                            else
                            {
                                Console.WriteLine($"Bad luck, you lose.");
                                player.GiveCash(amount);
                            }
                        }

                        else
                        {                     
                              return;                    
                        }
                        Console.WriteLine($"The house always wins.");
                        return;
                    }
                }
                else if (decision == "exit" || decision == "Exit")
                {
                    System.Environment.Exit(0);

                }
                else
                {
                    Console.WriteLine("Please enter the values stated");
                    Console.Clear();
                    continue;                    

                }
            }
        }
    }
}