using System;
using System.Collections.Generic;
using System.Text;

namespace InscrypShit
{
    public class Gameplay
    {
        public List<Drawable> Drawables = new List<Drawable>();

        public Card?[,] playedCards = new Card?[2, 5];

        public void AddCard(Card _card, bool _side, int _row)
        {
            Drawables.Add(_card);
            playedCards[_side ? 0 : 1, _row] = _card;
        }
    }
}
