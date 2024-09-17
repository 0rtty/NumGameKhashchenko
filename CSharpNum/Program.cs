using GuessNumberGame;
class Program
{
    static void Main(string[] args)
    {
        // Игра с файловым вводом/выводом
        //IGame fileGame = new NumberGame(new FileInputOutput("game_log.txt"));
        //PlayGame(fileGame);

        // Игра с консольным вводом/выводом
        IGame consoleGame = new NumberGame(new ConsoleInputOutput());
        Configure(consoleGame);
        PlayGame(consoleGame);
    }

    static void Configure(IGame game)
    {
        ConsoleInputOutput inputOutput = new ConsoleInputOutput();
        inputOutput.WriteLine("Введите минимальное число:");
        int min = Convert.ToInt32(inputOutput.ReadLine());
        inputOutput.WriteLine("Введите максимальное число:");
        int max = Convert.ToInt32(inputOutput.ReadLine());
        inputOutput.WriteLine("Введите количество жизней:");
        int lives = Convert.ToInt32(inputOutput.ReadLine());
        game.ConfigureGame(min, max, lives);
    }

    static void PlayGame(IGame game)
    {
        game.Start();
        ConsoleInputOutput inputOutput = new ConsoleInputOutput();
        while (!game.IsGameOver)
        {
            inputOutput.WriteLine("Введите число: ");
            string input = inputOutput.ReadLine();
            int number = int.Parse(input);

            game.Guess(number);
        }
    }
}