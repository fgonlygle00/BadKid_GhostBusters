using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invasion_Controller : MonoBehaviour  //충돌체 갖고 있음
{
    public int Health;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void FinalCheckpoint()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //태그 몬스터일 경우  
        //몬스터 스크립트에 붙은 Attack (공격력)을 가져와서 HP를 그만큼 깎을거에요
        //if (other.CompareTag == CompareTag("Enemy"))
        //{

        //}

        if(Health<=0)
        {
            //FinalCheckpoint();
            //혜림님의 스크립트가 퍼블릭이라면 그 엔딩 호출(씬전환 함수까지) 를 여기서 부르고싶다
        }
    }
}
