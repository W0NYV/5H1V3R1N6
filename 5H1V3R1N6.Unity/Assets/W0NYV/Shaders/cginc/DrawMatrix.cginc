float3x3 drawMat(float2 drawPos, int dtid, int quadCount, float time)
{    
    float3 pos = float3(drawPos.x - 2.65, 
                        -drawPos.y - 0.5, 
                        0.25 * abs(sin((float)dtid/(float)quadCount*acos(-1.0)*2.0 + time)));
    float3 rot = (float3)0.0;
    float3 scl = (float3)0.25 * abs(sin((float)dtid/(float)quadCount*acos(-1.0)*2.0 + time));

    return float3x3(pos, rot, scl);
}