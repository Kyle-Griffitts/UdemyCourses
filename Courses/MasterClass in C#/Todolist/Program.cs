Console.WriteLine("Hello");
Console.WriteLine("What do you want to do? ");
Console.WriteLine("[S]ee all TODOs");
Console.WriteLine("[A]dd a TODO");
Console.WriteLine("[R]emove a TODO");
Console.WriteLine("[E]xit");

var userChoice = Console.ReadLine();
Console.WriteLine("user input: " + userChoice);

if (userChoice == "S" || userChoice == "s")
{
    PrintSelectedOption("See all TODOs");
}
else if (userChoice == "A" || userChoice == "a")
{
    PrintSelectedOption("Add a TODO");
}
else if (userChoice == "R" || userChoice == "r")
{
    PrintSelectedOption("Remove a TODO");
}
else if (userChoice == "E" || userChoice == "e")
{
    PrintSelectedOption("Exit");
}
else
{
    PrintSelectedOption("Invalid option. Please try again.");
}

Console.ReadKey();

void PrintSelectedOption(string userChoice)
{ 
    Console.WriteLine("You selected: " + userChoice);
}


int Add(int a, int b)
{
    return a + b;
}



Math.Pow
