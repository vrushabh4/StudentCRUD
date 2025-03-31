using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRUD
{
    class Program
    {
        static void Main()
        {
            StudentService studentService = new StudentService();
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());
                        studentService.CreateStudent(name, age);
                        break;
                    case 2:
                        studentService.ReadStudents();
                        break;
                    case 3:
                        Console.Write("Enter Student ID to Update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter New Age: ");
                        int newAge = int.Parse(Console.ReadLine());
                        studentService.UpdateStudent(updateId, newName, newAge);
                        break;
                    case 4:
                        Console.Write("Enter Student ID to Delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        studentService.DeleteStudent(deleteId);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}

// Model Class
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

// Service Class for CRUD Operations
public class StudentService
{
    private List<Student> students = new List<Student>();
    private int nextId = 1;

    public void CreateStudent(string name, int age)
    {
        students.Add(new Student { Id = nextId++, Name = name, Age = age });
        Console.WriteLine("Student added successfully.");
    }

    public void ReadStudents()
    {
        if (!students.Any())
        {
            Console.WriteLine("No students found.");
            return;
        }
        Console.WriteLine("ID	Name	Age");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Age}");
        }
    }

    public void UpdateStudent(int id, string name, int age)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            student.Name = name;
            student.Age = age;
            Console.WriteLine("Student updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public void DeleteStudent(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}

// Main Program

