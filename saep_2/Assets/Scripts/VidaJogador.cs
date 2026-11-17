
using UnityEngine;

public class VidaJogador : MonoBehaviour
{
    public int vidas = 3;

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Obstaculo"))
        {
            vidas--;

            Debug.Log("Vidas restantes: " + vidas);

            if (vidas <= 0)
            {
                Debug.Log("Fim de jogo!");
            }
        }
    }
}
