using UnityEngine;

public class CameraFollow : MonoBehaviour // Script para fazer a câmera seguir o personagem
{
    public Transform alvo;  // Quem a câmera vai seguir
    public Vector3 distancia = new Vector3(0f, 0f, -10f); // E a distância entre a câmera e o player
    public bool movimentoSuave = true; // Ativa ou desativa o  efeito de atraso suave da câmera
    public float velocidade = 5f; // Velocidade que a câmera alcança o player

     void LateUpdate()  // LateUpdate seve  para rodar depois que o player já se mexeu  
    {
       

        Vector3 posicaoDesejada = alvo.position + distancia;  // Descobre onde a câmera estar

        if (movimentoSuave)
        {
            transform.position = Vector3.Lerp(transform.position, posicaoDesejada, velocidade * Time.deltaTime); // Vai mexendo a câmera até o alvo
        }
        else
        {
            transform.position = posicaoDesejada; // coloca a câmera direto no alvo, sem delay
        }
    }
}










