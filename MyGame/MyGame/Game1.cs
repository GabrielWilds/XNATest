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

namespace MyGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

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

            base.Initialize();
        }

        Texture2D myTexture;
        Vector2 spritePosition = Vector2.Zero;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myTexture = Content.Load<Texture2D>("Isaac5");
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            UpdateSprite(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        // Store some information about the sprite's motion.
        Vector2 spriteSpeed = new Vector2(50.0f, 50.0f);

        bool upKeyHasBeenReleased = true;
        bool downKeyHasBeenReleased = true;
        bool leftKeyHasBeenReleased = true;
        bool rightKeyHasBeenReleased = true;

        void UpdateSprite(GameTime gameTime)
        {
            long loopStartTime = gameTime.TotalGameTime.Ticks;
            // Move the sprite by speed, scaled by elapsed time.
            //spritePosition +=
            //    spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * 20;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Down) && downKeyHasBeenReleased)
            {
                spritePosition.Y += myTexture.Height;
                downKeyHasBeenReleased = false;
            }
            else if (state.IsKeyDown(Keys.Up) && upKeyHasBeenReleased)
            {
                spritePosition.Y -= myTexture.Height;
                upKeyHasBeenReleased = false;
            }

            if (state.IsKeyDown(Keys.Left) && leftKeyHasBeenReleased)
            {
                spritePosition.X -= myTexture.Width;
                leftKeyHasBeenReleased = false;
            }
            else if (state.IsKeyDown(Keys.Right) && rightKeyHasBeenReleased)
            {
                spritePosition.X += myTexture.Width;
                rightKeyHasBeenReleased = false;          
            }
            

            int MaxX =
                graphics.GraphicsDevice.Viewport.Width - myTexture.Width;
            int MinX = 0;
            int MaxY =
                graphics.GraphicsDevice.Viewport.Height - myTexture.Height;
            int MinY = 0;

            // Check for bounce.
            if (spritePosition.X > MaxX)
            {
                spriteSpeed.X *= -1;
                spritePosition.X = MaxX;
            }

            else if (spritePosition.X < MinX)
            {
                spriteSpeed.X *= -1;
                spritePosition.X = MinX;
            }

            if (spritePosition.Y > MaxY)
            {
                spriteSpeed.Y *= -1;
                spritePosition.Y = MaxY;
            }

            else if (spritePosition.Y < MinY)
            {
                spriteSpeed.Y *= -1;
                spritePosition.Y = MinY;
            }

            if (state.IsKeyUp(Keys.Down))
                downKeyHasBeenReleased = true;
            if (state.IsKeyUp(Keys.Up))
                upKeyHasBeenReleased = true;
            if (state.IsKeyUp(Keys.Left))
                leftKeyHasBeenReleased = true;
            if (state.IsKeyUp(Keys.Right))
                rightKeyHasBeenReleased = true;
            long loopTime = gameTime.TotalGameTime.Ticks - loopStartTime;
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(myTexture, spritePosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
