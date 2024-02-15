using System.IO;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    public static SaveAndLoadManager Instance { get; private set; }

    public class GameData
    {
        public float baseHealth; // ������ ü���� �����ϴ� ����
        public int cookie;
        public Vector3[] towerPosition; //Ÿ�� �Ŵ���
        public bool towerUpgrades;
        public int currentWave;
        public float soundVolume;
    }


    public GameData gameData;

    private string gameDataFileName = "save.json";

    public void SaveGame(Invasion_Controller invasionController)
    {
        GoodsData goodsData = GoodsData.instance; // GoodsData �ν��Ͻ��� ������
        gameData.baseHealth = invasionController.ReturnHealth();
        gameData.cookie = goodsData._cookies; // ��Ű�� ���� ����
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, gameDataFileName), json);
    }


    // ���� ���� �ҷ�����
    public void LoadGame(GoodsData goodsData)
    {
        string path = Path.Combine(Application.persistentDataPath, gameDataFileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(json);
            goodsData._cookies = gameData.cookie; // ��Ű�� ���� �����մϴ�.
        }
        else
        {
            // ����� ���� ���°� ���� ���, �⺻ ���� ���·� ����
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
