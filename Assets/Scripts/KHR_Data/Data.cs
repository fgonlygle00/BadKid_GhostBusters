using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;
    public Text gameOverText;
    public Text gameClearText;

    public Transform finalCheckpoint; // ���� ������ ��ġ
    public MonsterType currentMonsterAtFinalCheckpoint; // ���� ������ �ִ� ������ Ÿ��

    void Update()
    {
        bool monsterAtFinalCheckpoint = CheckMonstersAtFinalCheckpoint();
        bool monstersExistAtFinalCheckpoint = CheckMonstersExistAtFinalCheckpoint();
        bool allMonstersDefeated = currentMonsterAtFinalCheckpoint == MonsterType.None;

        // ���� ���� üũ
        if (monsterAtFinalCheckpoint || monstersExistAtFinalCheckpoint)
        {
            ShowGameOverPanel();
        }

        // ���� Ŭ���� üũ
        if (allMonstersDefeated)
        {
            ShowGameClearPanel();
        }
    }

    bool CheckMonstersAtFinalCheckpoint()
    {
        return currentMonsterAtFinalCheckpoint != MonsterType.None;
    }

    bool CheckMonstersExistAtFinalCheckpoint()
    {
        // ���� ������ ���Ͱ� �������� ���� ����� �߰����� Ȯ���� �ʿ�
        // ���� �ڵ�� ���÷� ����� ( ���� ȸ�Ǹ� ���� �̾߱� �ؾ���)
        return currentMonsterAtFinalCheckpoint != MonsterType.None;
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "���� ���� : ����� �Ƿ����κ��� ������ ��Ű�� ���߽��ϴ�.";
    }

    void ShowGameClearPanel()
    {
        gameClearPanel.SetActive(true);
        gameClearText.text = "���� Ŭ���� : ����� �Ƿ����κ��� ������ ���ѳ½��ϴ�.";
    }

    public void CloseGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }

    public void CloseGameClearPanel()
    { 
        gameClearPanel.SetActive(false); 
    
    }
}

public enum MonsterType
{
    None,
    Monster1,
    Monster2,
    monster3,
    monster4,
    monster5
    // �ʿ��� ���� Ÿ�Ե��� �߰� ����
}
