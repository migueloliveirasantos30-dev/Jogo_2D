using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public static int vidasSalvas = 4;

    public int vidasMaximas = 6;
    public int vidas = 4;

    public float tempoImunidade = 3f;

    private bool imune = false;

    void Start()
    {
        vidas = vidasSalvas;
    }

    public void TomarDano()
    {
        if (imune || vidas <= 0)
            return;

        vidas--;

        vidasSalvas = vidas;

        Debug.Log("Vidas: " + vidas);

        if (vidas <= 0)
        {
            vidas = 0;
            Debug.Log("Player morreu!");
            return;
        }

        StartCoroutine(Imunidade());
    }

    public void RecuperarVida()
    {
        if (vidas < vidasMaximas)
        {
            vidas++;
            vidasSalvas = vidas;

            Debug.Log("Vidas: " + vidas);
        }
    }

    public void PerderTodasAsVidas()
    {
        vidas = 0;
        vidasSalvas = 0;

        Debug.Log("Caiu no buraco!");
    }

    private System.Collections.IEnumerator Imunidade()
    {
        imune = true;

        yield return new WaitForSeconds(tempoImunidade);

        imune = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            TomarDano();
        }
    }
}