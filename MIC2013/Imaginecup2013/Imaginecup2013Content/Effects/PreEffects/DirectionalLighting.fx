#include "EffectVar.fxh"

/** Vertex Shader **/
ShadowMapInput ShadowMapVertexShader( float4 inPos : POSITION)
{
    ShadowMapInput Output = (ShadowMapInput)0;

    Output.Position = mul(inPos, lightProjection);
    Output.Position2D = Output.Position;

    return Output;
}

/** Pixel Shader **/
ShadowMapOutput ShadowMapPixelShader(ShadowMapInput PSIn)
{
    ShadowMapOutput Output = (ShadowMapOutput)0;            

    Output.Color = PSIn.Position2D.z/PSIn.Position2D.w;

    return Output;
}

/** Technique Simple **/
technique Main
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 ShadowMapVertexShader();
        PixelShader = compile ps_2_0 ShadowMapPixelShader();
    }
}
