fixed4 Outline(float2 uv, float width)
{
    float l = step(1.0, width/length(uv.x));
    float l2 = step(1.0, width/length(1 - uv.x));
    float l3 = step(1.0, width/length(uv.y));
    float l4 = step(1.0, width/length(1 - uv.y));

    return fixed4(l+l2+l3+l4, l+l2+l3+l4, l+l2+l3+l4, l+l2+l3+l4);
}