Shader "PostEffect/PostEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BayerTex ("Bayer Tex", 2D) = "white" {}

        _DThreshold ("DThreshold", Range(0.0, 1.0)) = 0.0

        [Toggle(_BUILD_UP)]_BuildUp("Build up", Float) = 0
        [Toggle(_X_REVERSE)]_XReverse("X Reverse", Float) = 0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma multi_compile _ _BUILD_UP
            #pragma multi_compile _ _X_REVERSE

            #include "UnityCG.cginc"
            #include "./cginc/Utilities.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _BayerTex;
            float _DThreshold;

            //reference - https://www.shadertoy.com/view/4sXSWs
            fixed3 grain(float2 uv, float strength)
            {
                float x = (uv.x + 4.0) * (uv.y + 4.0) * (_Time.y * 10.0);
                return (fixed3)(fmod((fmod(x, 13.0) + 1.0) * (fmod(x, 123.0) + 1.0), 0.01)-0.005)*strength;
            }

            //reference https://light11.hatenadiary.com/entry/2019/01/04/232733
            fixed4 RadicalIroSyusa(float2 uv)
            {

                fixed4 col = (fixed4)0;

                float sampleCount = 3.0;
                float strength = 0.025;

                float3x3 colMat = float3x3(1.0, 1.0, 1.0,  
                                           0.7, 1.0, 0.0, 
                                           0.4, 0.0, 1.0);
                float2 uv2 = uv - 0.5;
                float distance = length(uv2);
                float factor = strength / sampleCount * distance;
                for(int j = 0; j < sampleCount; j++)
                {
                    float uvOffset = 1 - factor * j;
                    col += tex2D(_MainTex, uv2 * uvOffset + 0.5) * fixed4(colMat[j], 1.0);
                }

                return col;
            }

            fixed4 frag (v2f i) : SV_Target
            {

                float2 uv = i.uv;

                #if _X_REVERSE
                    uv.x = abs(uv.x - 0.5);
                #endif

                fixed4 col = tex2D(_MainTex, uv);

                #if _BUILD_UP
                    fixed4 c = lerp(fixed4(0.4, 0.0, 1.0, 1.0), fixed4(0.7, 1.0, 0.0, 1.0), (sin(_Time.y*80.0)+1.0)*0.5);
                    col = lerp(col, (1.0-col)*c, (sin(_Time.y*40.0)+1.0)*0.5);
                #endif

                //ラディカル色収差付ける？
                //col = RadicalIroSyusa(uv);

                float2 tuv = uv * _ScreenParams.xy / 8.0;
                tuv = frac(tuv);
                float4 tdither = tex2D(_BayerTex, tuv);
                float4 lum = float4(0.299, 0.587, 0.114, 0);
                float dither = dot(tdither, lum);
                fixed3 dCol = step(dither, col.rgb) * fixed3(1.0, 0.0, 0.0);

                col.rgb = lerp(col.rgb, dCol, step(0.7, _DThreshold));
                
                col.rgb *= 1.0 - grain(i.uv, 128.0);

                return col;
            }
            ENDCG
        }
    }
}
