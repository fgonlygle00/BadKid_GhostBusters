using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour  //�̵� ȸ�� ����
{
    [SerializeField] private Monster_Status Datas;
    [SerializeField] private Status _stat;
    public float moveDistanse;

    private int _pointIndex;   //���� ��ġ�� ���

    private void Start()
    {
        SetPos();
        _stat.Set(Datas.status.hp, Datas.status.attack, Datas.status.speed);
    }


    private void Update()
    {
        if (_pointIndex<= Monster_Manager.Instanse.Points.Length-1)
        {

            //�̵�
            moveDistanse += Datas.status.speed *Time.deltaTime;
            transform.position = Vector3.MoveTowards
                (transform.position,
                Monster_Manager.Instanse.Points[_pointIndex].transform.position, Datas.status.speed * Time.deltaTime);

            // ��ǥ ������ ���� ȸ��
            Vector3 direction = Monster_Manager.Instanse.Points[_pointIndex].transform.position - transform.position; //��ǥ������ �ٶ󺸴� ���� ����
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up); // �̰� ���� �� ����
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1000 * Time.deltaTime);

            //���� ��ǥ ����
            if (transform.position == new Vector3(Monster_Manager.Instanse.Points[_pointIndex].transform.position.x,
                transform.position.y,Monster_Manager.Instanse.Points[_pointIndex].transform.position.z)){

                _pointIndex++;
            }
        }

        //���� ��
        if(_stat.hp <= 0)
        {
            Destroy(gameObject);
        }

    }




    public float Attack()
    {
        return Datas.status.attack;
    }

    public void Hit(float Attack)
    {
        _stat.hp -= Attack;
    }

    public void SetPos()
    {
        gameObject.transform.position = Monster_Manager.Instanse._spwanPos.position;
    }

}
