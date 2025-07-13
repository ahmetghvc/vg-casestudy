Shader "Case/WindFx"
{
    Properties
    {
        [NoScaleOffset]_MainTex ("Texture", 2D) = "white" {}
        _ScrollTrail("Scroll Trail",Range(0.2,0.49)) = 0.4
        _TrailSpeed("Trail Speed",Range(0,1)) = 0.5
        [HDR] _TrailColor("Trail Color", Color) = (1,1,1,1)

        [HDR] _WindColor("Wind Color", Color) = (1,1,1,1)

        _DebuggerSlide("Debugger Slide",Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float2 uvTrail : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed _ScrollTrail, _TrailSpeed;
            fixed4 _TrailColor, _WindColor;

            //debugger
            fixed _DebuggerSlide;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uvTrail = o.uv;
                return o;
            }

            //Custom Functions

            float2 Warp(float2 uv, float freq, float amp)
            {
                float time = _Time.y * 0.09;
                float waveX = sin((uv.y + time) * freq) * amp;
                float waveY = cos((uv.x + time) * freq) * amp;
                float2 distortion = float2(waveX, waveY);
                float2 p = uv + distortion;
                return p;
            }

            float2 OffsetUv (float2 uv, float2 offset)
            {
                return uv + offset;
            }

            float Seq(fixed t)
            {
                return _Time.y * t;
            }



            



            fixed4 frag (v2f i) : SV_Target
            {
                
                // Map Operations
                fixed windAlpha = tex2D(_MainTex,i.uv).r;
                fixed trailAlpha = tex2D(_MainTex, 
                    OffsetUv( 
                    Warp(i.uv,20,0.01),
                    float2(0 + Seq(_TrailSpeed),_ScrollTrail)
                    )).g;
                fixed meshGradient = tex2D(_MainTex, i.uv).b;

                //Mask Operations
                fixed trailMask= fmod(floor(frac(i.uv.x * 0.5 + Seq(_TrailSpeed*0.5)) * 2.0), 2.0);
                
                // Color Operations
                fixed4 trailCol = _TrailColor * trailAlpha*trailMask;

            
                return trailCol;
            }
            ENDCG
        }
    }
}
