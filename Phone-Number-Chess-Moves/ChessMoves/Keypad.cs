using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMoves
{
    /// <summary>
    /// In case we want to use other keyboard layouts
    /// </summary>
    public interface IKeyboardLayout
    {
        /// <summary>
        /// Return the actual characters on the keyboard as a 2d array
        /// </summary>
        string[,] Values { get; }
        /// <summary>
        /// Return the keyboard as a 2d array showing which keys are available
        /// </summary>
        bool[,] Keys { get; }
        /// <summary>
        /// Determine if a particular row/col combination is available
        /// </summary>
        bool Available(int row, int col) 
        { 
            return false; 
        }
        /// <summary>
        /// For each number on the keypad the keypad matrix will be offset by a certain amount
        /// </summary>
        int[] Offset(string key) 
        { 
            return new int[]{ 0, 0 }; 
        }
    }
    /// <summary>
    /// Standard phone keypad: 123, 456, 789, *0#
    /// </summary>
    public class Keypad: IKeyboardLayout
    {
        public string[,] Values => new string[4, 3]
        {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" },
            { "*", "0", "#" }
        };
        // 
        public bool[,] Keys => new bool[4, 3]
        {
            { true, true, true },
            { true, true, true },
            { true, true, true },
            { false, true, false }
        };
        // Determine if a particular row/col combination is available
        public bool Available(int row, int col)
        {
            if ((0 <= row && row <= 3) && (0 <= col && col <= 2))
            {
                return Keys[row, col];
            }
            return false;
        }
        // 
        public int[] Offset(string key)
        {
            return key switch
            {
                "1" => new int[2] { 0, 0 },
                "2" => new int[2] { 0, 1 },
                "3" => new int[2] { 0, 2 },
                "4" => new int[2] { 1, 0 },
                "5" => new int[2] { 1, 1 },
                "6" => new int[2] { 1, 2 },
                "7" => new int[2] { 2, 0 },
                "8" => new int[2] { 2, 1 },
                "9" => new int[2] { 2, 2 },
                "0" => new int[2] { 3, 1 },
                _ => throw new Exception("Invalid Key"),
            };
        }
    }
}
