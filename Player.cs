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
        private float jumpSpeed = 10f;
        private float ySpeed = 0;
        private float moveSpeed = 10;

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

            if (Keyboard.GetState().IsKeyDown(Keys.W) && IsTouching(typeof(Ground)))
            {
                ySpeed = jumpSpeed;
                Y -= jumpSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                X -= moveSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                X += moveSpeed;
            }
        }
    }
}
