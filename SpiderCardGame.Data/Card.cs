using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCardGame.Data
{
    public class Card
    {
        public enum Pattern
        {
            None = -1,
            Spade,
            Clover,
            Diamond,
            Heart,
        }

        public Pattern Pattern_ { get; private set; }   //카드 패턴
        public int Number { get; private set; }         //카드의 숫자
        public bool isOpened;                           //카드가 공개된 상태인지

        public Card(Pattern Pattern_, int number)
        {
            this.Pattern_ = Pattern_;
            this.Number = number;
        }


        //문양과 카드 숫자에 따라 출력받을 수 있도록 ToString Override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            switch (Pattern_)
            {
                case Pattern.Spade: sb.Append("♠"); break;
                case Pattern.Clover: sb.Append("♣"); break;
                case Pattern.Diamond: sb.Append("◆"); break;
                case Pattern.Heart: sb.Append("♥"); break;
            }

            switch(Number)
            {
                case 13: sb.Append("K"); break;
                case 12: sb.Append("Q"); break;
                case 11: sb.Append("J"); break;
                case 10: sb.Append("10"); break;
                default:
                    sb.Append("0" + Number); break;
            }

            return sb.ToString();
        }
    }
}
