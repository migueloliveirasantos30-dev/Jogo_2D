using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    private bool isGrounded = false;
    public MenuScene menu;
    public GameObject portalVitoria; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y); //esse é pra fazer o player andar na horizontal
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, 8f), ForceMode2D.Impulse); // esse é pra fazer player pular
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; //vai reconhecer quando o jogador pular no chão
        }

        if (collision.gameObject.CompareTag("Dano"))
        {
            menu.MostrarGameOver();
        }

        
        if (collision.gameObject == portalVitoria)
        {
            menu.MostrarVitoria(); //esse verifica se o objeto colidiu 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
