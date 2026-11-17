using UnityEngine;

public class PortalVitoria : MonoBehaviour
{
    public GameObject telaDeVitoria;

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            telaDeVitoria.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}