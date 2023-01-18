float3x3 tileMat(int dtid, int quadCount, float time)
{

    float sclRatioX = 0.385;
    float sclRatioY = 0.43;

    float3 pos = float3(fmod(dtid, 16.0)*sclRatioX - 7.5*sclRatioX, floor(dtid/16.0)*sclRatioY - 3.5*sclRatioY, sin(time+dtid*0.1)*0.25);
    float3 rot = (float3)0.0;
    float3 scl = float3(sclRatioX, sclRatioY, 1.0);

    return float3x3(pos, rot, scl);
}