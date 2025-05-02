
//Task 1
/*class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
}
interface ProductXML
{
    string toXml();
}

class Adapter : ProductXML
{   
   private readonly Product _product;
   
    public Adapter(Product product)
    {
        _product = product;
    }

    public string toXml()
    {
        return $"<product>\n  <name>{_product.Name}</name>\n  <price>{_product.Price}</price>\n</product>";
    }
}

class Program
{
    static void Main()
    {
        Product product = new Product()
        {
            Price = 10,
            Name = "Banana"

        };

        ProductXML xML = new Adapter(product);
        Console.Write(xML.toXml());
    }

}*/

//Task 2

/*public class Product
{
    public string Name { get; set; }
    public int Price { get; set; }

    public override string ToString()
    {
        return $"{Name} {Price}";
    }
}

public interface IProductProvider
{
    Product GetProduct();
}

public class CsvProductAdapter : IProductProvider
{
    private readonly string _cSV;

    public CsvProductAdapter(string cSV)
    {
        _cSV = cSV;
    }

    public Product GetProduct()
    {
        Product product = new Product();
        string[] strings = _cSV.Split(',');
        product.Name = strings[0];
        product.Price = int.Parse(strings[1]);
        return product;
        
    }
}

class Program
{
    static void Main()
    {
        
        string csv = "Barev,100";
        IProductProvider provider = new CsvProductAdapter(csv);
        Console.WriteLine(provider.GetProduct());
    }
}*/


//Task 3

/*public interface IPaymentProcessor
{
    void PayMessage();
}

public class StripeProcessor : IPaymentProcessor
{
    public void PayMessage()
    {
        Console.WriteLine("Stripe");
    }
}

public class PayPalProcessor : IPaymentProcessor
{
    public void PayMessage()
    {
        Console.WriteLine("Pay pal");
    }
}

public class CryptoWalletProcessor : IPaymentProcessor
{
    public void PayMessage()
    {
        Console.WriteLine("Crypto");
    }
}

public abstract class Payment
{
    protected readonly IPaymentProcessor _processor;

    public Payment(IPaymentProcessor processor)
    {
        _processor = processor;
    }

    public abstract void PaymentMessage();
}

public class BasicPayment : Payment
{
    public BasicPayment(IPaymentProcessor processor) : base(processor) { }

    public override void PaymentMessage()
    {
        Console.WriteLine("BasicPayment");
        _processor.PayMessage();
    }

}

public class SubscriptionPayment : Payment
{
    public SubscriptionPayment(IPaymentProcessor processor) : base(processor) { }

    public override void PaymentMessage()
    {
        Console.WriteLine("SubscriptionPayment");
        _processor.PayMessage();
    }
}

class Program
{
    static void Main()
    {
        IPaymentProcessor processor = new PayPalProcessor();
        Payment basic = new BasicPayment(processor);    
        basic.PaymentMessage();
    }
}*/


//Task 4
/*using System.Threading.Tasks;

public interface ITAskItem
{
    string getName();
    void Display(string name);
}

public class SimpleTask : ITAskItem
{
    private string _name {  get; set; }
    public SimpleTask(string name)
    {
        _name = name;
    }
    public string getName() { return _name; }
    public void Display(string name)
    {
        Console.WriteLine($"{name} {_name}");
    }

}

public class CompositeTask : ITAskItem
{
    public string getName() { return _name; }
    private string _name { get; set; }
    public CompositeTask(string name)
    {
        _name = name;
    }
    public List<ITAskItem> Tasks = new();

    public void Add(ITAskItem item)
    {
        Tasks.Add(item);
    }
    public string GetName() { return _name; }

    public void Display(string name)
    {
        Console.WriteLine(name);
        foreach (var task in Tasks)
        {
            task.Display(name);
        }

    }

}

class Program
{
    static void Main()
    {
        var task1 = new SimpleTask("Buy groceries");
        var task2 = new SimpleTask("Call mom");
        var task3 = new SimpleTask("Pay bills");

        var personalTasks = new CompositeTask("Personal Tasks");
        personalTasks.Add(task1);
        personalTasks.Add(task2);
        personalTasks.Add(task3);

        var task4 = new SimpleTask("Fix login bug");
        var task5 = new SimpleTask("Deploy new release");

        var workTasks = new CompositeTask("Work Tasks");
        workTasks.Add(task4);
        workTasks.Add(task5);

        var allTasks = new CompositeTask("All Tasks");
        allTasks.Add(personalTasks);
        allTasks.Add(workTasks);

        allTasks.Display("");
    }
}*/


//Task 5

using System.Reflection.Metadata;
using System;

/*public interface IDocument
{
    string GetContent();
}

public class PlainTextDocument : IDocument
{   
    public string GetContent() => "Plain doc";
}

public abstract class Decorator : IDocument
{
    protected IDocument document;
    public Decorator(IDocument document)
    {
        this.document = document;
    }
    public virtual string GetContent() => document.GetContent();
}

public class BoldDecorator : Decorator
{
    public BoldDecorator(IDocument document) : base(document) { }

    public override string GetContent()
    {
        return document.GetContent() + "Bold";
    }
}


public class ItalicDecorator : Decorator
{
    public ItalicDecorator(IDocument document) : base(document) { }

    public override string GetContent()
    {
        return document.GetContent() + "Italic";
    }
}


public class UnderlineDecorator : Decorator
{
    public UnderlineDecorator(IDocument document) : base(document) { }

    public override string GetContent()
    {
        return document.GetContent() + "Underline";
    }
}


public class HighlightDecorator : Decorator
{
    public HighlightDecorator(IDocument document) : base(document) { }

    public override string GetContent()
    {
        return document.GetContent() + "Highlight";
    }
}

public class Program
{
    static void Main()
    {
       IDocument document = new PlainTextDocument();
       document = new BoldDecorator(document);
       document = new UnderlineDecorator(document);
       document = new HighlightDecorator(document);
       Console.WriteLine(document.GetContent());

    }
}*/


//Task 6

/*public class CPU
{
    public void Freeze()
    {
        Console.WriteLine("CPU Freezing");
    }

    public void Execute()
    {
        Console.WriteLine("CPU executing");
    }
}

public class Memory
{
    public void Load()
    {
        Console.WriteLine("Memory is loading");
    }
}

public class HardDrive
{
    public void Read()
    {
        Console.WriteLine("HardDrive reading sector 0 (size 1024)");
    }
}

public class GPU
{
    public void Initalize()
    {
        Console.WriteLine("GPU initilazing");
    }
}

public class ComputerFacade
{
    private CPU cpu;
    private Memory memory;
    private HardDrive hardware;
    private GPU gpu;
    public ComputerFacade(CPU cpu, Memory memory, HardDrive hardware, GPU gpu)
    {
        this.cpu = cpu;
        this.memory = memory;
        this.hardware = hardware;
        this.gpu = gpu;
    }

    public void StartComputer()
    {
        cpu.Freeze();
        cpu.Execute();
        memory.Load();
        hardware.Read();
        gpu.Initalize();
    }
}

class Program
{
    static void Main()
    {
        ComputerFacade computer = new ComputerFacade(new CPU(), new Memory(), new HardDrive(), new GPU());
        computer.StartComputer();
    }
}*/