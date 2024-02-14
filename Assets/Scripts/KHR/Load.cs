using UnityEngine;
using System.IO;

public class Load : MonoBehaviour
{
    public GameData gameData;
    private string gameDataFileName = "save.json";

    // ���� ���� �ҷ�����
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
            // ����� ���� ���°� ���� ���, �⺻ ���� ���·� ����
            gameData = new GameData();
        }
    }
}
