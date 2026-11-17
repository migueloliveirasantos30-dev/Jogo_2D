
using UnityEngine;

public class RetornarInicio : MonoBehaviour
{
    public Transform jogador;
    public Transform inimigo;

    public float distanciaEntreCarros = 4f;

    private Rigidbody2D rbJogador;
    private Rigidbody2D rbInimigo;

    private Vector2 posicaoInicialJogador;
    private Vector2 posicaoInicialInimigo;

    private bool retornando = false;

    void Start()
    {
        rbJogador = jogador.GetComponent<Rigidbody2D>();
        rbInimigo = inimigo.GetComponent<Rigidbody2D>();

        posicaoInicialJogador = jogador.position;
        posicaoInicialInimigo = inimigo.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (retornando)
            return;

        if (other.CompareTag("Jogador") ||
            other.CompareTag("Inimigo"))
        {
            retornando = true;

            // Retorna o jogador à posição inicial
            rbJogador.position = posicaoInicialJogador;

            // Coloca o inimigo atrás do jogador
            rbInimigo.position = new Vector2(
                posicaoInicialJogador.x + distanciaEntreCarros,
                posicaoInicialInimigo.y
            );

            // Zera as velocidades físicas
            rbJogador.linearVelocity = Vector2.zero;
            rbInimigo.linearVelocity = Vector2.zero;

            retornando = false;
        }
    }
}

