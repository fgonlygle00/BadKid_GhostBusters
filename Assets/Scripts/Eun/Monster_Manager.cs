using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Manager : MonoBehaviour
{
    [Header("Spwan")]
    [SerializeField] private Transform _spwanPos;
    [SerializeField] private float _delay; //�����Ǵ� �ð�
    private float _curDelay;  //��ȭ�Ҷ� ���
    public GameObject[] monsterPrefap;
    [SerializeField] private Monster_Status _monster_Datas;
    [HideInInspector] public List<GameObject> _monsters = new List<GameObject>();

    [Header("Path")]
    public Transform[] Points;


    static public Monster_Manager Instanse; //�̱���


    void Start()
    {
        Instanse = this;
        _curDelay = _delay;

    }


    void Update()
    {

        if(_curDelay <= 0)
        {
            _monsters.Add(Instantiate(monsterPrefap[0], _spwanPos).GetComponent<GameObject>()); //�ӽ÷� �ε��� 0�� ���
            _curDelay = _delay;
        }
        else
        {
            _curDelay -= Time.deltaTime;
        }
    }
}
