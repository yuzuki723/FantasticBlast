Shader "Unlit/MagicSphere_Fire"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _SubTex ("SubTexture",2D) = "white" {}
        _Blend ("Blend",Range(0,1)) = 0.5
        _RotateSpeed ("RotateSpeed",Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            #define PI 3.141592

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _SubTex;
            float _Blend;
            float _RotateSpeed;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // åªç›ÇÃâÒì]äpìxÇéÊÇÈ
                half angle = frac(_Time.x) * PI * 2;

                // âÒì]çsóÒÇçÏÇÈ
                half angleCos = cos(angle * _RotateSpeed);
                half angleSin = sin(angle * _RotateSpeed);
                float2x2 rotateMatrix = float2x2(angleCos,-angleSin,angleSin,-angleCos);

                // íÜêSÇãNì_Ç…âÒì]Ç∑ÇÈ
                i.uv = mul(i.uv - 0.5, rotateMatrix) + 0.5;

                // sample the texture
                fixed4 main = tex2D(_MainTex, i.uv);

                fixed4 sub = tex2D(_SubTex, i.uv);

                fixed4 col = main * (1 - _Blend) + sub * _Blend;


                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);


                return col;
            }
            ENDCG
        }
    }
}
