using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Imaginecup2013.Rendering
{
    public static class DrawScene
    {

        public static void draw(Leoni game, Texture2D map)
        {
            //Draw Post processing
            game.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, game.postEffect);
            
            //Draw rendered frame
            game.spriteBatch.Draw(map, new Rectangle(0, 0, game.screenSizeWidth, game.screenSizeHeight), Color.White);
            game.spriteBatch.Draw(game.depthMap, new Rectangle(0, game.screenSizeHeight-200, 200, 200), Color.White);
            
            //Allow for text background to be clear instead of black
            game.GraphicsDevice.BlendState = BlendState.AlphaBlend;
            //Text
            game.spriteBatch.DrawString(game.fogFont, "Sample String", new Vector2(5, 5), Color.White, 0, new Vector2(0), 0.4f, SpriteEffects.None, 0);
            
            game.spriteBatch.End();
        }        
    }
}
