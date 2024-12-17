using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using EasyMonoGame;
using Microsoft.Xna.Framework.Input;

namespace EasyStart
{
    internal class Player : Actor
    {
        private float gravity = -0.5f;
        private float jumpSpeed = 15f;
        private float ySpeed = 0;
        private float moveSpeed = 10;
        private bool isInWallHorizontal = false;

        public override void Act()
        {
            if (!IsTouching(typeof(Ground)))
            {
                // i fritt fall
                ySpeed += gravity;
                Y = Y - ySpeed;
            }
            else
            {
  
                    // på marken
                    Y += ySpeed; //TODO kompensera mindre, bara så att man kommer upp till markytan men ej över
                    ySpeed = 0;
                
               
            }
            isInWallHorizontal = false;
            List<Actor> walls = GetIntersectingActors(typeof(Ground));
            if (walls.Count > 0) 
            {
                if (walls.Count == 1)
                {
                    // rör från sidan => flytta tillbaka i sidled, eller stopp i sidled
                    // delta x är 100
                    // delta y mellan -100, 100
                    float deltaX = Math.Abs(X - walls[0].X);
                    float deltaY = Math.Abs(Y - walls[0].Y);

                    if (deltaX < 100 && deltaY < 50) 
                    {
                        isInWallHorizontal = true;
                        // flytta tillbaka i x-led
                        if (X - walls[0].X > 0)
                        {
                            X -= moveSpeed;
                        }
                        else
                        {
                            X += moveSpeed;
                        }
                    }
                    
                    
                }
                if (walls.Count == 2)
                {
                    // rör från sidan => flytta tillbaka i sidled, eller stopp i sidled
                    // delta x är 100
                    // delta y mellan -100, 100
                    float deltaX = Math.Abs(X - walls[1].X);
                    float deltaY = Math.Abs(Y - walls[1].Y);

                    if (deltaX < 100 && deltaY < 50)
                    {
                        isInWallHorizontal = true;
                        // flytta tillbaka i x-led
                    }

                    // flytta tillbaka i x-led
                    if (X - walls[0].X < 0)
                    {
                        X -= moveSpeed;
                    }
                    else
                    {
                        X += moveSpeed;
                    }

            }

            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && IsTouching(typeof(Ground)))
            {
                ySpeed = jumpSpeed;
                Y -= jumpSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                // vänster
                //if (IsTouching(typeof(Ground)))
                // om vägg till vänster - stopp - gå lite tillbaka
                if (isInWallHorizontal == false)
                {
                    X -= moveSpeed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (isInWallHorizontal == false)
                {
                    X += moveSpeed;
                }
            }
        }
    }
}
