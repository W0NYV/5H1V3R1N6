Shader "FFT/FFTEmission"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        [HDR]_EmissionColor ("EmissionColor", Color) = (1,1,1,1)
        _EmissionTex ("Emission Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        Cull off

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        half4 _EmissionColor;
        sampler2D _EmissionTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {

            float2 uv = IN.uv_MainTex;

            float2 fl = uv;

            fl.y = floor(frac(IN.uv_MainTex.y+_Time.y*0.1) * 8.0);
            fl.x = floor(uv.x * 16.0) + (fl.y*16.0);
            // fixed4 col = tex2D(_MainTex, fl/128.0);

            float2 kari = fl/128.0;

            fixed4 c = tex2D(_MainTex, kari);
            c.g = c.r;
            c.b = c.r;
            
            fixed4 e = tex2D(_EmissionTex, kari);
            e.g = e.r;
            e.b = e.r;
            
            o.Albedo = c.rgb;
            o.Emission = _EmissionColor * e;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
