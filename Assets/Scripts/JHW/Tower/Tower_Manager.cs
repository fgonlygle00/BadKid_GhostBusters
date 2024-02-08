using UnityEngine;

public class Tower_Manager : MonoBehaviour
{
    public GameObject[] towerPrefabs; // 타워 프리팹들을 저장하는 배열
    public GameObject[,] towerGrid; // 타워가 배치된 그리드 배열
    public int gridRows = 2;
    public int gridColumns = 4;

    void Start()
    {
        towerGrid = new GameObject[gridRows, gridColumns];
        TowerPlacement(); // 게임 시작 시 타워 배치
    }

    void TowerPlacement()
    {
        for (int row = 0; row < gridRows; row++)
        {
            for (int col = 0; col < gridColumns; col++)
            {
                if (towerGrid[row, col] == null)
                {
                    int randomTowerIndex = Random.Range(0, towerPrefabs.Length);
                    GameObject newTower = Instantiate(towerPrefabs[randomTowerIndex], GetPosition(row, col), Quaternion.identity);
                    towerGrid[row, col] = newTower;

                    // 이웃한 타워를 확인하고 필요한 로직 추가
                    CheckNeighboringTowers(row, col);
                }
            }
        }
    }

    Vector3 GetPosition(int row, int col)
    {
        float x = col * 2.0f; // 타워 사이의 간격 조정
        float y = 0.0f; // 원하는 높이로 조정
        float z = row * 2.0f; // 타워 사이의 간격 조정

        return new Vector3(x, y, z);
    }

    void CheckNeighboringTowers(int row, int col)
    {
        // 이웃한 타워를 확인하고 필요한 로직 추가
        // 상: towerGrid[row - 1, col], 하: towerGrid[row + 1, col], 좌: towerGrid[row, col - 1], 우: towerGrid[row, col + 1]
    }

    // 다른 메서드들은 필요에 따라 구현
}