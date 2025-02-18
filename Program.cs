using System;

/*public class Contact
{
    public string Name;
    public string PhoneNumber;
    public string Email;
    
    public void DisplayInfo()
    {
        Console.WriteLine($"{Name}");
        Console.WriteLine($"{PhoneNumber}");
        Console.WriteLine($"{Email}");
    }
}class Program
{
    static void Main()
    {
        Contact[] contacts = new Contact[3];
        int i = 0;
        for (i = 0; i < 3; i++)
        {
            contacts[i] = new Contact();

            Console.WriteLine($"Enter the details for {i + 1} contact");
            contacts[i].Name = Console.ReadLine();
            contacts[i].PhoneNumber = Console.ReadLine();
            contacts[i].Email = Console.ReadLine();
        }
        Console.WriteLine("Please write contact name");
        string search = Console.ReadLine();
        int flag = 0;
        for (int j = 0; j < 3; j++)
        {
            if (contacts[j].Name == search)
            {
                flag = 1;
                Console.WriteLine($"{contacts[j].Name} {contacts[j].Email} {contacts[j].PhoneNumber}");
            }

        }
        if (flag == 0)
        {
            Console.WriteLine("Contact Not found");
        }
    }
}*/

/*public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }
    public void DisplayDetails()
    {
        Console.WriteLine($"{Name}");
        Console.WriteLine($"{Age}");
        Console.WriteLine($"{Grade}");
    }
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[3];
        for (int i = 0; i < 3; i++)
        {
            students[i] = new Student();
            Console.WriteLine($"Please input the {i + 1} student Name");
            students[i].Name = Console.ReadLine();
            Console.WriteLine($"please input the {i + 1} student Age");
            students[i].Age = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine($"please input the {i + 1} student Grade");
            students[i].Grade = Convert.ToDouble(Console.ReadLine());
        }
        for (int j = 0; j < 3; j++)
        {
            students[j].DisplayDetails();
        }
    }
}*/

/*public class BankAccount
{
    public int AccountNumber;
    public string HolderName;
    public int Balance;

    public BankAccount()
    {
        AccountNumber = 45514554;
        HolderName = "Gagik";
        Balance = 0;
    }
    public void Deposit(int amount)
    {
        Balance = Balance + amount;
        Console.WriteLine($"your balance is {Balance}");
    }

    public void Withdraw(int amount)
    {
        if (Balance > 0)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"your balance now is {Balance}");
            }
            else
            {
                Console.WriteLine("Your balance is not enough. Try again");
            }
        }
    }
}*/

/*class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();
        account.Withdraw(3000);
        account.Deposit(1000);
        

    }
}*/


public class BookLibrary
{
    public string Title;
    public string author;
    public bool isAvailable;

    public BookLibrary()
    {
        Title = "title";
        author = "Author";
        isAvailable = true;
    }

    private void showability()
    {
        if (isAvailable)
        {
            Console.WriteLine("You can borrow that book");
            
        }
        else
        {
            Console.WriteLine("You can not borrow that book");
        }
    }
    public void BorrowBook()
    {
       showability();
       isAvailable = false;
    }

    public void ReturnBook()
    {
        isAvailable = true;
        Console.WriteLine("Thank you for returning");
    }
    
    }


    class Program
    {
        static void Main()
        {

            BookLibrary[] bookLibrary = new BookLibrary[3];
            for (int i = 0; i < 3; i++)
            {
                bookLibrary[i] = new BookLibrary();
                Console.WriteLine($"please input {i + 1} book title");
                bookLibrary[i].Title = Console.ReadLine();
                Console.WriteLine($"please input {i + 1} book author");
                bookLibrary[i].author = Console.ReadLine();
            }

        int flag;
        bool chossing = true;
        while(chossing)
        {
            flag = int.Parse(Console.Readline());
            if(flag == 1)
            {
                
                for (int i = 0; i < 3; ++i)
                {
                    int chose = Console.ReadLine();
                    if(chose == i)
                    {
                        bookLibrary[i].BorrowBook();
                    }
                }
            }
        }

    
            
            

        }
    }

/*public class Employee
{

    public string Name;
    public string position;
    public int SalaryPerHour;
    public int HoursWorked;


    public int CalculateSalary()
    {
        if (HoursWorked < 40)
        {
            return HoursWorked * SalaryPerHour;
        }
        else
        {
            return ((int)(1.5 * (HoursWorked - 40) * SalaryPerHour) + 40 * SalaryPerHour);
        }
    }
}

class Program
{
    static void Main()
    {
        Employee[] employees = new Employee[3];
        for (int i = 0; i < 3; ++i)
        {
            employees[i] = new Employee();
            Console.WriteLine($"please input {i + 1} employer's name");
            employees[i].Name = Console.ReadLine();
            Console.WriteLine($"please input {i + 1} employer's salary for hour");
            employees[i].SalaryPerHour = Convert.ToInt32( Console.ReadLine() );
            Console.WriteLine($"please input {i + 1} employer's hours of work");
            employees[i].HoursWorked = Convert.ToInt32( Console.ReadLine() );
        }

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"The salary of {i + 1} employee is {employees[i].CalculateSalary()}");
        }
    }
}*/

