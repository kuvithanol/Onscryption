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
    public abstract class Drawable
    {
        public Drawable()
        {
            spriteLeaser = new List<Sprite>();
            position = new Vector2(0, 0);
        }
        public List<Sprite> spriteLeaser;
        public Vector2 position;

        public class Sprite
        {
            public Sprite(string _element, int _depth)
            {
                if (!(this is WordStr))
                    element = Onscription.textures[_element];
                relativepos = new Vector2(0, 0);
                rotation = 0;
                spriteEffects = SpriteEffects.None;
                depth = _depth;
                color = Color.White;
            }
            public Texture2D element = null;
            public Vector2 relativepos;
            public Color color;

            public float rotation;
            public SpriteEffects spriteEffects;
            public int depth;
        }

        public class WordStr : Sprite
        {
            public WordStr(string _element, int _depth) : base(_element, _depth)
            {
                element = null;
                text = _element;
                color = Color.Black;
            }
            public string text;
        }
    }
}
