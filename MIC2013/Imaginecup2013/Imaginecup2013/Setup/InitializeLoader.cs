using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Imaginecup2013.Setup
{
    public static class InitializeLoader
    {
        public static void load(Leoni game)
        {
            //Effects
            game.simpleEffect = game.Content.Load<Effect>("Effects\\PreEffects\\SimpleEffect");
            game.textureEffect = game.Content.Load<Effect>("Effects\\PreEffects\\TexturingEffect");
            game.shadowEffect = game.Content.Load<Effect>("Effects\\PreEffects\\DirectionalLighting");
            game.postEffect = game.Content.Load<Effect>("Effects\\PostEffects\\PostEffect");

            //Fonts
            game.fogFont = game.Content.Load<SpriteFont>("Font\\foglihten_48");
        }
    }
}
