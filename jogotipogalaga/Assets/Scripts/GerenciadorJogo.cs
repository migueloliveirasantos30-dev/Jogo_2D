using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GerenciadorJogo : MonoBehaviour
{
    public static GerenciadorJogo Instancia { get; private set; }

    [Header("Chefão")]
    [SerializeField] GameObject prefabChefe;
    [SerializeField] Vector3 posicaoEntradaChefe = new Vector3(0f, 7f, 0f);

    [Header("Jogador")]
    [SerializeField] int vidasIniciais = 3;

    [Header("UI")]
    [SerializeField] TMP_Text textoPontos;
    [SerializeField] TMP_Text textoVidas;
    [SerializeField] TMP_Text textoAviso;
    [SerializeField] Slider barraChefe;
    [SerializeField] GameObject painelFimDeJogo;
    [SerializeField] TMP_Text textoFimDeJogo;

    int inimigosVivos;
    int pontuacao;
    int vidas;
    bool chefeInvocado;
    bool jogoAcabou;

    void Awake()
    {
        Instancia = this;
        Time.timeScale = 1f;
        vidas = vidasIniciais;
    }

    void Start()
    {
        painelFimDeJogo.SetActive(false);
        barraChefe.gameObject.SetActive(false);
        textoAviso.text = "";
        AtualizarUI();
    }

    // ---------- Inimigos ----------
    public void RegistrarInimigo() => inimigosVivos++;

    public void InimigoMorreu(int pontos)
    {
        pontuacao += pontos;
        inimigosVivos--;
        AtualizarUI();

        if (inimigosVivos <= 0 && !chefeInvocado && !jogoAcabou)
        {
            chefeInvocado = true;
            textoAviso.text = "CUIDADO! CHEFÃO!";
            Invoke(nameof(InvocarChefe), 2f);
        }
    }

    void InvocarChefe()
    {
        textoAviso.text = "";
        barraChefe.gameObject.SetActive(true);
        Instantiate(prefabChefe, posicaoEntradaChefe, Quaternion.identity);
    }

    public void AtualizarBarraChefe(float porcentagem) => barraChefe.value = porcentagem;

    public void ChefeMorreu()
    {
        pontuacao += 5000;
        AtualizarUI();
        FimDeJogo(true);
    }

    // ---------- Jogador ----------
    public void PerderVida(int quantidade)
    {
        vidas -= quantidade;
        AtualizarUI();
        if (vidas <= 0) FimDeJogo(false);
    }

    // ---------- Fim de jogo ----------
    public void FimDeJogo(bool vitoria)
    {
        if (jogoAcabou) return;
        jogoAcabou = true;

        textoFimDeJogo.text = vitoria ? "VOCÊ VENCEU!\nPontos: " + pontuacao
                                      : "GAME OVER\nPontos: " + pontuacao;
        painelFimDeJogo.SetActive(true);
        Time.timeScale = 0f;
    }

    // Ligue estes dois nos botões do painel de fim de jogo (OnClick)
    public void Reiniciar() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void VoltarAoMenu() => SceneManager.LoadScene("MenuInicial");

    void AtualizarUI()
    {
        textoPontos.text = "Pontos: " + pontuacao;
        textoVidas.text = "Vidas: " + Mathf.Max(vidas, 0);
    }
}
