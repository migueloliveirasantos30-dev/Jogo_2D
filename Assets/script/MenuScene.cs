using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject painelPause;
    public GameObject painelGameOver;
    public GameObject painelVitoria;
    bool pausado = false;
    bool jogoAcabou = false;

    void Start()
    {
        painelPause.SetActive(false);
        painelGameOver.SetActive(false);
        painelVitoria.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        if (jogoAcabou == false)
        {
            pausado = true;
            painelPause.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Continuar()
    {
        pausado = false;
        painelPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MostrarGameOver()
    {
        jogoAcabou = true;
        painelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MostrarVitoria()
    {
        jogoAcabou = true;
        painelVitoria.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VoltarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ProximaFase()
    {
        Time.timeScale = 1f;
        int proximaCena = SceneManager.GetActiveScene().buildIndex + 1;

        
        if (proximaCena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(proximaCena);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}

