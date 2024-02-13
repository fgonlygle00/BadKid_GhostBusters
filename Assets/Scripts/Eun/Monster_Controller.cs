using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour  //�̵� ȸ�� ����
{
    [SerializeField]private Monster_Status Datas;
    public float moveDistanse;

    private int _pointIndex;   //���� ��ġ�� ���


    private void Update()
    {
        if (_pointIndex<= Monster_Manager.Instanse.Points.Length-1)
        {

            //�̵�
            moveDistanse += Datas.speed *Time.deltaTime;
            transform.position = Vector3.MoveTowards
                (transform.position,
                Monster_Manager.Instanse.Points[_pointIndex].transform.position, Datas.speed * Time.deltaTime);

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
    }




    public float Attack()
    {
        return Datas.attack;
    }

    public void Hit(float Attack)
    {
        Datas.hp -= Attack;
    }

    public void SetPos(Transform Trs)
    {
        gameObject.transform.position = Trs.position;
    }

}
