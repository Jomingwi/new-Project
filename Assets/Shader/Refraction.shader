Shader"Custom/Refraction"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _NoiseValue("NoiseValue",Range(0,1)) = 0.0
        _Speed("Speed",float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent""Queue" = "Transparent" }
        LOD 200

        GrabPass{} // 카메라화면



        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf nolight noambient

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _GrabTexture;

        struct Input
        {
            float2 uv_MainTex;
            float4 screenPos;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        float _NoiseValue;
        float _Speed;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 noise = tex2D (_MainTex, IN.uv_MainTex);
    
            float2 screenUV = IN.screenPos.rgb / IN.screenPos.a;
    
            o.Emission = tex2D(_GrabTexture, float2(
                (screenUV.x) + noise.x * _NoiseValue * sin(_Time.x * _Speed), 
                (screenUV.y) + noise.y * _NoiseValue * sin(_Time.y * _Speed)
                ));

        }
        float4 Lightingnolight(SurfaceOutput s, float3 lightDir, float atter)
        {
            return float4(0, 0, 0, 1);
        }

        ENDCG
    }
    FallBack "Regacy Shaders/Transparent/Vertexlit"
}



// noise값을 움직이면 굴곡이 생긴다