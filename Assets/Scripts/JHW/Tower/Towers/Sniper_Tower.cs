using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Sniper_Tower : Tower_Prototype
{

    // 추가 속성
    // public int level;
    // public float upgradeCost;
    // public float upgradedAttackDamage;
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;


    private void Update()
    {
        LookTargetMonster();
    }


    public override Monster_Controller MonsterTargeting() //몬스터를 타겟팅하는 메서드
    {
        if (Monster_Manager.Instanse._monsters.Count == 0)
        {
            return null;
        }

        Monster_Controller targetMonster = null;
        float maxMoveDistance = float.MinValue;

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters) //몬스터 리스트 중에서 가장 앞서나가는 몬스터를 찾는다.
        {
            if(monster != null)
            {
                float monsterMoveDistance = monster.GetComponent<Monster_Controller>().moveDistanse; //moveDistanse값이 가장 높은 몬스터를 찾는다.

                if (monsterMoveDistance > maxMoveDistance)
                {
                    maxMoveDistance = monsterMoveDistance;
                    targetMonster = monster;
                }
            }
        }

        return targetMonster;  //가장 앞선 몬스터를 리턴
    }
    

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
