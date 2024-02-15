using System.IO;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    public static SaveAndLoadManager Instance { get; private set; }

    public class GameData
    {
        public float baseHealth;
        public int baseLevel;
        public int cookie;
        public Vector3[] towerPosition; //타워 매니저
        public bool towerUpgrades;
        public int currentWave;
        public float soundVolume;
    }

    public GameData gameData;

    private string gameDataFileName = "save.json";

    // 게임 상태 저장
    public void SaveGame()
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, gameDataFileName), json);
    }

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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
