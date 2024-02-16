/*using System;
using System.IO;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    public static SaveAndLoadManager Instance { get; private set; }

    [Serializable]
    public class GameData
    {
        public float baseHealth = 50f; // ������ ü���� �����ϴ� ����
        public int cookie =150;
        public int currentWave = 1;
        public Tower_SaveData[] tower_Data;

        //public float soundVolume;
    }



    public GameData gameData;
    string path;
    private string gameDataFileName = "save.json";

    public void SaveGame()
    {
        Invasion_Controller invasionController = FindObjectOfType<Invasion_Controller>();
        GoodsData goodsData = GoodsData.instance;
        Tower_Manager towerManager = FindObjectOfType<Tower_Manager>();
        Monster_Manager monsterManager = FindObjectOfType<Monster_Manager>();


        if (invasionController == null || goodsData == null || towerManager == null || monsterManager == null)
        {
            Debug.LogError("Invasion_Controller, GoodsData, TowerManager �Ǵ� Monster_Manager �ν��Ͻ��� ã�� �� �����ϴ�.");
            return;
        }

        if (gameData == null)
        {
            gameData = new GameData();
        }
      
        gameData.baseHealth = invasionController.ReturnHealth();
        gameData.cookie = goodsData._cookies;
        gameData.currentWave = monsterManager.GetCurrentWave(); // ���� ���̺긦 �����մϴ�.
        
        gameData.tower_Data = towerManager.Get_TowerData();
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(path, json);

        Debug.Log(json);
    }


    // ���� ���� �ҷ�����
    public void LoadGame()
    {
        //string path = Path.Combine(Application.persistentDataPath, gameDataFileName + ".json");
        Tower_Manager towerManager = FindObjectOfType<Tower_Manager>();

        
        
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

        gameData = new GameData(); // gameData ��ü�� �ʱ�ȭ

        // ���� �����͸� �ҷ��ɴϴ�. "/path/to/save.json" �κ��� ���� ���� ��η� ����
        //LoadGameFromPath("/path/to/save.json");
        path = Path.Combine(Application.dataPath, gameDataFileName);
    }

    //private void Update()
    //{
    //    LoadGame();
    //}


}*/