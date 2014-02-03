using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEPUphysics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework.Graphics;
using BEPUphysics.Entities;
using BEPUphysics.MathExtensions;

namespace Imaginecup2013.Setup
{
    public static class InitializeWorld
    {
        public static void setup(Leoni game)
        {
            //Initilize ground
            InitializeGround.setup(game);
            
            //Initilize camera collision
            game.cameraBox = new Sphere(new Vector3(0, 3, 5), 1, 1);
            game.space.Add(game.cameraBox);

            //Set gravity
            game.space.ForceUpdater.Gravity = new Vector3(0, -9.8f, 0);
        }
    }
}
