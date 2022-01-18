using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;
using System.Net;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using SpriteFontPlus;
using System.Reflection;

namespace InscrypShit
{
    public class Onscription : Game
    {
        public static SpriteFont font;
        private static Dictionary<string, Texture2D> pTextures = new Dictionary<string, Texture2D>();
        public static Dictionary<string, Texture2D> textures
        {
            get
            {
                return pTextures;
            }
        }

        static NetPeerConfiguration netPeerConfig = new NetPeerConfiguration("Onscription")
        {
            Port = 28770,
            SendBufferSize = 4096,
            AcceptIncomingConnections = false,
            PingInterval = 1,
            ConnectionTimeout = 10,
            MaximumConnections = 100
        };

        static NetClient client = new NetClient(netPeerConfig);

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Vector2 windowDimensions;

        public static float scaleX
        {
            get
            {
                return instance.Window.ClientBounds.X / 560;
            }
        }
        public static float scaleY
        {
            get
            {
                return instance.Window.ClientBounds.X / 300;
            }
        }

        public Onscription()
        {
            _graphics = new GraphicsDeviceManager(this);    
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            instance = this;
        }
        public static Game instance;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            //try
            //{
            //    server.Start();
                client.Start();
            //}
            //catch(Exception e)
            //{
            //    netPeerConfig.
            //}
            for(int i = 0; i < 5; i++)
            {
                OnscryptionGame.AddCard(new Card(Card.ECardType.Geck), true, i);
                OnscryptionGame.AddCard(new Card(Card.ECardType.Vessel), false, i);
            }
        }

        protected override void LoadContent()
        {
            pTextures.Add("card", Content.Load<Texture2D>("Sprites\\card"));

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            string fontdata;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("InscrypShit.Content.test.fnt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    fontdata = reader.ReadToEnd();
                }

                font = BMFontLoader.Load(fontdata, name => Assembly.GetExecutingAssembly().GetManifestResourceStream("InscrypShit.Content." + name), GraphicsDevice);
            }

            // As we use font with one texture, always return it independently from requested name  
        }

        protected override void Update(GameTime gameTime)
        {    
            windowDimensions = new Vector2(Onscription.instance.Window.ClientBounds.X, Onscription.instance.Window.ClientBounds.Y);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 28770);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                client.Shutdown("goo bye");
                Exit();
            }


            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                List<Animation.actionFrame> Frames = new List<Animation.actionFrame> { new Animation.actionFrame(100, new Vector2(80, 80)) , new Animation.actionFrame(100, new Vector2(-80, -80)) };
                OnscryptionGame.cardField[1][0].animation = new Animation(Frames);
            }


            // TODO: Add your update logic here

            Window.AllowUserResizing = true;
            Window.IsBorderless = true;

            base.Update(gameTime);
        }
        Random r = new Random();

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);            

            // TODO: Add your drawing code here
            SpriteBatch batch = new SpriteBatch(GraphicsDevice);
            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            foreach(Drawable drawable in OnscryptionGame.drawables)
            {
                if(drawable.animation != null)
                {
                    drawable.position += drawable.animation.Proceed((float)gameTime.ElapsedGameTime.Milliseconds);
                }

                foreach (Drawable.Sprite sprite in drawable.spriteLeaser)
                {
                    if (sprite is Drawable.WordStr str)
                    {
                        batch.DrawString(font, str.text, drawable.position + str.relativepos, str.color);
                    }
                    else
                        batch.Draw(sprite.element, drawable.position + sprite.relativepos, null, sprite.color, sprite.rotation, Vector2.Zero, 4, sprite.spriteEffects, sprite.depth);
                }
            }


            batch.End();
                     
            base.Draw(gameTime);
        }
    }
}
