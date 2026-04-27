//Task1
//using System;

//class Student
//{
//    public string Name { get; set; }
//    public int Grade1 { get; set; }
//    public int Grade2 { get; set; }
//    public int Grade3 { get; set; }

//    public Student(string name, int g1, int g2, int g3)
//    {
//        Name = name;
//        Grade1 = g1;
//        Grade2 = g2;
//        Grade3 = g3;
//    }

//    public double GetAverage()
//    {
//        return (Grade1 + Grade2 + Grade3) / 3.0;
//    }

//    public string GetLetterGrade()
//    {
//        double avg = GetAverage();

//        if (avg >= 90) return "A";
//        else if (avg >= 75) return "B";
//        else if (avg >= 60) return "C";
//        else return "F";
//    }

//    public void Print()
//    {
//        Console.WriteLine($"{Name} | Avg: {GetAverage():F2} | Grade: {GetLetterGrade()}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Student[] roster = new Student[]
//        {
//            new Student("Alice", 90, 85, 88),
//            new Student("Bob", 70, 75, 72),
//            new Student("Charlie", 95, 92, 96),
//            new Student("Diana", 60, 65, 58)
//        };

//        foreach (var s in roster)
//        {
//            s.Print();
//        }

//        Student best = roster[0];

//        foreach (var s in roster)
//        {
//            if (s.GetAverage() > best.GetAverage())
//            {
//                best = s;
//            }
//        }

//        Console.WriteLine($"\nBest student: {best.Name} with avg {best.GetAverage():F2}");
//    }
//}


//Task2
//using System;

//class BankAccount
//{
//    public string Owner { get; }
//    public decimal Balance { get; private set; }

//    public BankAccount(string owner, decimal initialDeposit)
//    {
//        if (initialDeposit < 0)
//            throw new ArgumentException("Initial deposit cannot be negative");

//        Owner = owner;
//        Balance = initialDeposit;
//    }

//    public void Deposit(decimal amount)
//    {
//        if (amount <= 0)
//            throw new ArgumentException("Deposit must be positive");

//        Balance += amount;
//    }

//    public void Withdraw(decimal amount)
//    {
//        if (amount <= 0)
//            throw new ArgumentException("Withdrawal must be positive");

//        if (amount > Balance)
//            throw new InvalidOperationException("Insufficient funds");

//        Balance -= amount;
//    }

//    public void PrintStatement()
//    {
//        Console.WriteLine($"{Owner} | Balance: ${Balance}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        BankAccount acc = new BankAccount("John", 100m);

//        acc.Deposit(50m);
//        acc.Withdraw(30m);

//        try
//        {
//            acc.Withdraw(1000m); 
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }

//        acc.PrintStatement();
//    }
//}

//Task3
//using System;

//class Temperature
//{
//    private double _celsius;

//    public double Celsius
//    {
//        get { return _celsius; }
//        set
//        {
//            if (value < -273.15)
//                throw new ArgumentException("Temperature below absolute zero");

//            _celsius = value;
//        }
//    }

//    public double Fahrenheit
//    {
//        get { return _celsius * 9 / 5 + 32; }
//        set
//        {
//            // convert and reuse validation
//            Celsius = (value - 32) * 5 / 9;
//        }
//    }

//    public Temperature(double celsius)
//    {
//        Celsius = celsius;
//    }

//    public void Print()
//    {
//        Console.WriteLine($"{Celsius:F1}°C / {Fahrenheit:F1}°F");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Temperature temp = new Temperature(25);

//        temp.Print();

//        temp.Fahrenheit = 100;
//        temp.Print();

//        try
//        {
//            temp.Celsius = -300; // should throw
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }
//    }
//}
    
