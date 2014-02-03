using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Imaginecup2013.Rendering
{
    public static class SaveScene
    {
        //Save the current Render Target information in a Texture2D format
        public static Texture2D save(Leoni leoni, RenderTarget2D target)
        {
            //Set the render target to none and save the image
            leoni.graphics.GraphicsDevice.SetRenderTarget(null);
            return (Texture2D)target;
        }
    }
}
