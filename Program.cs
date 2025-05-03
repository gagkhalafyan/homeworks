//Task 1, Chain of Responsibility
/*public class SupportTicket
{
    public string IssueType;
    public string Description;

    public SupportTicket(string issueType, string description)
    {
        this.IssueType = issueType;
        this.Description = description;
    }
}
public abstract class SupportHandler
{
    protected SupportHandler next;
    public void SetNext(SupportHandler next)
    {
        this.next = next;
    }
    public void Handle(SupportTicket ticket)
    {
        if (IsHandle(ticket))
        {
            Process(ticket);
        }
        else if (next != null)
        {
            next.Handle(ticket);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
    public abstract bool IsHandle(SupportTicket ticket);
    public abstract void Process(SupportTicket ticket);
}

public class BillingSupport : SupportHandler
{
    public override bool IsHandle(SupportTicket ticket)
    {
        if (ticket.IssueType == "Billing") { return true; }
        return false;
    }

    public override void Process(SupportTicket ticket)
    {
        Console.WriteLine($"{ticket.Description}");
    }

}

public class TechnicalSupport : SupportHandler
{
    public override bool IsHandle(SupportTicket ticket)
    {
        if (ticket.IssueType == "Technical") { return true; }
        return false;
    }

    public override void Process(SupportTicket ticket)
    {
        Console.WriteLine($"{ticket.Description}");
    }

}

public class GeneralSupport : SupportHandler
{
    public override bool IsHandle(SupportTicket ticket)
    {
        if (ticket.IssueType == "General") { return true; }
        return false;
    }

    public override void Process(SupportTicket ticket)
    {
        Console.WriteLine($"{ticket.Description}");
    }

}

public class Program
{
    static void Main()
    {
        var billing = new BillingSupport();
        var tech = new TechnicalSupport();
        var gen = new GeneralSupport();

        billing.SetNext( tech );
        tech.SetNext( gen );
        var ticket1 = new SupportTicket("Billing", "Refund for last month's invoice.");
        var ticket2 = new SupportTicket("Technical", "App crashes when I login.");
        var ticket3 = new SupportTicket("General", "My package hasn't arrived.");
        var ticket4 = new SupportTicket("unknown", "I need help but don’t know who to ask.");
        
        billing.Handle(ticket1);
    }
}*/


//Task 2, Command

using System.Net;
using System.Security.Principal;

/*public class BankAccount
{
    public BankAccount(string name,int balance)
    {
        this.Balance = balance;
        this.Name = name;
    }
    public BankAccount() { }
    public string Name { get; set; }
    public int Balance { get; set; }
    public void WithDraw(int amount)
    {
        if(Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Can not do withdraw");
        }
    }

    public void Deposit(int amount)
    {
        Balance += amount;
    }

}
public interface ITransactionCommand
{
    void Execute();
    void Undo();
}

class WithdrawCommand : ITransactionCommand
{
    private readonly BankAccount bankAccount;
    int amount;
    public WithdrawCommand(BankAccount bankAccount,int amount)
    {
        this.bankAccount = bankAccount;
        this.amount = amount;
    }
    public void Execute()
    {
        bankAccount.WithDraw(amount);
    }
    public void Undo()
    {
        bankAccount.Deposit(amount);
    }
}

public class DepositCommand : ITransactionCommand
{
    private readonly BankAccount bankAccount;
    int amount;
    public DepositCommand(BankAccount bankAccount, int amount)
    {
        this.bankAccount = bankAccount;
        this.amount = amount;

    }
    public void Execute()
    {
        bankAccount.Deposit(amount);
    }
    public void Undo()
    {
        bankAccount.WithDraw(amount);
    }
}

class Invoker
{
    private readonly BankAccount account;
    private ITransactionCommand _lastCommand;
    Stack<ITransactionCommand> _transactions = new();
    public void PressButton(ITransactionCommand command)
    {
        _lastCommand = command;
        command.Execute();
        _transactions.Push(command);
    }

    public void PressUndo()
    {
        var last = _transactions.Pop();
        last.Undo();
    }
}

class Program
{
    static void Main()
    {
        var Account = new BankAccount("Aram",2000);
        var deposit = new DepositCommand(Account, 200);
        var withdraw = new WithdrawCommand(Account, 150);
        var invoker = new Invoker();
        invoker.PressButton(withdraw);
        invoker.PressButton(deposit);
        invoker.PressButton(withdraw);
        invoker.PressUndo();
        invoker.PressUndo();
        
        Console.WriteLine($"{Account.Balance}");

    }
}*/


//Task 3, Memento

