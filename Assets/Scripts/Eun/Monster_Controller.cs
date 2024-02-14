using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Controller : MonoBehaviour  //이동 회전 로직
{
    [SerializeField] protected Monster_Status Datas;
    [SerializeField] protected Status _stat;
    public float moveDistanse;

    private int _pointIndex;   //현재 위치한 경로
    float _movementDebuff;
    float _healDebuff;
    bool _movementBool;
    bool _healBool;


    private Monster_Heal _monsterHeal;
    private Monster_Bomb _monsterBomb;

    public Image healthBar;

    private void Start()
    {
        _stat.Set(Datas.status.hp, Datas.status.attack, Datas.status.speed);
        _monsterHeal = gameObject.GetComponent<Monster_Heal>();
        _monsterBomb = gameObject.GetComponent<Monster_Bomb>();
    }


    private void Update()
    {
        SetHealthBar();
        if (_pointIndex<= Monster_Manager.Instanse.Points.Length-1)
        {

            //이동
            moveDistanse += Datas.status.speed *Time.deltaTime;
            transform.position = Vector3.MoveTowards
                (transform.position,
                Monster_Manager.Instanse.Points[_pointIndex].transform.position, _stat.speed * Time.deltaTime);

            // 목표 지점을 향해 회전

            Vector3 direction = Monster_Manager.Instanse.Points[_pointIndex].transform.position - transform.position; //목표지점을 바라보는 각도 구함
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up); // 이건 뭐지 더 공부
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1000 * Time.deltaTime);
            }


            //다음 목표 설정
            if (transform.position == new Vector3(Monster_Manager.Instanse.Points[_pointIndex].transform.position.x,
                transform.position.y,Monster_Manager.Instanse.Points[_pointIndex].transform.position.z)){

                //힐 몬스터
                if (_monsterHeal != null)
                {
                    foreach (var P in _monsterHeal.Healindex)
                    {
                        if (_pointIndex == P)
                        {
                            _stat.hp += Datas.status.hp * _monsterHeal.Heal();
                            if (_stat.hp > Datas.status.hp) _stat.hp = Datas.status.hp;
                        }
                    }
                }

                //폭탄 몬스터
                if (_monsterBomb != null)
                {

                }



                _pointIndex++;
            }

        }

        if (_movementDebuff <= 0 && _movementBool)
        {
            MovementReset();
        }
        else
        {
            _movementDebuff -= Time.deltaTime;
        }

        if (_healDebuff <0 && _healBool)
        {
            _healBool = false;
            _healDebuff = 0;
            _monsterHeal.ResetHeal();
        }
        else
        {
            _healDebuff -= Time.deltaTime;
        }

        //죽을 때
        if (_stat.hp <= 0)
        {
            Destroy(gameObject);
        }

    }



    void SetHealthBar()
    {
        float fill = _stat.hp / Datas.status.hp;
        healthBar.fillAmount = fill;
    }



    public float Attack()
    {
        return _stat.attack;
    }

    public void Hit(float Attack)
    {
        _stat.hp -= Attack;
    }

    public void SetPos(Transform transform)
    {
        gameObject.transform.position = transform.position;
    }

    //HP 값 리턴
    public float ReturnHP()
    {
        return _stat.hp;
    }

    //현우님 사용
    public void MovementDown(float down)
    {
        _movementDebuff += 2;
        if(!_movementBool)
        {
            _stat.speed *= down; 
            _movementBool = true;
        }
    }
    //현우님 사용
    public void HPDown(float Down)
    {
        _healDebuff += 2;
        if(_healBool)
        {
            _monsterHeal.ReturnHealPersent(Down);
            _healBool = true;
        }

    }

    void MovementReset()
    {
        _stat.speed = Datas.status.speed;
        _movementBool = false;
        _movementDebuff = 0;
    }

}