/*Task 7: Ticket Booking System
Task: Create a MovieTicket class with :
MovieName, SeatNumber, IsBooked.
A method BookTicket() that marks it as booked.
In Main(), create 5 seats, allow the user to book one, and prevent double booking.
Show all available seats before booking.*/


/*public class MovieTicket
{
    public string MovieName;
    public int SeatNumber;
    public bool IsBooked;

    public void BookTicket()
    {
        if (IsBooked)
        {
            Console.WriteLine("That SeatNumber has already booked");
        }
        else
        {
            IsBooked = true;
            Console.WriteLine("You booked that seat succesfully");
        }
    }
    public void ShowAvailableseats()
    {
        if (!IsBooked)
        {
            Console.WriteLine($"You can book {SeatNumber} seat");
        }
    }
}

class Program
{
    static void Main()
    {
        MovieTicket[] movieTickets = new MovieTicket[5];
        for (int i = 0; i < 5; i++)
        {
            movieTickets[i] = new MovieTicket();
            movieTickets[i].SeatNumber = i + 1;
            movieTickets[i].ShowAvailableseats();
        }
        movieTickets[0].BookTicket();
        Console.WriteLine("I want to seat first seat");
        movieTickets[0].BookTicket();
        Console.WriteLine("Okay, I want the second one");
        movieTickets[1].BookTicket();

    }
}*/


/*public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int grade { get; set; }

}
public class Teacher
{
    public string Name { get; set; }
    public string Subject { get; set; }
    public int YearsOfExperience { get; set; }
}

public class School
{

    public Student[] students = new Student[3];
    public Teacher[] teachers = new Teacher[3];

    public void TopStudents()
    {
        for (int i = 0; i < 3; i++)
        {
            if (students[i].grade > 8)
            {
                Console.WriteLine($"{students[i].Name}");
            }
        }
    }

    public void TopTeachers()
    {
        for (int i = 0; i < 3; i++)
        {
            if (teachers[i].YearsOfExperience > 2)
            {
                Console.WriteLine($"{teachers[i].Name}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            School school = new School();
            for (int i = 0; i < 3; ++i)
            {
                school.students[i] = new Student();
                school.students[i].Name = Console.ReadLine();
                school.students[i].grade = Convert.ToInt32(Console.ReadLine());
            }
        
            for (int i = 0;i < 3; i++)
            {
                school.teachers[i] = new Teacher();
                Console.WriteLine($"Please input {i + 1} teacher name");
                school.teachers[i].Name = Console.ReadLine();
                Console.WriteLine("please input his/her experience");
                school.teachers[i].YearsOfExperience = Convert.ToInt32(Console.ReadLine());
            }
            school.TopStudents();
            school.TopTeachers();
        }
    }
}*/


/*public class Car
{
    public string Model;
    public int Year;
    public bool IsRented;

    public Car()
    {
        Model = null;
        Year = 0;
        IsRented = false;
    }

    public void RentCar()
    {
        if (IsRented)
        {
            Console.WriteLine("You can not rent that car");

        }
        else
        {
            Console.WriteLine("You have sucsessfully rent this car");
            IsRented = true;
        }
    }
    public void ReturnCar()
    {
        if (IsRented)
        {
            Console.WriteLine("Thank you for returning the car.");
            IsRented = false;
        }
        else
        {
            Console.WriteLine("This car was not rented, so it can't be returned.");
        }
    }
}

class Program
{
    static void Main()
    {
        Car[] cars = new Car[3];
        for (int i = 0; i < 3; ++i)
        {
            cars[i] = new Car();
            Console.WriteLine($"Please input {i + 1} car model");
            cars[i].Model = Console.ReadLine();
            Console.WriteLine("Please input this car's year");
            cars[i].Year = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("I want to rent the first car");
        cars[0].RentCar();
        Console.WriteLine("I want to rent this car again");
        cars[0].RentCar();
        Console.WriteLine("Thank you for car");
        cars[0].ReturnCar();
        
    }
}*/

/*Task 10: To - Do List Application
Task: Create a TaskItem class with :
Description, IsCompleted.
Methods MarkComplete() and MarkIncomplete().
Store multiple tasks in a list and allow users to add, remove, or mark tasks as complete*/

/*public class TaskItem
{
    public string Description;
    public bool IsCompleted;

    public TaskItem()
    {
        this.IsCompleted = false;
        this.Description = null;
    }

    public void MarkComplete()
    {
        Console.WriteLine($"Thank you for completing {Description} task");
        this.IsCompleted = true;
    }

    public void MarkIncomplete()
    {
        IsCompleted = false;
        Console.WriteLine($"{Description} task has not completed");
    }

}

class Program
{
    static void Main()
    {
      
    }
}*/

