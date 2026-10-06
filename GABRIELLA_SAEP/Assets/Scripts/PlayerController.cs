using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 8f;

    private Rigidbody2D rb;
    private bool estaNoChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movimento = 0f;

        // Movimento para esquerda
        if (Keyboard.current.aKey.isPressed)
        {
            movimento = -1f;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Movimento para direita
        if (Keyboard.current.dKey.isPressed)
        {
            movimento = 1f;
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Aplicar movimento
        rb.linearVelocity = new Vector2(
            movimento * velocidade,
            rb.linearVelocity.y
        );

        // Pular
        if (Keyboard.current.spaceKey.wasPressedThisFrame && estaNoChao)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                forcaPulo
            );

            estaNoChao = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estaNoChao = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estaNoChao = false;
        }
    }
}