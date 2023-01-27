float rand2(float2 st)
{
    return frac(sin(dot(st.xy, float2(12.988, 78.233))) * 43758.5453123);
}

float rand3(float3 co)
{
    return frac(sin(dot(co.xyz, float3(12.9898, 78.233, 56.787))) * 43758.5453);
}