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

                if (_monsterHeal != null)
                {
                    Debug.Log("왜 안돼냐");
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

        //죽을 때
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

    //HP 값 리턴
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
