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
    GameObject _destroyObject;


    public GameObject changePaticle;
    GameObject paticle;

    [SerializeField] private AudioSource _audioSource;
    void Start()
    {
        _audioSource.clip = AudioManager.instance._backGroundMusics[7];
        _changeObject = new GameObject[18];
        _towelPosition = new GameObject[18];
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
        _changeObject = Tower_Manager.Instance.Tower_Disposition_Arr;
        _towelPosition = Tower_Manager.Instance.Tower_Coordinate_Arr;
        for (int i = _changeObject.Length-1; i>=0;i--)
        {
            if (_changeObject[i] == null) continue;


            tower = _changeObject[i].GetComponent<Tower_Prototype>();
            int I = 0;
            if (tower.arr_Index >= start && tower.arr_Index <= length)
            {
                I = tower.arr_Index;
                _destroyObject = _changeObject[i];
                ChangePrefeb = Tower_Manager.Instance.GetRandomTowerPrefab();
                currentPosition = _towelPosition[i].transform.position;
                currentPosition.y += 33f;



                _changeObject[i] = Instantiate(ChangePrefeb);


                Tower_Manager.Instance.Tower_Disposition_Arr[i] = _changeObject[i];
                _changeObject[i].transform.position = currentPosition;
                _changeObject[i].GetComponent<Tower_Prototype>().Index_Get(I);


                //ÆÄÆ¼Å¬
                paticle = Instantiate(changePaticle, _changeObject[i].transform);
                paticle.transform.position = _changeObject[i].transform.position;

                Destroy(_destroyObject);


            }
        }

        StartCoroutine(PlayChange());
    }


    IEnumerator PlayChange()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(2f);
        _audioSource.Stop();
        Destroy(paticle);
    }
}
