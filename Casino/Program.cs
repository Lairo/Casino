namespace Casino
{
    class Program
    {
        public static Player player = new Player();
        public static Player[] playerArray = new Player[2];
        public static bool existingPlayer = false;
        public static double odds = .75;
        static void Main()
        {
            playerArray[0] = new Player() { Cash = 100, Name = "Joe",};
            playerArray[1] = new Player() { Cash = 2000, Name = "Bob", };
            Random random = new Random();
            
            

            ///Make an existing players'
            ///1. Bob
            ///2. Joe
            ///Add option to add a new player to the list 
            while (existingPlayer == false)
            {
                Console.WriteLine("Pick a player?\n1.Bob\n2.Joe");
                string pick = Console.ReadLine();
                if (pick == "1")
                {
                    playerChoice(pick);
                }
                else if (pick == "2")
                {
                    playerChoice(pick);                   

                }
                else
                {
                    Console.WriteLine("Please enter the values stated");
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                Console.WriteLine($"Welcome to the casino. The standard odds are {odds}");
                while (true)
                {
                    Console.Write("Would you like to change the odds?\n(to exit type Exit at any moment)\nEnter Yes or No Please: ");
                    string decision = Console.ReadLine();
                    if (decision == "yes" || decision == "Yes")
                    {
                        Console.WriteLine($"Enter your new odds percentage (1-100)");
                        int.TryParse(Console.ReadLine(), out int newOdds);
                        odds = newOdds * 0.01;
                        Console.Clear();
                        Console.WriteLine($"Your odds have been set to {odds}.");
                        continue;

                    }
                    else if (decision == "no" || decision == "No")
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
                            }else
                            {
                            return;
                            }                                                       
                        }
                        Console.WriteLine($"The house always wins.");
                        return;

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
        public static string playerChoice(string e)
        {
            int.TryParse(e, out int choice);
            player.Cash = playerArray[choice - 1].Cash;
            player.Name = playerArray[choice - 1].Name;
            Console.WriteLine($"You have picked {playerArray[choice - 1]}");
            existingPlayer = true;
            return e;
        }
    }
}