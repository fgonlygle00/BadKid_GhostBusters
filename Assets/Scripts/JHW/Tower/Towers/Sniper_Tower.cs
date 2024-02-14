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

    public override void BasicAttack() //�⺻����
    {
        Monster_Controller targetMonster = MonsterTargeting(); //Ÿ�� ���͸� ���Ϲ޴´�

        if (targetMonster != null)
        {
            Vector3 direction = targetMonster.transform.position - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.LookRotation(direction);

            Vector3 currentPosition = transform.position;
            currentPosition.y += 5f;

            GameObject bullet = Instantiate(bulletPrefab, currentPosition, Quaternion.identity); //�Ѿ� ������ �ν��Ͻ� ����

            Bullet_Prototype bulletScript = bullet.GetComponent<Bullet_Prototype>(); //�Ѿ� �ν��Ͻ��� �Ҹ� ������Ÿ�� ��ũ��Ʈ�� �����´�

            if (bulletScript != null)
            {

                bulletScript.SetAttackDamage(attackDamage); //�Ҹ��� ���ݷ��� Ÿ�� ���ݷ����� ����
                bulletScript.SetTargetMonster(targetMonster); //�Ҹ��� Ÿ���� Ÿ�� ���ͷ� ����
                bulletScript.Upgraded(isUpgraded);
            }
            else
            {
            }
        }
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
