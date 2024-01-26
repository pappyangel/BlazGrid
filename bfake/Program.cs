using Bogus;

internal class Program
{
    private static void Main(string[] args)
    {
        var now = DateTime.Now;
        Console.WriteLine($"{now}");

        var faker = new Faker();

        var whatareyou = faker.Image.LoremFlickrUrl(320, 240, "people");
        // var whatareyou = faker.Image.PicsumUrl(320, 240, "people");
        
        Console.WriteLine($"{whatareyou}");

        Console.WriteLine(faker.Date.Future(20));
        Console.WriteLine(faker.Date.Past(22, DateTime.Now));
        Console.WriteLine(faker.Date.Past(22));

        Console.WriteLine(faker.Date.Past(50));
        Console.WriteLine(faker.Date.Between(new DateTime(2022, 1, 1), new DateTime(2025, 1, 1)));

        List<PersonClass> people;
        DateTime startDate = new DateTime(1995, 06, 26);
        DateTime endDate = DateTime.Now;
        int cat = 0;
        Console.WriteLine($"cat {cat}");
        Console.WriteLine($"cat {++cat}");
        int dog = 1000;
        var testUsers = new Bogus.Faker<PersonClass>()            
            // .RuleFor(u => u.Id, f => f.Random.Int(1, 100))
            .RuleFor(u => u.Id, f => ++dog)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            // .RuleFor(u => u.StartDate, f => f.Date.Between(startDate, endDate))
            .RuleFor(u => u.StartDate, f => f.Date.Past(22, DateTime.Now))
            .Generate(5);

        people = testUsers;

        Console.WriteLine("Class");

        foreach (var item in people)
        {
            Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.StartDate}");
        }
    }
}

record PersonRecord(int Id, string FirstName, string LastName, DateOnly StartDate);
public class PersonClass
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime StartDate { get; set; }
}
