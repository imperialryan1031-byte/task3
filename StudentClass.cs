using System;

class Student
{
    // Properties
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    // Constructor
    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    // DisplayInfo method - displays student information
    public void DisplayInfo()
    {
        Console.WriteLine($"Student Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Grade: {Grade}");
    }

    // IsPassed method - checks if student passed (grade >= 60)
    public bool IsPassed()
    {
        return Grade >= 60;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Student Class Demonstration ===\n");

        // Create first student
        Student student1 = new Student("Alice Johnson", 20, 85.5);
        Console.WriteLine("Student 1 Information:");
        student1.DisplayInfo();
        Console.WriteLine($"Passed: {student1.IsPassed()}\n");

        // Create second student
        Student student2 = new Student("Bob Smith", 19, 72.0);
        Console.WriteLine("Student 2 Information:");
        student2.DisplayInfo();
        Console.WriteLine($"Passed: {student2.IsPassed()}\n");

        // Create third student (failed)
        Student student3 = new Student("Charlie Brown", 21, 45.0);
        Console.WriteLine("Student 3 Information:");
        student3.DisplayInfo();
        Console.WriteLine($"Passed: {student3.IsPassed()}\n");

        // Demonstrate modifying student properties
        Console.WriteLine("=== After Modifying Student 3 ===\n");
        student3.Grade = 65.0;
        student3.DisplayInfo();
        Console.WriteLine($"Passed: {student3.IsPassed()}");
    }
}
