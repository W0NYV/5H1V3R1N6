float3x3 tileMat(int dtid, int quadCount, float time, float actionValue)
{

    float sclRatioX = 0.385;
    float sclRatioY = 0.43;

    float posX = fmod(dtid, 16.0)*sclRatioX - 7.5*sclRatioX;
    float posY = floor(dtid/16.0)*sclRatioY - 3.5*sclRatioY;
    float posZ = abs(sin(length(float2(posX, posY)) + time)) * actionValue;

    float3 pos = float3(posX, posY, posZ);
    float3 rot = (float3)0.0;
    float3 scl = float3(sclRatioX, sclRatioY, 1.0);

    return float3x3(pos, rot, scl);
}