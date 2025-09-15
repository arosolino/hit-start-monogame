//-----------------------------------------------------------------------------
// SpriteEffect.fx
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

Texture2D<float4> Texture : register(t0);
sampler TextureSampler : register(s0);

cbuffer _MG_Globals : register(b0) {
	float3x3 Layer1Colors;
	float3x3 Layer2Colors;
}

struct VSOutput
{
	float4 position		: SV_Position;
	float4 color		: COLOR0;
    float2 texCoord		: TEXCOORD0;
};

float4 SpritePixelShader(VSOutput input) : SV_Target0
{
	float3 color = Layer1Colors[0] + Layer1Colors[1] + Layer1Colors[2] + Layer2Colors[0] + Layer2Colors[1] + Layer2Colors[2];
    return Texture.Sample(TextureSampler, input.texCoord) * input.color + float4(color.r, color.g, color.b, 1);
}

technique { pass {  PixelShader = compile ps_6_0 SpritePixelShader(); } }