using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Manager : MonoBehaviour
{
    // Ÿ�� ������ ����
    public GameObject NormalTower;
    public GameObject SplashTower;
    public GameObject SummonTower;
    public GameObject BuffTower;

    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;
    public GameObject Cube4;
    public GameObject Cube5;
    public GameObject Cube6;
    public GameObject Cube7;
    public GameObject Cube8;
    public GameObject Cube9;
    public GameObject Cube10;
    public GameObject Cube11;
    public GameObject Cube12;
    public GameObject Cube13;
    public GameObject Cube14;
    public GameObject Cube15;
    public GameObject Cube16;
    public GameObject Cube17;
    public GameObject Cube18;
    public GameObject Cube19;

    public int Cookie = 0;


    // Ÿ�� ��ġ �迭�� Ÿ�� �ν��Ͻ��� ���� �迭.
    // Ÿ�� ��ǥ �迭�� ť����� ���ִ� �迭.
    GameObject[] Tower_Disposition_Arr = new GameObject[19];
    GameObject[] Tower_Coordinate_Arr = new GameObject[19];


    void Start()
    {
        for (int i = 0; i < 19; i++)
        {
            Tower_Coordinate_Arr[i] = (GameObject)GetType().GetField("Cube" + (i + 1)).GetValue(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Enter Ű �Է� �� tower_Arrange() �޼��� ȣ��
            tower_Arrange();
        }
    }

    void tower_Arrange() //Ÿ���� �������� ��� ���� ĭ�� ��ġ�ϴ� �޼���
    {
        // Ÿ�� ��ġ �迭�� ���ڸ��� �ִ��� üũ�ϰ�, �� ���ڸ��� ����Ʈ�� �����
        List<int> emptySlots = new List<int>();
        for (int i = 0; i < Tower_Disposition_Arr.Length; i++)
        {
            if (Tower_Disposition_Arr[i] == null)
            {
                emptySlots.Add(i);
            }
        }

        // Ÿ�� ��ġ �迭�� ���ڸ��� ���� ���, �� �� �ϳ��� �������� ����.
        if (emptySlots.Count > 0)
        {
            int randomEmptySlotIndex = emptySlots[Random.Range(0, emptySlots.Count)];

            // ������ Ÿ���� �������� ����.
            GameObject selectedTowerPrefab = GetRandomTowerPrefab();

            // �ν��Ͻ� ����
            GameObject towerInstance = Instantiate(selectedTowerPrefab);

            // Ÿ�� ��ġ �迭�� Ÿ�� �ν��Ͻ��� �߰��Ѵ�.
            Tower_Disposition_Arr[randomEmptySlotIndex] = towerInstance;

            // Ÿ�� �ν��Ͻ��� ��ǥ�� Ÿ�� ��ǥ �迭�� ��ǥ�� �����Ѵ�.
            Vector3 currentPosition = Tower_Coordinate_Arr[randomEmptySlotIndex].transform.position;

            // Y ��ǥ�� 10�� ����
            currentPosition.y += 10;

            // ���ο� ��ġ�� ����
            towerInstance.transform.position = currentPosition;
        }
    }

    GameObject GetRandomTowerPrefab() //Ÿ���� �������� ���� �޼���
    {
        // Ÿ�� �������� �������� �����մϴ�
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0:
                return NormalTower;
            case 1:
                return SplashTower;
            case 2:
                return SummonTower;
            case 3:
                return BuffTower;
            default:
                return NormalTower; // Default to towerA if something goes wrong
        }
    }
}
