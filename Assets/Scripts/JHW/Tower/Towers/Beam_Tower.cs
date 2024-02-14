using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Beam_Tower : Tower_Prototype
{
    // �⺻ �Ӽ�


    // �߰� �Ӽ�
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
                // �� ������Ʈ�� ��ġ�� ��������
                Vector3 monsterPosition = monster.transform.position;
                float hp = monster.ReturnHP();

                // ��ǥ ���� ���� �ִ��� Ȯ��
                if (Vector3.Distance(center, monsterPosition) <= radius)
                {
                    // 'hp'���� ���� �ִ밪���� ū�� Ȯ��
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
