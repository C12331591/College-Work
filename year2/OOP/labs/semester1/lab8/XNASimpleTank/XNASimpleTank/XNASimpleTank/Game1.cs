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
        Texture2D tankSprite;
        Vector2 tankPos;
        Vector2 tank2Pos;

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
            tankPos = new Vector2(100, 100);
            tank2Pos = new Vector2(300, 300);
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
            tankSprite = Content.Load<Texture2D>("smalltank");
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState kState = Keyboard.GetState();
            float speed = 30.0f;
            float timeDelta = (float) gameTime.ElapsedGameTime.TotalSeconds;
            if (kState.IsKeyDown(Keys.Up))
            {
                tankPos.Y -= speed * timeDelta;
            }
            if (kState.IsKeyDown(Keys.Down))
            {
                tankPos.Y += speed * timeDelta;
            }
            if (kState.IsKeyDown(Keys.Left))
            {
                tankPos.X -= speed * timeDelta;
            }
            if (kState.IsKeyDown(Keys.Right))
            {
                tankPos.X += speed * timeDelta;
            }
            if (kState.IsKeyDown(Keys.W))
            {
                tank2Pos.Y -= speed * timeDelta;
            }
            if (kState.IsKeyDown(Keys.S))
            {
                tank2Pos.Y += speed * timeDelta;
            }
            if (kState.IsKeyDown(Keys.A))
            {
                tank2Pos.X -= speed * timeDelta;
            }
            if (kState.IsKeyDown(Keys.D))
            {
                tank2Pos.X += speed * timeDelta;
            }

            if (kState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            

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
            spriteBatch.Draw(tankSprite, tankPos, Color.White);
            spriteBatch.Draw(tankSprite, tank2Pos, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
