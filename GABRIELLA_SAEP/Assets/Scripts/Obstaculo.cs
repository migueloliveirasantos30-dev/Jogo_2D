using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public int dano = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            VidaPlayer vida = collision.gameObject.GetComponent<VidaPlayer>();

            if (vida != null)
            {
                vida.TomarDano();
            }
        }
    }
}