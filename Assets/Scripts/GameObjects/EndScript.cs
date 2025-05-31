using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{
    public RawImage videoScreen;             
    public VideoPlayer videoPlayer;          
    private static bool player1OnButton = false;
    private static bool player2OnButton = false;
    private bool videoStarted = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform parent = other.transform.parent;
        string parentName = parent.name;
        if (parentName == "1")
        {
            player1OnButton = true;
            Debug.Log("Player 1");
        }

        if (parentName == "2")
        {
            player2OnButton = true;
            Debug.Log("Player 2");
        }
        Debug.Log("1 : " + player1OnButton + ", 2 : " + player2OnButton);

        CheckLevelComplete();
    }

    private void CheckLevelComplete()
    {
        if (!videoStarted && player1OnButton && player2OnButton && Coin.coinCount == -1)
        {
            videoStarted = true;
            PlayEndingVideo();
        }
    }
    
    private void PlayEndingVideo()
    {
        videoScreen.gameObject.SetActive(true); 

        string path = System.IO.Path.Combine(Application.streamingAssetsPath, "end.mp4");
        videoPlayer.url = path;

        videoPlayer.Play();

        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        videoScreen.gameObject.SetActive(false); 
        Debug.Log("Відео завершено!");
        Application.Quit();
    }
}