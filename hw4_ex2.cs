
Passport passport = new Passport("Ivan", "Ivanov", "01.01.1990", "123456789", "Russia", "01.01.2010", "01.01.2020");
passport.DisplayInfo();

Console.WriteLine();

// Создание заграничного паспорта
ForeignPassport foreignPassport = new ForeignPassport("Petr", "Petrov", "02.02.1985", "987654321", "Russia", "02.02.2015", "02.02.2025", "FP123456");
foreignPassport.AddVisa("Schengen Visa");
foreignPassport.AddVisa("US Visa");
foreignPassport.DisplayInfo();
public class Passport
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; } 
    public string PassportNumber { get; set; }
    public string IssuingCountry { get; set; }
    public string IssueDate { get; set; }
    public string ExpirationDate { get; set; }

    public Passport(string firstName, string lastName, string dateOfBirth, string passportNumber, string issuingCountry, string issueDate, string expirationDate)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PassportNumber = passportNumber;
        IssuingCountry = issuingCountry;
        IssueDate = issueDate;
        ExpirationDate = expirationDate;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Passport Info: {FirstName} {LastName}, Date of Birth: {DateOfBirth}, Passport Number: {PassportNumber}, Issuing Country: {IssuingCountry}, Issue Date: {IssueDate}, Expiration Date: {ExpirationDate}");
    }
}
public class ForeignPassport : Passport
{
    public string ForeignPassportNumber { get; set; }
    public List<string> Visas { get; set; }

    public ForeignPassport(string firstName, string lastName, string dateOfBirth, string passportNumber, string issuingCountry, string issueDate, string expirationDate, string foreignPassportNumber)
        : base(firstName, lastName, dateOfBirth, passportNumber, issuingCountry, issueDate, expirationDate)
    {
        ForeignPassportNumber = foreignPassportNumber;
        Visas = new List<string>();
    }

    public void AddVisa(string visa)
    {
        Visas.Add(visa);
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Foreign Passport Number: {ForeignPassportNumber}");
        Console.WriteLine("Visas: " + (Visas.Count > 0 ? string.Join(", ", Visas) : "No visas"));
    }
}