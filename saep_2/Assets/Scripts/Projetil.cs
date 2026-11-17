
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoVida = 5f;

    void Start()
    {
        Destroy(gameObject, tempoVida);
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }
}
