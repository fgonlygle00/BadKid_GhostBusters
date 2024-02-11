using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Manager : MonoBehaviour
{
    // Ÿ�� ������ ����
    public GameObject towerA;
    public GameObject towerB;
    public GameObject towerC;

    // Ÿ�� ��ġ �迭�� Ÿ�� �ν��Ͻ��� ���� �迭.
    // Ÿ�� ��ǥ �迭�� �� ĭ�� ���� ��ǥ���� ����ִ� �迭. (UI�� Ÿ�� ��ǥ �迭�� �߰����ּ���.)
    GameObject[] Tower_Disposition_Arr = new GameObject[19];
    Vector3[] Tower_Coordinate_Arr = new Vector3[19];

    void Start()
    {
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
            towerInstance.transform.position = Tower_Coordinate_Arr[randomEmptySlotIndex];

        }
    }

    GameObject GetRandomTowerPrefab() //Ÿ���� �������� ���� �޼���
    {
        // Ÿ�� �������� �������� �����մϴ�
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0:
                return towerA;
            case 1:
                return towerB;
            case 2:
                return towerC;
            default:
                return towerA; // Default to towerA if something goes wrong
        }
    }
}
