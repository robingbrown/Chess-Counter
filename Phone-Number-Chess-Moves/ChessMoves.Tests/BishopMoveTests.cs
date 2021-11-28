using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace ChessMoves.Tests
{
    public class BishopMoveTests
    {
        private int maxLength = 7;
        private readonly ITestOutputHelper Output;
        public BishopMoveTests(ITestOutputHelper output)
        {
            this.Output = output;
        }
        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { "1", new Bishop() },
            new object[] { "2", new Bishop() },
            new object[] { "3", new Bishop() },
            new object[] { "4", new Bishop() },
            new object[] { "5", new Bishop() },
            new object[] { "6", new Bishop() },
            new object[] { "7", new Bishop() },
            new object[] { "8", new Bishop() },
            new object[] { "9", new Bishop() },
            new object[] { "0", new Bishop() }
        };
        [Theory]
        [MemberData(nameof(Data))]
        public void PrintMoves(string key, IPiece piece)
        {
            Move target = new();
            target.Key = key;
            target.Piece = piece;
            target.Keyboard = new Keypad();
            target.Length = maxLength;
            target.Position = 1;
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
            target.Keyboard = new Keypad();
            target.Piece = piece;
            target.Position = 1;
            target.Length = maxLength;
            target.Build();
            string results = target.Output();
            Output.WriteLine(results);
            Assert.True(results.Length > 0);
        }
        [Theory]
        [MemberData(nameof(Data))]
        public void TotalMovesTest(string key, IPiece piece)
        {
            Move target = new();
            target.Key = key;
            target.Piece = piece;
            target.Keyboard = new Keypad();
            target.Position = 1;
            target.Length = maxLength;
            target.Build();
            long results = target.TotalTelnos();
            Output.WriteLine(results.ToString());
            Assert.True(results > 0);
        }
    }
}
