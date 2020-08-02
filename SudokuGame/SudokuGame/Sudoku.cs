using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SudokuGame
{
    public class Sudoku
    {
        //private List<Cell> Solution { get; set; }
        public List<Cell> Cells { get; set; }

        public bool IsSolved
        {
            get
            {
                foreach (var cell in Cells)
                {
                    if (
                        !(IsValidRowValue(cell, cell.Value) &&
                        IsValidColumnValue(cell, cell.Value) &&
                        IsValidBlockValue(cell, cell.Value))
                        )
                        return false;
                }
                return true;
            }
        }


        public Sudoku(int[,] sudokuMatrix)
        {
            Cells = new List<Cell>();
            //Solution = new List<Cell>();
            int count = 0;
            for (int i = 1; i < 10; i++)
                for (int j = 1; j < 10; j++)
                    Cells.Add(new Cell(i, j, sudokuMatrix[i - 1, j - 1], count++));

            //SolveSudoku(sudokuMatrix);
        }

        public void PrintSudokuBoard()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            // Blank Line
            string blankLine = "  |";
            for (int i = 0; i < 47; i++)
                blankLine += " ";
            blankLine += "|";

            // Horizontal Line
            string horizontalBorder = "  ";
            for (int i = 0; i < 49; i++)
                horizontalBorder += "-";

            // Printing Top Border
            Console.WriteLine(horizontalBorder);
            //Board Printing
            for (int row = 1; row <= 9; row++)
            {
                // 2-Pix Padding
                string BoardRow = "  |";

                for (int col = 1; col <= 9; col++)
                {
                    BoardRow += "  " + Cells.Single(cell => cell.Row == row && cell.Column == col).Value.ToString() + "  ";
                    if (col % 3 == 0)
                        BoardRow += "|";
                }
                // Printing Line of All Values
                Console.WriteLine(BoardRow);
                if (!(row % 3 == 0))
                    Console.WriteLine(blankLine);
                // Horizontal Block Limits
                if (row % 3 == 0)
                    Console.WriteLine(horizontalBorder);
            }

            Console.WriteLine("  INSTRUCTIONS: Use ARROW_KEYS to move between values.");
            //Console.WriteLine("                Press 'S' to show the solution of the sudoku.");
            Console.WriteLine("                Press ESCAPE to Exit.");

        }


        //private void SolveSudoku(int[,] sudokuMatrix)
        //{
        //    for (int i = 1; i < 10; i++)
        //        for (int j = 1; j < 10; j++)
        //            Solution.Add(new Cell(i, j));

        //    for (int row = 0; row < 9; row++)
        //    {
        //        for (int col = 0; col < 9; col++)
        //        {
        //            if (sudokuMatrix[row, col] != 0)
        //                this.SetCellSolutionValue(row + 1, col + 1, sudokuMatrix[row, col]);
        //        }
        //    }
        //}

        public void SetCellValue(int row, int column, int value)
        {

            Cell activeCell = Cells.First(cell => (cell.Row == row && cell.Column == column));

            if (activeCell.IsSolved)
                return;

            activeCell.Value = value;
        }

        private bool IsValidColumnValue(Cell cellToValidate, int? value)
        {
            var columnCells = Cells.Where(cell => cell.Column == cellToValidate.Column && cell.Id != cellToValidate.Id);
            return columnCells.Any(cell => cell.Value == value);
        }

        private bool IsValidRowValue(Cell cellToValidate, int? value)
        {
            var rowCells = Cells.Where(cell => cell.Row == cellToValidate.Row && cell.Id != cellToValidate.Id);
            return rowCells.Any(cell => cell.Value == value);
        }

        private bool IsValidBlockValue(Cell cellToValidate, int? value)
        {
            var blockCells = Cells.Where(cell => cell.Block == cellToValidate.Block && cell.Id != cellToValidate.Id);
            return blockCells.Any(cell => cell.Value == value);
        }

        //private void SetCellSolutionValue(int row, int column, int value)
        //{
        //    Cell activeCell = Solution.First(cell => (cell.Row == row && cell.Column == column));

        //    activeCell.Value = value;

        //    foreach (Cell cell in Solution.Where(cell => !cell.IsSolved && cell.Row == row))
        //        cell.PotentialValues.Remove(value);

        //    foreach (Cell cell in Solution.Where(cell => !cell.IsSolved && cell.Column == column))
        //        cell.PotentialValues.Remove(value);

        //    foreach (Cell cell in Solution.Where(cell => !cell.IsSolved && cell.Block == activeCell.Block))
        //        cell.PotentialValues.Remove(value);

        //    foreach (Cell cell in Solution.Where(cell => !cell.IsSolved && cell.PotentialValues.Count == 1))
        //        this.SetCellSolutionValue(cell.Row, cell.Column, cell.PotentialValues[0]);
        //}
    }
}
