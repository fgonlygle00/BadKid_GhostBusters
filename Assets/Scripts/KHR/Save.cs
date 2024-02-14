using UnityEngine;
using System.IO;
using UnityEngine.Playables;

public class GameData
{

    public float baseHealth;
    public int baseLevel;
    public int cookie;
    public Vector3[] towerPosition;//타워 매니저
    public bool towerUpgrades;
    public int currentWave;
    public float soundVolume;
}


public class Save : MonoBehaviour
{
    public GameData gameData;

    private string gameDataFileName = "save.json";

    // 게임 상태 저장
    public void SaveGame()
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, gameDataFileName), json);
    }
}