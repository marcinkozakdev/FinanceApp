using FinanceApp;

Hello();

while (true)
{
    WriteLineColor(ConsoleColor.DarkGray,
        "Where you want to save data:\n" +
        "----------------------------------------------\n" +
        "\t1 - Program memory\n" +
        "\t2 - In .txt file\n" +
        "\tX - Close App\n" +
        "----------------------------------------------\n" +
        "Press key 1, 2 or X: "
        );

    var userInput = Console.ReadLine().ToUpper();

    switch (userInput)
    {
        case "1":
            AddTransactionsToMemory();
            break;

        case "2":
            AddTransactionsToTxtFile();
            break;

        case "X":
            Environment.Exit(0);
            break;

        default:
            WriteLineColor(ConsoleColor.Red, "\tInvalid operation!\n");
            continue;
    }
};

static void AddTransactionsToMemory()
{
    string name = GetValueFromUser("Please insert your name: ");
    string surname = GetValueFromUser("Please insert your surname: ");
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var inMemoryUser = new UserInMemory(name, surname);
        inMemoryUser.TransactionAdded += TransactionAdded;
        EnterTransaction(inMemoryUser);
        inMemoryUser.ShowStatistics();
    }
    else
    {
        WriteLineColor(ConsoleColor.Red, "User name ond surname can't be empty!");
    }
}

static void AddTransactionsToTxtFile()
{
    string name = GetValueFromUser("Please insert your name: ");
    string surname = GetValueFromUser("Please insert your surname: ");
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var userInFile = new UserInFile(name, surname);
        userInFile.TransactionAdded += TransactionAdded;
        EnterTransaction(userInFile);
        userInFile.ShowStatistics();
    }
    else
    {
        WriteLineColor(ConsoleColor.Red, "User name ond surname can't be empty!");
    }
}

static void EnterTransaction(IUser user)
{
    while (true)
    {
        WriteLineColor(ConsoleColor.DarkGray, $"Enter the amount of the transaction: ");
        var input = Console.ReadLine();

        if (input == "q" || input == "Q")
        {
            break;
        }
        try
        {
            user.AddTransaction(input);
        }
        catch (ArgumentException ex)
        {
            WriteLineColor(ConsoleColor.Red, ex.Message);
        }
        finally
        {
            WriteLineColor(ConsoleColor.DarkGray, "To leave and show statistics enter 'q'.\n");
        }
    }
}

static void TransactionAdded(object sender, EventArgs args)
{
    WriteLineColor(ConsoleColor.DarkGreen, "\tAdded new transaction!\n");
}

static void WriteLineColor(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine("----------------------------------------------");
    Console.Write(text);
    Console.ResetColor();
}

static void Hello()
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("==============================================");
    Console.WriteLine("\tWelcome to console FINANCE APP");
    Console.WriteLine("==============================================\n");
    Console.ResetColor();
}

static string GetValueFromUser(string comment)
{
    WriteLineColor(ConsoleColor.DarkGray, comment);
    string userInput = Console.ReadLine();
    return userInput;
}
