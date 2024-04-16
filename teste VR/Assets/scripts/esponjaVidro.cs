using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class esponjaVidro : MonoBehaviour
{
    public Material material;
    public float tempoParaLimpar = 10f;
    public float timer = 0f;
    public float fracaoTempo;

    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("esponja"))
        {
            timer += Time.deltaTime;
            fracaoTempo = Mathf.Clamp01(timer / tempoParaLimpar);
            float aux = 1f - fracaoTempo;
            material.SetFloat("_normalStrength", aux);

        }
    }
    void Start()
    {
        material.SetFloat("_normalStrength", 1);
    }

}
