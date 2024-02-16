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

    Monster_Controller past_Monster = null;
    public float sum = 0;


    public override void BasicAttack() //�⺻����
    {
        Monster_Controller targetMonster = MonsterTargeting(); //Ÿ�� ���͸� ���Ϲ޴´�

        if (targetMonster != null)
        {
            if (isUpgraded == true)
            {
                if (targetMonster == past_Monster)
                {
                    if (sum <= attackDamage * upgrade_Factor)
                    {
                        sum += 0.4f;
                    }
                }
                else
                {
                    sum = 0;
                }
                Vector3 direction = targetMonster.transform.position - transform.position;
                direction.y = 0f;
                transform.rotation = Quaternion.LookRotation(direction);

                Vector3 currentPosition = transform.position;
                currentPosition.y += 5f;

                GameObject bullet = Instantiate(bulletPrefab, currentPosition, Quaternion.identity); //�Ѿ� ������ �ν��Ͻ� ����

                Bullet_Prototype bulletScript = bullet.GetComponent<Bullet_Prototype>(); //�Ѿ� �ν��Ͻ��� �Ҹ� ������Ÿ�� ��ũ��Ʈ�� �����´�

                if (bulletScript != null)
                {

                    bulletScript.SetAttackDamage(attackDamage*1.15f + sum); //�Ҹ��� ���ݷ��� Ÿ�� ���ݷ����� ���� // �� Ÿ���� ���׷��̵� �� ������ �ٴ´�
                    bulletScript.SetTargetMonster(targetMonster); //�Ҹ��� Ÿ���� Ÿ�� ���ͷ� ����
                    past_Monster = targetMonster;
                }
                else
                {
                }
            }
            else
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

                    bulletScript.SetAttackDamage(attackDamage); //�Ҹ��� ���ݷ��� Ÿ�� ���ݷ����� ���� // �� Ÿ���� ������ �ٴ´�
                    bulletScript.SetTargetMonster(targetMonster); //�Ҹ��� Ÿ���� Ÿ�� ���ͷ� ����
                }
                else
                {
                }
            }
        }
    }


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
            return max_hp_Monster;
        }



        return max_hp_Monster;
    }
}
