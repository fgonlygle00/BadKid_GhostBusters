using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Snow_Tower : Tower_Prototype
{
    // ����
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;
    // public string towerName; //Ÿ�� �̸�
    //
    // public string bulletType; //�Ѿ� Ÿ��
    // public float installationCost; //��ġ���
    public GameObject snow_Summon;



    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate); //�⺻ ���� �ֱ������� 
        InvokeRepeating("UseSkill", 0f, skillCastRate); //��ų �ֱ�������
    }

    public void UseSkill()
    {
        Monster_Controller targetMonster = MonsterTargeting_Random();
        if (targetMonster != null)
        {
            Vector3 direction = targetMonster.transform.position - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.LookRotation(direction);

            Vector3 pos = targetMonster.transform.position;
            pos.y += 1f;

            GameObject snow = Instantiate(snow_Summon, pos, Quaternion.identity); //������ ������ �ν��Ͻ� ����

            Snow_Summon snowScript = snow.GetComponent<Snow_Summon>(); //����� �ν��Ͻ��� ��ũ��Ʈ�� �����´�

            if (snowScript != null)
            {
                if (isUpgraded)
                {
                    snowScript.SetAttackDamage(attackDamage * upgrade_Factor); //���׷��̵� �� ��� �߰�    
                }
                else
                {
                    snowScript.SetAttackDamage(attackDamage);
                }
                snowScript.checkUpgrade(isUpgraded);
            }
        }
    }

    public Monster_Controller MonsterTargeting_Random()
    {
        if (Monster_Manager.Instanse._monsters.Count == 0)
        {
            return null;
        }

        List<Monster_Controller> validMonsters = new List<Monster_Controller>();

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
            {
                // �� ������Ʈ�� ��ġ�� ��������
                Vector3 monsterPosition = monster.transform.position;

                // ��ǥ ���� ���� �ִ��� Ȯ��
                if (Vector3.Distance(center, monsterPosition) <= radius)
                {
                    validMonsters.Add(monster);
                }
            }
        }

        // ��ǥ ���� ���� �ִ� ��ȿ�� ���Ͱ� ���ٸ� null ��ȯ
        if (validMonsters.Count == 0)
        {
            return null;
        }

        // �������� ���� �����Ͽ� ��ȯ
        int randomIndex = Random.Range(0, validMonsters.Count);
        return validMonsters[randomIndex];
    }
}
