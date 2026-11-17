using UnityEngine;

public class Inimigo : MonoBehaviour, IDanificavel
{
    [SerializeField] int vida = 1;
    [SerializeField] int pontos = 100;

    [Header("Tiro")]
    [SerializeField] GameObject prefabTiro;
    [SerializeField] float tempoMinTiro = 3f;
    [SerializeField] float tempoMaxTiro = 8f;

    float proximoTiro;

    void Start()
    {
        GerenciadorJogo.Instancia.RegistrarInimigo();
        proximoTiro = Time.time + Random.Range(tempoMinTiro, tempoMaxTiro);
    }

    void Update()
    {
        if (prefabTiro == null || Time.time < proximoTiro) return;

        proximoTiro = Time.time + Random.Range(tempoMinTiro, tempoMaxTiro);
        Instantiate(prefabTiro, transform.position + Vector3.down * 0.5f, Quaternion.identity);
    }

    public void LevarDano(int dano)
    {
        vida -= dano;
        if (vida > 0) return;

        GerenciadorJogo.Instancia.InimigoMorreu(pontos);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        // Encostou na nave do jogador
        if (outro.CompareTag("Jogador") && outro.TryGetComponent(out IDanificavel jogador))
            jogador.LevarDano(1);
    }
}
