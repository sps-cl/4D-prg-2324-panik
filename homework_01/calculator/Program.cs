﻿using System;

// abstraktni trida IOperation (klicove slovo interface)
// nemuzeme k ni pristupovat primo ale pouze pres jeji potomky (child : parent) 
public interface IOperation
{
    int Execute(int a, int b);
}

// trida OpAdd - potomek tridy IOperation
public class OpAdd : IOperation
{
    public int Execute(int a, int b)
    {
        return a + b;
    }
}

// trida OpSub - potomek tridy IOperation
public class OpSub : IOperation
{
    public int Execute(int a, int b)
    {
        return a - b;
    }
}

// trida OpMagic - potomek tridy IOperation
public class OpMagic : IOperation
{
    // deklarace Random uvnitr tridy OpMagic (private access modifier)
    private Random random;

    public OpMagic(Random random)
    {
        this.random = random;
    }

    public int Execute(int a, int b)
    {
        // generovani nahodneho integeru pro magickou operaci
        int randomNumber = random.Next(0, 3);

        // vyber magicke operace
        switch (randomNumber)
        {
            case 0:
                return a + b;
            case 1:
                return a - b;
            case 2:
                return a * b;
            default:
                // po konzultaci s ChatGPT
                throw new InvalidOperationException("Invalid random number.");
        }
    }
}


public class CalculatorContext
{
    // deklarace operation typu IOperation
    private IOperation opStrategy;
    // zapouzdreni pristupu
    public IOperation operace
    {
        get { return opStrategy; }
    }
    public CalculatorContext(IOperation opStrategy)
    {
        this.opStrategy = opStrategy;
    }

    public int executeStrategy(int a, int b)
    {
        return opStrategy.Execute(a, b);
    }
}


// rozhrani CalculatorApp
public class CalculatorApp
{
    static void Main()
    {
        Console.WriteLine("Zadej první operand:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Zadej druhý operand:");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Zadej operaci (+, -, magic):");
        string selectedOperation = Console.ReadLine();

        IOperation op;

        if (selectedOperation == "+")
        {
            op = new OpAdd();
        }
        else if (selectedOperation == "-")
        {
            op = new OpSub();
        }
        else if (selectedOperation == "magic")
        {
            Random random = new Random();
            op = new OpMagic(random);
        }
        else
        {
            Console.WriteLine("Zkus jinou operaci blude");
            return;
        }

        // novy objekt calculator tridy CalculatorContext
        CalculatorContext calculator = new CalculatorContext(op);
        Console.WriteLine($"Výsledek operace {calculator.operace} ({a} {selectedOperation} {b}) je: {calculator.executeStrategy(a, b)}");
        Console.ReadLine();
    }
}
