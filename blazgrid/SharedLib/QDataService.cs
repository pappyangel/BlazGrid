﻿namespace SharedLib;

public class QDataService
{
    public string GiveRandomNumber()
    {
        int randomValue = Random.Shared.Next(1,100);
        return $"The value is {randomValue}";
    }

    public async Task<IQueryable<PersonClass>?> GetPeopleAsync(int rowCount, int SeedKey)
    {
        var testUsers = await Task.Run(() => new Bogus.Faker<PersonClass>()
            .RuleFor(u => u.Id, f => ++SeedKey)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.StartDate, f => f.Date.Past(22, DateTime.Now))
            .Generate(rowCount));

        return testUsers.AsQueryable();
    }
    public IQueryable<PersonClass>? GetPeople(int rowCount, int SeedKey)
    {
        var testUsers = new Bogus.Faker<PersonClass>()
            .RuleFor(u => u.Id, f => ++SeedKey)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.StartDate, f => f.Date.Past(22, DateTime.Now))
            .Generate(rowCount);

        return testUsers.AsQueryable();
    }

    
    public IQueryable<PersonClass>? GetPeopleVirt(int rowCount, int SeedKey)
    {
        var testUsers = new Bogus.Faker<PersonClass>()
            .RuleFor(u => u.Id, f => ++SeedKey)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.StartDate, f => f.Date.Past(22, DateTime.Now))
            .Generate(rowCount);

        return testUsers.AsQueryable();
    }
    public IQueryable<PersonClass>? GetPeoplePic(int rowCount, int SeedKey)
    {
        var testUsers = new Bogus.Faker<PersonClass>()
            .RuleFor(u => u.Id, f => ++SeedKey)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.StartDate, f => f.Date.Past(22, DateTime.Now))
            .RuleFor(u => u.ImageUrl, f => f.Image.LoremFlickrUrl(320, 240, "people"))
            .Generate(rowCount);

        return testUsers.AsQueryable();
    }

 

}