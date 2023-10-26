using FinanceApp;

Hello();

bool CloseApp = false;

while (true)
{
    WriteLineColor(ConsoleColor.DarkGray, 
        "Where you want to save data:\n" +
        "-----------------------------------\n" +
        "1 - Program memory\n" +
        "2 - In .txt file\n" +
        "X - Close App\n" +
        "-----------------------------------\n" +
        "Press key 1, 2 or X: "
        );

    var userInput = Console.ReadLine().ToUpper();

    switch (userInput)
    {
        case "1":
            AddTransactionsToMemory();
            break;

        case "2":
            break;

        case "X":
            CloseApp = true;
            break;

        default:
            WriteLineColor(ConsoleColor.Red, "Invalid operation.\n");
            continue;
    }
    Console.WriteLine();
    WriteLineColor(ConsoleColor.DarkGray, "Press any key to leave.");
    Console.ReadKey();
};

static void AddTransactionsToMemory()
{
    string name = GetValueFromUser("Please insert your name: ");
    string surname = GetValueFromUser("Please insert your surname: ");
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var inMemoryUser = new UserInMemory(name, surname);
        EnterTransaction(inMemoryUser);
        inMemoryUser.TransactionAdded += TransactionSaved;
    }
    else
    {
        WriteLineColor(ConsoleColor.Red, "");
    }
}

static void AddtransactionsToTxtFile()
{
    string name = GetValueFromUser("Please insert your name: ");
    string surname = GetValueFromUser("Please insert your surname: ");
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var savedStudent = new UserInFile(name, surname);

    }
    else
    {
        WriteLineColor(ConsoleColor.Red, "");
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
        catch (FormatException ex)
        {
            WriteLineColor(ConsoleColor.Red, ex.Message);
        }
        catch (ArgumentException ex)
        {
            WriteLineColor(ConsoleColor.Red, ex.Message);
        }
        catch (NullReferenceException ex)
        {
            WriteLineColor(ConsoleColor.Red, ex.Message);
        }
        finally
        {
            WriteLineColor(ConsoleColor.DarkCyan, $"To leave and show {user.Name} {user.Surname} statistics enter 'q'.");
        }
    }
}

static void TransactionSaved(object sender, EventArgs args)
{
    Console.WriteLine("Added new transaction!");
}

static void WriteLineColor(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine("-----------------------------------");
    Console.Write(text);
    Console.ResetColor();
}

static void Hello()
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("===================================");
    Console.WriteLine("Welcome to console FINANCE APP");
    Console.WriteLine("===================================");
    Console.ResetColor();
}

static string GetValueFromUser(string comment)
{
    WriteLineColor(ConsoleColor.DarkGray, comment);
    string userInput = Console.ReadLine();
    return userInput;
}
