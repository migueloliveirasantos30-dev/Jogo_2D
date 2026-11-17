using UnityEngine;

// Fica em um objeto vazio "Formacao" e cria os 25 inimigos (5x5) como filhos dele.
public class FormacaoInimigos : MonoBehaviour
{
    [Header("Grade (5 x 5 = 25 inimigos)")]
    [SerializeField] GameObject prefabInimigo;
    [SerializeField] int linhas = 5;
    [SerializeField] int colunas = 5;
    [SerializeField] float espacamentoX = 1.3f;
    [SerializeField] float espacamentoY = 1f;

    [Header("Movimento")]
    [SerializeField] float velocidade = 2f;
    [SerializeField] float limiteX = 5.5f;
    [SerializeField] float descida = 0.4f;
    [SerializeField] float limiteInferiorY = -2.5f;

    int direcao = 1;

    void Start()
    {
        float larguraTotal = (colunas - 1) * espacamentoX;

        for (int l = 0; l < linhas; l++)
        {
            for (int c = 0; c < colunas; c++)
            {
                Vector3 offset = new Vector3(-larguraTotal / 2f + c * espacamentoX, -l * espacamentoY, 0f);
                Instantiate(prefabInimigo, transform.position + offset, Quaternion.identity, transform);
            }
        }
    }

    void Update()
    {
        transform.Translate(Vector3.right * direcao * velocidade * Time.deltaTime);

        bool bateuDireita = transform.position.x >= limiteX && direcao > 0;
        bool bateuEsquerda = transform.position.x <= -limiteX && direcao < 0;

        if (bateuDireita || bateuEsquerda)
        {
            direcao *= -1;
            transform.position += Vector3.down * descida;
        }

        // Se a formação chegar muito perto do jogador, perdeu
        if (transform.position.y < limiteInferiorY)
            GerenciadorJogo.Instancia.FimDeJogo(false);
    }
}
