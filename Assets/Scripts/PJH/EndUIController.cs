using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayUIController : MonoBehaviour
{
    public void StartHome()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("MakeMapScene");
    }
}
