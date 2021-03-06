Shader "FishFlock/FishShader" 
{
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		[HDR] _EmissionColor("Emission Color", Color) = (0,0,0)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_EmissionMap ("Emission Map", 2D) = "black" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_AnimationSpeed("Animation Speed", Range(0 , 10)) = 0.5
		_Scale("Scale", Range(0 , 1)) = 0.8
		_Yaw("Yaw", Float) = 0.2
		_Roll("Roll", Float) = 0.2
	}
	SubShader 
	{
		Tags { "RenderType"="Opaque" "Queue" = "Geometry+0" }
		LOD 200
		Cull Back

		CGPROGRAM
		#pragma multi_compile_instancing
		#pragma surface surf Standard fullforwardshadows vertex:vertexProcess
		#pragma target 3.0

		struct Input 
		{
			float2 uvcoord;
		};

		sampler2D _MainTex;
		sampler2D  _EmissionMap;
		uniform float _AnimationSpeed;
		uniform float _Yaw;
		uniform float _Roll;
		uniform float _Scale;

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _EmissionColor;

		void vertexProcess(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);

			float3 vertexPos = v.vertex.xyz;
			v.vertex.xyz += ((sin(((_Time.w * _AnimationSpeed) + (vertexPos.z * _Yaw) + (vertexPos.y * _Roll))) * _Scale) * float3(1, 0, 0));
		}

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			fixed4 c = tex2D (_MainTex, IN.uvcoord) * _Color;
			fixed4 e = tex2D (_MainTex, IN.uvcoord) * _EmissionColor;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			o.Emission = e;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
		}
		ENDCG
	}

	FallBack "Diffuse"
}
