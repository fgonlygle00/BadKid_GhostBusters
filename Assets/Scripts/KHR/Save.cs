using UnityEngine;
using System.IO;
using UnityEngine.Playables;

[System.Serializable]
public class GameData
{

    public float baseHealth;
    public int baseLevel;
    public int cookie;
    public Vector3[] towerPosition;//Ÿ�� �ν��Ͻ� ����Ʈ
    public bool towerUpgrades;
    public int currentWave;
    public float soundVolume;
}


public class Save : MonoBehaviour
{
    public GameData gameData;'

    private string gameDataFileName = "save.json";

    // ���� ���� ����
    public void SaveGame()
    {
        baseHealth = Tower_Manager.Instance.
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, gameDataFileName), json);
    }
}

public static Tower_Manager

