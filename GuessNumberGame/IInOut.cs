using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame
{
    public interface IInputOutput
    {
        void WriteLine(string message);
        string ReadLine();
    }

    public class ConsoleInputOutput : IInputOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }

    public class FileInputOutput : IInputOutput
    {
        private readonly string filePath;
        private string[] lines;
        private int currentLineIndex;

        public FileInputOutput(string filePath)
        {
            this.filePath = filePath;
            lines = File.ReadAllLines(this.filePath);
            currentLineIndex = 0;
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }

        public string ReadLine()
        {
            if (currentLineIndex < lines.Length)
            {
                return lines[currentLineIndex++];
            }
            else
            {
                return null;
            }
        }
    }

    public class FormInputOutput : IInputOutput
    {
        //private readonly System.Windows.Forms.TextBox textBox;

        //public FormInputOutput(System.Windows.Forms.TextBox textBox)
        //{
        //    this.textBox = textBox;
        //}

        public void WriteLine(string message)
        {
            //textBox.AppendText(message + Environment.NewLine);
        }

        public string ReadLine()
        {
            //string input = _textBox.Text;
            //textBox.Clear();
            //return input;
            return "Not implemented";
        }
    }
}
