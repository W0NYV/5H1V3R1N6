Shader "CustomSkybox/Skybox"
{
    SubShader
    {
        Tags
        {
            "RenderType"="Background"
            "Queue"="Background"
            "PreviewType"="SkyBox"
        }

        Pass
        {
            ZWrite Off
            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata
            {
                float4 vertex : POSITION;
                float3 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 texcoord : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            float rand(float2 st)
            {
                return frac(sin(dot(st.xy, float2(12.988, 78.233))) * 43758.5453123);
            }

            fixed4 frag (v2f i) : SV_Target
            {

                float2 uv = i.texcoord;

                uv.y += _Time.y * 0.1;

                uv = frac(uv * 2.0) - 0.5;

                // float s = step(rand(floor(uv*100.0)), 0.00001);
                float s = step(1.0, 0.0045 / length(uv. y)) - 0.9;

                return fixed4(s, s, s, 1.0);
            }
            ENDCG
        }
    }
}