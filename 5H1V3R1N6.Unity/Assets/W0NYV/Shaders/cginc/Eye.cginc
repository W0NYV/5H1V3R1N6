//reference
//https://www.shadertoy.com/view/3llGzH#

float S(float x)
{
    float smooth = 16.0 / _ScreenParams.x;
    return smoothstep(-smooth, smooth, x);
}

fixed4 eye(float2 uv, float time, float offset){

    float openDeg = 4.5;

    float PI = acos(-1.0);

    float fsty = frac(uv.y) - 0.5;
    float2 fst = float2(uv.x * PI * 2.0 - 0.5 * PI, fsty);
    
    float eyeOpen = (sin(time*2.0 + (acos(-1.0)*2.0*(offset/4.0))) + 1.0) / 2.0;
    eyeOpen = 1.0 - pow(eyeOpen, 3.0);
    
    float col = (sin(fst.x) + 1.)/2.0;
    float col2 = col* eyeOpen + fst.y*openDeg - 0.1;
    col = col* eyeOpen - fst.y*openDeg - 0.1;
    float cs1 = min(col - 0.1, col2- 0.1);
    float cs2 = S(cs1);
    col = S(min(col, col2));
    //col = step(0.1, col);
    float2 loc = float2(frac(fst.x/PI/2.0 + PI*2.0) - 0.53,fst.y);
    
    float lloc = length(loc);

    float iris = abs((length(loc)*15.0) - 2.0);
    float iris2 = abs((length(loc)*15.0) - 1.0);
    float iris3 = length(loc)*9.0;
 
    iris *= iris2 * iris3;

    float3 irisColor = (float3)1.0;
    float3 baseCol = (float3)0.0;
    
    float3 finCol = lerp(baseCol, irisColor, S(-iris + 0.15));

    finCol = lerp((float3)1.0,finCol, cs2);
    finCol = min(finCol, col);
    
    return fixed4(finCol, finCol.r);
}