using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiderCardGame.Data;

namespace SpiderCardGame.UnitTest
{
    [TestClass]
    public class DealerTest
    {
        [TestMethod]
        public void ShuffleTest()
        {
            Dealer dealer = new Dealer();
            dealer.Shuffle();

            int count = Dealer.MAX_CARD_NUMBER * Dealer.MAX_CARD_SET * Dealer.MAX_TRUMPCARD_SET;

            Assert.AreEqual(count, dealer.cards.Count);
        }

        [TestMethod]
        public void SetDifficultyTest()
        {
            Dealer dealer = new Dealer();
            Difficulty difficulty = Difficulty.VerryHard;
            dealer.SetDifficulty(difficulty);

            Assert.AreEqual(difficulty, dealer.Difficulty_);
        }

        [TestMethod]
        public void PlayCardTest()
        {
            Dealer dealer = new Dealer();
            dealer.Shuffle();
            Card card = dealer.PlayCard();
            Card card2 = dealer.PlayCard();
            Card card3 = dealer.PlayCard();

            Assert.AreEqual(card, dealer.cards[0]);
            Assert.AreEqual(card2, dealer.cards[1]);
            Assert.AreEqual(card3, dealer.cards[2]);
        }

        [TestMethod]
        public void CanPlayCardTest()
        {
            Dealer dealer = new Dealer();
            dealer.Shuffle();
            bool canPlayCard = dealer.CanPlayCard();

            int maxCardNum = Dealer.MAX_CARD_NUMBER * Dealer.MAX_CARD_SET * Dealer.MAX_TRUMPCARD_SET;

            for (int i = 0; i < maxCardNum; i++)
            {
                dealer.PlayCard();
            }

            bool cantPlayCard = dealer.CanPlayCard();

            Assert.AreEqual(canPlayCard, true);
            Assert.AreEqual(cantPlayCard, false);
        }
    }
}
