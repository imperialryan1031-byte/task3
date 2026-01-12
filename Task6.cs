using System;

public class Student
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

    // IsPassed method - returns true if grade >= 75
    public bool IsPassed()
    {
        return Grade >= 75;
    }
}
