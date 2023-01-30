//行列
float2x2 rot(float r)
{
    return float2x2(cos(r), sin(r), -sin(r), cos(r));
}

//乱数
float rand(float r)
{
    return frac(sin(r*10000.0));
}

float rand2(float2 st)
{
    return frac(sin(dot(st.xy, float2(12.988, 78.233))) * 43758.5453123);
}

float rand3(float3 co)
{
    return frac(sin(dot(co.xyz, float3(12.9898, 78.233, 56.787))) * 43758.5453);
}

float2 hash(float n)
{
    return frac(sin(float2(n, n+1.0))*float2(43758.5453123, 22578.1459123));
}

//色
// float4 hsv2rgb(float h, float s, float v)
// {
//     fixed3 hsv = ((clamp(abs(frac(h+float3(0,2,1)/3.)*6.-3.)-1.,0.,1.)-1.)*s+1.)*v;

//     return fixed4(hsv, 1.0);
// }