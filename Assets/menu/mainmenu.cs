using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("�����_�����"); // set name of scene
    }

    public void OpenProgressList()
    {
        Debug.Log("Trying to load: list");
        SceneManager.LoadScene("list");

    }

    public void ExitGame()
    {
        Application.Quit();

    }
}
