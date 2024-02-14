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
        Monster_Controller max_hp_Monster = null;
        float max_hp = 0;

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
            {
                // �� ������Ʈ�� ��ġ�� ��������
                Vector3 monsterPosition = monster.transform.position;
                Vector3 center = transform.position;
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
 
    

    /* Monster_Controller MonsterTargeting() //���͸� Ÿ�����ϴ� �޼���
    {
        List<Monster_Controller> monsterList = Monster_Manager.Instanse._monsters; //���� ����Ʈ�� �ҷ��´�.

        Monster_Controller targetMonster = null;
        float maxMoveDistance = float.MinValue;

        foreach (Monster_Controller monster in monsterList) //���� ����Ʈ �߿��� ���� �ռ������� ���͸� ã�´�.
        {
            float monsterMoveDistance = monster.GetComponent<Monster_Controller>().moveDistanse; //moveDistanse���� ���� ���� ���͸� ã�´�.

            if (monsterMoveDistance > maxMoveDistance)
            {
                maxMoveDistance = monsterMoveDistance;
                targetMonster = monster;
            }
        }

        return targetMonster;  //���� �ռ� ���͸� ����
    }
    */

    void LookTargetMonster() //���͸� �ٶ󺸴� �޼���
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
