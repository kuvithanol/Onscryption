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
    public class Onscription : Game
    {
        public static SpriteFont font;
        public static OnscryptionGame gameplayInstance;
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
        static NetServer server = new NetServer(netPeerConfig);

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
            //    client.Start();
            //}
            //catch(Exception e)
            //{
            //    netPeerConfig.
            //}
            gameplayInstance = new OnscryptionGame();
            for(int i = 0; i < 5; i++)
            {
                gameplayInstance.AddCard(new Card(Card.ECardType.Geck), true, i);
                gameplayInstance.AddCard(new Card(Card.ECardType.Geck), false, i);
            }
        }

        protected override void LoadContent()
        {
            pTextures.Add("card", Content.Load<Texture2D>("Sprites\\card"));
            font = Content.Load<SpriteFont>("Sprites\\font");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            windowDimensions = new Vector2(Onscription.instance.Window.ClientBounds.X, Onscription.instance.Window.ClientBounds.Y);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 28770);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


            // TODO: Add your update logic here

            Window.AllowUserResizing = true;
            Window.IsBorderless = true;
            Debug.WriteLine($"{scaleX}, {scaleY}");

            base.Update(gameTime);
        }
        Random r = new Random();

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);            

            // TODO: Add your drawing code here
            SpriteBatch batch = new SpriteBatch(GraphicsDevice);
            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            foreach(Drawable drawable in gameplayInstance.Drawables)
            {
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
