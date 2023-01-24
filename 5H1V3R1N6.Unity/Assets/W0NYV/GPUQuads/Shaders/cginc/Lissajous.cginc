float3x3 lissajousMat(int dtid, int quadCount, float time)
{

    float radius = 1.8;
    float tau = acos(-1.0) * 2.0;

    float t = 5.0 * (sin(time/40.0)+1.0);
    float t2 = 5.0 * (sin(time/40.0 + tau/2.0)+1.0);

    float posX = sin((tau * (float)dtid / (float)quadCount) + time / 2.0) * radius;
    float posY = cos((tau * (float)dtid / (float)quadCount) + time / 2.0) * radius;
    float posZ = posX * posY;

    float3 pos = float3(posX, posY, posZ);
    float3 rot = (float3)0.0;
    float3 scl = float3(0.3, 0.3, 0.3);

    return float3x3(pos, rot, scl);
}