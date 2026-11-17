
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public float velocidade = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            -velocidade,
            0f
        );
    }
}
