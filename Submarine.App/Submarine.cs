using Submarine.Entities;
using Submarine.Helpers;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Submarine
{
    public class Submarine : IDisposable
    {
        private int XAxis;
        private int YAxis;
        private int ZAxis;
        private CardinalDirection CurrentDirection;

        public Submarine()
        {
            XAxis = 0;
            YAxis = 0;
            ZAxis = 0;
            CurrentDirection = Directions.All().First(f => f.Id == Directions.MinId);
        }

        public string Operate(string commands)
        {
            if (!ValidateCommand(commands))
            {
                return TranslateCurrentCoordinates();
            }

            foreach (var letter in commands)
            {
                switch (letter)
                {
                    case 'M':
                        MoveFoward();
                        break;
                    case 'U':
                        MoveUp();
                        break;
                    case 'D':
                        MoveDown();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'L':
                        TurnLeft();
                        break;
                }
            }

            return TranslateCurrentCoordinates();
        }

        private void MoveDown()
        {
            ZAxis--;
        }

        private void MoveUp()
        {
            if (ZAxis < 0)
            {
                ZAxis++;
            }
        }

        private void TurnLeft()
        {
            if (CurrentDirection.Id == 1)
            {
                CurrentDirection = Directions.All().First(f => f.Id == Directions.MaxId);
            }
            else
            {
                var newOrder = CurrentDirection.Id - 1;
                CurrentDirection = Directions.All().First(w => w.Id == newOrder);
            }
        }

        private void TurnRight()
        {
            if (CurrentDirection.Id == 4)
            {
                CurrentDirection = Directions.All().First(f => f.Id == Directions.MinId);
            }
            else
            {
                var newOrder = CurrentDirection.Id + 1;
                CurrentDirection = Directions.All().First(w => w.Id == newOrder);
            }
        }

        private void MoveFoward()
        {
            if (CurrentDirection.Axis == 'X')
            {
                XAxis += CurrentDirection.Factor;
            }
            else
            {
                YAxis += CurrentDirection.Factor;
            }
        }

        private bool ValidateCommand(string command)
        {
            var regex = new Regex("[MUDRL]");

            return regex.Replace(command, "") == string.Empty;
        }

        private string TranslateCurrentCoordinates()
        {
            return $"{XAxis} {YAxis} {ZAxis} {CurrentDirection.Name}";
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
