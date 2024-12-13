using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;

namespace EasyStart
{
    internal class Goomba : Actor
    {
        private float moveSpeed = 2f;
        private const int RIGHT = 1;
        private const int LEFT = -1;
        private int lastDirection = LEFT;
        private float ySpeed = 0;
        private float gravity = -0.5f;
        public override void Act()
        {
            X -= moveSpeed;
            if (IsAtEdge())
            {
                moveSpeed *= -1;
                lastDirection *= -1;
                if (lastDirection == LEFT)
                {
                    IsFlippedHorizontally = true;
                }
                else
                {
                    IsFlippedHorizontally = false;
                }
            }
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
        }
    }
}
