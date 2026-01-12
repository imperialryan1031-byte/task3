using System;
using System.Collections.Generic;
using System.Linq;

class StudentMarks
{
    // Multi-dimensional array to store student names and marks
    // Row structure: [StudentIndex] = [Name, English, Math, Computer, Total, Position]
    private static List<(string name, int english, int math, int computer, int total)> students = 
        new List<(string name, int english, int math, int computer, int total)>();

    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("  Student Marks Management System");
        Console.WriteLine("========================================\n");

        int numStudents = GetNumberOfStudents();

        // Accept student data
        AcceptStudentData(numStudents);

        // Calculate totals
        CalculateTotals();

        // Sort students by total marks in descending order
        SortStudentsByTotalMarks();

        // Display report card with positions
        DisplayReportCard();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    /// <summary>
    /// Gets the number of students from user input
    /// </summary>
    static int GetNumberOfStudents()
    {
        int numStudents = 0;
        bool isValid = false;

        while (!isValid)
        {
            Console.Write("Enter the number of students: ");
            isValid = int.TryParse(Console.ReadLine(), out numStudents) && numStudents > 0;

            if (!isValid)
                Console.WriteLine("Invalid input! Please enter a positive number.\n");
        }

        return numStudents;
    }

    /// <summary>
    /// Accepts student names and marks for English, Math, and Computer subjects
    /// </summary>
    static void AcceptStudentData(int numStudents)
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("  Enter Student Details");
        Console.WriteLine("========================================\n");

        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"--- Student {i + 1} ---");
            
            string name = GetStudentName();
            int english = GetMarks("English");
            int math = GetMarks("Math");
            int computer = GetMarks("Computer");

            // Add student data to list (total will be calculated later)
            students.Add((name, english, math, computer, 0));

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Gets and validates student name
    /// </summary>
    static string GetStudentName()
    {
        string name = "";
        
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Enter student name: ");
            name = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name))
                Console.WriteLine("Name cannot be empty. Please try again.\n");
        }

        return name;
    }

    /// <summary>
    /// Gets and validates marks for a subject
    /// </summary>
    static int GetMarks(string subject)
    {
        int marks = -1;
        bool isValid = false;

        while (!isValid)
        {
            Console.Write($"Enter marks for {subject} (0-100): ");
            isValid = int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100;

            if (!isValid)
                Console.WriteLine("Invalid input! Please enter a number between 0 and 100.\n");
        }

        return marks;
    }

    /// <summary>
    /// Calculates total marks for each student
    /// </summary>
    static void CalculateTotals()
    {
        for (int i = 0; i < students.Count; i++)
        {
            var student = students[i];
            int total = student.english + student.math + student.computer;
            students[i] = (student.name, student.english, student.math, student.computer, total);
        }
    }

    /// <summary>
    /// Sorts students by total marks in descending order
    /// </summary>
    static void SortStudentsByTotalMarks()
    {
        students = students.OrderByDescending(s => s.total)
                          .ThenBy(s => s.name)  // Secondary sort by name for ties
                          .ToList();
    }

    /// <summary>
    /// Displays the report card with positions
    /// </summary>
    static void DisplayReportCard()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("  Student Report Card");
        Console.WriteLine("========================================\n");

        Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10} {4,-10} {5,-10} {6,-10}",
            "Pos.", "Name", "English", "Math", "Computer", "Total", "Percentage");
        
        Console.WriteLine(new string('-', 95));

        for (int i = 0; i < students.Count; i++)
        {
            var student = students[i];
            double percentage = (student.total / 300.0) * 100;

            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10} {4,-10} {5,-10} {6:F2}%",
                i + 1,
                student.name,
                student.english,
                student.math,
                student.computer,
                student.total,
                percentage);
        }

        Console.WriteLine(new string('-', 95));

        // Display summary statistics
        DisplaySummaryStatistics();
    }

    /// <summary>
    /// Displays summary statistics
    /// </summary>
    static void DisplaySummaryStatistics()
    {
        if (students.Count == 0)
            return;

        int totalMarksSum = students.Sum(s => s.total);
        double averageTotal = totalMarksSum / (double)students.Count;
        int maxTotal = students.Max(s => s.total);
        int minTotal = students.Min(s => s.total);

        Console.WriteLine("\n========================================");
        Console.WriteLine("  Summary Statistics");
        Console.WriteLine("========================================\n");

        Console.WriteLine($"Total Number of Students: {students.Count}");
        Console.WriteLine($"Highest Total Marks: {maxTotal}");
        Console.WriteLine($"Lowest Total Marks: {minTotal}");
        Console.WriteLine($"Average Total Marks: {averageTotal:F2}");

        Console.WriteLine("\n========================================\n");
    }
}
