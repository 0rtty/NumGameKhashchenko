using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame
{
    public interface IGame
    {
        void Start();
        void Guess(int number);
        void ConfigureGame(int min, int max, int lives);
        bool IsGameOver { get; }
        string GetResult();
    }
}
