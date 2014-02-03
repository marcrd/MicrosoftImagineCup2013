using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using BEPUphysics.Entities.Prefabs;

namespace Imaginecup2013.Input
{
    static class UpdateKeyboardInput
    {
        public static void update(Leoni game)
        {
            //Update Keyboard and Mouse states
            game.KeyboardState = Keyboard.GetState();
            game.MouseState = Mouse.GetState();

            //SHOOTING BLOCKS
            /*if (game.MouseState.LeftButton == ButtonState.Pressed)
            {
                //If the user is clicking, start firing some boxes.
                //First, create a new dynamic box at the camera's location.
                Box toAdd = new Box(game.Camera.Position, 1, 1, 1, 1);
                //Set the velocity of the new box to fly in the direction the camera is pointing.
                //Entities have a whole bunch of properties that can be read from and written to.
                //Try looking around in the entity's available properties to get an idea of what is available.
                toAdd.LinearVelocity = game.Camera.WorldMatrix.Forward * 10;
                //Add the new box to the simulation.
                game.space.Add(toAdd);

                //Add a graphical representation of the box to the drawable game components.
                EntityModel model = new EntityModel(toAdd, CubeModel, Matrix.Identity, this);
                game.Components.Add(model);
                toAdd.Tag = model;  //set the object tag of this entity to the model so that it's easy to delete the graphics component later if the entity is removed.
            }*/

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || game.KeyboardState.IsKeyDown(Keys.Escape))
                game.Exit();
        }
    }
}
