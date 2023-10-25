WriteLineColor(ConsoleColor.DarkCyan, "Welcome to console FINANCE APP");
bool CloseApp = false;

while (true)
{
    Console.WriteLine("Where you want to save data:\n" + 
        "------------------------------\n" +
        "1 - PROGRAM MEMORY\n" +
        "2 - IN .TXT FILE\n" +
        "X - CLOSE APP\n");

    WriteLineColor(ConsoleColor.DarkCyan, "Press key 1, 2 or X: ");
    var userInput = Console.ReadLine().ToUpper();

    switch (userInput)
    {
        case "1":
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

    WriteLineColor(ConsoleColor.DarkYellow, "\n\nPress any key to leave.");
    Console.ReadKey();
};

static void WriteLineColor(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine("==============================");
    Console.WriteLine(text);
    Console.WriteLine("==============================\n");
    Console.ResetColor();
}
