using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace ChessMoves.Tests
{
    public class PawnMoveTests
    {
        private int maxLength = 4;
        private readonly ITestOutputHelper Output;
        public PawnMoveTests(ITestOutputHelper output)
        {
            this.Output = output;
        }
        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { "1", new Pawn() },
            new object[] { "2", new Pawn() },
            new object[] { "3", new Pawn() },
            new object[] { "4", new Pawn() },
            new object[] { "5", new Pawn() },
            new object[] { "6", new Pawn() }
            // Starting on 7, 8, 9, or 0 gives no possible moves for a pawn
            //new object[] { "7", new Pawn() },
            //new object[] { "8", new Pawn() },
            //new object[] { "9", new Pawn() },
            //new object[] { "0", new Pawn() }
        };
        [Theory]
        [MemberData(nameof(Data))]
        public void PrintMoves(string key, IPiece piece)
        {
            Move target = new();
            target.Key = key;
            target.Piece = piece;
            target.Keyboard = new Keypad();
            target.Position = 1;
            target.Length = maxLength;
            string moves = target.PrintMoves();
            Output.WriteLine(moves);
            Assert.True(moves.Length > 0);
        }
        [Theory]
        [MemberData(nameof(Data))]
        public void BuildTest(string key, IPiece piece)
        {
            Move target = new();
            target.Key = key;
            target.Piece = piece;
            target.Keyboard = new Keypad();
            target.Position = 1;
            target.Length = maxLength;
            target.Build();
            Assert.True(target.Moves.Count > 0);
        }
        [Theory]
        [MemberData(nameof(Data))]
        public void OutputTest(string key, IPiece piece)
        {
            Move target = new();
            target.Key = key;
            target.Piece = piece;
            target.Keyboard = new Keypad();
            target.Position = 1;
            target.Length = maxLength;
            target.Build();
            string results = target.Output();
            Output.WriteLine(results);
            Assert.True(results.Length > 0);
        }
    }
}
