using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Manager : MonoBehaviour
{
    // 타워 프리펩 정의
    public GameObject towerA;
    public GameObject towerB;
    public GameObject towerC;

    // 타워 배치 배열은 타워 인스턴스가 들어가는 배열.
    // 타워 좌표 배열은 각 칸의 고정 좌표값이 들어있는 배열. (UI가 타워 좌표 배열을 추가해주세요.)
    GameObject[] Tower_Disposition_Arr = new GameObject[19];
    Vector3[] Tower_Coordinate_Arr = new Vector3[19];

    void Start()
    {
    }

    void tower_Arrange() //타워를 랜덤으로 골라 랜덤 칸에 배치하는 메서드
    {
        // 타워 배치 배열에 빈자리가 있는지 체크하고, 그 빈자리의 리스트를 만든다
        List<int> emptySlots = new List<int>();
        for (int i = 0; i < Tower_Disposition_Arr.Length; i++)
        {
            if (Tower_Disposition_Arr[i] == null)
            {
                emptySlots.Add(i);
            }
        }

        // 타워 배치 배열의 빈자리가 있을 경우, 그 중 하나를 무작위로 고른다.
        if (emptySlots.Count > 0)
        {
            int randomEmptySlotIndex = emptySlots[Random.Range(0, emptySlots.Count)];

            // 생성할 타워를 무작위로 고른다.
            GameObject selectedTowerPrefab = GetRandomTowerPrefab();

            // 인스턴스 생성
            GameObject towerInstance = Instantiate(selectedTowerPrefab);

            // 타워 배치 배열에 타워 인스턴스를 추가한다.
            Tower_Disposition_Arr[randomEmptySlotIndex] = towerInstance;

            // 타워 인스턴스의 좌표를 타워 좌표 배열의 좌표로 변경한다.
            towerInstance.transform.position = Tower_Coordinate_Arr[randomEmptySlotIndex];

        }
    }

    GameObject GetRandomTowerPrefab() //타워를 무작위로 고르는 메서드
    {
        // 타워 프리펩을 무작위로 선택합니다
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
