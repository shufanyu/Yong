// Upgrade NOTE: replaced 'UNITY_INSTANCE_ID' with 'UNITY_VERTEX_INPUT_INSTANCE_ID'

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "light_opacity"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_Color("Color", Color) = (1,1,1,1)
		_Albedo("Albedo", 2D) = "white" {}
		_Normal("Normal", 2D) = "bump" {}
		_Emission("Emission", 2D) = "black" {}
		_Oclussion("Oclussion", 2D) = "white" {}
		_HighlightColor("Highlight Color", Color) = (0.7065311,0.9705882,0.9596617,1)
		_MinHighLightLevel("MinHighLightLevel", Range( 0 , 1)) = 0.68
		_opacity("opacity", Range( -1 , 1)) = 0
		_MaxHighLightLevel("MaxHighLightLevel", Range( 0 , 1)) = 0.98
		_HighlightSpeed("Highlight Speed", Range( 0 , 200)) = 0
		[Toggle]_Highlighted("Highlighted", Float) = 1
		_smoothness("smoothness", Range( 0 , 1)) = 0.125
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		#ifdef UNITY_PASS_SHADOWCASTER
			#undef INTERNAL_DATA
			#undef WorldReflectionVector
			#undef WorldNormalVector
			#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
			#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
			#define WorldNormalVector(data,normal) fixed3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
		#endif
		struct Input
		{
			float2 texcoord_0;
			float3 viewDir;
			INTERNAL_DATA
			float3 worldPos;
		};

		uniform sampler2D _Normal;
		uniform float4 _Color;
		uniform sampler2D _Albedo;
		uniform float _Highlighted;
		uniform sampler2D _Emission;
		uniform float _HighlightSpeed;
		uniform float _MinHighLightLevel;
		uniform float _MaxHighLightLevel;
		uniform float4 _HighlightColor;
		uniform float _smoothness;
		uniform sampler2D _Oclussion;
		uniform float _opacity;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			o.texcoord_0.xy = v.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 Normal26 = UnpackNormal( tex2D( _Normal, i.texcoord_0 ) );
			o.Normal = Normal26;
			float4 Albedo59 = ( _Color * tex2D( _Albedo, i.texcoord_0 ) );
			o.Albedo = Albedo59.rgb;
			float4 Emision45 = tex2D( _Emission, i.texcoord_0 );
			float3 normalizeResult27 = normalize( i.viewDir );
			float dotResult32 = dot( Normal26 , normalizeResult27 );
			float mulTime22 = _Time.y * 0.05;
			float Highlight_Level36 = (_MinHighLightLevel + (sin( ( mulTime22 * _HighlightSpeed ) ) - -1.0) * (_MaxHighLightLevel - _MinHighLightLevel) / (1.0 - -1.0));
			float4 Highlight_Color41 = _HighlightColor;
			float4 Highlight_Rim48 = ( pow( ( 1.0 - saturate( dotResult32 ) ) , (10.0 + (Highlight_Level36 - 0.0) * (0.0 - 10.0) / (1.0 - 0.0)) ) * Highlight_Color41 );
			float4 Final_Emision58 = lerp(Emision45,( Emision45 + Highlight_Rim48 ),_Highlighted);
			o.Emission = Final_Emision58.xyz;
			float temp_output_14_0 = _smoothness;
			o.Metallic = temp_output_14_0;
			o.Smoothness = temp_output_14_0;
			float4 Oclussion60 = tex2D( _Oclussion, i.texcoord_0 );
			o.Occlusion = Oclussion60.x;
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			o.Alpha = ( _opacity - ase_vertex3Pos.y );
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard alpha:fade keepalpha fullforwardshadows exclude_path:deferred vertex:vertexDataFunc 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			# include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float3 worldPos : TEXCOORD6;
				float4 tSpace0 : TEXCOORD1;
				float4 tSpace1 : TEXCOORD2;
				float4 tSpace2 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				vertexDataFunc( v, customInputData );
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				fixed3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				fixed tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				fixed3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			fixed4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				float3 worldPos = float3( IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w );
				fixed3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.viewDir = IN.tSpace0.xyz * worldViewDir.x + IN.tSpace1.xyz * worldViewDir.y + IN.tSpace2.xyz * worldViewDir.z;
				surfIN.worldPos = worldPos;
				surfIN.internalSurfaceTtoW0 = IN.tSpace0.xyz;
				surfIN.internalSurfaceTtoW1 = IN.tSpace1.xyz;
				surfIN.internalSurfaceTtoW2 = IN.tSpace2.xyz;
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13101
179;509;1335;506;435.1706;902.778;1;True;False
Node;AmplifyShaderEditor.CommentaryNode;16;-1271.007,2096.142;Float;False;1244.203;1368.811;Comment;11;51;52;49;24;20;44;53;59;60;45;26;Textures;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;15;43.97207,2115.068;Float;False;1262.517;561.4071;Comment;8;33;22;29;30;21;31;23;36;Highlight Level (Ping pong animation);1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;17;40.0701,2853.254;Float;False;1900.698;589.5023;Comment;12;28;27;35;32;34;25;43;48;39;37;40;42;Highlight (Rim);1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;21;73.97208,2369.716;Float;False;Property;_HighlightSpeed;Highlight Speed;9;0;0;0;200;0;1;FLOAT
Node;AmplifyShaderEditor.TextureCoordinatesNode;20;-1221.007,2695.843;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleTimeNode;22;158.276,2221.263;Float;False;1;0;FLOAT;0.05;False;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;24;-810.6049,2561.043;Float;True;Property;_Normal;Normal;2;0;None;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT3;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;25;90.0701,3025.854;Float;True;Tangent;0;4;FLOAT3;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;23;426.5251,2296.717;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0,0,0,0;False;1;FLOAT
Node;AmplifyShaderEditor.GetLocalVarNode;28;323.9691,2978.556;Float;False;26;0;1;FLOAT3
Node;AmplifyShaderEditor.RegisterLocalVarNode;26;-415.5048,2603.343;Float;False;Normal;-1;True;1;0;FLOAT3;0.0;False;1;FLOAT3
Node;AmplifyShaderEditor.RangedFloatNode;30;365.5911,2561.475;Float;False;Property;_MaxHighLightLevel;MaxHighLightLevel;8;0;0.98;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.SinOpNode;31;613.0781,2304.828;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;29;378.6431,2438.314;Float;False;Property;_MinHighLightLevel;MinHighLightLevel;6;0;0.68;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.NormalizeNode;27;350.4712,3096.854;Float;False;1;0;FLOAT3;0,0,0,0;False;1;FLOAT3
Node;AmplifyShaderEditor.TFHCRemap;33;823.5504,2340.526;Float;False;5;0;FLOAT;0.0;False;1;FLOAT;-1.0;False;2;FLOAT;1.0;False;3;FLOAT;0.0;False;4;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.DotProductOpNode;32;618.8691,2956.354;Float;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0.0,0,0,0;False;1;FLOAT
Node;AmplifyShaderEditor.CommentaryNode;18;-1239.423,3540.648;Float;False;642.599;257;Comment;2;38;41;Highlight Color;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;36;1038.489,2342.038;Float;False;Highlight_Level;-1;True;1;0;FLOAT;0,0,0,0;False;1;FLOAT
Node;AmplifyShaderEditor.SaturateNode;34;794.8701,2934.054;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.GetLocalVarNode;35;303.8622,3212.756;Float;False;36;0;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;38;-1189.423,3590.648;Float;False;Property;_HighlightColor;Highlight Color;5;0;0.7065311,0.9705882,0.9596617,1;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.TFHCRemap;37;774.7642,3149.856;Float;False;5;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;1.0;False;3;FLOAT;10.0;False;4;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.OneMinusNode;39;995.0706,2967.054;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.RegisterLocalVarNode;41;-863.8239,3596.949;Float;False;Highlight_Color;-1;True;1;0;COLOR;0.0;False;1;COLOR
Node;AmplifyShaderEditor.PowerNode;42;1267.87,2903.254;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.GetLocalVarNode;40;1246.468,3156.556;Float;False;41;0;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;43;1515.87,3011.054;Float;False;2;2;0;FLOAT;0.0;False;1;COLOR;0.0;False;1;COLOR
Node;AmplifyShaderEditor.CommentaryNode;19;-491.5026,3542.068;Float;False;987.1003;293;Comment;5;58;54;50;47;46;Emission Mix & Highlight Switching;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;44;-798.6058,2771.043;Float;True;Property;_Emission;Emission;3;0;Assets/AmplifyShaderEditor/Plugins/EditorResources/Textures/black.png;True;0;False;black;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RegisterLocalVarNode;48;1702.502,3012;Float;False;Highlight_Rim;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.GetLocalVarNode;47;-446.2517,3579.218;Float;False;45;0;1;FLOAT4
Node;AmplifyShaderEditor.RegisterLocalVarNode;45;-410.2059,2804.743;Float;False;Emision;-1;True;1;0;FLOAT4;0.0;False;1;FLOAT4
Node;AmplifyShaderEditor.GetLocalVarNode;46;-444.3728,3746.601;Float;False;48;0;1;COLOR
Node;AmplifyShaderEditor.SamplerNode;51;-799.3048,2342.343;Float;True;Property;_Albedo;Albedo;1;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleAddOpNode;50;-193.1629,3702.068;Float;False;2;2;0;FLOAT4;0.0;False;1;COLOR;0.0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.ColorNode;49;-788.7048,2146.142;Float;False;Property;_Color;Color;0;0;1,1,1,1;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;53;-428.5048,2308.042;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT4;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.RangedFloatNode;6;57.87355,-682.8139;Float;False;Property;_opacity;opacity;7;0;0;-1;1;0;1;FLOAT
Node;AmplifyShaderEditor.PosVertexDataNode;63;93.89702,-567.9012;Float;False;0;0;5;FLOAT3;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ToggleSwitchNode;54;-4.642913,3602.294;Float;False;Property;_Highlighted;Highlighted;10;1;[Toggle];1;2;0;FLOAT4;0.0;False;1;FLOAT4;0.0;False;1;FLOAT4
Node;AmplifyShaderEditor.SamplerNode;52;-794.1049,2993.545;Float;True;Property;_Oclussion;Oclussion;4;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RegisterLocalVarNode;60;-419.1049,3043.545;Float;False;Oclussion;-1;True;1;0;FLOAT4;0.0;False;1;FLOAT4
Node;AmplifyShaderEditor.GetLocalVarNode;61;808.5679,-649.5542;Float;False;60;0;1;FLOAT4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;5;455.5183,-664.636;Float;True;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.GetLocalVarNode;55;796.9102,-1058.54;Float;False;59;0;1;COLOR
Node;AmplifyShaderEditor.RegisterLocalVarNode;59;-260.8038,2307.942;Float;False;Albedo;-1;True;1;0;COLOR;0.0;False;1;COLOR
Node;AmplifyShaderEditor.GetLocalVarNode;57;740.6825,-788.4727;Float;False;58;0;1;FLOAT4
Node;AmplifyShaderEditor.RegisterLocalVarNode;58;238.5981,3604.067;Float;False;Final_Emision;-1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.GetLocalVarNode;56;744.5121,-978.1418;Float;False;26;0;1;FLOAT3
Node;AmplifyShaderEditor.RangedFloatNode;14;489.7899,-872.6505;Float;False;Property;_smoothness;smoothness;11;0;0.125;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1067.946,-1042.871;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;light_opacity;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;Back;0;0;False;0;0;Transparent;0;True;True;0;False;Transparent;Transparent;ForwardOnly;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;24;1;20;0
WireConnection;23;0;22;0
WireConnection;23;1;21;0
WireConnection;26;0;24;0
WireConnection;31;0;23;0
WireConnection;27;0;25;0
WireConnection;33;0;31;0
WireConnection;33;3;29;0
WireConnection;33;4;30;0
WireConnection;32;0;28;0
WireConnection;32;1;27;0
WireConnection;36;0;33;0
WireConnection;34;0;32;0
WireConnection;37;0;35;0
WireConnection;39;0;34;0
WireConnection;41;0;38;0
WireConnection;42;0;39;0
WireConnection;42;1;37;0
WireConnection;43;0;42;0
WireConnection;43;1;40;0
WireConnection;44;1;20;0
WireConnection;48;0;43;0
WireConnection;45;0;44;0
WireConnection;51;1;20;0
WireConnection;50;0;47;0
WireConnection;50;1;46;0
WireConnection;53;0;49;0
WireConnection;53;1;51;0
WireConnection;54;0;47;0
WireConnection;54;1;50;0
WireConnection;52;1;20;0
WireConnection;60;0;52;0
WireConnection;5;0;6;0
WireConnection;5;1;63;2
WireConnection;59;0;53;0
WireConnection;58;0;54;0
WireConnection;0;0;55;0
WireConnection;0;1;56;0
WireConnection;0;2;57;0
WireConnection;0;3;14;0
WireConnection;0;4;14;0
WireConnection;0;5;61;0
WireConnection;0;9;5;0
ASEEND*/
//CHKSM=08FF2AB33DBEC89CDEFDF6CC26534529481CDC7F