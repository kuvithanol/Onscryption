using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;
using System.Net;

namespace InscrypShit
{
    public class Onscription : Game
    {
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
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            server.Start();
            client.Start();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 28770);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                client.Connect(ipep);
                

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
