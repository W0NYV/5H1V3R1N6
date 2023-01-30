float3x3 tunnelMat(int dtid, int tunnelCount, float time)
{
    float3 pos;
    
    if(dtid < tunnelCount)
    {
        pos = float3(0.0, 0.0, dtid*0.02 - 2.699);
        //pos = float3(0.0, 0.0, dtid*0.025 - 3.0);

    }
    else
    {
        //どっかいけ
        pos = (float3)10000.0;
    }
    
    float3 rot = float3(0.0, 0.0, 4 * 360 * dtid / 128.0 + (5.0*time*dtid));
    float3 scl = float3(0.616, 0.3465, 1.0);
    //float3 scl = (float3)1.0;

    return float3x3(pos, rot, scl);
}