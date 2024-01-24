﻿namespace SharedLib;

public class QDataService
{
    public string GiveRandomNumber()
    {
        int randomValue = Random.Shared.Next(1,100);
        return $"The value is {randomValue}";
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

}