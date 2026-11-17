
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Botão JOGAR
    public void Jogar()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Botão CONTROLES
    public void AbrirControles()
    {
        SceneManager.LoadScene("Controles");
    }

    // Botão SAIR
    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saindo do jogo...");
    }
}
