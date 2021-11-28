using ChessMoves;
using System;
using System.IO;
using System.Text;

namespace Counter
{
    class Program
    {
        /// <summary>
        /// Calculate all the numbers that can be made and output to some files
        /// We only start on keys 2-9
        /// </summary>
        static void Main(string[] args)
        {
            // We are going to keep a running total and a total for the current piece
            long ultimateTotal = 0;
            long pieceTotal = 0;
            StringBuilder totals = new();

            // Pawn
            // Pawns can't make seven step moves so are excluded

            // Rook
            pieceTotal += Count(new Rook(), new Keypad());
            ultimateTotal += pieceTotal;
            totals.AppendLine($"Rook total: {pieceTotal}");
            pieceTotal = 0;

            // Bishop
            pieceTotal += Count(new Bishop(), new Keypad());
            ultimateTotal += pieceTotal;
            totals.AppendLine($"Bishop total: {pieceTotal}");
            pieceTotal = 0;

            // Queen
            pieceTotal += Count(new Queen(), new Keypad());
            ultimateTotal += pieceTotal;
            totals.AppendLine($"Queen total: {pieceTotal}");
            pieceTotal = 0;

            // Knight
            pieceTotal += Count(new Knight(), new Keypad());
            ultimateTotal += pieceTotal;
            totals.AppendLine($"Knight total: {pieceTotal}");
            pieceTotal = 0;

            // King
            pieceTotal += Count(new King(), new Keypad());
            ultimateTotal += pieceTotal;
            totals.AppendLine($"King total: {pieceTotal}");

            // Total
            totals.AppendLine($"Ultimate Total: {ultimateTotal}");
            File.WriteAllText("Chess_Moves_Count_Totals.CSV", totals.ToString());
        }

        public static long Count(IPiece piece, IKeyboardLayout keyboard)
        {
            string name = piece.GetType().Name;
            long total = 0;
            StringBuilder telnos = new();
            telnos.AppendLine($"{name} telnos");
            for (int key = 2; key <= 9; key++)
            {
                Move curMove = new(key.ToString(), piece, keyboard);
                File.WriteAllText($"{name}_Moves_Key_{key}.csv", curMove.PrintMoves());
                total += curMove.TotalTelnos();
                //telnos.AppendLine($"Key {key} Total: {total}");
                telnos.AppendLine(curMove.Output());
            }
            telnos.AppendLine($"Total for keys 2-9: {total}");
            File.WriteAllText($"{name}_TelNos.csv", telnos.ToString());
            return total;
        }
    }
}
