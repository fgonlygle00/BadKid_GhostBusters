using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Manager : MonoBehaviour
{
    [Header("Spwan")]
    [SerializeField] private Transform _spwanPos;
    [SerializeField] private float _delay; //생성되는 시간
    private float _curDelay;  //변화할때 사용
    public GameObject[] monsterPrefap;
    [SerializeField] private Monster_Status _monster_Datas;
    [HideInInspector] public List<GameObject> _monsters = new List<GameObject>();

    [Header("Path")]
    public Transform[] Points;


    static public Monster_Manager Instanse; //싱글톤


    void Start()
    {
        Instanse = this;
        _curDelay = _delay;

    }


    void Update()
    {

        if(_curDelay <= 0)
        {
            _monsters.Add(Instantiate(monsterPrefap[0], _spwanPos).GetComponent<GameObject>()); //임시로 인덱스 0을 사용
            _curDelay = _delay;
        }
        else
        {
            _curDelay -= Time.deltaTime;
        }
    }
}
