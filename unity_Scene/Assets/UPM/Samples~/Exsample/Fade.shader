

/**  @brief シェーダー。
*/


Shader "Samples/Scene/Exsample"
{
	Properties
	{
		visible("visible",Range(0.0,1.0)) = 1.0
	}
	SubShader
	{
		Tags
		{
			"RenderType" = "Opaque"
		}
		Pass
        {
			Cull Off
			ZWrite Off
			ZTest Always

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

			/** appdata
			*/
            struct appdata
            {
                float4 vertex	: POSITION;
                float2 uv		: TEXCOORD0;
            };

			/** v2f
			*/
            struct v2f
            {
                float2 uv		: TEXCOORD0;
                float4 vertex	: SV_POSITION;
            };

			/** visible
			*/
			float visible;

			/** vert
			*/
            v2f vert(appdata a_appdata)
            {
                v2f t_ret;
				{
					t_ret.vertex = UnityObjectToClipPos(a_appdata.vertex);
					t_ret.uv = a_appdata.uv;
				}
                return t_ret;
            }

			/** frag
			*/
            fixed4 frag(v2f a_v2f) : SV_Target
            {
				float t_aspect = _ScreenParams.x / _ScreenParams.y;
				float t_value = (2.0f + sin(a_v2f.uv.x * 150 * t_aspect - _Time.w * 10) + sin(a_v2f.uv.y * 150 - _Time.w * 10)) * 0.25f;

				if(t_value > visible){
					discard;
				}

				return fixed4(0,0,0,1);
            }
            ENDCG
        }
    }
}

