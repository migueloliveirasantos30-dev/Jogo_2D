using UnityEngine;

public class Jogador : MonoBehaviour, IDanificavel
{
    [Header("Movimento")]
    [SerializeField] float velocidade = 8f;
    [SerializeField] float limiteX = 8f;

    [Header("Tiro")]
    [SerializeField] GameObject prefabTiro;
    [SerializeField] Transform pontoTiro;
    [SerializeField] float intervaloTiro = 0.25f;

    [Header("Dano")]
    [SerializeField] float tempoInvulneravel = 1.5f;

    float proximoTiro;
    float fimInvulneravel;
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Input Manager antigo
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + h * velocidade * Time.deltaTime, -limiteX, limiteX);
        transform.position = pos;

        if (Input.GetKey(KeyCode.Space) && Time.time >= proximoTiro)
        {
            proximoTiro = Time.time + intervaloTiro;
            Instantiate(prefabTiro, pontoTiro.position, Quaternion.identity);
        }

        // Pisca enquanto está invulnerável
        if (sr != null)
            sr.enabled = Time.time >= fimInvulneravel || Mathf.FloorToInt(Time.time * 15f) % 2 == 0;
    }

    public void LevarDano(int dano)
    {
        if (Time.time < fimInvulneravel) return;

        fimInvulneravel = Time.time + tempoInvulneravel;
        GerenciadorJogo.Instancia.PerderVida(dano);
    }
}
