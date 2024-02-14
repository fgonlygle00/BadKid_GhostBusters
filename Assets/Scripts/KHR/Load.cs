using UnityEngine;
using System.IO;

public class Load : MonoBehaviour
{
    public GameData gameData;
    private string gameDataFileName = "save.json";

    // 게임 상태 불러오기
    public void LoadGame()
    {
        string path = Path.Combine(Application.persistentDataPath, gameDataFileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            // 저장된 게임 상태가 없는 경우, 기본 게임 상태로 시작
            gameData = new GameData();
        }
    }
}
