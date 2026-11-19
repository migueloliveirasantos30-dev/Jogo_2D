using UnityEngine;
using UnityEngine.SceneManagement;
public class Scriptpassardefase : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene("Fase2");
        }


    }  

       
    
       
        
    
}
