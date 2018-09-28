using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiderCardGame.Data;

namespace SpiderCardGame.UnitTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void ToStringOverride()
        {
            Card card = new Card(Card.Pattern.Spade, 1);
            Card card2 = new Card(Card.Pattern.Clover, 7);
            Card card3 = new Card(Card.Pattern.Diamond, 13);
            Card card4 = new Card(Card.Pattern.Heart, 11);
            

            Assert.AreEqual("♠01", card.ToString());
            Assert.AreEqual("♣07", card2.ToString());
            Assert.AreEqual("◆K", card3.ToString());
            Assert.AreEqual("♥J", card4.ToString());
        }
    }
}
