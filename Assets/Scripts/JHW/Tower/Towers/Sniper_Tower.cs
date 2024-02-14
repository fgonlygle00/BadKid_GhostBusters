using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Sniper_Tower : Tower_Prototype
{

    // �߰� �Ӽ�
    // public int level;
    // public float upgradeCost;
    // public float upgradedAttackDamage;
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;


    private void Update()
    {
        LookTargetMonster();
    }


    public override Monster_Controller MonsterTargeting() //���͸� Ÿ�����ϴ� �޼���
    {
        if (Monster_Manager.Instanse._monsters.Count == 0)
        {
            return null;
        }

        Monster_Controller targetMonster = null;
        float maxMoveDistance = float.MinValue;

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters) //���� ����Ʈ �߿��� ���� �ռ������� ���͸� ã�´�.
        {
            if(monster != null)
            {
                float monsterMoveDistance = monster.GetComponent<Monster_Controller>().moveDistanse; //moveDistanse���� ���� ���� ���͸� ã�´�.

                if (monsterMoveDistance > maxMoveDistance)
                {
                    maxMoveDistance = monsterMoveDistance;
                    targetMonster = monster;
                }
            }
        }

        return targetMonster;  //���� �ռ� ���͸� ����
    }
    

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
