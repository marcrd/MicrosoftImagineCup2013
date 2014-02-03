/** Vertex Shader **/
VertexShaderOutput DepthVertex( float4 inPos : POSITION0, float3 inNormal: NORMAL0, float2 inTexCoords : TEXCOORD0)
{
    VertexShaderOutput output;

    float4 worldPosition = mul(inPos, World);
    float4 viewPosition = mul(worldPosition, lightView);
	float4x4 preWorldViewProjection = mul(World, lightView);
	float4x4 vLightsWorldViewProjection = mul(World, lightView);

    output.Position = mul(viewPosition, lightProjection);	
	output.TexCoords = inTexCoords;
	output.Normal = normalize(mul(inNormal, (float3x3)World));  
	output.Pos2DAsSeenByLight = mul(inPos, vLightsWorldViewProjection);
	output.Position3D = mul(inPos, World);

    return output;
}

/** Pixel Shader **/
float4 DepthPixel(VertexShaderOutput input) : COLOR0
{  
	float dist = distance(lightPosition, input.Position3D);

	return dist/30;	
}

/** Technique Simple **/
technique Depth
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 DepthVertex();
        PixelShader = compile ps_2_0 DepthPixel();
    }
}
