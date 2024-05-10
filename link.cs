
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace monogame1
{
    public class Link
    {
        public AnimatedSprite LinkLeft;
        public AnimatedSprite LinkRight;
        public AnimatedSprite LinkUp;
        public AnimatedSprite LinkDown;
        public AnimatedSprite LinkAttackD;
        public AnimatedSprite LinkAttackR;
        public AnimatedSprite LinkAttackU;
        public AnimatedSprite LinkAttackL;
        public AnimatedSprite LinkHurt;

        public int AtkCnt;
        public int HurtCnt;
        public Vector2 LinkPos;
        public float LinkSpeed;
        public Direction direction;
        public State state;

        public Link()
        {
            LinkPos = new Vector2(400, 300);
            LinkSpeed = 100f;
            direction = Direction.Down;
            state = State.None;

            AtkCnt = 0;
            HurtCnt = 0;
        }
        private void processState()
        {
            switch (state)
            {
                case State.Attack:
                    {
                        if (AtkCnt >= 16)
                        {
                            state = State.None;
                            AtkCnt = 0;
                        }
                        else
                        {
                            switch (direction)
                            {
                                case Direction.Down:
                                    LinkAttackD.Update();
                                    break;
                                case Direction.Left:
                                    LinkAttackL.Update();
                                    break;
                                case Direction.Right:
                                    LinkAttackR.Update();
                                    break;
                                case Direction.Up:
                                    LinkAttackU.Update();
                                    break;
                                default:
                                    break;
                            }
                            AtkCnt++;
                        }
                        break;
                    }
            }
        }
        public void Update(KeyboardState kstate, GameTime gameTime)
        {
            if (kstate.IsKeyDown(Keys.Up) || kstate.IsKeyDown(Keys.W))
            {
                LinkPos.Y -= LinkSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                direction = Direction.Up;

            }
            if (kstate.IsKeyDown(Keys.Down) || kstate.IsKeyDown(Keys.S))
            {
                LinkPos.Y += LinkSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                direction = Direction.Down;
            }

            if (kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.A))
            {
                LinkPos.X -= LinkSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                direction = Direction.Left;
            }
            if (kstate.IsKeyDown(Keys.Right) || kstate.IsKeyDown(Keys.D))
            {
                LinkPos.X += LinkSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                direction = Direction.Right;
            }

            if (kstate.IsKeyDown(Keys.Z))
            {
                state = State.Attack;
            }
            if (kstate.IsKeyDown(Keys.Q))
            {
                state = State.Hurt;
            }
            if (kstate.IsKeyDown(Keys.R))
            {
                state = State.Speed;
            }

            processState();
            //if (isHurting)
            //{
            //    if (HurtCnt >= 16)
            //    {
            //        isHurting = false;
            //        HurtCnt = 0;
            //    }
            //    else
            //    {
            //        LinkHurt.Update();
            //        HurtCnt++;
            //    }
            //}
            //if (isAttacking)
            //{

            //}
            LinkDown.Update();
            LinkRight.Update();
            LinkUp.Update();
            LinkLeft.Update();
        }


    }
}
