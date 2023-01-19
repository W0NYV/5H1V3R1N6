float3x3 lineMat(int dtid, int quadCount, float time)
{
    float3 pos = float3(0.0, 0.0, dtid - (float)quadCount/2.0 + frac(time/4.0)*4.0);
    float3 rot = (float3)0.0;
    float3 scl = (float3)1.0;

    return float3x3(pos, rot, scl);
}