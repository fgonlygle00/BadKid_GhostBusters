using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Beam_Tower : Tower_Prototype
{
    // 기본 속성


    // 추가 속성
    // public int level;
    // public float upgradeCost;
    // public float upgradedAttackDamage;
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;

     public override Monster_Controller MonsterTargeting()
    {
        Monster_Controller max_hp_Monster = null;
        float max_hp = 0;

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
            {
                // 이 오브젝트의 위치를 가져오기
                Vector3 monsterPosition = monster.transform.position;
                Vector3 center = transform.position;
                float hp = monster.ReturnHP();

                // 좌표 범위 내에 있는지 확인
                if (Vector3.Distance(center, monsterPosition) <= radius)
                {
                    // 'hp'값이 현재 최대값보다 큰지 확인
                    if (hp > max_hp)
                    {
                        max_hp = hp;
                        max_hp_Monster = monster;
                    }
                }
            }
        }
        if (max_hp == 0)
        {
            max_hp_Monster = null;
        }

        return max_hp_Monster;
    }
 
    

    /* Monster_Controller MonsterTargeting() //몬스터를 타겟팅하는 메서드
    {
        List<Monster_Controller> monsterList = Monster_Manager.Instanse._monsters; //몬스터 리스트를 불러온다.

        Monster_Controller targetMonster = null;
        float maxMoveDistance = float.MinValue;

        foreach (Monster_Controller monster in monsterList) //몬스터 리스트 중에서 가장 앞서나가는 몬스터를 찾는다.
        {
            float monsterMoveDistance = monster.GetComponent<Monster_Controller>().moveDistanse; //moveDistanse값이 가장 높은 몬스터를 찾는다.

            if (monsterMoveDistance > maxMoveDistance)
            {
                maxMoveDistance = monsterMoveDistance;
                targetMonster = monster;
            }
        }

        return targetMonster;  //가장 앞선 몬스터를 리턴
    }
    */

    void LookTargetMonster() //몬스터를 바라보는 메서드
    {
        Monster_Controller targetMonster = MonsterTargeting();

        if (targetMonster != null)
        {
            Vector3 direction = targetMonster.transform.position - transform.position;
            direction.y = 0f; // Optional: Keep the rotation only in the horizontal plane

            transform.rotation = Quaternion.LookRotation(direction);
        }

    }
}
