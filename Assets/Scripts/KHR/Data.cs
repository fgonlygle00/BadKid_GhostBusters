using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    public Invasion_Controller invasionController; // Invasion_Controller ��ũ��Ʈ�� �ҷ����� ���� ����
    public int waveCount = 0; // ������� ��ƾ ���̺� ��

    public void Awake()
    {
        Time.timeScale = 1.0f;
    }

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
            Time.timeScale = 0;
            ShowGameOverPanel();
        }

        // ���� Ŭ���� üũ: 20 ���̺긦 ��Ƽ�� ���� Ŭ����
        if (Monster_Manager.Instanse.Wave > 20)
        {
            ShowGameClearPanel();
        }
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowGameClearPanel()
    {
        gameClearPanel.SetActive(true);
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
