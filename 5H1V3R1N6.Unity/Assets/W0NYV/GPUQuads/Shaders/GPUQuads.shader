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

        _TexArray ("Texture Array", 2DArray) = "" {}
        _TexArrayIndex ("Texture Array Index", float) = 0.0

        [Toggle(_USE_TEXT_TEX)]_UseTextTex("Use TextTex", Float) = 0

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

        #pragma multi_compile _ _USE_TEXT_TEX

        #include "./Eye.cginc"

        struct Input
        {
            float2 uv_MainTex;
            float texIndex;
        };

        struct QuadData
        {
            float3 position;
            float3 rotation;
            float3 scale;
            float texIndex;
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

        void vert(inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);

            #ifdef UNITY_PROCEDURAL_INSTANCING_ENABLED

            float3 pos = _QuadDataBuffer[unity_InstanceID].position;
            float3 rot = _QuadDataBuffer[unity_InstanceID].rotation;
            float3 scl = _QuadDataBuffer[unity_InstanceID].scale;

            float4x4 rotMatrix = eulerAnglesToRotationMatrix(rot);

            float4x4 object2world = (float4x4)0;

            object2world._11_22_33_44 = float4(scl.xyz, 1.0);

            object2world = mul(rotMatrix, object2world);

            object2world._14_24_34 += pos.xyz;

            v.vertex = mul(object2world, v.vertex);

            v.normal = normalize(mul(object2world, v.vertex));

            o.texIndex = _QuadDataBuffer[unity_InstanceID].texIndex;

            #endif
        }

        void setup(){}

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uv = IN.uv_MainTex;

            float2 fl = uv;

            fixed4 c = (fixed4)0;
            fixed4 e = (fixed4)0;

            fl.y = floor(frac(IN.uv_MainTex.y+_Time.y*0.1) * 8.0);
            fl.x = floor(uv.x * 16.0) + (fl.y*16.0);

            float2 kari = fl/128.0;

            kari = frac(kari*10.0);

            c = tex2D(_MainTex, kari);
            c.g = c.r;
            c.b = c.r;
            c.a = c.r;
            
            e = tex2D(_EmissionTex, kari);
            e.g = e.r;
            e.b = e.r;

            c = eye(uv, _Time.y, IN.texIndex);
            e = eye(uv, _Time.y, IN.texIndex);

            #if _USE_TEXT_TEX
            e = UNITY_SAMPLE_TEX2DARRAY(_TexArray, float3(uv, IN.texIndex));
            c = UNITY_SAMPLE_TEX2DARRAY(_TexArray, float3(uv, IN.texIndex));
            #endif

            c *= _InsideIntensity;
            e *= _InsideIntensity;

            //Outline
            float l = step(1.0, 0.01/length(uv.x));
            float l2 = step(1.0, 0.01/length(1 - uv.x));
            float l3 = step(1.0, 0.01/length(uv.y));
            float l4 = step(1.0, 0.01/length(1 - uv.y));

            fixed4 outline = fixed4(l+l2+l3+l4, l+l2+l3+l4, l+l2+l3+l4, l+l2+l3+l4);

            c += outline*_OutlineIntensity;
            e += outline*_OutlineIntensity;

            o.Albedo = c.rgb;
            o.Emission = _EmissionColor * e;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
