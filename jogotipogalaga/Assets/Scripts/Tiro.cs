using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Tiro : MonoBehaviour
{
    [SerializeField] float velocidade = 12f;
    [SerializeField] float direcao = 1f;          // 1 = sobe (jogador), -1 = desce (inimigos)
    [SerializeField] int dano = 1;
    [SerializeField] string tagAlvo = "Inimigo";   // "Inimigo" ou "Jogador"
    [SerializeField] float tempoDeVida = 4f;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * direcao * velocidade;
        Destroy(gameObject, tempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (!outro.CompareTag(tagAlvo)) return;

        if (outro.TryGetComponent(out IDanificavel alvo))
        {
            alvo.LevarDano(dano);
            Destroy(gameObject);
        }
    }
}
