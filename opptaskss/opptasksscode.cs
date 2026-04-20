using System;

class Student
{
    public string Name { get; set; }
    public int Grade1 { get; set; }
    public int Grade2 { get; set; }
    public int Grade3 { get; set; }

    public Student(string name, int g1, int g2, int g3)
    {
        Name = name;
        Grade1 = g1;
        Grade2 = g2;
        Grade3 = g3;
    }

    public double GetAverage()
    {
        return (Grade1 + Grade2 + Grade3) / 3.0;
    }

    public string GetLetterGrade()
    {
        double avg = GetAverage();

        if (avg >= 90) return "A";
        else if (avg >= 75) return "B";
        else if (avg >= 60) return "C";
        else return "F";
    }

    public void Print()
    {
        Console.WriteLine($"{Name} | Avg: {GetAverage():F2} | Grade: {GetLetterGrade()}");
    }
}

class Program
{
    static void Main()
    {
        Student[] roster = new Student[]
        {
            new Student("Toghan", 95, 90, 92),
            new Student("Alikhan", 70, 75, 72),
            new Student("Asylai", 88, 84, 91),
            new Student("Arlan", 60, 58, 65)
        };

        
        foreach (Student s in roster)
        {
            s.Print();
        }

      
        Student best = roster[0];

        foreach (Student s in roster)
        {
            if (s.GetAverage() > best.GetAverage())
            {
                best = s;
            }
        }

        Console.WriteLine("\nBest student:");
        best.Print();
    }
}
