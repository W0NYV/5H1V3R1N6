Shader "PostEffect/PostEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
                fixed4 col = tex2D(_MainTex, i.uv);

                col.rgb *= 1.0 - grain(i.uv, 128.0);

                return col;
            }
            ENDCG
        }
    }
}
