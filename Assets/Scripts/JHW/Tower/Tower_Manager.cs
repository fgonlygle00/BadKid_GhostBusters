using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower_Manager : MonoBehaviour
{
    private static Tower_Manager _instance;

    // 싱글톤 인스턴스에 접근하는 프로퍼티
    public static Tower_Manager Instance
    {
        get
        {
            // 인스턴스가 없으면 새로 생성
            if (_instance == null)
            {
                _instance = FindObjectOfType<Tower_Manager>();

                // 만약 Scene에 해당 클래스의 인스턴스가 없다면
                if (_instance == null)
                {
                    // 빈 GameObject에 추가하여 인스턴스 생성
                    GameObject singletonObject = new GameObject("Tower_Manager");
                    _instance = singletonObject.AddComponent<Tower_Manager>();
                }
            }
            return _instance;
        }
    }

    // 기존 MonoBehaviour 메서드와 같이 사용 가능
    private void Awake()
    {
        // 싱글톤 인스턴스 확인
        if (_instance == null)
        {
            // 현재 인스턴스를 설정
            _instance = this;
        }
        else
        {
        }
    }
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


    public int Cookie = 0;

    public void Add_Cookie(int drop)    //유령 죽을 때 이 메서드를 쓰세요
    {
        Cookie += drop;
    }


    // 타워 배치 배열은 타워 인스턴스가 들어가는 배열.
    // 타워 좌표 배열은 큐브(발판)들의 위치가 들어가있는 배열.
    public GameObject[] Tower_Disposition_Arr = new GameObject[18];        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<이거 타워 인스턴스들 다 들어있는 배열입니다
    public GameObject[] Tower_Coordinate_Arr = new GameObject[18];        //

    //버프 효과 배열. 모두 1로 초기화.
    public float[] Buff_Value_Arr = new float[18];

    //버프 이벤트
    public delegate void BuffValueChangedEventHandler(int index, float newValue);
    public event BuffValueChangedEventHandler OnBuffValueChanged;

    public void SetBuffValue(int index, float newValue)
    {
        Buff_Value_Arr[index] = newValue;

        // 이벤트 호출
        OnBuffValueChanged?.Invoke(index, newValue);
    }

    private void BuffChangedHandler(int index, float newValue)
    {
        // 특정 메소드에서 할 일 작성
        if (Tower_Disposition_Arr[index] != null)
        {
            Tower_Prototype tower_script = Tower_Disposition_Arr[index].GetComponent<Tower_Prototype>();
            tower_script.Buffed(newValue);
        }
    }



    void Start()
    {
        // 이벤트에 메소드 등록
        OnBuffValueChanged += BuffChangedHandler;

        for (int i = 0; i < Buff_Value_Arr.Length; i++)
        {
            Buff_Value_Arr[i] = 1.0f;
        }
    }

    private void Update()
    {
    }




    public void tower_Arrange() //타워를 랜덤으로 골라 랜덤 칸에 배치하는 메서드
    {
        if (GoodsData.instance._cookies >= 50)
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

                //타워 생성시 쿠키 소모
                GoodsData.instance._cookies -= 50;
            }
        }
    }

    public GameObject GetRandomTowerPrefab() //타워를 무작위로 고르는 메서드
    {
        // 타워 프리펩을 무작위로 선택합니다
        int randomIndex = Random.Range(0, 8);
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

    public void ReRoll(int i)
    {
        {
            Tower_Disposition_Arr[i] = null;
            // 생성할 타워를 무작위로 고른다.
            GameObject selectedTowerPrefab = GetRandomTowerPrefab();

            // 인스턴스 생성
            GameObject towerInstance = Instantiate(selectedTowerPrefab);

            // 타워 배치 배열에 타워 인스턴스를 추가한다.
            Tower_Disposition_Arr[i] = towerInstance;

            // 타워 인스턴스의 좌표를 타워 좌표 배열의 좌표로 변경한다.
            Vector3 currentPosition = Tower_Coordinate_Arr[i].transform.position;

            // Y 좌표에 33을 더함
            currentPosition.y += 33f;

            // 새로운 위치로 설정
            towerInstance.transform.position = currentPosition;


            //타워 인스턴스에 지금 자리 배치 정보를 저장
            Tower_Prototype tower_script = towerInstance.GetComponent<Tower_Prototype>();
            tower_script.Index_Get(i);

            //타워 생성시 쿠키 소모
            GoodsData.instance._cookies -= 100;
        }
    }
}
