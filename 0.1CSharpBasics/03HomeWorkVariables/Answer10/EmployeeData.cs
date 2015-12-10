using System;

public class EmployeeData
{
    public static void Main()
    {
        string firstName;
        string familyName;
        byte age;
        char gender;
        long IDnumber;
        uint uniqueEmployeeNumber;

        firstName = "Petar";
        familyName = "Yankov";
        age = 31;
        gender = 'm';
        IDnumber = 8112312891;
        uniqueEmployeeNumber = 27560001;
        Console.WriteLine("{0} {1}\n{2}\n{3}\n{4}\n{5}", firstName, familyName, age, gender, IDnumber, uniqueEmployeeNumber);
    }
}