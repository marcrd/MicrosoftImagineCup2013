/** Global Variables **/
float4x4 World;
float4x4 View;
float4x4 Projection;

float Ambient = 0.5;
float4x4 lightView;
float4x4 lightProjection;
float3 lightPosition;

float3 cameraPosition = float3(0, 5, 0);



//Point lighting
float3 Color = float3(1, 1, 1);//Color of the light
float lightRadius = 25.0f;
float lightIntensity = 1.0f;


Texture tex;
sampler textureSampler = sampler_state{ texture = <tex> ; magfilter = LINEAR; minfilter = LINEAR; mipfilter=LINEAR; AddressU = mirror; AddressV = mirror;};

Texture shadowMap;
sampler shadowSampler = sampler_state{ texture = <shadowMap> ; magfilter = LINEAR; minfilter = LINEAR; mipfilter=LINEAR; AddressU = clamp; AddressV = clamp;};

/** Functions **/
float DotProduct(float3 lightPos, float3 pos3D, float3 normal)
{
    float3 lightDir = normalize(pos3D - lightPos);
    return dot(-lightDir, normal);
}
float4 GetPositionFromLight(float4 position)
{	
    float4x4 WorldViewProjection = mul( mul(World, lightView), lightProjection);
    return mul(position, WorldViewProjection);  
}

/** Input/Ouput Structures **/
//Basic drawing
struct VertexShaderInput
{
    float4 Position : POSITION0;	
};

struct VertexShaderOutput
{
    float4 Position : POSITION0;
	float2 TexCoords : TEXCOORD0;
	float3 Normal : TEXCOORD1;
	float3 Position3D : TEXCOORD2;
	float4 Pos2DAsSeenByLight : TEXCOORD3;
};

//Shadow Map
struct ShadowMapInput
{
	float4 Position : POSITION0;
	float4 Position2D : TEXCOORD0;
};
struct ShadowMapOutput
{
    float4 Color : COLOR0;
};
