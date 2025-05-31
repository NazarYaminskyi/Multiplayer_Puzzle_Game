using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    private static bool player1Inside = false;
    private static bool player2Inside = false;
    private bool levelLoaded = false;
    public Camera camera1;
    public Camera camera2;

    private void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform parent = other.transform.parent;
        if (parent != null)
        {
            if (parent.name == "1" && other.gameObject.name != "PlayerVisual")
            {
                player1Inside = true;
                var player = other.GetComponentInParent<Player>();
                player.Coordinates.x += 47;
                player.Coordinates.y--;
                Debug.Log("Player 1 inside");
            }
            else if (parent.name == "2" && other.gameObject.name != "PlayerVisual")
            {
                player2Inside = true;
                var player = other.GetComponentInParent<Player>();
                player.Coordinates.x += 47;
                player.Coordinates.y++;
                Debug.Log("Player 2 inside");
            }
        }

        CheckLoadLevel();
    }

    private void CheckLoadLevel()
    {
        if (player1Inside && player2Inside && !levelLoaded )
        {
            levelLoaded = true;
            Debug.Log("Both players entered! Loading 2Level...");
            GameObject p1 = GameObject.Find("1");
            GameObject p2 = GameObject.Find("2");
            SceneManager.LoadScene("2nd Level");
            p1.transform.position = new Vector2(21, -9);
            p2.transform.position = new Vector2(21, 4);
            
        }
    }
}
