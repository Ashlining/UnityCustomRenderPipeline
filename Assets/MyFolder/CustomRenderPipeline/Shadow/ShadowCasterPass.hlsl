#ifndef CUSTOM_SHADOW_CASTER_PASS_INCLUDED
#define CUSTOM_SHADOW_CASTER_PASS_INCLUDED

#include "Packages/com.unity.render-pipelines.universal/Shaders/PostProcessing/Common.hlsl"

TEXTURE2D(_BaseMap);
SAMPLER(sampler_BaseMap);

Varyings ShadowCasterPassVertex(Attributes input)
{
    Varyings output;
    output.positionCS = TransformObjectToHClip(input.positionOS);
    output.uv= input.uv;
    return output;
}

void ShadowCasterPassFragment(Varyings input)
{
    float4 baseMap = SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,input.uv);
    float4 base = baseMap;
}

#endif