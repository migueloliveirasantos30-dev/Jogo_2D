
using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform jogador;
    public float suavidade = 5f;

    private float alturaInicial;

    void Start()
    {
        alturaInicial = transform.position.y;
    }

    void LateUpdate()
    {
        if (jogador == null)
            return;

        Vector3 posicaoDesejada = new Vector3(
            jogador.position.x,
            alturaInicial,
            -10f
        );

        transform.position = Vector3.Lerp(
            transform.position,
            posicaoDesejada,
            suavidade * Time.deltaTime
        );
    }
}
