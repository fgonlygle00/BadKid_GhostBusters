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
    string path;
    private string gameDataFileName = "save.json";

    public void SaveGame()
    {
        Invasion_Controller invasionController = FindObjectOfType<Invasion_Controller>(); // Invasion_Controller �ν��Ͻ��� �����ɴϴ�.
        GoodsData goodsData = GoodsData.instance; // GoodsData �ν��Ͻ��� �����ɴϴ�.

        if (invasionController == null || goodsData == null) // �ν��Ͻ��� null���� �˻��մϴ�.
        {
            Debug.LogError("Invasion_Controller �ν��Ͻ� �Ǵ� GoodsData �ν��Ͻ��� ã�� �� �����ϴ�.");
            return;
        }

        // ���ӵ����Ͱ� ���ٸ� ���ο� �����͸� �����.
        if (gameData == null)
        {
            gameData = new GameData();
        }
        gameData.baseHealth = invasionController.ReturnHealth();
        gameData.cookie = goodsData._cookies; // ��Ű�� ���� �����մϴ�.

        string json = JsonUtility.ToJson(gameData);
        //File.WriteAllText(Path.Combine(Application.persistentDataPath, gameDataFileName + ".json"), json);
        File.WriteAllText(path, json);

        Debug.Log(json);
    }


    // ���� ���� �ҷ�����
    public void LoadGame()
    {
        //string path = Path.Combine(Application.persistentDataPath, gameDataFileName + ".json");
        LoadGameFromPath(path);
    }

    // ������ ��ο��� ���� ���� �ҷ�����
    public void LoadGameFromPath(string path)
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(json);
            //��ư�� �־�� 
            Debug.Log(json);
            //GoodsData.instance._cookies = gameData.cookie; // ��Ű�� ���� �����մϴ�.
        }
        else
        {
            // ����� ���� ���°� ���� ���, �⺻ ���� ���·� ����
            //gameData = new GameData();
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
            return; // ���� �ڵ带 �������� �ʵ��� �մϴ�.
        }

        //gameData = new GameData(); // gameData ��ü�� �ʱ�ȭ

        // ���� �����͸� �ҷ��ɴϴ�. "/path/to/save.json" �κ��� ���� ���� ��η� ����
        //LoadGameFromPath("/path/to/save.json");
        path = Path.Combine(Application.dataPath, gameDataFileName);
    }

    //private void Update()
    //{
    //    LoadGame();
    //}


}