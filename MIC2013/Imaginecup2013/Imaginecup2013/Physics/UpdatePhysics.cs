using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Imaginecup2013.Physics
{
    public static class UpdatePhysics
    {       

        //Update physics
        public static void update(Leoni leoni, GameTime gameTime)
        {
            //updates game camera
            UpdateCamera.update(leoni, gameTime);

            //Update light data
            leoni.lightPos = new Vector3(5, 5, 5);
            leoni.lightsView = Matrix.CreateLookAt(leoni.lightPos, new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            leoni.lightProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver2, 1f, 0.1f, 100f);
            leoni.lightProjectionMatrix = leoni.lightsView * leoni.lightProjection;

            //Steps the simulation forward one time step.
            leoni.space.Update();            
        }

      
    }
}
