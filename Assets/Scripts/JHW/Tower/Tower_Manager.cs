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


    

    public int Cookie = 0;

    public void Add_Cookie(int drop)    //���� ���� �� �� �޼��带 ������
    {
        Cookie += drop;
    }


    // Ÿ�� ��ġ �迭�� Ÿ�� �ν��Ͻ��� ���� �迭.
    // Ÿ�� ��ǥ �迭�� ť����� ���ִ� �迭.
    GameObject[] Tower_Disposition_Arr = new GameObject[18];
    public GameObject[] Tower_Coordinate_Arr = new GameObject[18];


    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Enter Ű �Է� �� tower_Arrange() �޼��� ȣ��
            tower_Arrange();
        }
    }

    public void tower_Arrange() //Ÿ���� �������� ��� ���� ĭ�� ��ġ�ϴ� �޼���
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

            // Y ��ǥ�� 33�� ����
            currentPosition.y += 33f;

            // ���ο� ��ġ�� ����
            towerInstance.transform.position = currentPosition;

            //Ÿ�� �ν��Ͻ��� ���� �ڸ� ��ġ ������ ����
            Tower_Prototype tower_script = towerInstance.GetComponent<Tower_Prototype>();
            tower_script.Index_Get(randomEmptySlotIndex);
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
