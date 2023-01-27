float3x3 tiledBoxMat(int dtid)
{

    float p = floor(dtid/32.0);
    float p2 = floor(fmod(dtid, 4.0));
    float p3 = floor(fmod(floor(dtid/4.0), 8.0));

    float3 pos = (float3)0.0;
    float3 rot = (float3)0.0;

    if(p == 0.0)
    {
        pos = float3(-p2 + 1.5, p3 - 3.5, 2.0);
        rot = float3(0.0, 180.0, 90*p+90*p2+90*p3);
    }
    else if(p == 1.0)
    {
        pos = float3(2.0, p3 - 3.5, p2 - 1.5);
        rot = float3(0.0, 270.0, 90*p+90*p2+90*p3);
    }
    else if(p == 2.0)
    {
        pos = float3(p2 - 1.5, p3 - 3.5, -2.0);
        rot = float3(0.0, 0.0, 90*p+90*p2+90*p3);
    }
    else if(p == 3.0)
    {
        pos = float3(-2.0, p3 - 3.5, -p2 + 1.5);
        rot = float3(0.0, 90.0, 90*p+90*p2+90*p3);
    }

    float3 scl = (float3)1.0;

    return float3x3(pos, rot, scl);
}