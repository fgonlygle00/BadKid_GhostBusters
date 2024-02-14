using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;
    public Text gameOverText;
    public Text gameClearText;

    public Invasion_Controller invasionController; // Invasion_Controller 스크립트를 불러오기 위한 변수
    public int waveCount = 0; // 현재까지 버틴 웨이브 수

    public void Start()
    {
        // Invasion_Controller 스크립트의 인스턴스를 찾아서 할당
        invasionController = FindObjectOfType<Invasion_Controller>();
    }

    public void Update()
    {
        // 게임 오버 체크: 최종 거점의 체력이 0 이하일 경우
        if (invasionController.ReturnHealth() <= 0)
        {
            ShowGameOverPanel();
        }

        // 게임 클리어 체크: 20 웨이브를 버티면 게임 클리어
        if (waveCount >= 20)
        {
            ShowGameClearPanel();
        }
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "게임 오버: 당신은 악령으로부터 마을을 지키지 못했습니다.";
    }

    public void ShowGameClearPanel()
    {
        gameClearPanel.SetActive(true);
        gameClearText.text = "게임 클리어: 당신은 악령으로부터 마을을 지켜냈습니다.";
    }

    public void CloseGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }

    public void CloseGameClearPanel()
    {
        gameClearPanel.SetActive(false);
    }

    public void IncreaseWaveCount()
    {
        waveCount++;
    }
}
