float3x3 oneBox(int gtid)
{
    float3 pos;
    float3 rot;
    float3 scl;

    if(gtid == 0)
    {
        pos = float3(0.5, 0, 0);
        rot = float3(0, 270, 0);
    }
    else if(gtid == 1)
    {
        pos = float3(-0.5,  0, 0);
        rot = float3(0, 90, 0);

    }
    else if(gtid == 2)
    {
        pos = float3(0, 0, 0.5);
        rot = float3(0, 180, 0);
    }
    else if(gtid == 3)
    {
        pos = float3(0, 0, -0.5);
        rot = float3(0, 0, 0);
    }

    scl = (float3)1.0;

    return float3x3(pos, rot, scl);
}
