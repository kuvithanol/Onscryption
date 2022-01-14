using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace InscrypShit
{
    public abstract class Drawable
    {
        public Drawable()
        {
            spriteLeaser = new List<Sprite>();
        }
        public List<Sprite> spriteLeaser;
        public Vector2 position;

        public class Sprite
        {
            public Sprite(string _element, int _depth)
            {
                element = Onscription.textures[_element];
                pos = new Vector2(0, 0);
                rotation = 0;
                spriteEffects = SpriteEffects.None;
                depth = _depth;
            }
            public Texture2D element;
            public Vector2 pos;
            public float rotation;
            public SpriteEffects spriteEffects;
            public int depth;
        }
    }
}
