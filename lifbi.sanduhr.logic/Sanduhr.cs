using System;
using System.Text;

namespace lifbi.sanduhr.logic
{
    public class Sanduhr
    {
        private const char _sign = '*';
        private const char _space = ' ';

        private bool _isEven = false;
        private int _width = 0;
        private int _symbolsPerLine = 0;
        private int _spacersPerLine = 0;
        private StringBuilder _builder = new StringBuilder();

        /// <summary>
        /// Returns the hourglass to be printe or used otherwise
        /// </summary>
        /// <param name="width">the width of the top and base of the hourglass</param>
        public string Print(int width)
        {
            _width = width;
            Validate();
            return DrawHourglass();
        }

        /// <summary>
        /// Validating wheter or not to throw an Exception
        /// </summary>
        private void Validate()
        {
            if (_width < 3)
            {
                throw new ArgumentOutOfRangeException("width", _width, "The given parameter must be equal or greater than 3!");
            }
        }

        /// <summary>
        /// Checks if the width is even, and than process the information to finally return the final string.
        /// </summary>
        /// <return>returns the finished hourglass string</return>
        private string DrawHourglass()
        {
            int TotalAmountOfLines = _width;

            if (_width % 2 == 0)
            {
                _isEven = true;
                TotalAmountOfLines -= 1;
            }

            for (int CurrentLine = 0; CurrentLine < TotalAmountOfLines; CurrentLine++)
            {
                //Skipping the first line
                if (CurrentLine > 0)
                {
                    _builder.Append(Environment.NewLine);
                }

                CalcAmountOfCharactersPerLine(CurrentLine, TotalAmountOfLines);

                DrawElement(_spacersPerLine, _space);

                DrawElement(_symbolsPerLine, _sign);
            }
            return _builder.ToString();
        }

        /// <summary>
        /// Calculates how many signs and how many whitespaces needs to be printed in the current line.
        /// </summary>
        /// <param name="line">current line of the hourglass</param>
        /// <param name="amountOfLines">the total amount of lines wich will be created</param>
        private void CalcAmountOfCharactersPerLine(int line, int amountOfLines)
        {
            if (line <= amountOfLines / 2)
            {
                _symbolsPerLine = _width - 2 * line;
                _spacersPerLine = line;
            }
            else
            {
                if (_isEven)
                {
                    _symbolsPerLine = 2 + 2 * (line - amountOfLines / 2);
                }
                else
                {
                    _symbolsPerLine = 1 + 2 * (line - amountOfLines / 2);
                }

                _spacersPerLine = amountOfLines - line - 1;
            }
        }
        
        /// <summary>
        /// Adds a repeated amount of char elements into the Stringbuilder.
        /// </summary>
        /// <param name="amount">describes the amount of signs printed into the string</param>
        /// <param name="drawSign">designates the sign(char format) wich will be printed</param>
        private void DrawElement(int amount, char drawSign)
        {
            _builder.Append(new string(drawSign, amount));
        }
    }
}
