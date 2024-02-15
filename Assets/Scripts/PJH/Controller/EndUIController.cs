using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUIController : MonoBehaviour
{
    public void StartHome()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameEnding()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
