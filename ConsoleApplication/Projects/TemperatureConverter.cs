namespace Projects;

public class TemperatureConverter
{

    private enum Temperatures { Celsius, Fahrenheit }
    private const float _fahrenheitToCelsius = (float)5 / 9;
    private const float _celsiusToFahrenheit = (float)9 / 5;
    public void MainTemperatureProcess()
    {
        Greeting();
        Calculate();
    }
    private void Greeting()
    {
        Console.WriteLine("Welcome to Temperature Converter!!!");
    }

    private void DisplayMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1.- From Celsius to Fahrenheit");
        Console.WriteLine("2.- From Fahrenheit to Celsius");
        Console.WriteLine("E - Exit");
    }

    private (bool isValid, int userSelectionInt) EvaluateUserInput()
    {
        string? userSelectionstr = Console.ReadLine();
        bool isValidSelection = int.TryParse(userSelectionstr, out int userSelectionInt);

        if (string.Equals(userSelectionstr, "E", StringComparison.OrdinalIgnoreCase))
            return (false, 3);

        if (!isValidSelection)
        {
            Console.WriteLine("Invalid selection");
            return (false, 0);
        }

        if (userSelectionInt != 1 && userSelectionInt != 2)
        {
            Console.WriteLine("Choose 1 or 2");
            return (false, 0);
        }

        return (true, userSelectionInt);
    }

    private void Calculate()
    {
        bool keepCalculate = true;

        while (keepCalculate)
        {
            DisplayMenu();

            var (isValid, userSelectionInt) = EvaluateUserInput();

            if (!isValid && userSelectionInt == 3)
            {
                keepCalculate = false;
                continue;
            }

            if (!isValid)
                continue;

            if (userSelectionInt == 1)
                CalculateTemperature(Temperatures.Celsius);
            else
                CalculateTemperature(Temperatures.Fahrenheit);
        }
    }

    private void CalculateTemperature(Temperatures scale)
    {
        bool calculateTemperature = true;
        while (calculateTemperature)
        {
            Console.WriteLine($"What is your temperature in {scale}?");

            if (!float.TryParse(Console.ReadLine(), out float userValue))
            {
                Console.WriteLine("Enter a number");
                continue;
            }

            float result;

            if (scale == Temperatures.Celsius)
            {
                result = CalculateFromCelsius(userValue);
                Console.WriteLine($"Your temperature in Fahrenheit is {result}");
            }
            else
            {
                result = CalculateFromFaherenheit(userValue);
                Console.WriteLine($"Your temperature in Celsius is {result}");
            }


            //Aquí también se puede meter en un método.
            bool exitScale = false;

            while (!exitScale)
            {
                Console.WriteLine("You want to calculate new temperature? y/n");

                var (exit, exitConverter) = HandleExitScale();
                
                if(!exit && !exitConverter)
                    continue;

                if(exit && !exitConverter)
                    exitScale = true;

                if(exit && exitConverter)
                {
                    exitScale = true;
                    calculateTemperature = false;
                }
            }
        }
    }

    private (bool exit, bool exitConverter) HandleExitScale()
    {
        string? keepInScale = Console.ReadLine();

        if (!string.Equals(keepInScale, "y", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(keepInScale, "n", StringComparison.InvariantCultureIgnoreCase))
        {
            Console.WriteLine("Make a valid selection");
            return (false, false);
        }

        if (string.Equals(keepInScale, "y", StringComparison.OrdinalIgnoreCase))
        {
            return (true, false);
        }

        //if (string.Equals(keepInScale, "n", StringComparison.InvariantCultureIgnoreCase))
        
        return (true, true);
        
    }

    private float CalculateFromCelsius(float userValue)
    {
        return (userValue * _celsiusToFahrenheit) + 32;
    }
    private float CalculateFromFaherenheit(float userValue)
    {
        return (userValue - 32) * _fahrenheitToCelsius;
    }
}