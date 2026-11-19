using UnityEngine;
using UnityEngine.SceneManagement;  // Serve para conseguir trocar de cena ou fase

public class MenuManager : MonoBehaviour // Script para controlar os botões do menu 
{
    public void StartGame()  //  Vai ser chamada quando o jogador clicar no botão jogar
    {
        SceneManager.LoadScene("Fase1"); // Carrega a cena do jogo
    }

    public void QuitGame()
    {
        Application.Quit(); // fecha o jogo
    }
}

