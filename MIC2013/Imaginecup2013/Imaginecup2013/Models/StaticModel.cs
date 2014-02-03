using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BEPUphysics.DataStructures;
using System.Collections.Generic;

namespace Imaginecup2013
{
    public class StaticModel : DrawableGameComponent
    {
        Model model;

        // Base transformation to apply to the model.
        public Matrix Transform;
        Matrix[] boneTransforms;
        List<Effect> effect = new List<Effect>();    

        /// <summary>
        /// Creates a new StaticModel.
        /// </summary>
        /// <param name="model">Graphical representation to use for the entity.</param>
        /// <param name="transform">Base transformation to apply to the model before moving to the entity.</param>
        /// <param name="game">Game to which this component will belong.</param>

        public StaticModel(Model model, Matrix transform, Game game) : base(game)
        {
            this.model = model;
            this.Transform = transform;

            //Go through each mesh and assign pre-made effects
            for (int i = 0; i < model.Meshes.Count; i++)
            {
                this.effect.Add(model.Meshes[i].Effects[0]);
            }

            boneTransforms = new Matrix[model.Bones.Count];                       
        }        

        public override void Draw(GameTime gameTime)
        {           

            model.CopyAbsoluteBoneTransformsTo(boneTransforms);

            int lc = 0;//Loop counter for meshs

            foreach (ModelMesh mesh in model.Meshes)
            {
                //Should we be trying to get a depth map or get a normal map?
                if ((Game as Leoni).isShadowMapping)
                {
                    effect[lc].CurrentTechnique = effect[lc].Techniques["Depth"];
                }
                else
                {
                    effect[lc].CurrentTechnique = effect[lc].Techniques["Main"];
                    effect[lc].Parameters["shadowMap"].SetValue((Game as Leoni).depthMap);
                }

                foreach (EffectPass pass in effect[lc].CurrentTechnique.Passes)
                {                 

                    //Set Effect values
                    effect[lc].Parameters["lightView"].SetValue((Game as Leoni).lightsView);
                    effect[lc].Parameters["lightProjection"].SetValue((Game as Leoni).lightProjection);
                    effect[lc].Parameters["cameraPosition"].SetValue((Game as Leoni).Camera.Position);
                    effect[lc].Parameters["lightPosition"].SetValue((Game as Leoni).lightPos);
                    effect[lc].Parameters["View"].SetValue((Game as Leoni).Camera.ViewMatrix);
                    effect[lc].Parameters["Projection"].SetValue((Game as Leoni).Camera.ProjectionMatrix);
                    effect[lc].Parameters["World"].SetValue(boneTransforms[mesh.ParentBone.Index] * Transform);
                    
                    //Apply effect
                    pass.Apply();

                    //Render Scene
                    for (int q = 0; q < mesh.MeshParts.Count; q++)
                    {                        
                        (Game as Leoni).GraphicsDevice.SetVertexBuffer(mesh.MeshParts[q].VertexBuffer);
                        (Game as Leoni).GraphicsDevice.Indices = mesh.MeshParts[q].IndexBuffer;
                        (Game as Leoni).GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, mesh.MeshParts[q].NumVertices, 0, mesh.MeshParts[q].PrimitiveCount);
                    }
                   
                }
                lc++;              
                

            }           
            
            base.Draw(gameTime);
        }
    }
}
