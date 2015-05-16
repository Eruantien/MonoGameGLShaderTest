//sampler2D textureBlockStates	: register(s1);
//sampler2D textureTileSet		: register(s2);
//sampler2D textureLights			: register(s3);
//sampler2D textureLightMask		: register(s4);

sampler TextureSampler;

float4 Operation1(in float2 textureMainCoords : TEXCOORD0) : COLOR0{
	return float4(1, 1, 0, 1);
}

float4 Operation2(in float2 textureMainCoords : TEXCOORD0) : COLOR0{
	if (textureMainCoords.x < 0.5){
		/*return float4(1, 1, 1, 1);*/
return tex2D(TextureSampler, textureMainCoords);
	}

	return tex2D(TextureSampler, textureMainCoords);
}

technique Technique1
{
	pass Pass1
	{
		PixelShader = compile ps_3_0 Operation1();
	}

	pass Pass2
	{
		PixelShader = compile ps_3_0 Operation2();
	}
}