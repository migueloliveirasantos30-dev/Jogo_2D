using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene(1);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}