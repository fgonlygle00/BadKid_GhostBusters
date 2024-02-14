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
        if (Monster_Manager.Instanse._monsters.Count == 0)
        {
            return null;
        }

        Monster_Controller max_hp_Monster = null;
        float max_hp = 0;

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
            {
                // 이 오브젝트의 위치를 가져오기
                Vector3 monsterPosition = monster.transform.position;
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
}
