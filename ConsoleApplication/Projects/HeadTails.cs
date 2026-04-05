namespace Projects;

public class HeadTails
{
    public void Greeting()
    {
        Console.WriteLine("Welcome to head/tails!!!");
        Play();
    }

    public void Play()
    {        
        bool keepPlaying = true;
        Random rnd = new Random();

        while(keepPlaying)
        {
            Console.WriteLine("Select:");
            Console.WriteLine("1.- Heads");
            Console.WriteLine("2.- Tails");            

            if(!int.TryParse(Console.ReadLine(), out int userSelection))
            {
                Console.WriteLine("Invalid selection");
                continue;
            }

            if(userSelection != 1 && userSelection != 2)
            {
                Console.WriteLine("Choose 1 or 2");
                continue;
            }

            int coin = rnd.Next(1,2);
            string stringCoin = coin == 1 ? "Heads" : "Tails";

            if(userSelection == coin)
                Console.WriteLine($"You won! the result was {stringCoin}");
            else
                Console.WriteLine($"You loose! the result was {stringCoin}");

            
            bool exit = false;

            while(!exit)
            {
                Console.WriteLine("Keep playing? y/n");    
                string? keepPlay = Console.ReadLine();

                if(keepPlay.ToLower() != "n" && keepPlay.ToLower() != "y")
                {
                    Console.WriteLine("Make a valid selection.");
                    continue;
                }

                if(keepPlay.ToLower() == "n")
                {
                    Console.WriteLine("Bye!");
                    keepPlaying = false;
                    exit = true;
                    continue;
                }

                if(keepPlay == "y")
                    exit = true;
                    continue;

            }
        }
    }
}