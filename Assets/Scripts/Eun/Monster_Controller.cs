using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour  //이동 회전 로직
{
    [SerializeField] private Monster_Status Datas;
    [SerializeField] private Status _stat;
    public float moveDistanse;

    private int _pointIndex;   //현재 위치한 경로

    private void Start()
    {
        SetPos();
        _stat.Set(Datas.status.hp, Datas.status.attack, Datas.status.speed);
    }


    private void Update()
    {
        if (_pointIndex<= Monster_Manager.Instanse.Points.Length-1)
        {

            //이동
            moveDistanse += Datas.status.speed *Time.deltaTime;
            transform.position = Vector3.MoveTowards
                (transform.position,
                Monster_Manager.Instanse.Points[_pointIndex].transform.position, Datas.status.speed * Time.deltaTime);

            // 목표 지점을 향해 회전
            Vector3 direction = Monster_Manager.Instanse.Points[_pointIndex].transform.position - transform.position; //목표지점을 바라보는 각도 구함
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up); // 이건 뭐지 더 공부
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1000 * Time.deltaTime);

            //다음 목표 설정
            if (transform.position == new Vector3(Monster_Manager.Instanse.Points[_pointIndex].transform.position.x,
                transform.position.y,Monster_Manager.Instanse.Points[_pointIndex].transform.position.z)){

                _pointIndex++;
            }
        }

        //죽을 때
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
