using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SudokuGame
{
    public class Game
    {
        private readonly int[,] sudokuProblem =
        {
            {0, 7, 0, 0, 0, 0, 0, 0, 9 },
            {5, 1, 0, 4, 2, 0, 6, 0, 0 },
            {0, 8, 0, 3, 0, 0, 7, 0, 0 },
            {0, 0, 8, 0, 0, 1, 3, 7, 0 },
            {0, 2, 3, 0, 8, 0, 0, 4, 0 },
            {4, 0, 0, 9, 0, 0, 1, 0, 0 },
            {9, 6, 2, 8, 0, 0, 0, 3, 0 },
            {0, 0, 0, 0, 1, 0, 4, 0, 0 },
            {7, 0, 0, 2, 0, 3, 0, 9, 6 }
        };

        public int PointerLeft { get; set; }
        private int PointerTop { get; set; }
        private int HorizontalJump { get; set; }
        private int VerticalJump { get; set; }

        private int SudokuRow { get; set; }
        private int SudokuCol { get; set; }

        public Sudoku Board { get; private set; }

        public Game()
        {
            Board = new Sudoku(sudokuProblem);
            PointerLeft = 5;
            PointerTop = 1;
            HorizontalJump = 5;
            VerticalJump = 2;
            SudokuRow = 1;
            SudokuCol = 1;
        }

        public void Start()
        {
            while (!Board.IsSolved)
            {
                Board.PrintSudokuBoard();
                Console.SetCursorPosition(PointerLeft, PointerTop);
                Console.CursorVisible = true;
                KeyPressedHandler(Console.ReadKey(true).Key);
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("You Won!");
            Console.Read();
        }

        private void KeyPressedHandler(ConsoleKey key)
        {

            if (key == ConsoleKey.UpArrow)
                HandleUpArrowKeyPressed();
            if (key == ConsoleKey.DownArrow)
                HandleDownArrowKeyPressed();
            if (key == ConsoleKey.LeftArrow)
                HandlLeftArrowKeyEvent();
            if (key == ConsoleKey.RightArrow)
                HandleRightArrowKeyEvent();
            if (key >= ConsoleKey.D1 && key <= ConsoleKey.D9)
            {
                int value = ConvertDKeyCodeToInt(key);
                Board.SetCellValue(SudokuRow, SudokuCol, value);
            }
            if (key > ConsoleKey.NumPad0 && key <= ConsoleKey.NumPad9)
            {
                int value = ConvertNumPadKeyCodeToInt(key);
                Board.SetCellValue(SudokuRow, SudokuCol, value);
            }
            //if (key == ConsoleKey.S)
            //    Board.ShowSolution();


        }

        private int ConvertNumPadKeyCodeToInt(ConsoleKey key)
        {
            return key - ConsoleKey.NumPad0;
        }

        private int ConvertDKeyCodeToInt(ConsoleKey key)
        {
            return key - ConsoleKey.D0;
        }

        private void HandleRightArrowKeyEvent()
        {
            if (PointerLeft < 47)
            {
                PointerLeft += SudokuCol % 3 == 0 ? HorizontalJump + 1 : HorizontalJump;
                SudokuCol++;
            }
        }

        private void HandlLeftArrowKeyEvent()
        {
            if (PointerLeft > 6)
            {
                PointerLeft -= SudokuCol == 4 || SudokuCol == 7 ? HorizontalJump + 1 : HorizontalJump;
                SudokuCol--;
            }
        }

        private void HandleDownArrowKeyPressed()
        {
            if (PointerTop < 17)
            {
                PointerTop += VerticalJump;
                SudokuRow++;
            }
        }

        private void HandleUpArrowKeyPressed()
        {
            if (PointerTop > 1)
            {
                PointerTop -= VerticalJump;
                SudokuRow--;
            }
        }
    }
}
