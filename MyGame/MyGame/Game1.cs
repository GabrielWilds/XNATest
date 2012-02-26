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
        Sprite _sprite;

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

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            _sprite = new Sprite(Content.Load<Texture2D>("Isaac5"));
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

        bool upKeyHasBeenReleased = true;
        bool downKeyHasBeenReleased = true;
        bool leftKeyHasBeenReleased = true;
        bool rightKeyHasBeenReleased = true;

        void UpdateSprite(GameTime gameTime)
        {
            // Move the sprite by speed, scaled by elapsed time.
            //spritePosition +=
            //    spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * 20;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Down) && downKeyHasBeenReleased)
            {
                _sprite.MoveDown(_sprite.Texture.Height);
                downKeyHasBeenReleased = false;
            }
            else if (state.IsKeyDown(Keys.Up) && upKeyHasBeenReleased)
            {
                _sprite.MoveUp(_sprite.Texture.Height);
                upKeyHasBeenReleased = false;
            }

            if (state.IsKeyDown(Keys.Right) && rightKeyHasBeenReleased)
            {
                _sprite.MoveRight(_sprite.Texture.Width);
                rightKeyHasBeenReleased = false;          
            }
            else if (state.IsKeyDown(Keys.Left) && leftKeyHasBeenReleased)
            {
                _sprite.MoveLeft(_sprite.Texture.Width);
                leftKeyHasBeenReleased = false;
            }
            

            int MaxX =
                graphics.GraphicsDevice.Viewport.Width - _sprite.Texture.Width;
            int MinX = 0;
            int MaxY =
                graphics.GraphicsDevice.Viewport.Height - _sprite.Texture.Height;
            int MinY = 0;

            // Check for bounce.
            if (_sprite.Position.X > MaxX)
            {
                _sprite.ReverseXSpeed();
                _sprite.Position = new Vector2( MaxX, _sprite.Position.Y);
            }

            else if (_sprite.Position.X < MinX)
            {
                _sprite.ReverseXSpeed();
                _sprite.Position = new Vector2(MinX, _sprite.Position.Y);
            }

            if (_sprite.Position.Y > MaxY)
            {
                _sprite.ReverseYSpeed();
                _sprite.Position = new Vector2(_sprite.Position.X, MaxY);
            }

            else if (_sprite.Position.Y < MinY)
            {
                _sprite.ReverseYSpeed();
                _sprite.Position = new Vector2(_sprite.Position.X, MinY);
            }

            if (state.IsKeyUp(Keys.Down))
                downKeyHasBeenReleased = true;
            if (state.IsKeyUp(Keys.Up))
                upKeyHasBeenReleased = true;
            if (state.IsKeyUp(Keys.Left))
                leftKeyHasBeenReleased = true;
            if (state.IsKeyUp(Keys.Right))
                rightKeyHasBeenReleased = true;
            
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
            _sprite.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
