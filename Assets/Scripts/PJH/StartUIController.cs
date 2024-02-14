using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIController : MonoBehaviour
{
    // 게임 시작
    public void GamePlay()
    {
        SceneManager.LoadScene("MakeMapScene");
    }

    // 게임 설명
    public void GameDescription()
    {
        // 후추
    }

    // 게임 종료
    public void GameExit()
    {
        // 후추
    }
}
