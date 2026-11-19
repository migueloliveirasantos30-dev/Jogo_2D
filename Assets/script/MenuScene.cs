using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject painelPause;
    public GameObject painelGameOver;
    public GameObject painelVitoria;
    bool pausado = false;
    bool jogoAcabou = false;

    void Start()  // Executado uma vez quando  a fase começa
    {
        painelPause.SetActive(false); 
        painelGameOver.SetActive(false);
        painelVitoria.SetActive(false);
        Time.timeScale = 1f; // Faz que o tempo do jogo esteja correndo na velocidade normal 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Verifica se o jogador apertou a tecla ESC
        {
            if (pausado) // Se já estiver pausado, retoma o jogo se nao ele pausa o jogo
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar() // Ativa o menu de pausa e congela o jogo
    {
        if (jogoAcabou == false)  // Pausar se o jogo ainda não tiver terminado 
        {
            pausado = true;
            painelPause.SetActive(true);
            Time.timeScale = 0f; // congela as movimentaçoes
        }
    }

    public void Continuar() // Fecha o menu de pausa e faz o jogo voltar a rodar
    {
        pausado = false;
        painelPause.SetActive(false);
        Time.timeScale = 1f; // Volta a velocidade normal do tempo
    }

    public void MostrarGameOver() // Aparece na tela  quando o jogador morre
    {
        jogoAcabou = true; // Trava o jogo para impedir que o menu de pausa abre
        painelGameOver.SetActive(true); // Aparece a tela de derrota
        Time.timeScale = 0f;// Congela o jogo 
    }   

    public void MostrarVitoria() // quando o jogador vence a fase 
    {
        jogoAcabou = true; // Trava ojogo para nao abrir o menu de pausa 
        painelVitoria.SetActive(true); //aparece a tela de vitória
        Time.timeScale = 0f; // congela o jogo 
    }

    public void Reiniciar() // Recarrega a fase que voce esta 
    {
        Time.timeScale = 1f; // Descongela o tempo antes de sair para a próxima cena não começar travada 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Carrega a cena 
    }

    public void VoltarMenu()  // Retorna para a tela inicial do jogo 
    {
        Time.timeScale = 1f; // Descongela o tempo
        SceneManager.LoadScene(0); // Carrega a primeira cena
    }

    public void ProximaFase()  // Vai para a próxima fase 
    {
        Time.timeScale = 1f; // Descongela o tempo 
        int proximaCena = SceneManager.GetActiveScene().buildIndex + 1; // Verifica se essa próxima cena  existe


        if (proximaCena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(proximaCena); // Carrega a próxima fase
        }
        else
        {
            SceneManager.LoadScene(0); // se nao tiver mais fases ele volta pro menu 
        }
    }
}

