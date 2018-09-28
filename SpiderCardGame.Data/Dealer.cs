using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCardGame.Data
{
    public enum Difficulty
    {
        None,
        Normal = 1,
        Hard = 2,
        VerryHard = 4,
    }

    public class Dealer
    {
        public const int MAX_TRUMPCARD_SET = 2;
        public const int MAX_CARD_SET = 4;
        public const int MAX_CARD_NUMBER = 13;

        private int _index = 0;
        
        public Difficulty Difficulty_ = Difficulty.None;

        public List<Card> cards = new List<Card>();
        int _pattern = 1;


        //게임에 사용할 카드들을 생성 후 셔플
        public void Shuffle()
        {
            //트럼프카드 두 벌을 가지고 게임을 한다.
            for(int i = 1; i <= MAX_TRUMPCARD_SET; i++)
            { 
                //트럼프카드는 13장의 카드 4세트가 모여서 완성된다.
                for (int j = 1; j <= MAX_CARD_SET; j++)
                {
                    //카드는 1~13의 숫자까지 가능
                    for (int k = 1; k <= MAX_CARD_NUMBER; k++)
                    {
                        Card card = new Card((Card.Pattern)_pattern, k);
                        cards.Add(card);
                    }

                    if (_pattern == (int)Difficulty_)
                    {
                        _pattern = 1;
                    }
                    else _pattern++;
                }
            }

            cards = cards.OrderBy(a => Guid.NewGuid()).ToList();
        }

        //게임 난이도 선택
        public void SetDifficulty(Difficulty Difficulty_)
        {
            this.Difficulty_ = Difficulty_;
        }

        //딜러에게서 카드를 가져옴
        public Card PlayCard()
        {
            return cards[_index++];
        }

        //딜러에게서 카드를 가져올 수 있는지의 여부 확인
        public bool CanPlayCard()
        {
            if (_index < cards.Count) return true;
            return false;
        }
    }
}
