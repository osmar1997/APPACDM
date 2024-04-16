using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativarBrilho : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do jogador
    public Material material; // Refer�ncia ao material que possui o Graph Shader
    public float activationDistance = 10f; // Dist�ncia em que o shader est� completamente ativado
    public float maxIntensity = 1f; // Intensidade m�xima do shader
    public float minIntensity = 0f; // Intensidade m�nima do shader

    private void Update()
    {
        // Calcula a dist�ncia entre o objeto e o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Calcula a intensidade com base na dist�ncia
        float intensity = Mathf.InverseLerp(activationDistance, 0f, distanceToPlayer);
        intensity = Mathf.Clamp(intensity, minIntensity, maxIntensity);

        // Atualiza o valor do uniform no material do shader
        material.SetFloat("_ActivationIntensity", intensity);
    }
}
