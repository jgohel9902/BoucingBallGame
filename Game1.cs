using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace BouncingBallGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //declaring for ball, bat and collissionmanager
        private Ball ball;
        private Bat bat;
        private CollissionManager collissionManager;

        // shows the  different sound effects
        private SoundEffect hitSound;
        private SoundEffect missSound;
        private Song backgroundMusic;

        // textures of ball and bat
        private Texture2D ballTexture;
        private Texture2D batTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        //this manages the teture of ball and bat
           Texture2D ballTexture = Content.Load<Texture2D>("ball");
           Texture2D batTexture = Content.Load<Texture2D>("bat");

            // manages the different sounds of the game
            hitSound = Content.Load<SoundEffect>("ding");
            missSound = Content.Load<SoundEffect>("applause1");
            backgroundMusic = Content.Load<Song>("Chimes");

            ball = new Ball(ballTexture, GraphicsDevice.Viewport.Bounds, hitSound, missSound);
            bat = new Bat(batTexture, GraphicsDevice.Viewport.Bounds);
            collissionManager = new CollissionManager(ball, bat, hitSound);

            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.IsRepeating = true;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ball.Update(gameTime);
            bat.Update(gameTime);
            collissionManager.CheckCollission();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            ball.Draw(_spriteBatch);
            bat.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
