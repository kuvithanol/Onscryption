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
    public static class OnscryptionGame
    {
        public static List<Drawable> drawables = new List<Drawable>();

        public static Card[][] cardField = new Card[2][] { new Card[5], new Card[5]};

        public static void AddCard(Card _card, bool _side, int _row)
        {
            if(cardField[_side ? 0 : 1][ _row] != null)
            {
                throw (new Exception("ImpropperCardPlacement: The game attempted to place a card in an impropper slot"));
            }

            _card.location = new Card.CardLocation(_side, _row);
            drawables.Add(_card);
            cardField[_side ? 0 : 1][ _row] = _card;
            _card.position = new Vector2(((_row + 1.5f) * 100) * Onscription.scaleX, (_side ? 125 : 245) * Onscription.scaleY);
        }

        public static void KillCard(bool _side, int _row)
        {
            if(cardField[_side ? 0 : 1][_row] == null)
            {
                throw (new Exception("ImpropperCardKilling: The game attempted to kill a nonexistent card"));
            }
            drawables.Remove(cardField[_side ? 0 : 1][_row]);
            cardField[_side ? 0 : 1][_row] = null;
        }
    }
}