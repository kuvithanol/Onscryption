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
        public static Gameplay gameplayInstance;
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
            gameplayInstance = new Gameplay();
            gameplayInstance.AddCard(new Card(Card.ECardType.Geck), false, 2);
        }

        protected override void LoadContent()
        {
            pTextures.Add("card", Content.Load<Texture2D>("Sprites\\card"));
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 28770);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                
            }


            // TODO: Add your update logic here
            Window.AllowUserResizing = true;
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);            

            // TODO: Add your drawing code here
            SpriteBatch batch = new SpriteBatch(GraphicsDevice);
            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            foreach(Drawable drawable in gameplayInstance.Drawables)
            {
                foreach(Drawable.Sprite sprite in drawable.spriteLeaser)
                {
                    batch.Draw(sprite.element, sprite.pos, null, Color.White, sprite.rotation, Vector2.Zero, 100, sprite.spriteEffects, 0 - sprite.depth);
                    Debug.WriteLine("yeah");
                }
            }

            batch.End();
                     
            base.Draw(gameTime);
        }
    }
}
