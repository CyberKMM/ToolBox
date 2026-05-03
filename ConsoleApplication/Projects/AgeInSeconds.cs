namespace Projects;

public class AgeInSeconds
{
    private string _usersName = string.Empty;
    private DateTime _usersDOB;

    private int[] _daysInMonths = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

    private DateTime _today = DateTime.Now;

    private const int _secondsInADay = 86400;

    public void MainAgeInSecondsProcess()
    {
       Greeting(); 
       CalculateAgeInSeconds();
    }

    private void Greeting()
    {
        Console.WriteLine("Welcome to your age in seconds!!!!");
        Console.WriteLine("What's your name?");
        
        _usersName = Console.ReadLine() ?? "Usuario";
        
        bool validAge = false;

        while(!validAge)
        {
            Console.WriteLine($"What is your date of birth {_usersName}? (year/month/day)");
            string? inputAge = Console.ReadLine();

            if(!DateTime.TryParse(inputAge, out DateTime dob))
            {
                Console.WriteLine("Invalid format");
                continue;
            }
            else
            {
                _usersDOB = dob;
            }
        }
    }

    private void CalculateAgeInSeconds()
    {
        int day = _usersDOB.Day;
        int month = _usersDOB.Month;
        int year = _usersDOB.Year;

        int totalDaysSinceBirth = 
            RemainingDaysInYearSinceBirth(month, day, year) + CalculateDaysSinceBirth(year)
            + DaysPassedInCurrentYear();


        int finalResult = CalculateTotalSeconds(totalDaysSinceBirth);
        
        ShowResult(finalResult);
    }

    private void ShowResult(int seconds)
    {
        Console.WriteLine($"{seconds} have passed since you were born!!!");
    }

    private int DaysToSeconds(int days)
    {
        return days * _secondsInADay;
    }

    private int CalculateTotalSeconds(int days)
    {
        int totalSeconds = DaysToSeconds(days);
        int differenceInSeconds = 24 - _today.Hour;
        int secondsInHourDifference = differenceInSeconds * 60 * 60;

        return totalSeconds - secondsInHourDifference;
    }

    private int DaysPassedInCurrentYear()
    {
        int currentYear = _today.Year;   
        int currentMonth = _today.Month; 
        int daysPassedInCurrentYear = 0;            
        int[] daysinMonth = _daysInMonths;
        int daysPassedInCurrentMonth = _today.Day;
        
        if(IsLeapYear(currentYear))
                daysinMonth[1] = 29;

        for(var i = 0; i < currentMonth - 1; i++)
        {
            daysPassedInCurrentYear += daysinMonth[i];
        }

        return daysPassedInCurrentYear + daysPassedInCurrentMonth;
    }

    internal int CalculateDaysSinceBirth(int year)
    {
        int untilYear = _today.Year - 1;
        int startYear = year + 1;
        int totalDays = 0;

        for(var i = startYear; i <= untilYear; i++)
        {
            int[] daysinMonth = (int[])_daysInMonths.Clone();
            
            if(IsLeapYear(i))
                daysinMonth[1] = 29;

            totalDays += daysinMonth.Sum();
        }

        return totalDays;
    }

    internal int RemainingDaysInYearSinceBirth(int month, int day, int year)
    {
        int[] monthsCopy = _daysInMonths;

        if(IsLeapYear(year))
            monthsCopy[1] += 1;

        int remainingDaysInMonth = monthsCopy[month - 1] - day;

        for(int i = month; i < monthsCopy.Length; i++)
        {
            remainingDaysInMonth += monthsCopy[i];
        }

        return remainingDaysInMonth;
    }

    internal bool IsLeapYear(int year)
    {
        bool isValid = false;

        if(year % 4 == 0)
            isValid = true;
        if(year % 4 == 0 && year % 100 == 0)
            isValid = false;
        if(year % 4 == 0 && year % 100 == 0 && year % 400 == 0)
            isValid = true;

        return isValid;
    }
}