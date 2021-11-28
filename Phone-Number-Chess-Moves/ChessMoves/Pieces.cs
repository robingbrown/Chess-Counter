using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMoves
{
    public interface IPiece
    {
        /// <summary>
        /// The matrix is a 7x7 array deciding which moves the piece can make
        /// We are limiting it to 7x7 as the maximum distance a piece could move on the keypad is three squares
        /// </summary>
        public bool[,] Matrix { get; }
        //= new bool[7, 7]
        //{
        //    { false, false, false, false, false, false, false },
        //    { false, false, false, false, false, false, false },
        //    { false, false, false, false, false, false, false },
        //    { false, false, false, false, false, false, false },
        //    { false, false, false, false, false, false, false },
        //    { false, false, false, false, false, false, false },
        //    { false, false, false, false, false, false, false }
        //};
    }

    public class Pawn : IPiece
    {
        bool[,] IPiece.Matrix => new bool[7, 7]
            {
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, true , false, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false }
            };
    }
    public class King : IPiece
    {
        bool[,] IPiece.Matrix => new bool[7, 7]
            {
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false },
                { false, false, true , true , true , false, false },
                { false, false, true , false, true , false, false },
                { false, false, true , true , true , false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false }
            };
    }
    public class Rook : IPiece
    {
        bool[,] IPiece.Matrix => new bool[7, 7]
            {
                { false, false, false, true , false, false, false },
                { false, false, false, true , false, false, false },
                { false, false, false, true , false, false, false },
                { true , true , true , false, true , true , true  },
                { false, false, false, true , false, false, false },
                { false, false, false, true , false, false, false },
                { false, false, false, true , false, false, false }
            };
    }
    public class Bishop : IPiece
    {
        bool[,] IPiece.Matrix => new bool[7, 7]
            {
                { true , false, false, false, false, false, true  },
                { false, true , false, false, false, true , false },
                { false, false, true , false, true , false, false },
                { false, false, false, false, false, false, false },
                { false, false, true , false, true , false, false },
                { false, true , false, false, false, true , false },
                { true , false, false, false, false, false, true  }
            };
    }
    public class Queen : IPiece
    {
        bool[,] IPiece.Matrix => new bool[7, 7]
            {
                { true , false, false, true , false, false, true  },
                { false, true , false, true , false, true , false },
                { false, false, true , true , true , false, false },
                { true , true , true , false, true , true , true  },
                { false, false, true , true , true , false, false },
                { false, true , false, true , false, true , false },
                { true , false, false, true , false, false, true  }
            };
    }
    public class Knight : IPiece
    {
        bool[,] IPiece.Matrix => new bool[7, 7]
            {
                { false, false, false, false, false, false, false },
                { false, false, true , false, true , false, false },
                { false, true , false, false, false, true , false },
                { false, false, false, false, false, false, false },
                { false, true , false, false, false, true , false },
                { false, false, true , false, true , false, false },
                { false, false, false, false, false, false, false }
            };
    }

}
