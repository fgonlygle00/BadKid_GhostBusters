using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;
    public Text gameOverText;
    public Text gameClearText;

    public Transform finalCheckpoint; // 최종 거점의 위치
    public MonsterType currentMonsterAtFinalCheckpoint; // 최종 거점에 있는 몬스터의 타입

    void Update()
    {
        bool monsterAtFinalCheckpoint = CheckMonstersAtFinalCheckpoint();
        bool monstersExistAtFinalCheckpoint = CheckMonstersExistAtFinalCheckpoint();
        bool allMonstersDefeated = currentMonsterAtFinalCheckpoint == MonsterType.None;

        // 게임 오버 체크
        if (monsterAtFinalCheckpoint || monstersExistAtFinalCheckpoint)
        {
            ShowGameOverPanel();
        }

        // 게임 클리어 체크
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
        // 최종 거점에 몬스터가 도달했을 때를 고려해 추가적인 확인이 필요
        // 현재 코드는 예시로 만든것 ( 추후 회의를 통해 이야기 해야함)
        return currentMonsterAtFinalCheckpoint != MonsterType.None;
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "게임 오버 : 당신은 악령으로부터 마을을 지키지 못했습니다.";
    }

    void ShowGameClearPanel()
    {
        gameClearPanel.SetActive(true);
        gameClearText.text = "게임 클리어 : 당신은 악령으로부터 마을을 지켜냈습니다.";
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
    // 필요한 몬스터 타입들을 추가 가능
}
