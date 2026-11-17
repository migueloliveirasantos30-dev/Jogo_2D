
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoJogador : MonoBehaviour
{
    public float velocidadeInicial = 5f;
    public float aceleracao = 8f;
    public float freio = 10f;
    public float velocidadeMaxima = 15f;

    public float limiteSuperior = 1.5f;
    public float limiteInferior = -1.5f;
    public float velocidadeFaixa = 5f;

    private Rigidbody2D rb;
    private float velocidadeAtual;
    private float movimentoVertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadeAtual = velocidadeInicial;
    }

    void Update()
    {
        movimentoVertical = 0f;

        if (Keyboard.current.wKey.isPressed)
            movimentoVertical = 1f;

        if (Keyboard.current.sKey.isPressed)
            movimentoVertical = -1f;

        // A acelera
        if (Keyboard.current.aKey.isPressed)
        {
            velocidadeAtual += aceleracao * Time.deltaTime;
        }

        // D freia
        if (Keyboard.current.dKey.isPressed)
        {
            velocidadeAtual -= freio * Time.deltaTime;
        }

        velocidadeAtual = Mathf.Clamp(
            velocidadeAtual,
            0f,
            velocidadeMaxima
        );
    }

    void FixedUpdate()
    {
        float novaAltura = Mathf.Clamp(
            rb.position.y + movimentoVertical * velocidadeFaixa * Time.fixedDeltaTime,
            limiteInferior,
            limiteSuperior
        );

        rb.MovePosition(new Vector2(
            rb.position.x - velocidadeAtual * Time.fixedDeltaTime,
            novaAltura
        ));
    }
}

