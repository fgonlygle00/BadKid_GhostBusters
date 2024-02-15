using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Flame_Tower : Tower_Prototype
{
    // ����
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;
    // public string towerName; //Ÿ�� �̸�
    //
    // public string bulletType; //�Ѿ� Ÿ��
    // public float installationCost; //��ġ���
    public GameObject flame_Summon;



    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate); //�⺻ ���� �ֱ������� 
        InvokeRepeating("UseSkill", 0f, skillCastRate); //��ų �ֱ�������
    }

    public void UseSkill()
    {
        Monster_Controller targetMonster = MonsterTargeting();
        if (targetMonster != null)
        {
            GameObject flame = Instantiate(flame_Summon, targetMonster.transform.position, Quaternion.identity); //�÷��� ������ �ν��Ͻ� ����

            Flame_Summon flameScript = flame.GetComponent<Flame_Summon>(); //�÷��� �ν��Ͻ��� ��ũ��Ʈ�� �����´�

            if (flameScript != null)
            {
                if (isUpgraded)
                {
                    flameScript.SetAttackDamage(attackDamage * upgrade_Factor); //���׷��̵� �� ��� �߰�
                    flameScript.checkUpgrade(isUpgraded);
                }
                else
                {
                    flameScript.SetAttackDamage(attackDamage);
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
