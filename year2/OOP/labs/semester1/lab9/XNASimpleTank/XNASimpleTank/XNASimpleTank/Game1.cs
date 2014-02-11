using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNASimpleTank
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Tank tank1;
        public AITank tank2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tank1 = new Tank(100.0f, 100.0f);
            tank2 = new AITank(100.0f, 100.0f);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tank1.LoadContent(Content.Load<Texture2D>("smalltank"));
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            tank1.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            tank1.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }

    public class Tank : Game1
    {
        public Vector2 tankPos;
        public Vector2 look = new Vector2(0, 0);
        public Texture2D tankSprite;
        public float speed = 30.0f;
        public float rotation = 0.0f;
        public float scale = 1.0f;

        public Tank(float x, float y)
        {
            tankPos = new Vector2(x, y);
            Content.RootDirectory = "Content";
        }

        public Tank()
            : this(0.0f, 0.0f)
        {
        }
        
        public void Update(float timeDelta)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState kState = Keyboard.GetState();
            
            if (kState.IsKeyDown(Keys.Up))
            {
                tankPos += speed * timeDelta * look;
            }
            if (kState.IsKeyDown(Keys.Down))
            {
                tankPos -= speed * timeDelta * look;
            }
            if (kState.IsKeyDown(Keys.Left))
            {
                rotation -= timeDelta;
            }
            if (kState.IsKeyDown(Keys.Right))
            {
                rotation += timeDelta;
            }

            if (kState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            look.X = (float)Math.Sin(rotation);
            look.Y = -(float)Math.Cos(rotation);
        }

        public void LoadContent(Texture2D texture)
        {
            tankSprite = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 cent = new Vector2();
            cent.X = tankSprite.Width / 2;
            cent.Y = tankSprite.Height / 2;

            spriteBatch.Draw(tankSprite, tankPos, null, Color.White, rotation, cent, scale, SpriteEffects.None, 1);
        }
    }

    public class AITank : Tank
    {
        public override void Update(float timeDelta)
        {
            tankPos += speed * timeDelta * look;

            if (tankPos.X < 50 || tankPos.Y < 50)
            {
                rotation += timeDelta;
            }
        }
    }
}
