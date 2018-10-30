using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiderCardGame.Data;

namespace SpiderCardGame.UnitTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void BoardConstructorTest()
        {
            Board board = new Board(new Dealer());

            Assert.AreEqual(Board.MAX_LINES, board.boardLines.Count);
        }

        [TestMethod]
        public void InitBoardTest()
        {
            Dealer dealer = new Dealer();
            Board board = new Board(dealer);

            dealer.Shuffle();

            board.InitBoard();

            List<int> lineCardcounts = new List<int>();
            foreach (List<Card> boardLine in board.boardLines)
            {
                lineCardcounts.Add(boardLine.Count);
            }

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(6, lineCardcounts[i]);
            }
            for (int i = 4; i < lineCardcounts.Count; i++)
            {
                Assert.AreEqual(5, lineCardcounts[i]);
            }
        }

        [TestMethod]
        public void TakeCardTest()
        {
            Board board = new Board(new Dealer());

            Card c1 = new Card(Card.Pattern.Spade, 11);
            Card c2 = new Card(Card.Pattern.Spade, 3);
            Card c3 = new Card(Card.Pattern.Spade, 7);

            List<Card> cards = new List<Card>() { c1, c2, c3 };

            board.TakeCard(1, c1);

            Assert.AreEqual(1, board.boardLines[0].Count);
        }

        [TestMethod]
        public void BringCardsTest()
        {
            Board board = new Board(new Dealer());

            Card c1 = new Card(Card.Pattern.Spade, 11);
            Card c2 = new Card(Card.Pattern.Spade, 3);
            Card c3 = new Card(Card.Pattern.Spade, 7);

            List<Card> cards = new List<Card>() { c1, c2, c3 };

            foreach (Card card in cards)
            {
                board.TakeCard(3, card);
            }
            board.BringCards(3, 2);

            Assert.AreEqual(cards.Count - 2, board.boardLines[2].Count);
        }

        [TestMethod]
        public void ConveyCardToAllLineTest()
        {
            Dealer dealer = new Dealer();
            Board board = new Board(dealer);

            dealer.Shuffle();
            board.ConveyCardToAllLine();

            foreach (List<Card> boardLine in board.boardLines)
            {
                Assert.AreEqual(1, boardLine.Count);
            }
        }

        [TestMethod]
        public void RemoveCardSetTest()
        {
            Board board = new Board(new Dealer());
            int margin = 3;

            for(int i = 0; i < Dealer.MAX_CARD_NUMBER + margin; i++)
            {
                Card card = new Card(Card.Pattern.Spade, 3);
                board.TakeCard(3, card);
            }

            board.RemoveOneCardSet(3);

            Assert.AreEqual(margin, board.boardLines[2].Count);
        }

        [TestMethod]
        public void ConveyCardLineToLineTest()
        {
            Dealer dealer = new Dealer();
            Board board = new Board(dealer);

            dealer.Shuffle();
            
            board.ConveyCardToAllLine();
            board.ConveyCardToAllLine();

            int sendLine = 1;
            int recvLine = 2;
            int conveyAmount = 2;
            board.ConveyCardLineToLine(sendLine,conveyAmount,recvLine);

            Assert.AreEqual(2- conveyAmount, board.boardLines[sendLine-1].Count);
            Assert.AreEqual(2+ conveyAmount, board.boardLines[recvLine-1].Count);
        }

        [TestMethod]
        public void SetHintLinesTest()
        {
            Board board = new Board(new Dealer());

            int sendLine = 1;
            int recvLine = 2;
            board.SetHintLines(sendLine, recvLine);

            Assert.AreEqual(sendLine, board.hintLines[0]);
            Assert.AreEqual(recvLine, board.hintLines[1]);
        }

        [TestMethod]
        public void GetCardChainAmountFromLineTest()
        {
            Board board = new Board(new Dealer());

            Card c1 = new Card(Card.Pattern.Spade, 1);
            Card c2 = new Card(Card.Pattern.Spade, 2);
            Card c3 = new Card(Card.Pattern.Spade, 3);
            Card c4 = new Card(Card.Pattern.Heart, 2);
            Card c5 = new Card(Card.Pattern.Spade, 2);

            c1.isOpened = true; 
            c2.isOpened = true; 
            c3.isOpened = true; 
            c4.isOpened = true; 


            //숫자가 연속되면 카드가 연결되어있음
            board.TakeCard(1, c3);
            board.TakeCard(1, c2);
            board.TakeCard(1, c1);
            //문양이 다르면 연속으로 인정 안됨
            board.TakeCard(2, c4);
            board.TakeCard(2, c1);
            //카드가 오픈된 상황이 아니면 연속으로 인정 안됨
            board.TakeCard(3, c5);
            board.TakeCard(3, c1);

            Assert.AreEqual(3, board.GetCardChainAmountFromLine(1));
            Assert.AreEqual(1, board.GetCardChainAmountFromLine(2));
            Assert.AreEqual(1, board.GetCardChainAmountFromLine(3));
        }

        [TestMethod]
        public void LinesAreNotEmptyTest()
        {
            Dealer dealer = new Dealer();
            Board board = new Board(dealer);

            bool b1 = board.LinesAreNotEmpty();

            dealer.Shuffle();
            board.ConveyCardToAllLine();

            bool b2 = board.LinesAreNotEmpty();

            Assert.AreEqual(b1, false);
            Assert.AreEqual(b2, true);
        }

        [TestMethod]
        public void GetMaxCardsLineTest()
        {
            Board board = new Board(new Dealer());
            List<int> nums = new List<int> { 1, 3, 7, 2, 4, 7, 13, 9, 5, 3 };

            for (int i = 1; i <= Board.MAX_LINES; i++)
            {
                for (int j = 0; j < nums[i-1]; j++)
                {
                    board.TakeCard(i, new Card(Card.Pattern.Spade, 3)); 
                }
            }

            Assert.AreEqual(13, board.GetMaxCardsLine());
        }
    }
}
