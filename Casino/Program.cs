namespace Casino
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            double odds = .75;
            Player player = new Player() { Cash = 100, Name = "The Player"};

            Console.WriteLine($"Welcome to the casino. The odds are {odds}");
            while (true)
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

                else { 
                    Console.WriteLine($"The house always wins.");
                        return;                    
                }
            }
        }
    }
}