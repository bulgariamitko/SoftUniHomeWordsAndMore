using System;

public class ExchangeVariable
{
    public static void Main()
    {
        int number1 = 5;
        int number2 = 10;
        Console.WriteLine("Before exchange \u2192 number1={0}\tnumber2={1}", number1, number2);
        int number3;
        number3 = number1;
        number1 = number2;
        number2 = number3;
        Console.WriteLine("After exchange \u2192 number1={0}\tnumber2={1}", number1, number2);
    }
}