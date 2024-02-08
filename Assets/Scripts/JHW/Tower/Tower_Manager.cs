using UnityEngine;

public class Tower_Manager : MonoBehaviour
{
    public GameObject[] towerPrefabs; // Ÿ�� �����յ��� �����ϴ� �迭
    public GameObject[,] towerGrid; // Ÿ���� ��ġ�� �׸��� �迭
    public int gridRows = 2;
    public int gridColumns = 4;

    void Start()
    {
        towerGrid = new GameObject[gridRows, gridColumns];
        TowerPlacement(); // ���� ���� �� Ÿ�� ��ġ
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

                    // �̿��� Ÿ���� Ȯ���ϰ� �ʿ��� ���� �߰�
                    CheckNeighboringTowers(row, col);
                }
            }
        }
    }

    Vector3 GetPosition(int row, int col)
    {
        float x = col * 2.0f; // Ÿ�� ������ ���� ����
        float y = 0.0f; // ���ϴ� ���̷� ����
        float z = row * 2.0f; // Ÿ�� ������ ���� ����

        return new Vector3(x, y, z);
    }

    void CheckNeighboringTowers(int row, int col)
    {
        // �̿��� Ÿ���� Ȯ���ϰ� �ʿ��� ���� �߰�
        // ��: towerGrid[row - 1, col], ��: towerGrid[row + 1, col], ��: towerGrid[row, col - 1], ��: towerGrid[row, col + 1]
    }

    // �ٸ� �޼������ �ʿ信 ���� ����
}