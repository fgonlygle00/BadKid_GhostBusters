using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Manager : MonoBehaviour
{
    // 타워 프리펩 정의
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


    // 타워 배치 배열은 타워 인스턴스가 들어가는 배열.
    // 타워 좌표 배열은 큐브들이 들어가있는 배열.
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
            // Enter 키 입력 시 tower_Arrange() 메서드 호출
            tower_Arrange();
        }
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
            Vector3 currentPosition = Tower_Coordinate_Arr[randomEmptySlotIndex].transform.position;

            // Y 좌표에 10을 더함
            currentPosition.y += 10;

            // 새로운 위치로 설정
            towerInstance.transform.position = currentPosition;
        }
    }

    GameObject GetRandomTowerPrefab() //타워를 무작위로 고르는 메서드
    {
        // 타워 프리펩을 무작위로 선택합니다
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
