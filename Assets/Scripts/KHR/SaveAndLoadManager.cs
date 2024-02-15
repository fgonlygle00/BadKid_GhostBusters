using System.IO;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    public static SaveAndLoadManager Instance { get; private set; }

    public class GameData
    {
        public float baseHealth; // 거점의 체력을 저장하는 변수
        public int cookie;
        public Vector3[] towerPosition; //타워 매니저
        public bool towerUpgrades;
        public int currentWave;
        public float soundVolume;
    }


    public GameData gameData;
    string path;
    private string gameDataFileName = "save.json";

    public void SaveGame()
    {
        Invasion_Controller invasionController = FindObjectOfType<Invasion_Controller>(); // Invasion_Controller 인스턴스를 가져옵니다.
        GoodsData goodsData = GoodsData.instance; // GoodsData 인스턴스를 가져옵니다.

        if (invasionController == null || goodsData == null) // 인스턴스가 null인지 검사합니다.
        {
            Debug.LogError("Invasion_Controller 인스턴스 또는 GoodsData 인스턴스를 찾을 수 없습니다.");
            return;
        }

        // 게임데이터가 없다면 새로운 데이터를 만든다.
        if (gameData == null)
        {
            gameData = new GameData();
        }
        gameData.baseHealth = invasionController.ReturnHealth();
        gameData.cookie = goodsData._cookies; // 쿠키의 수를 저장합니다.

        string json = JsonUtility.ToJson(gameData);
        //File.WriteAllText(Path.Combine(Application.persistentDataPath, gameDataFileName + ".json"), json);
        File.WriteAllText(path, json);

        Debug.Log(json);
    }


    // 게임 상태 불러오기
    public void LoadGame()
    {
        //string path = Path.Combine(Application.persistentDataPath, gameDataFileName + ".json");
        LoadGameFromPath(path);
    }

    // 지정된 경로에서 게임 상태 불러오기
    public void LoadGameFromPath(string path)
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(json);
            //버튼이 있어야 
            Debug.Log(json);
            //GoodsData.instance._cookies = gameData.cookie; // 쿠키의 수를 복원합니다.
        }
        else
        {
            // 저장된 게임 상태가 없는 경우, 기본 게임 상태로 시작
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
            return; // 이후 코드를 실행하지 않도록 합니다.
        }

        //gameData = new GameData(); // gameData 객체를 초기화

        // 게임 데이터를 불러옵니다. "/path/to/save.json" 부분은 실제 파일 경로로 변경
        //LoadGameFromPath("/path/to/save.json");
        path = Path.Combine(Application.dataPath, gameDataFileName);
    }

    //private void Update()
    //{
    //    LoadGame();
    //}


}