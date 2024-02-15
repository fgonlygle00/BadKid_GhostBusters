using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower_Manager : MonoBehaviour
{
    private static Tower_Manager _instance;

    // �̱��� �ν��Ͻ��� �����ϴ� ������Ƽ
    public static Tower_Manager Instance
    {
        get
        {
            // �ν��Ͻ��� ������ ���� ����
            if (_instance == null)
            {
                _instance = FindObjectOfType<Tower_Manager>();

                // ���� Scene�� �ش� Ŭ������ �ν��Ͻ��� ���ٸ�
                if (_instance == null)
                {
                    // �� GameObject�� �߰��Ͽ� �ν��Ͻ� ����
                    GameObject singletonObject = new GameObject("Tower_Manager");
                    _instance = singletonObject.AddComponent<Tower_Manager>();
                }
            }
            return _instance;
        }
    }

    // ���� MonoBehaviour �޼���� ���� ��� ����
    private void Awake()
    {
        // �̱��� �ν��Ͻ� Ȯ��
        if (_instance == null)
        {
            // ���� �ν��Ͻ��� ����
            _instance = this;
        }
        else
        {
        }
    }
    // Ÿ�� ������ ����

    // ���� 4��
    public GameObject Gun_Tower;
    public GameObject Cannon_Tower;
    public GameObject Sniper_Tower;
    public GameObject Beam_Tower;

    //���� Ÿ�� 2��
    public GameObject Range_Enhance_Tower;
    public GameObject Density_Enhance_Tower;

    //����� Ÿ�� 2��
    public GameObject Snow_Tower;
    public GameObject Flame_Tower;


    public int Cookie = 0;

    public void Add_Cookie(int drop)    //���� ���� �� �� �޼��带 ������
    {
        Cookie += drop;
    }


    // Ÿ�� ��ġ �迭�� Ÿ�� �ν��Ͻ��� ���� �迭.
    // Ÿ�� ��ǥ �迭�� ť��(����)���� ��ġ�� ���ִ� �迭.
    public GameObject[] Tower_Disposition_Arr = new GameObject[18];        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<�̰� Ÿ�� �ν��Ͻ��� �� ����ִ� �迭�Դϴ�
    public GameObject[] Tower_Coordinate_Arr = new GameObject[18];        //

    //���� ȿ�� �迭. ��� 1�� �ʱ�ȭ.
    public float[] Buff_Value_Arr = new float[18];

    //���� �̺�Ʈ
    public delegate void BuffValueChangedEventHandler(int index, float newValue);
    public event BuffValueChangedEventHandler OnBuffValueChanged;

    public void SetBuffValue(int index, float newValue)
    {
        Buff_Value_Arr[index] = newValue;

        // �̺�Ʈ ȣ��
        OnBuffValueChanged?.Invoke(index, newValue);
    }

    private void BuffChangedHandler(int index, float newValue)
    {
        // Ư�� �޼ҵ忡�� �� �� �ۼ�
        if (Tower_Disposition_Arr[index] != null)
        {
            Tower_Prototype tower_script = Tower_Disposition_Arr[index].GetComponent<Tower_Prototype>();
            tower_script.Buffed(newValue);
        }
    }



    void Start()
    {
        // �̺�Ʈ�� �޼ҵ� ���
        OnBuffValueChanged += BuffChangedHandler;

        for (int i = 0; i < Buff_Value_Arr.Length; i++)
        {
            Buff_Value_Arr[i] = 1.0f;
        }
    }

    private void Update()
    {
    }




    public void tower_Arrange() //Ÿ���� �������� ��� ���� ĭ�� ��ġ�ϴ� �޼���
    {
        if (GoodsData.instance._cookies >= 50)
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

                //Ÿ�� ������ ��Ű �Ҹ�
                GoodsData.instance._cookies -= 50;
            }
        }
    }

    public GameObject GetRandomTowerPrefab() //Ÿ���� �������� ���� �޼���
    {
        // Ÿ�� �������� �������� �����մϴ�
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
                return Gun_Tower; // �⺻���� �� Ÿ��
        }

    }

    public void ReRoll(int i)
    {
        {
            Tower_Disposition_Arr[i] = null;
            // ������ Ÿ���� �������� ����.
            GameObject selectedTowerPrefab = GetRandomTowerPrefab();

            // �ν��Ͻ� ����
            GameObject towerInstance = Instantiate(selectedTowerPrefab);

            // Ÿ�� ��ġ �迭�� Ÿ�� �ν��Ͻ��� �߰��Ѵ�.
            Tower_Disposition_Arr[i] = towerInstance;

            // Ÿ�� �ν��Ͻ��� ��ǥ�� Ÿ�� ��ǥ �迭�� ��ǥ�� �����Ѵ�.
            Vector3 currentPosition = Tower_Coordinate_Arr[i].transform.position;

            // Y ��ǥ�� 33�� ����
            currentPosition.y += 33f;

            // ���ο� ��ġ�� ����
            towerInstance.transform.position = currentPosition;


            //Ÿ�� �ν��Ͻ��� ���� �ڸ� ��ġ ������ ����
            Tower_Prototype tower_script = towerInstance.GetComponent<Tower_Prototype>();
            tower_script.Index_Get(i);

            //Ÿ�� ������ ��Ű �Ҹ�
            GoodsData.instance._cookies -= 100;
        }
    }
}
