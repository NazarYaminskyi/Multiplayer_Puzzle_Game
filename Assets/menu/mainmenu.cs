using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public void PlayGame()
    //{
    //    SceneManager.LoadScene("Назва_Сцени"); // set name of scene
    //}

    public void OpenProgressList()
    {
        Debug.Log("Trying to load: list");
        SceneManager.LoadScene("list");

    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu"); 
    }

    public void GoTo1LVL()
    {
        SceneManager.LoadScene("1st Level - 1st version");
    }
    public void GoTo2LVL()
    {
        SceneManager.LoadScene("2nd Level");
    }
    public void GoToMenuLVL()
    {
        SceneManager.LoadScene("menuLVL");
    }

    public void GoToListProgress()
    {
        SceneManager.LoadScene("list");
    }

    public void ExitGame()
    {
        Application.Quit();

    }
}
