Shader "Custom/test"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _LightDirection("light Direction",Vector) = (0,0,1,0)
        _LightPosition("light Position",Vector) = (0,0,0,0)
        _LightAngle("light Angle",Range(0,180)) = 45
        _LightStrength("light Strength", float) = 50
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:fade 

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float4 _LightPosition;
        float4 _LightDirection;
        float _LightAngle;
        float _LightStrength;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float distance =  length(float3(_LightPosition.xyz - IN.worldPos.xyz));
            float attentuation =1 / distance;
            float3 direction = normalize(_LightPosition - IN.worldPos);
            _LightStrength = _LightStrength * (attentuation*attentuation);
            float scale = dot(direction,_LightDirection);
            float strength = scale - cos(_LightAngle * (70/360.0));//6.28
            strength = min(max(strength*_LightStrength,0),1);
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb * strength;
            o.Emission =c.rgb * c.a * strength * 10;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = strength * c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
