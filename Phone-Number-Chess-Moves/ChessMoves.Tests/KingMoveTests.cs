using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace ChessMoves.Tests
{
    public class KingMoveTests
    {
        private int maxLength = 7;
        private readonly ITestOutputHelper Output;
        public KingMoveTests(ITestOutputHelper output)
        {
            this.Output = output;
        }
        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { "1", new King() },
            new object[] { "2", new King() },
            new object[] { "3", new King() },
            new object[] { "4", new King() },
            new object[] { "5", new King() },
            new object[] { "6", new King() },
            new object[] { "7", new King() },
            new object[] { "8", new King() },
            new object[] { "9", new King() },
            new object[] { "0", new King() }
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
            target.Piece = piece;
            target.Keyboard = new Keypad();
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
