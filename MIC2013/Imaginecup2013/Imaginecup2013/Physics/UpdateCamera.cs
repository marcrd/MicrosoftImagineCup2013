using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Imaginecup2013.Physics
{
    public static class UpdateCamera
    {
        const int cameraSpeed = 10;

        //Jumping variables
        static bool jumping;//Is player currently jumping?
        static int jumpCur;//Current Jumping tick
        static double jumpLength = 5;//20 loops (60 frames per second)
        static float jumpThreshold = 1f;//+- JumpThreshold is how far up/down a hill they can go
        static bool jumpComplete = false;//Is the up portion done?

        public static void update(Leoni leoni, GameTime gameTime)
        {
            //Camera Collision Box
            /*Get Keyboard movement*/
            float tbX = 0;
            float tbY = 0;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                tbX += 1;

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                tbX -= 1;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                tbY += 1;

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                tbY -= 1;

            //Check to see if the user wants to jump
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //Are we in a jump right now?
                if (jumping == false && Math.Abs(leoni.cameraBox.LinearVelocity.Y) < jumpThreshold)
                {
                    //Turn Jumping on
                    jumping = true;
                    jumpCur = 0;
                    jumpComplete = false;
                }
            }
            
            //Get Jump
            float yval = leoni.cameraBox.LinearVelocity.Y;
            if (jumping)
            {    
                if (jumpCur++>=jumpLength)
                {
                    if (leoni.cameraBox.LinearVelocity.Y < -1)
                    {
                        jumpComplete = true;                        
                    }
                    //Wait until we are not moving, or just barely going down hill
                    if (Math.Abs(leoni.cameraBox.LinearVelocity.Y) < jumpThreshold && jumpComplete == true)
                    {
                        jumping = false;//We can jump again!
                    }
                }
                else
                {
                     yval = 5;//Go Up
                }                    
            }

            //Set velocity based on input
            leoni.cameraBox.LinearVelocity = leoni.Camera.WorldMatrix.Left * tbX * cameraSpeed + leoni.Camera.WorldMatrix.Forward * tbY * cameraSpeed;

            //Filter to input to prevent people from going up unless we want them to
            leoni.cameraBox.LinearVelocity = new Vector3(leoni.cameraBox.LinearVelocity.X, yval, leoni.cameraBox.LinearVelocity.Z);
            
            leoni.Camera.Position = new Vector3(leoni.cameraBox.Position.X, leoni.cameraBox.Position.Y + 2, leoni.cameraBox.Position.Z);

            //Update the camera.
            leoni.Camera.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
