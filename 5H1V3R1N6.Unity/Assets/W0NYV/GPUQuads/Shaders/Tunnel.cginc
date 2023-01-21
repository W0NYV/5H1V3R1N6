float3x3 tunnelMat(int dtid, int tunnelCount)
{
    float3 pos;
    
    if(dtid < tunnelCount)
    {
        pos = float3(0.0, 0.0, dtid*0.1 - 2.699);
    }
    else
    {
        //どっかいけ
        pos = (float3)10000.0;
    }
    
    float3 rot = (float3)0.0;
    float3 scl = float3(0.616, 0.3465, 1.0);

    return float3x3(pos, rot, scl);
}