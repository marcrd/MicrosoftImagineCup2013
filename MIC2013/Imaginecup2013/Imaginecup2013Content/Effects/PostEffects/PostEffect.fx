sampler TextureSampler : register(s0);

float4 PlainPixel(float2 TextureCoordinate : TEXCOORD0) : COLOR0
{
   float4 c = tex2D(TextureSampler, TextureCoordinate);    
 
   return c;
}

technique Plain
{
    pass Pass1
    {		
        PixelShader = compile ps_2_0 PlainPixel();
    }
}
