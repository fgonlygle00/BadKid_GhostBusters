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

    private Monster_Heal _monsterHeal;

    public Image healthBar;

    private void Start()
    {
        _stat.Set(Datas.status.hp, Datas.status.attack, Datas.status.speed);
        _monsterHeal = gameObject.GetComponent<Monster_Heal>();
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

                if (_monsterHeal != null)
                {
                    Debug.Log("�� �ȵų�");
                    foreach (var P in _monsterHeal.Healindex)
                    {
                        if (_pointIndex == P)
                        {
                            _stat.hp += Datas.status.hp * _monsterHeal.Heal();
                            if (_stat.hp > Datas.status.hp) _stat.hp = Datas.status.hp;
                        }
                    }
                }
                
                _pointIndex++;
            }
        }

        //���� ��
        if(_stat.hp <= 0)
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

    //HP �� ����
    public float ReturnHP()
    {
        return _stat.hp;
    }

    public void MovementDown(float down)
    {
        
    }

    public void HPDown(float Down)
    {

    }
}
