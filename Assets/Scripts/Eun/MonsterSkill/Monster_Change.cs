using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Change : MonoBehaviour
{
    public int[] _changeIndex;
    GameObject[] _changeObject;
    GameObject[] _towelPosition;


    Tower_Prototype tower;
    Vector3 currentPosition;
    GameObject ChangePrefeb;
    GameObject DestroyObject;

    void Start()
    {
        _changeObject = Tower_Manager.Instance.Tower_Disposition_Arr;
        _towelPosition = Tower_Manager.Instance.Tower_Coordinate_Arr;
    }

    public void RandomTowel()
    {
        int rend = Random.Range(1, 4);

        switch (rend)
        {
            case 1:
                RandomPrefeb(0, 7);
                break;
            case 2:
                RandomPrefeb(8, 13);
                break;
            case 3:
                RandomPrefeb(14, 17);
                break;

        }
    }


    void RandomPrefeb(int start,int length)
    {
        for (int i = _changeObject.Length; i>=0;i--)
        {
            tower = _changeObject[i].GetComponent<Tower_Prototype>();
            int I = 0;
            if (tower.arr_Index >= start && tower.arr_Index <= length)
            {
                I = tower.arr_Index;
                DestroyObject = _changeObject[i];
                ChangePrefeb = Tower_Manager.Instance.GetRandomTowerPrefab();
                currentPosition = _towelPosition[i].transform.position;
                currentPosition.y += 33f;


                _changeObject[i] = Instantiate(ChangePrefeb);
                _changeObject[i].transform.position = currentPosition;
                _changeObject[i].GetComponent<Tower_Prototype>().Index_Get(I);


                Destroy(DestroyObject);
            }
        }
    }
}
