using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEPUphysics;
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BEPUphysics.MathExtensions;

namespace Imaginecup2013.Setup
{
    static class InitializeGround 
    {
        public static void setup(Leoni game)
        {
            //initClasses
            InitializeEntityModel eModels = new InitializeEntityModel();
            InitializeStaticModel sModels = new InitializeStaticModel();

            /** Static Models **/           
            sModels.add("Terrain//floor1", game, new AffineTransform(new Vector3(0)));
            sModels.add("Models//test", game, new AffineTransform(new Vector3(0)));
            
            /** Entity Models **/
            Model CubeModel = game.Content.Load<Model>("Models//Cube");
            Model plantPot1 = game.Content.Load<Model>("Terrain//plantpot1");

            eModels.add(new Box(new Vector3(3, 2, 3), 1, 1, 1, 1), plantPot1, game);
            
            //Cube Demo
            eModels.add(new Box(new Vector3(0, 2, 0), 1, 1, 1, 1), CubeModel, game);
            eModels.add(new Box(new Vector3(0, 4, 0), 1, 1, 1, 1), CubeModel, game);
            eModels.add(new Box(new Vector3(0, 6, 0), 1, 1, 1, 1), CubeModel, game);            
        }
    }
}
