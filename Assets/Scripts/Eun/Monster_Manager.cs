using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Manager : MonoBehaviour
{
    [Header("Wave")]
    [SerializeField] int Wave;



    [Header("Spwan")]
    [SerializeField] private Transform _spwanPos;
    [SerializeField] private float _delay; //생성되는 시간
    private float _curDelay;  //변화할때 사용
    public GameObject[] monsterPrefap;
    [SerializeField] private Monster_Status[] _monster_Datas;
    [HideInInspector] public List<Monster_Controller> _monsters = new List<Monster_Controller>();

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
            _monsters.Add(Instantiate(monsterPrefap[0], _spwanPos).GetComponent<Monster_Controller>()); //임시로 인덱스 0을 사용
            _monsters[_monsters.Count - 1].SetPos(_spwanPos);
            _curDelay = _delay;
        }
        else
        {
            _curDelay -= Time.deltaTime;
        }
    }
}
