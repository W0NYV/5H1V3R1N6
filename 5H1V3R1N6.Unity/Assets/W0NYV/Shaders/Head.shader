Shader "Custom/Head"
{
    Properties
    {
        _Cutoff ("Cutoff", Range(0, 1)) = 0.01

        _FFTTex ("FFT", 2D) = "white" {}

        _RimColor ("Rim Color", Color) = (1.0, 1.0, 1.0, 1.0)
        _RimPower ("RimPower", Range(0.5, 8.0)) = 3.0

        _Alpha ("Alpha", Range(0.0, 1.0)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="TransparentCutout" "Queue"="AlphaTest" }
//        Tags { "RenderType"="Opaque" }
        LOD 200

		// Pass
        // {
        //     ZWrite ON
        //     ColorMask 0
		// }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert alphatest:_Cutoff//alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        #include "./cginc/Eye.cginc"

        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
            float4 pos;
        };

        fixed4 _RimColor;
        float _RimPower;
        sampler2D _FFTTex;

        float _Alpha;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)


        void vert(inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            
            o.pos =  UnityObjectToClipPos(v.vertex);

            float t = tex2Dlod(_FFTTex, clamp(frac(v.texcoord.y - _Time.y), 0.0, 1.0));
            t -= 0.7;
            t = clamp(t, 0.0, 1.0);

            v.vertex.x += sin(t * v.vertex.y * 10.0 + _Time.y) * t;
            v.vertex.z += cos(t * v.vertex.y * 10.0 + _Time.y) * t;

            //法線を正しくしてないから、たまたまフラットシェーディングっぽく見えるだけじゃねこれ
            // v.normal = normalize(v.vertex);

        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 f = tex2D(_FFTTex, clamp(frac(IN.uv_MainTex.y - _Time.y), 0.0, 1.0));

            half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
            o.Emission = _RimColor.rgb * pow(rim, _RimPower - f.r*5.0) * _Alpha;
            
            //half2 uv = IN.pos.xy;
            //fixed4 e = eye(uv, _Time.y/2.0, 0.0);
            // fixed4 e = eye(frac(IN.uv_MainTex*10.0), _Time.y/2.0, floor(IN.uv_MainTex*10.0)/10.0);
            // o.Emission = e;
            
            o.Alpha = _Alpha;

        }
        ENDCG
    }
    FallBack "Diffuse"
}
