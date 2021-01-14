Shader "Unlit/SimpleColorShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }
    SubShader
    {
        Pass
        {
            Material {
                Diffuse [_Color]
            }
        }
    }
}
