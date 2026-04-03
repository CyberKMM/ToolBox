namespace Projects;

public class NameGenerator
{
    public void Greeting()
    {
        Console.WriteLine("Welcome to name generator!!!");
        Console.WriteLine("Your name is: ");
        Console.WriteLine(GenerateName());
    }

    public string GenerateName()
    {
        string[] nameBlock1 = ["Castigador","Angel","Destructor","Cupcake","Teodoro"];
        string[] nameBlock2 = ["Del infierno", "Galactico", "Etèreo", "Liberador", "Castigador"];

        Random rnd = new Random();

        return nameBlock1[rnd.Next(1,5)] + " " + nameBlock2[rnd.Next(1,5)];
    }

}