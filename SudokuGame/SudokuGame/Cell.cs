using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SudokuGame
{
    public enum Blocks
    {
        UpperLeft,
        UpperMiddle,
        UpperRight,
        MiddleLeft,
        Middle,
        MiddleRight,
        LowerLeft,
        LowerMiddle,
        LowerRight
    }

    public class Cell
    {

        public int Id { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }

        internal Blocks Block
        {
            get
            {
                return (this.Row < 4 && this.Column < 4) ? Blocks.UpperLeft :
                    (this.Row < 4 && this.Column < 7) ? Blocks.MiddleLeft :
                    (this.Row < 4 && this.Column < 9) ? Blocks.LowerLeft :
                    (this.Row < 7 && this.Column < 4) ? Blocks.UpperMiddle :
                    (this.Row < 7 && this.Column < 7) ? Blocks.Middle :
                    (this.Row < 7 && this.Column < 9) ? Blocks.LowerMiddle :
                    (this.Row < 9 && this.Column < 4) ? Blocks.UpperRight :
                    (this.Row < 9 && this.Column < 7) ? Blocks.MiddleRight :
                    Blocks.LowerRight;
            }
        }

        public bool IsSolved { get; private set; }
        public int? Value { get; set; }

        //internal List<int> PotentialValues { get; private set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            //PotentialValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        public Cell(int row, int column, int value, int id)
        {
            Id = id;
            Row = row;
            Column = column;
            Value = value;
            //PotentialValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IsSolved = value != 0;
        }
    }
}
