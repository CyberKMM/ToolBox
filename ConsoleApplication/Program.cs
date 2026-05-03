using Projects;

Console.WriteLine("Welcome to the Project Box");
Console.WriteLine("Type a number to run an App.");

bool exit = false;

while(!exit)
{
    Console.WriteLine("1.- Name Generator");
    Console.WriteLine("2.- Head/Tails");
    Console.WriteLine("3.- Temperature Converter");
    Console.WriteLine("E - Exit");

    string? userSelection = Console.ReadLine();

    if(userSelection.ToUpper() == "E")
    {
        exit = true;
        continue;
    }

    if(!int.TryParse(userSelection, out int intSelection))
    {
        Console.WriteLine("Invalid selection");
        continue;
    }

    if(intSelection == 1)
    {
        NameGenerator ng = new NameGenerator();
        ng.Greeting();
    }
    else if (intSelection == 2)
    {
        HeadTails ht = new HeadTails();
        ht.Greeting();
    }
    else if (intSelection == 3)
    {
        TemperatureConverter tc = new TemperatureConverter();
        tc.MainTemperatureProcess();
    }
    else if(intSelection == 4)
    {
        AgeInSeconds ageIn = new AgeInSeconds();
    }

}

