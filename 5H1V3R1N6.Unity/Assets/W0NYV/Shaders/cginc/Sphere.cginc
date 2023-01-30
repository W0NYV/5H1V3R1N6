float3x3 sphereMat(int dtid, int quadCount, float time)
{
    float rad =  acos(-1.0) * 2.0 * (float)dtid/(float)quadCount + time/8.0;
    float rad2 = frac(sin((float)dtid*10000.0)) * acos(-1.0) * 2.0 + time/4.0;
    float r = 6.0;

    float3 pos = float3(r * sin(rad) * cos(rad2), 
                        r * sin(rad) * sin(rad2), 
                        r * cos(rad));

    float3 v = pos - (float3)0.0;
    v = normalize(v);

    //3次元ベクトルを角度に変換
    float rotx = atan2(v.y, v.z) * 180.0/acos(-1.0);
    float roty = atan2(v.x, v.z) * 180.0/acos(-1.0);
    float rotz = atan2(v.y, v.x) * 180.0/acos(-1.0);

    float3 rot = float3(rotx, roty, rotz);
    float3 scl = (float3)frac(sin((float)dtid*10000.0)) + 0.4;

    return float3x3(pos, rot, scl);
}