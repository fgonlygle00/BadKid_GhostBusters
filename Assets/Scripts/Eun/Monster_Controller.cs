using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Controller : MonoBehaviour  //�̵� ȸ�� ����
{
    [SerializeField] protected Monster_Status Datas;
    [SerializeField] protected Status _stat;
    public float moveDistanse;

    private int _pointIndex;   //���� ��ġ�� ���
    float _movementDebuff;
    float _healDebuff;
    bool _movementBool;
    bool _healBool;


    private Monster_Heal _monsterHeal;
    private Monster_Bomb _monsterBomb;
    private Monster_Change _monsterChange;

    public Image healthBar;

    private void Start()
    {
        _stat.Set(Datas.status.hp, Datas.status.attack, Datas.status.speed);
        _monsterHeal = gameObject.GetComponent<Monster_Heal>();
        _monsterBomb = gameObject.GetComponent<Monster_Bomb>();
        _monsterChange = gameObject.GetComponent<Monster_Change>();
    }


    private void Update()
    {
        SetHealthBar();
        if (_pointIndex<= Monster_Manager.Instanse.Points.Length-1)
        {

            //�̵�
            moveDistanse += Datas.status.speed *Time.deltaTime;
            transform.position = Vector3.MoveTowards
                (transform.position,
                Monster_Manager.Instanse.Points[_pointIndex].transform.position, _stat.speed * Time.deltaTime);

            // ��ǥ ������ ���� ȸ��

            Vector3 direction = Monster_Manager.Instanse.Points[_pointIndex].transform.position - transform.position; //��ǥ������ �ٶ󺸴� ���� ����
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up); // �̰� ���� �� ����
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1000 * Time.deltaTime);
            }


            //���� ��ǥ ����
            if (transform.position == new Vector3(Monster_Manager.Instanse.Points[_pointIndex].transform.position.x,
                transform.position.y,Monster_Manager.Instanse.Points[_pointIndex].transform.position.z)){

                //�� ����
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

                //��ź ����
                if (_monsterBomb != null)
                {
                    foreach (var B in _monsterBomb.bombIndex)
                    {
                        if (_pointIndex == B)
                        {
                            _monsterBomb.BombPrefeb(_pointIndex);
                        }
                    }
                }

                if (_monsterChange != null)
                {
                    foreach (var C in _monsterChange._changeIndex)
                    {
                        if(_pointIndex == C)
                        {
                            _monsterChange.RandomTowel();
                        }
                    }
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

        //���� ��
        if (_stat.hp <= 0)
        {
            switch(Datas.monster_Type)
            {
                case Monster_Type.monster1: GoodsData.instance._cookies += 1; break;
                case Monster_Type.monster2: GoodsData.instance._cookies += 2; break;
                case Monster_Type.monster3: GoodsData.instance._cookies += 3; break;
                case Monster_Type.monster4: GoodsData.instance._cookies += 4; break;
                case Monster_Type.boss1: GoodsData.instance._cookies += 5; break;
                case Monster_Type.boss2: GoodsData.instance._cookies += 10; break;
                case Monster_Type.boss3: GoodsData.instance._cookies += 15; break;
                case Monster_Type.boss4: GoodsData.instance._cookies += 20; break;
            }
            Destroy(gameObject);
        }

    }



    void SetHealthBar()
    {
        float fill = _stat.hp / Datas.status.hp;
        healthBar.fillAmount = fill;
    }


    public float maxHP()
    {
        return Datas.status.hp;
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

    //HP �� ����
    public float ReturnHP()
    {
        return _stat.hp;
    }

    //����� ���
    public void MovementDown(float down)
    {
        _movementDebuff += 0.3f;
        if(!_movementBool)
        {
            _stat.speed *= down; 
            _movementBool = true;
        }
    }
    //����� ���
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
