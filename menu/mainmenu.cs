using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Назва_Сцени"); // set name of scene
    }

    public void OpenProgressList()
    {
        Debug.Log("Trying to load: list");
        SceneManager.LoadScene("list");

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("menu"); // set name of scene
    }

    public void GoToLVLMenu()
    {
        SceneManager.LoadScene("menuLVL");
    }

    public void GoToLVL1()
    {
        SceneManager.LoadScene("1st Level - 1st version");
    }

    public void GoToLVL2()
    {
        SceneManager.LoadScene("2nd Level");
    }

    public void ExitGame()
    {
        Application.Quit();

    }
}
