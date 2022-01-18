using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;
using System.Net;
using System.Diagnostics;
using System.Linq;

namespace InscrypShit
{
    public class Card : Drawable
    {
        public struct CardLocation
        {
            public CardLocation(bool _side, int _row)
            {
                lane = _row;
                side = _side;
            }
            public int lane;
            public bool side;
        }

        public CardLocation? location;

        public string title;

        public Card(Card.ECardType type)
        {
            switch (type)
            {
                case ECardType.Geck:
                    cost = new Cost(Cost.ECostType.None, 0);
                    health = 1;
                    attack = 1;
                    base.spriteLeaser.Add(new Sprite("card", 1));
                    title = "Geck";
                    base.spriteLeaser.Add(new WordStr(title, 1) { relativepos = new Vector2(40 - Onscription.font.MeasureString(title).X / 2, 3)  });
                    return;
                case ECardType.Vessel:
                    cost = new Cost(Cost.ECostType.Energy, 1);
                    health = 2;
                    attack = 0;
                    base.spriteLeaser.Add(new Sprite("card", 1));
                    title = "Vessel";
                    base.spriteLeaser.Add(new WordStr(title, 1) { relativepos = new Vector2(40 - Onscription.font.MeasureString(title).X / 2, 3) });
                    return;
                case ECardType.Skeleton:
                    cost = new Cost(Cost.ECostType.None, 0);
                    health = 1;
                    attack = 1;
                    base.spriteLeaser.Add(new Sprite("card", 1));
                    title = "Skeleton";
                    base.spriteLeaser.Add(new WordStr(title, 1) { relativepos = new Vector2(40 - Onscription.font.MeasureString(title).X / 2, 3) });
                    return;
            }
        }// this holds all the cardery

        class Cost
        {
            public Cost(ECostType _type, int _amount)
            {
                type = _type; amount = _amount;
            }
            ECostType type;
            int amount;

            public enum ECostType
            {
                Blood,
                Energy,
                Bones,
                Mox,
                None
            }
        }

        public enum ECardType
        {
            Geck,
            //Squirrel,
            Vessel,
            Skeleton,
            //SaphireMox,
            //EmeraldMox,
            //RubyMox
        }

        Cost cost;


        int health; int damage = 0;
        int attack;
        
        int hp
        {
            get
            {
                return health - damage;
            }
        }
        
        void takeDamage(int _damage)
        {
            damage += _damage;
        }

    }
}
