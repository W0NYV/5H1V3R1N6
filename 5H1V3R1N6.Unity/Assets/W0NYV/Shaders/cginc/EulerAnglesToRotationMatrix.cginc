float4x4 eulerAnglesToRotationMatrix(float3 angles)
{
    float3 _angles = angles;
    _angles.x = _angles.x * acos(-1.0)/180.0;
    _angles.y = _angles.y * acos(-1.0)/180.0;
    _angles.z = _angles.z * acos(-1.0)/180.0;

    float ch = cos(_angles.y);
    float sh = sin(_angles.y);

    float ca = cos(_angles.z);
    float sa = sin(_angles.z);

    float cb = cos(_angles.x);
    float sb = sin(_angles.x);

    return float4x4(
        ch*ca+sh*sb*sa,
        -ch*sa+sh*sb*ca,
                    sh*cb,
                        0,

                    cb*sa,
                    cb*ca,
                    -sb,
                        0,

        -sh*ca+ch*sb*sa,
        sh*sa+ch*sb*ca,
                    ch*cb,
                        0,

                        0,
                        0,
                        0,
                        1
    );
}