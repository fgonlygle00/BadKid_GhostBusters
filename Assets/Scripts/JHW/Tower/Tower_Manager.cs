using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Manager : MonoBehaviour
{
    // 타워 프리펩 정의

    // 딜러 4종
    public GameObject Gun_Tower;
    public GameObject Cannon_Tower;
    public GameObject Sniper_Tower;
    public GameObject Beam_Tower;

    //버프 타워 2종
    public GameObject Range_Enhance_Tower;
    public GameObject Density_Enhance_Tower;

    //디버프 타워 2종
    public GameObject Snow_Tower;
    public GameObject Flame_Tower;

    //타워 종류 정하는 랜덤인수




    public int Cookie = 0;

    public void Add_Cookie(int drop)    //유령 죽을 때 이 메서드를 쓰세요
    {
        Cookie += drop;
    }


    // 타워 배치 배열은 타워 인스턴스가 들어가는 배열.
    // 타워 좌표 배열은 큐브들이 들어가있는 배열.
    GameObject[] Tower_Disposition_Arr = new GameObject[18];
    public GameObject[] Tower_Coordinate_Arr = new GameObject[18];


    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Enter 키 입력 시 tower_Arrange() 메서드 호출
            tower_Arrange();
        }
    }

    public void tower_Arrange() //타워를 랜덤으로 골라 랜덤 칸에 배치하는 메서드
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

            // Y 좌표에 33을 더함
            currentPosition.y += 33f;

            // 새로운 위치로 설정
            towerInstance.transform.position = currentPosition;

            
            //타워 인스턴스에 지금 자리 배치 정보를 저장
            Tower_Prototype tower_script = towerInstance.GetComponent<Tower_Prototype>();
            tower_script.Index_Get(randomEmptySlotIndex);
        }
    }

    GameObject GetRandomTowerPrefab() //타워를 무작위로 고르는 메서드
    {
        // 타워 프리펩을 무작위로 선택합니다
        int randomIndex = Random.Range(1, 1);
        switch (randomIndex)
        {
            case 0:
                return Gun_Tower;
            case 1:
                return Cannon_Tower;
            case 2:
                return Sniper_Tower;
            case 3:
                return Beam_Tower;
            case 4:
                return Range_Enhance_Tower; 
            case 5:
                return Density_Enhance_Tower;
            case 6:
                return Snow_Tower;
            case 7:
                return Flame_Tower;
            default:
                return Gun_Tower; // 기본값은 건 타워
        }
    }
}
