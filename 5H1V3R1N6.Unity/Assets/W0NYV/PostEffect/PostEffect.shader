Shader "PostEffect/PostEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

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
            sampler2D _CameraDepthTexture;

            float rand(float2 st)
            {
                return frac(sin(dot(st.xy, float2(12.988, 78.233))) * 43758.5453123);
            }

            //reference - https://www.shadertoy.com/view/4sXSWs
            fixed3 grain(float2 uv, float strength)
            {
                float x = (uv.x + 4.0) * (uv.y + 4.0) * (_Time.y * 10.0);
                return (fixed3)(fmod((fmod(x, 13.0) + 1.0) * (fmod(x, 123.0) + 1.0), 0.01)-0.005)*strength;
            }

            fixed4 frag (v2f i) : SV_Target
            {

                float2 uv = i.uv;

                #if _X_REVERSE
                    uv.x = abs(uv.x - 0.5);
                #endif

                fixed4 col = tex2D(_MainTex, uv);

                // fixed4 face = tex2D(_FaceTex, i.uv);
                // face = step(0.1, face);
                // face = fixed4(face.r+face.g+face.b/3.0, face.r+face.g+face.b/3.0, face.r+face.g+face.b/3.0, face.r+face.g+face.b/3.0);
                // col += face;

                #if _BUILD_UP
                    fixed4 c = lerp(fixed4(0.4, 0.0, 1.0, 1.0), fixed4(0.7, 1.0, 0.0, 1.0), (sin(_Time.y*80.0)+1.0)*0.5);
                    col = lerp(col, (1.0-col)*c, (sin(_Time.y*40.0)+1.0)*0.5);
                #endif
                
                col.rgb *= 1.0 - grain(uv, 64.0);

                half depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv);;
                depth = Linear01Depth(depth);

                col = fixed4(depth, depth, depth, 1.0);

                return col;
            }
            ENDCG
        }
    }
}
