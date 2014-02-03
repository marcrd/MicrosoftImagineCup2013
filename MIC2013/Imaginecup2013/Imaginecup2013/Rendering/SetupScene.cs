using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Imaginecup2013.Rendering
{
    public static class SetupScene
    {
       
        //Setup graphics for drawing
        public static void draw(Leoni leoni, RenderTarget2D target)
        {
            
            //Background color
            leoni.GraphicsDevice.Clear(Color.CornflowerBlue);

            leoni.GraphicsDevice.BlendState = BlendState.Opaque;
            leoni.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            //Set and clear the render target
            leoni.graphics.GraphicsDevice.SetRenderTarget(target);
            leoni.graphics.GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0);
        }            

    }
}
