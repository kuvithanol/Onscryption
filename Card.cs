using System;
using System.Collections.Generic;
using System.Text;
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
    public class Card : Drawable
    {
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
                    title = "splambo!";
                    base.spriteLeaser.Add(new WordStr(title, 1) { relativepos = new Vector2(40 - Onscription.font.MeasureString(title).X / 2, 3)  });
                    return;

            }
        }

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


        

        Cost cost;

        public enum ECardType
        {
            Geck,
            //Squirrel,
            //Vessel,
            //Skeleton,
            //SaphireMox,
            //EmeraldMox,
            //RubyMox
        }

        int health; int attack;
        int damage = 0;
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
