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
            Board board = new Board();

            Assert.AreEqual(Board.MAX_LINES, board.boardLines.Count);
        }

        [TestMethod]
        public void TakeCardTest()
        {
            Board board = new Board();

            Card c1 = new Card(Card.Pattern.Spade, 11);
            Card c2 = new Card(Card.Pattern.Spade, 3);
            Card c3 = new Card(Card.Pattern.Spade, 7);

            List<Card> cards = new List<Card>() { c1, c2, c3 };

            board.TakeCard(1, c1);
            board.TakeCards(3, cards);

            Assert.AreEqual(1, board.boardLines[0].Count);
            Assert.AreEqual(3, board.boardLines[2].Count);
        }

        [TestMethod]
        public void BringCardsTest()
        {
            Board board = new Board();

            Card c1 = new Card(Card.Pattern.Spade, 11);
            Card c2 = new Card(Card.Pattern.Spade, 3);
            Card c3 = new Card(Card.Pattern.Spade, 7);

            List<Card> cards = new List<Card>() { c1, c2, c3 };

            board.TakeCards(3, cards);
            board.BringCards(3, 2);

            Assert.AreEqual(cards.Count - 2, board.boardLines[2].Count);
        }

        [TestMethod]
        public void RemoveCardSetTest()
        {
            Board board = new Board();
            int margin = 3;

            for(int i = 0; i < Dealer.MAX_CARD_NUMBER + margin; i++)
            {
                Card card = new Card(Card.Pattern.Spade, 3);
                board.TakeCard(3, card);
            }

            board.RemoveCardSet(3);

            Assert.AreEqual(margin, board.boardLines[2].Count);
        }

        [TestMethod]
        public void GetMaxCardsLineTest()
        {
            Board board = new Board();
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
