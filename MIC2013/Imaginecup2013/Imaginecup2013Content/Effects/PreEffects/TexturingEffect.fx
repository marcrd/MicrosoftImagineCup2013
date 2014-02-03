#include "EffectVar.fxh"
#include "DepthEffect.fxh"

//Texture given by the custom pipeline processor
Texture DefaultTexture;

sampler DefaultTextureSampler = sampler_state
{
    Texture = (DefaultTexture);

    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
    
    AddressU = Wrap;
    AddressV = Wrap;
};

/** Vertex Shader **/
VertexShaderOutput SimpleVertex( float4 inPos : POSITION0, float3 inNormal: NORMAL0, float2 inTexCoords : TEXCOORD0)
{
    VertexShaderOutput output;

    float4 worldPosition = mul(inPos, World);
    float4 viewPosition = mul(worldPosition, View);

	float4x4 preWorldViewProjection = mul(World, View);
	float4x4 vLightsWorldViewProjection = mul(World, lightView);

    output.Position = mul(viewPosition, Projection);
	output.TexCoords = inTexCoords;
	output.Normal = normalize(mul(inNormal, (float3x3)World));  
	output.Position3D = mul(inPos, World);
	output.Pos2DAsSeenByLight = mul(inPos, vLightsWorldViewProjection);
    return output;
}

/** Pixel Shader **/
float4 SimplePixel(VertexShaderOutput input) : COLOR0
{    
	//Get Texture
	float4 texColor = tex2D(DefaultTextureSampler, input.TexCoords);	
	
	//Get Diffuse Lighting
	float diffuseLightingFactor = DotProduct(lightPosition, input.Position3D, input.Normal);	
	
	//Clip the mins of diffuseLightingFactor
	if(diffuseLightingFactor<0)	
	  diffuseLightingFactor = 0;
	
	return texColor*(diffuseLightingFactor+Ambient);
}

/** Technique Simple **/
technique Main
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 SimpleVertex();
        PixelShader = compile ps_2_0 SimplePixel();
    }
}
