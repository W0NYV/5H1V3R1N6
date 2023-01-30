Shader "GPUQuads/GPUQuads"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        [HDR]_EmissionColor ("EmissionColor", Color) = (1,1,1,1)
        _EmissionTex ("Emission Texture", 2D) = "white" {}
        _Cutoff ("Cutoff", Range(0, 1)) = 0.5

        _InsideIntensity ("InsideIntensity", Range(0.0, 1.0)) = 1.0

        _OutlineIntensity ("OutlineIntensity", Range(0.0, 1.0)) = 1.0
        _OutlineWidth ("OutlineWidth", Range(0.003, 0.01)) = 0.01

        _TexArray ("Texture Array", 2DArray) = "" {}
        _TexArrayIndex ("Texture Array Index", float) = 0.0

        //SingleTexMode
        _SingleModeTex ("Single Mode Texture", 2D) = "white" {}

        _YmgTexArray ("Ymg Texture Array", 2DArray) = "" {}

        [Toggle(_USE_TEXT_TEX)]_UseTextTex("Use TextTex", Float) = 0
        [Toggle(_USE_EYE_TEX)]_UseEyeTex("Use EyeTex", Float) = 0
        [Toggle(_USE_FFT_TEX)]_UseFFTTex("Use FFTTex", Float) = 0
        [Toggle(_USE_SINGLE_TEX)]_UseSingleTex("Use SingleTex", Float) = 0
        [Toggle(_USE_WAVE_TEX)]_UseWaveTex("Use WaveTex", Float) = 0
        [Toggle(_USE_YMG_TEX)]_UseYmgTex("Use YmgTex", Float) = 0

        [Toggle(_USE_FFT_AMPLITUDE)]_UseFFTAmplitude("Use FFT Amplitude", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="TransparentCutout" "Queue"="AlphaTest" }
        LOD 200
        Cull Off
        
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard vertex:vert alphatest:_Cutoff
        #pragma instancing_options procedural:setup
        #pragma require 2darray
        #pragma target 4.0

        #pragma multi_compile _ _USE_TEXT_TEX
        #pragma multi_compile _ _USE_EYE_TEX
        #pragma multi_compile _ _USE_SINGLE_TEX
        #pragma multi_compile _ _USE_FFT_TEX
        #pragma multi_compile _ _USE_WAVE_TEX
        #pragma multi_compile _ _USE_YMG_TEX

        #pragma multi_compile _ _USE_FFT_AMPLITUDE

        #include "./cginc/Outline.cginc"
        #include "./cginc/Eye.cginc"
        #include "./cginc/EulerAnglesToRotationMatrix.cginc"
        #include "./cginc/Utilities.cginc"

        struct Input
        {
            float2 uv_MainTex;
            float index;
            float index4;
            float index8;
            float index16;
            float index32;
            float amplitude;

            float4 rnd;
        };

        struct QuadData
        {
            float3 position;
            float3 rotation;
            float3 scale;
            float2 drawPos;
        };

        #ifdef UNITY_PROCEDURAL_INSTANCING_ENABLED
        StructuredBuffer<QuadData> _QuadDataBuffer;
        #endif

        sampler2D _MainTex;
        half4 _EmissionColor;
        sampler2D _EmissionTex;

        UNITY_DECLARE_TEX2DARRAY(_TexArray);

        float _InsideIntensity;

        float _OutlineIntensity;
        float _OutlineWidth;

        sampler2D _SingleModeTex;

        UNITY_DECLARE_TEX2DARRAY(_YmgTexArray);

        void vert(inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);

            #ifdef UNITY_PROCEDURAL_INSTANCING_ENABLED

            float3 pos = _QuadDataBuffer[unity_InstanceID].position;
            float3 rot = _QuadDataBuffer[unity_InstanceID].rotation;
            float3 scl = _QuadDataBuffer[unity_InstanceID].scale;
            float index = (float)unity_InstanceID;

            float4x4 rotMatrix = eulerAnglesToRotationMatrix(rot);

            float4x4 object2world = (float4x4)0;

            object2world._11_22_33_44 = float4(scl.xyz, 1.0);

            object2world = mul(rotMatrix, object2world);

            object2world._14_24_34 += pos.xyz;

            v.vertex = mul(object2world, v.vertex);

            v.normal = normalize(mul(object2world, v.vertex));

            o.index = index;
            o.index4 = floor(fmod(index, 4.0));
            o.index8 = floor(index/16.0);
            o.index16 = floor(fmod(index, 16.0));
            o.index32 = floor(fmod(index, 32.0));

            o.rnd = float4(rand((float)index), rand(index+300.0), rand(index+200.0), rand((float)index+128.0));

            o.amplitude = tex2Dlod(_MainTex, float4(index/128.0, 0.0, 0.0, 0.0)).r * 3.0;

            #endif
        }

        void setup(){}

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uv = IN.uv_MainTex;

            fixed4 c = (fixed4)0;
        
            #if _USE_FFT_TEX
                float2 fl = uv;
                fl.y = floor(frac(IN.uv_MainTex.y+_Time.y*0.1) * 8.0);
                fl.x = floor(uv.x * 16.0) + (fl.y*16.0);
                fl = fl/128.0;
                c = (fixed4)tex2D(_MainTex, fl).r;
            #elif _USE_SINGLE_TEX
                float2 uv2 = uv;
                uv2.x = uv2.x/16.0 + (1.0/16.0*IN.index16);
                uv2.y = uv2.y/8.0 + (1.0/8.0*IN.index8);
                uv2.x = frac(uv2.x*1.0+_Time.y/20.0);
                c = tex2D(_SingleModeTex, uv2);
            #elif _USE_EYE_TEX
                c = eye(uv, _Time.y, IN.index4);
            #elif _USE_TEXT_TEX
                c = UNITY_SAMPLE_TEX2DARRAY(_TexArray, float3(uv, floor(fmod(_Time.y*2.0+IN.index4, 4.0))));
                c.rgb *= 0.85;
            #elif _USE_WAVE_TEX
                float4 rnd = IN.rnd;
                float2 p = (uv - 0.5) * 2.0;
                p = mul(rot(acos(-1.0) * 2.0 * floor(rnd.r*4.99)/4.0), p);
                p.x += _Time.y * rnd.g;
                rnd *= 3.0;
                fixed vc = rnd*0.05 / length(frac(p.x*rnd.b));
                vc = step(rand(rnd*3.0)*0.75, vc);
                vc *= clamp(1.0-rnd.a, 0.4, 0.85);
                c = (fixed4)vc;
            #elif _USE_YMG_TEX
                c = UNITY_SAMPLE_TEX2DARRAY(_YmgTexArray, float3(uv, fmod(IN.index32 + IN.rnd.r*128.0 + _Time.y * 8.0, 32.0)));
                c *= 1.5;
            #endif

            fixed4 e = c;

            c *= _InsideIntensity;
            e *= _InsideIntensity;

            fixed4 outline = Outline(uv, _OutlineWidth);

            c += outline*_OutlineIntensity;
            e += outline*_OutlineIntensity;

            #if _USE_FFT_AMPLITUDE
                o.Albedo = c.rgb * (fixed4)IN.amplitude;
                o.Emission = _EmissionColor * e * (fixed4)IN.amplitude;
                o.Alpha = c.a * (fixed4)IN.amplitude;
            #else
                o.Albedo = c.rgb;
                o.Emission = _EmissionColor * e;
                o.Alpha = c.a;
            #endif

        }
        ENDCG
    }
    FallBack "Diffuse"
}
