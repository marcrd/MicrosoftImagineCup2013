using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEPUphysics;
using Microsoft.Xna.Framework.Graphics;
using Imaginecup2013;
using BEPUphysics.DataStructures;
using BEPUphysics.Collidables;
using BEPUphysics.MathExtensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using BEPUphysics.Entities;
using BEPUphysics.Entities.Prefabs;

namespace Imaginecup2013.Setup
{
    class InitializeEntityModel
    {
        //Constructor
        public InitializeEntityModel(Entity e, Model model, Leoni game)
        {
            add(e, model, game);
        }
        //Blank Constructor
        public InitializeEntityModel() { }

        public void add(Entity e, Model model, Leoni game)
        {
            //Add collisions
            game.space.Add(e);

            //Get the eneity now in space
            Entity _e = game.space.Entities[game.space.Entities.Count - 1];
            Box _box = _e as Box;
            if (_box != null)
            {
                //Setup Entity Model
                Matrix scaling = Matrix.CreateScale(_box.Width, _box.Height, _box.Length);
                EntityModel eModel = new EntityModel(_e, model, scaling, game, game.textureEffect);

                //Add the new model to the world
                game.Components.Add(eModel);

                //Tag the model to the collision box
                _e.Tag = eModel;
            }

        }
    }
}
