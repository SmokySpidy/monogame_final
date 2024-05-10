using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

namespace monogame1
{
    public enum Direction { Left, Right, Up, Down };
    public enum State { Attack, Hurt, Speed, None };
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Link link;


        private Texture2D BackGround;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            link = new Link();

            
            base.Initialize();
        }
        protected void LinkLoad()
        {
            Texture2D texture = Content.Load<Texture2D>("LinkDown");
            link.LinkDown = new AnimatedSprite(texture, 4, 4);

            texture = Content.Load<Texture2D>("LinkRight");
            link.LinkRight = new AnimatedSprite(texture, 4, 4);

            texture = Content.Load<Texture2D>("LinkUp");
            link.LinkUp = new AnimatedSprite(texture, 4, 4);

            texture = Content.Load<Texture2D>("LinkLeft");
            link.LinkLeft = new AnimatedSprite(texture, 4, 4);

            texture = Content.Load<Texture2D>("LinkAttackD");
            link.LinkAttackD = new AnimatedSprite(texture, 4, 4);

            texture = Content.Load<Texture2D>("LinkAttackR");
            link.LinkAttackR = new AnimatedSprite(texture, 4, 4);

            texture = Content.Load<Texture2D>("LinkAttackU");
            link.LinkAttackU = new AnimatedSprite(texture, 4, 4);

            texture = Content.Load<Texture2D>("LinkAttackL");
            link.LinkAttackL = new AnimatedSprite(texture, 4, 4);

            texture = Content.Load<Texture2D>("LinkHurt");
            link.LinkHurt = new AnimatedSprite(texture, 4, 4);
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            BackGround = Content.Load<Texture2D>("BackGround");
            LinkLoad();


        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
           
            var kstate = Keyboard.GetState();

            link.Update(kstate ,gameTime);
            base.Update(gameTime);
        }
        protected void LinkDraw(GameTime gameTime)
        {
            switch (link.state)
            {
                case State.Attack:
                    {
                        switch (link.direction)
                        {
                            case Direction.Left:
                                link.LinkAttackL.Draw(_spriteBatch,link.LinkPos); break;
                            case Direction.Right:
                                link.LinkAttackR.Draw(_spriteBatch, link.LinkPos); break;
                            case Direction.Up:
                                link.LinkAttackU.Draw(_spriteBatch, link.LinkPos); break;
                            case Direction.Down:
                                link.LinkAttackD.Draw(_spriteBatch, link.LinkPos); break;
                            default :
                                break;
                        }
                        break;
                    }
                case State.Hurt:
                {
                        link.LinkHurt.Draw(_spriteBatch, link.LinkPos);
                    break;
                }
                case State.Speed:
                case State.None:
                    {
                        switch (link.direction)
                        {
                            case Direction.Left:
                                link.LinkLeft.Draw(_spriteBatch, link.LinkPos);
                                break;
                            case Direction.Right:
                                link.LinkRight.Draw(_spriteBatch, link.LinkPos);
                                break;
                            case Direction.Up:
                                link.LinkUp.Draw(_spriteBatch, link.LinkPos);
                                break;
                            case Direction.Down:
                                link.LinkDown.Draw(_spriteBatch, link.LinkPos);
                                break;
                        }
                        break;

                    }
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(BackGround, GraphicsDevice.Viewport.Bounds, Color.White);
            _spriteBatch.End();


            LinkDraw(gameTime);
            
            base.Draw(gameTime);
        }
    }
}
