Shader "Custom/shaderAmarelo"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _RimColor ("Rim Color", Color) = (1,1,1,1)
        _RimPower ("Rim Power", Range(0.1, 10)) = 1.5
        _Opacity ("Opacity", Range(0.0, 1.0)) = 1.0
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 200
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };
            
            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
                float3 viewDir : TEXCOORD3;
            };
            
            sampler2D _MainTex;
            fixed4 _RimColor;
            float _RimPower;
            float _Opacity;
            
            //transformar os vértices do modelo do espaço do objeto para o espaço da tela (clip space) e preparar os dados para serem utilizados no fragment shader.
            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.viewDir = UnityWorldSpaceViewDir(o.worldPos);
                return o;
            }
            
            //Esta função é responsável por calcular a cor final de cada fragmento (pixel) no objeto.
            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 c = tex2D (_MainTex, i.uv);
                
                // Calculate rim light intensity
                float rim = 1.0 - saturate(dot(normalize(i.worldNormal), normalize(i.viewDir)));
                rim = pow(rim, _RimPower);
                
                // Add rim light to final color
                fixed4 finalColor = c + _RimColor * rim;
                finalColor.a *= _Opacity;
                
                return finalColor;
            }
            ENDCG
        }
    }
    
    FallBack "Diffuse"
}