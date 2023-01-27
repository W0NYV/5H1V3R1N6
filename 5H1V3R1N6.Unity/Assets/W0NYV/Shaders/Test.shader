Shader "Unlit/Test"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TileOffset ("TileOffset", float) = 1
        _Threshold ("Threshold", float) = 0.1
        _MainColor ("MainColor", Vector) = (1, 1, 1, 1)

    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend One One

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _TileOffset;
            float _Threshold;
            float4 _MainColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, frac(i.uv*_TileOffset));
                fixed4 col2 = tex2D(_MainTex, frac((i.uv+0.005)*_TileOffset));
                fixed4 col3 = tex2D(_MainTex, frac((i.uv-0.005)*_TileOffset));

                col.rgb = step(_Threshold, col.rrr);
                col2.rgb = step(_Threshold, col2.rrr) * fixed3(0.3, 0.2, 0.9);
                col3.rgb = step(_Threshold, col3.rrr) * fixed3(0.7, 0.8, 0.2);

                col += col2 + col3;

                col.rgb *= fixed3(_MainColor.r, _MainColor.g, _MainColor.b);

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
