
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject projetilPrefab;
    public Transform pontoDeDisparo;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(
                projetilPrefab,
                pontoDeDisparo.position,
                pontoDeDisparo.rotation
            );
        }
    }
}
