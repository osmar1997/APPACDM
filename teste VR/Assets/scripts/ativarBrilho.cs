using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativarBrilho : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public Material material; // Referência ao material que possui o Graph Shader
    public float activationDistance = 10f; // Distância em que o shader está completamente ativado
    public float maxIntensity = 1f; // Intensidade máxima do shader
    public float minIntensity = 0f; // Intensidade mínima do shader

    private void Update()
    {
        // Calcula a distância entre o objeto e o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Calcula a intensidade com base na distância
        float intensity = Mathf.InverseLerp(activationDistance, 0f, distanceToPlayer);
        intensity = Mathf.Clamp(intensity, minIntensity, maxIntensity);

        // Atualiza o valor do uniform no material do shader
        material.SetFloat("_ActivationIntensity", intensity);
    }
}
