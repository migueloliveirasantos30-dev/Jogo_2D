using UnityEngine;

public class Chefe : MonoBehaviour, IDanificavel
{
    [SerializeField] int vidaMaxima = 40;

    [Header("Movimento")]
    [SerializeField] float velocidade = 3f;
    [SerializeField] float limiteX = 6f;
    [SerializeField] float alturaAlvo = 3.5f;   // onde ele para depois de entrar

    [Header("Tiro")]
    [SerializeField] GameObject prefabTiro;
    [SerializeField] Transform[] canhoes;
    [SerializeField] float intervaloTiro = 1f;

    int vida;
    int direcao = 1;
    bool entrando = true;
    float proximoTiro;

    void Start()
    {
        vida = vidaMaxima;
        GerenciadorJogo.Instancia.AtualizarBarraChefe(1f);
    }

    void Update()
    {
        // Entrada: desce até a posição de luta
        if (entrando)
        {
            transform.Translate(Vector3.down * 2f * Time.deltaTime);
            if (transform.position.y <= alturaAlvo) entrando = false;
            return;
        }

        // Fase 2: abaixo de 50% de vida fica mais rápido e atira mais
        bool fase2 = vida <= vidaMaxima / 2;
        float vel = fase2 ? velocidade * 1.5f : velocidade;
        float intervalo = fase2 ? intervaloTiro * 0.5f : intervaloTiro;

        transform.Translate(Vector3.right * direcao * vel * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) >= limiteX)
        {
            direcao = transform.position.x > 0 ? -1 : 1;
        }

        if (Time.time >= proximoTiro)
        {
            proximoTiro = Time.time + intervalo;
            foreach (Transform canhao in canhoes)
                Instantiate(prefabTiro, canhao.position, Quaternion.identity);
        }
    }

    public void LevarDano(int dano)
    {
        if (entrando) return;

        vida -= dano;
        GerenciadorJogo.Instancia.AtualizarBarraChefe(Mathf.Max(vida, 0) / (float)vidaMaxima);

        if (vida <= 0)
        {
            GerenciadorJogo.Instancia.ChefeMorreu();
            Destroy(gameObject);
        }
    }
}