/*public class EmployeeProfile
{
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public EmployeeProfile(string name, string position, double salary)
    {
        Name = name; Position = position; Salary = salary;
    }

    public void Promote(string newPosition, double newSalary)
    {
        Position = newPosition;
        Salary = newSalary;
    }
    public EmployeeMemento CreateMemento() {  return new EmployeeMemento(Name,Position,Salary); }
    public void Restore(EmployeeMemento memento)
    {
        Name = memento.Name;
        Position = memento.Position;
        Salary = memento.Salary;
    }
    public override string ToString()
    {
        return $"{Name} {Position} {Salary}";
    }


}
public class EmployeeMemento
{
    public string Name;
    public string Position;
    public double Salary;
    public EmployeeMemento(string name,  string position, double salary)
    {
        Name = name ; Position = position ; Salary = salary ;
    }
}


class Program
{
    static void Main(string[] args)
    {
        var profile = new EmployeeProfile("Anna", "Junior Developer", 40000);

        // Save initial version
        var v1 = profile.CreateMemento();

        profile.Promote("Mid Developer", 60000);
        var v2 = profile.CreateMemento();

        profile.Promote("Senior Developer", 80000);
        Console.WriteLine("🟢 Current: " + profile);

        // Reset to v2 (Mid Developer)
        profile.Restore(v2);
        Console.WriteLine("🟡 Restored to Mid: " + profile);

        // Reset to v1 (Junior Developer)
        profile.Restore(v1);
        Console.WriteLine("🔵 Restored to Junior: " + profile);
    }
}*/

//Task 5, Strategy

/*public class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string FaceId { get; set; }
}
public interface IAuthentication
{
    bool Authenticate(User user);
}

class PasswordAuthStrategt : IAuthentication
{
    private readonly string _password;
    public PasswordAuthStrategt(string password)
    {
        _password = password;
    }

    public bool Authenticate(User user)
    {
        return user.Password == _password;
    }
}

class OtpAuthStrategy : IAuthentication
{
    private int _code;
    public OtpAuthStrategy(int code)
    {
        _code = code;
    }

    public bool Authenticate(User user)
    {
        return _code == 1456;
    }

}

class AuthService
{
    User user = new User();
    IAuthentication _authentication;

    public AuthService(IAuthentication authentication, User user)
    {
        _authentication = authentication;
        this.user = user;
    }

    public bool Authenticate(User user)
    {
        return _authentication.Authenticate(user);
    }
}

class Program
{
    static void Main()
    {
        var user = new User
        {
            Name = "Anna",
            Password = "1234",
            PhoneNumber = "099123456",
            FaceId = "face-xyz"
        };

        var passwordAuth = new PasswordAuthStrategt("1234");
        var authService = new AuthService(passwordAuth, user);

        bool isAuthenticated = authService.Authenticate(user);
        Console.WriteLine(isAuthenticated ? "Login successful" : "Login failed");
    }
}*/


//Task 6, Visitor

/*public interface IProduct
{
    void Accept(IDiscountVisitor visitor);
    decimal Price { get; }
    string Name { get; }
}

public interface IDiscountVisitor
{
    void Visit(Book product);
    void Visit(Electronics product);
    void Visit(Clothing product);
}

public class Book : IProduct
{
    public decimal Price { get; set; }
    public string Name { get; set; }
    public Book(decimal price,string name)
    {
        Price = price;
        Name = name;
    }

    public void Accept(IDiscountVisitor visitor)
    {
        visitor.Visit(this);
    }


}

public class Electronics : IProduct
{
    public decimal Price { get; set; }
    public string Name { get; set; }
    public Electronics(decimal price, string name)
    {
        Price = price;
        Name = name;
    }

    public void Accept(IDiscountVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Clothing : IProduct
{
    public decimal Price { get; set; }
    public string Name { get; set; }
    public Clothing(decimal price, string name)
    {
        Price = price;
        Name = name;
    }

        public void Accept(IDiscountVisitor visitor)
    {
        visitor.Visit(this);
    }

}

public class HolidayDiscountVisitor : IDiscountVisitor
{
    public void Visit(Book product)
    {
        double dis = (double)product.Price * 0.9;
        Console.WriteLine($"Book {product.Name} Original:{product.Price} -> Discounted {dis}");
    }
    public void Visit(Electronics product)
    {
        double dis = (double)product.Price * 0.85;
        Console.WriteLine($"Book {product.Name} Original:{product.Price} -> Discounted {dis}");
    }
    public void Visit(Clothing product)
    {
        double dis = (double)product.Price * 0.75;
        Console.WriteLine($"Book {product.Name} Original:{product.Price} -> Discounted {dis}");
    }
}

class Program
{
    static void Main()
    {
        List<IProduct> cart = new()
{
    new Book(40,"Design Patterns"),
    new Electronics(120,"Headphones"),
    new Clothing(80,"Jacket")
};

        IDiscountVisitor holidaySale = new HolidayDiscountVisitor();

        foreach (var item in cart)
        {
            item.Accept(holidaySale);
        }

    }
}*/