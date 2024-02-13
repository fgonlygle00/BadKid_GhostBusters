using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Density_Enhance_Tower : MonoBehaviour
{
    // �⺻ �Ӽ�
    public float attackDamage = 2; //�⺻��
    public float skillDamage; //����
    public float baseAttackRate = 1f; //����
    public float skillCastRate = 5f; //��ų��
    public float buffValue; //������
    public float installationCost; //��ġ���
    public string towerName; //Ÿ�� �̸�
    public string towerType; //Ÿ�� Ÿ��
    public string bulletType; //�Ѿ� Ÿ��
    public GameObject bulletPrefab; //�Ѿ� ������
    private int arr_Index;


    //��Ÿ� �߽����� �ݰ�
    private Vector3 center;
    private float radius;


    // �߰� �Ӽ�
    // public int level;
    // public float upgradeCost;
    // public float upgradedAttackDamage;
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;

    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate); //�⺻ ���� �ֱ������� 
        InvokeRepeating("UseSkill", 0f, skillCastRate); //��ų �ֱ�������
    }

    private void Update()
    {
        LookTargetMonster();
    }


    void BasicAttack() //�⺻����
    {
        Monster_Controller targetMonster = MonsterTargeting(); //Ÿ�� ���͸� ���Ϲ޴´�

        if (targetMonster != null)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y += 5f;

            GameObject bullet = Instantiate(bulletPrefab, currentPosition, Quaternion.identity); //�Ѿ� ������ �ν��Ͻ� ����

            Bullet_Prototype bulletScript = bullet.GetComponent<Bullet_Prototype>(); //�Ѿ� �ν��Ͻ��� �Ҹ� ������Ÿ�� ��ũ��Ʈ�� �����´�

            if (bulletScript != null)
            {

                bulletScript.SetAttackDamage(attackDamage); //�Ҹ��� ���ݷ��� Ÿ�� ���ݷ����� ����
                bulletScript.SetTargetMonster(targetMonster); //�Ҹ��� Ÿ���� Ÿ�� ���ͷ� ����
            }
            else
            {
            }
        }
    }
    void UseSkill()
    {
        MonsterTargeting();
        // ��ų ��� ���� �߰�
        // UniqueSkillEffect();
    }


    /*

    Monster_Controller MonsterTargeting()
    {
        List<Monster_Controller> monsterList = Monster_Manager.Instanse._monsters;

        Monster_Controller max_moveDistanse_Monster = null;
        float max_moveDistanse = float.MinValue;

        foreach (Monster_Controller monster in monsterList)
        {
            // �� ������Ʈ�� ��ġ�� ��������
            Vector3 monsterPosition = monster.transform.position;
            Vector3 center = transform.position;

            // ����ĳ��Ʈ�� �̿��Ͽ� ������ ��ġ���� �浹�� ����
            RaycastHit hit;
            if (Physics.Raycast(center, monsterPosition - center, out hit, 150f))
            {
                // �浹�� ������Ʈ�� �������� Ȯ��
                Monster_Controller hitMonster = hit.collider.GetComponent<Monster_Controller>();
                if (hitMonster != null)
                {
                    // 'moveDistanse'���� ���� �ִ밪���� ū�� Ȯ��
                    if (hitMonster.moveDistanse > max_moveDistanse)
                    {
                        max_moveDistanse = hitMonster.moveDistanse;
                        max_moveDistanse_Monster = hitMonster;
                    }
                }
            }
        }

        return max_moveDistanse_Monster;
    }
    */


     Monster_Controller MonsterTargeting()
    {
        List<Monster_Controller> monsterList = Monster_Manager.Instanse._monsters;


        Monster_Controller max_moveDistanse_Monster = null;
        float max_moveDistanse = float.MinValue;

        foreach (Monster_Controller monster in monsterList)
        {
            if (monster != null)
            {
                // �� ������Ʈ�� ��ġ�� ��������
                Vector3 monsterPosition = monster.transform.position;
                Vector3 center = transform.position;

                // ��ǥ ���� ���� �ִ��� Ȯ��
                if (Vector3.Distance(center, monsterPosition) <= radius)
                {
                    // 'moveDistanse'���� ���� �ִ밪���� ū�� Ȯ��
                    if (monster.moveDistanse > max_moveDistanse)
                    {
                        max_moveDistanse = monster.moveDistanse;
                        max_moveDistanse_Monster = monster;
                    }
                }
            }
        }

        return max_moveDistanse_Monster;
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

    public void Index_Get(int index)
    {
        arr_Index = index;
        if (arr_Index >= 0 && arr_Index <= 7)
        {
            center = new Vector3(70f, 19.1f, 190f);
            radius = 113f;
        }
        else if (arr_Index >= 8 && arr_Index <= 13)
        {
            center = new Vector3(289f, 19.1f, 86f);
            radius = 125f;
        }
        else if (arr_Index >= 14 && arr_Index <= 17)
        {
            center = new Vector3(356f, 19.1f, 279f);
            radius = 102f;
        }
        else
        {
            // Handle invalid arr_Index here if needed
        }
    }

    // void UniqueSkillEffect()
    // {
    //     ������ ��ų ȿ�� ���� �߰�
    // }
}
