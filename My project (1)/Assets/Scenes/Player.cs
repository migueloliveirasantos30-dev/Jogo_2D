using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    public float velocidade Speed = 5.0f;
    public int pulo = 7;
    Rigidbody2D rb;












    void Start()
    {
        Player player = GetComponent<Player>();
        player.velocidade= velocidade;
       
        rb = GetComponent<Rigidbody2D>();
        player.rb = rb;
        player.pulo = pulo;
        
        











    }

  
    void Update()
    {
        
        
    }
}
