using System;
using System.IO;

namespace GuessNumberGame
{
    public class NumberGame : IGame
    {
        private readonly Random random = new Random();
        private int secretNumber;
        private int attempts;
        private bool gameOver;
        private string result;
        private IInputOutput inputOutput;
        private int min;
        private int max;
        private int lives;

        public NumberGame(IInputOutput inputOutput)
        {
            this.inputOutput = inputOutput;
            secretNumber = 0;
            attempts = 0;
            gameOver = false;
            result = "";
            ConfigureGame();
        }

        public void Start()
        {
            attempts = 0;
            gameOver = false;
            result = "";
            secretNumber = random.Next(min, max+1);
            inputOutput.WriteLine("Добро пожаловать в игру 'Угадай число'!");
            inputOutput.WriteLine($"Я загадал число от {min} до {max}. Попробуйте его угадать.");
        }
        public void ConfigureGame(int min = 1, int max = 100, int lives = 5)
        {
            this.min = min;
            this.max = max;
            this.lives = lives;
        }
        public void Guess(int number)
        {
            attempts++;
            lives--;
            result = "";
            if (gameOver)
            {
                inputOutput.WriteLine($"Игра окончена. Число было: {secretNumber}");
                gameOver = true;
                return;
            }
            else if (lives <= 0)
            {
                gameOver = true;
            }

            if (number == secretNumber)
            {
                gameOver = true;
                result = $"Поздравляю! Вы угадали число {secretNumber} за {attempts} попыток.";
            }
            else if (number < secretNumber)
            {
                result = "Слишком мало! Попробуйте ещё раз.";
            }
            else
            {
                result = "Слишком много! Попробуйте ещё раз.";
            }

            inputOutput.WriteLine(result);
        }

        public bool IsGameOver => gameOver;

        public string GetResult() => result;
    }
}