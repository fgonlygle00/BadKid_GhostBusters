using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour  //이동 회전 로직
{
    [SerializeField]private Monster_Status Datas;
    public float moveDistanse;

    private int _pointIndex;   //현재 위치한 경로


    private void Update()
    {
        if (_pointIndex<= Monster_Manager.Instanse.Points.Length-1)
        {
            moveDistanse += Datas.speed *Time.deltaTime;
            transform.position = Vector3.MoveTowards
                (transform.position,
                Monster_Manager.Instanse.Points[_pointIndex].transform.position, Datas.speed * Time.deltaTime);

            if(transform.position == new Vector3(Monster_Manager.Instanse.Points[_pointIndex].transform.position.x,
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

}
