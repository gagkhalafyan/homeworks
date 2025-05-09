
using System;
using Linq_2;
class Program
{
    static void Main()
    {
        var departments = new List<Department>
{
    new Department(1, "Computer Science"),
    new Department(2, "Mathematics"),
    new Department(3, "Physics")
};

        var courses = new List<Course>
{
    new Course(101, "Algorithms", 1),
    new Course(102, "Data Structures", 1),
    new Course(201, "Calculus", 2),
    new Course(301, "Quantum Mechanics",3),
    new Course(104, "Algorithm", 1),
    new Course(105, "Data Structure", 1),
    new Course(207, "Calculue", 2),
    new Course(302, "Quantum Mechanich",3)
};

        var students = new List<Student>
{
    new Student(22,1, "Arman Hakobyan", 1, new List<int> { 101, 102 }),
    new Student(19,2, "Mariam Sargsyan", 1, new List<int> { 201 }),
    new Student(25,3, "Gor Petrosyan", 3, new List<int> { 301 })
};

        var subjects = new List<Subject>
{

    new Subject { Name = "Programming Basics", DepartmentId = 1 },
    new Subject { Name = "Data Structures", DepartmentId = 1 },
    new Subject { Name = "Operating Systems", DepartmentId = 1 },
    new Subject { Name = "Databases", DepartmentId = 1 },

    new Subject { Name = "Linear Algebra", DepartmentId = 2 },
    new Subject { Name = "Calculus I", DepartmentId = 2 },
    new Subject { Name = "Probability Theory", DepartmentId = 2 },

    new Subject { Name = "Classical Mechanics", DepartmentId = 3 },
    new Subject { Name = "Electromagnetism", DepartmentId = 3 },
    new Subject { Name = "Quantum Physics", DepartmentId = 3 }
};


        //Task 1

        var res = (from department in departments
                   where department.Name == "Computer Science"
                   select department.Id).SingleOrDefault();

        var result = from student in students
                     where student.DepartmentId.Equals(res)
                     select student.FullName;
        Console.WriteLine("Computer Science students:");
        foreach (var s in result)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine();

        //Task 3

        var res3 = from subject in subjects
                   where subject.DepartmentId.Equals(res)
                   select subject.Name;

        Console.WriteLine("Subjects in Computer Science:");
        foreach (var s in res3)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine();

        //Task 4

        var res4 = from department in departments
                   join student in students
                   on department.Id equals student.DepartmentId
                   group department by department.Name into DeptGroup
                   where DeptGroup.Count() > 1
                   select DeptGroup.Key;

        foreach (var s in res4)
        {
            Console.WriteLine(s);
        }

        //Task 5

        var res5 = (from student in students
                   join department in departments
                   on student.Id equals department.Id
                   orderby student.Age
                   select student.DepartmentId).First();

        Console.WriteLine(res5);

        //Task 6

        var res6 = (from subject in subjects
                   group subject by subject.DepartmentId into g
                   let count = g.Count()
                   orderby count descending
                   select new { DepartmentId = g.Key, Count = count }).FirstOrDefault();

        var departmentName = (from d in departments
                              where d.Id == res6.DepartmentId
                              select d.Name).FirstOrDefault();

        Console.WriteLine($"{departmentName} ({res6.Count})");


    }
}

