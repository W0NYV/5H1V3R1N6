Shader "Custom/StarField"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard vertex:vert fullforwardshadows
        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        #include "./cginc/EulerAnglesToRotationMatrix.cginc"
        #include "./cginc/Utilities.cginc"

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;

            float rnd;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;


        void vert(inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            
            // float l = length(v.vertex.xz); 

            // float3 pos = float3(sin(_Time.y * 100.0) * l, 
            //                     0.0, 
            //                     cos(_Time.y * 100.0) * l);

            // // float3 rot = float3(0.0, _Time.y * 20.0, 0.0);

            // // float4x4 rotMatrix = eulerAnglesToRotationMatrix(rot);

            // float4x4 object2world = (float4x4)0;

            // object2world._11_22_33_44 = (float4)1.0;

            // //object2world = mul(rotMatrix, object2world);

            // object2world._14_24_34 += pos.xyz;

            // v.vertex = mul(object2world, v.vertex);

            // v.normal = normalize(mul(object2world, v.vertex));
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;

            o.Emission = (fixed4)0.1;

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
