using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChessMoves
{
    /// <summary>
    /// A 'move' consists of one move that a chess piece can make, a chain of seven moves makes up a phone number
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Move() { }
        /// <summary>
        /// Immediately Build all Moves for the given Key and Piece 
        /// </summary>
        public Move(string key, IPiece piece, IKeyboardLayout keyboard)
        {
            Key = key;
            Piece = piece;
            Keyboard = keyboard;
            Build();
        }
        /// <summary>
        /// The Key determines where we start
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Position determines how far we are into the chain, default is one.
        /// </summary>
        public int Position { get; set; } = 1;
        /// <summary>
        /// Total length of the chain, default is seven.
        /// </summary>
        public int Length { get; set; } = 7;
        /// <summary>
        /// A Piece determines the moves we can make
        /// </summary>
        public IPiece Piece { get; set; }
        /// <summary>
        /// The keyboard we are using
        /// </summary>
        public IKeyboardLayout Keyboard { get; set; }
        /// <summary>
        /// The moves are all the legitimate single step moves that can be made from the Key by the Piece
        /// </summary>
        public List<Move> Moves { get; set; } = new();
        /// <summary>
        /// Build a complete set of Moves, Moves within Moves, etc.
        /// </summary>
        public void Build()
        {
            // Clear any current moves
            Moves = new List<Move>();
            //Don't build past the required length
            if (Position >= Length) { return; }
            // Using the Key and the Piece determine which moves are possible and create a new move for each one
            bool[,] possible = new bool[7, 7];
            // Work out the offsets
            int[] offset = Keyboard.Offset(Key);
            // AND our arrays to get the possibilities
            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    // The keys array is offset from the moves array
                    // remembering our chess piece is located in the middle of the move array at 3, 3
                    int keyRow = row - 3 + offset[0];
                    int keyCol = col - 3 + offset[1];
                    if( Piece.Matrix[row, col] && Keyboard.Available(keyRow, keyCol))
                    {
                        Move newMove = new()
                        {
                            Key = Keyboard.Values[keyRow, keyCol],
                            Position = Position + 1,
                            Piece = Piece,
                            Keyboard = Keyboard,
                            Length = Length
                        };
                        newMove.Build();
                        Moves.Add(newMove);
                    }
                }
            }
        }
        /// <summary>
        /// Check all the Moves and Moves within Moves, etc. To get all the combinations that can be made
        /// </summary>
        public string Output()
        {
            StringBuilder sb = new();
            //sb.AppendLine($"{Piece.GetType().Name}");
            foreach (var move in Moves)
            {
                move.Read(sb, Key);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Recurse into the chain reading all the Moves, Moves within Moves, etc.
        /// </summary>
        public void Read(StringBuilder sb, string number)
        {
            number += Key;
            if (Moves.Count == 0)
            {
                sb.AppendLine(number);
                return;
            }
            // We are avoiding using linq here as it's not so good at recursion, especially if we need to debug it
            foreach (var move in Moves)
            {
                move.Read(sb, number);
            }
        }
        /// <summary>
        /// Count how many telnos we can produce by recursing into the chain
        /// </summary>
        public long TotalTelnos()
        {
            Counter total = new();
            foreach (var move in Moves)
            {
                move.Count(total);
            }
            return total.Total();
        }
        public void Count(Counter total)
        {
            if (Moves.Count == 0)
            {
                total.Add();
                return;
            }
            // We are avoiding using linq here as it's not so good at recursion, especially if we need to debug it
            foreach (var move in Moves)
            {
                move.Count(total);
            }
        }
        /// <summary>
        /// Return a string representation of the current moves the Piece can make given the Key
        /// </summary>
        public string PrintMoves()
        {
            // Using the Key and the Piece determine which moves are possible and create a new move for each one
            bool[,] possible = new bool[7, 7];
            // Work out the offsets
            int[] offset = Keyboard.Offset(Key);
            // AND our arrays to get the possibilities
            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Debug.WriteLine($"R{row}:C{col} - {possible[row, col]}");
                }
            }
            // Output
            StringBuilder sb = new();
            sb.AppendLine($"{Piece.GetType().Name}, Key: {Key}");
            for (int row = 0; row < 7; row++)
            {
                string line = "";
                for (int col = 0; col < 7; col++)
                {
                    // The keys array is offset from the moves array
                    // remembering our chess piece is located in the middle of the move array at 3, 3
                    int keyRow = row - 3 + offset[0];
                    int keyCol = col - 3 + offset[1];
                    possible[row, col] = Piece.Matrix[row, col] && Keyboard.Available(keyRow, keyCol);
                    if (row == 3 && col == 3)
                    {
                        line += "X";
                    }
                    else
                    {
                        line += possible[row, col] ? Keyboard.Values[keyRow, keyCol] : "N";
                    }
                }
                sb.AppendLine(line);
            }
            return sb.ToString();
        }
    }
}
