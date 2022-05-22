using SquaresGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresGame.EventArguments
{
    public class FieldChangedEventArgs
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public FieldState NewState { get; set; }

        public FieldChangedEventArgs(int row, int column, FieldState newState)
        {
            this.Row = row;
            this.Column = column;
            this.NewState = newState;

        }

    }
}
