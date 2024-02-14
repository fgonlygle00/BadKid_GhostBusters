using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;
    public Text gameOverText;
    public Text gameClearText;

    public Invasion_Controller invasionController; // Invasion_Controller ��ũ��Ʈ�� �ҷ����� ���� ����
    public int waveCount = 0; // ������� ��ƾ ���̺� ��

    public void Start()
    {
        // Invasion_Controller ��ũ��Ʈ�� �ν��Ͻ��� ã�Ƽ� �Ҵ�
        invasionController = FindObjectOfType<Invasion_Controller>();
    }

    public void Update()
    {
        // ���� ���� üũ: ���� ������ ü���� 0 ������ ���
        if (invasionController.ReturnHealth() <= 0)
        {
            ShowGameOverPanel();
        }

        // ���� Ŭ���� üũ: 20 ���̺긦 ��Ƽ�� ���� Ŭ����
        if (waveCount >= 20)
        {
            ShowGameClearPanel();
        }
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "���� ����: ����� �Ƿ����κ��� ������ ��Ű�� ���߽��ϴ�.";
    }

    public void ShowGameClearPanel()
    {
        gameClearPanel.SetActive(true);
        gameClearText.text = "���� Ŭ����: ����� �Ƿ����κ��� ������ ���ѳ½��ϴ�.";
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