using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    private bool isGrounded = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);


        }
    }

    void OncollisionEnter2D(Collision2D collision)




        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))

            isGrounded = false;  // vai reconhecer quando o jogador pular no chao

    }

}