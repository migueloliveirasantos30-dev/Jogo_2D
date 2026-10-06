using UnityEngine;

public class Coletavel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Algo encostou no coletável!");

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER PEGOU O COLETÁVEL!");

            VidaPlayer vida = other.GetComponent<VidaPlayer>();

            if (vida != null)
            {
                vida.RecuperarVida();
                Destroy(gameObject);
            }
        }
    }
}