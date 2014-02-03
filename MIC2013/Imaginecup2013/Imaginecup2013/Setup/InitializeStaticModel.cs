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

namespace Imaginecup2013.Setup
{
    class InitializeStaticModel
    {
        //Constructor
        public InitializeStaticModel(String file, Leoni game, AffineTransform pos)
        {
            add(file, game, pos);
        }
        //Blank Constructor
        public InitializeStaticModel(){  }

        public void add(String file, Leoni game, AffineTransform pos)
        {
            //Load Model
            Model model = game.Content.Load<Model>(file);

            //change the model to a mesh to create vertici collision
            Vector3[] vertices;
            int[] indices;
            TriangleMesh.GetVerticesAndIndicesFromModel(model, out vertices, out indices);
            var mesh = new StaticMesh(vertices, indices, pos);          
            
            //Add it to the space!
            game.space.Add(mesh);

            //Make it visible too.
            StaticModel tmpModel = new StaticModel(model, mesh.WorldTransform.Matrix, game); 
            
            game.Components.Add(tmpModel);
        }             
    }
}
