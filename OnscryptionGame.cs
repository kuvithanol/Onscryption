using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;
using System.Net;
using System.Diagnostics;
using System;
using System.Collections.Generic;

namespace InscrypShit
{
    public class OnscryptionGame
    {
        public List<Drawable> Drawables = new List<Drawable>();

        public Card?[,] playedCards = new Card?[2, 5];

        public void AddCard(Card _card, bool _side, int _row)
        {
            if(playedCards[_side ? 0 : 1, _row] != null)
            {
                throw (new Exception("ImpropperCardPlacement: The game attempted to place a card in an impropper slot"));
            }
            Drawables.Add(_card);
            playedCards[_side ? 0 : 1, _row] = _card;
            _card.position = new Vector2(((_row + 1.5f) * 100) * Onscription.scaleX, (_side ? 125 : 245) * Onscription.scaleY);
        }
    }
}