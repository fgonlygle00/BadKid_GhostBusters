using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower_Prototype : MonoBehaviour
{
    // �⺻ �Ӽ�
    public float attackDamage = 2; //�⺻��
    public float Defalt_attackDamage = 2;
    public float baseAttackRate = 1f; //����
    public float skillCastRate = 3f; //��ų��
    public float buffValue; //������
    public bool isUpgraded;
    public GameObject bulletPrefab; //�Ѿ� ������
    public string towerType; //Ÿ�� Ÿ��
    public int arr_Index; //�� Ÿ���� �迭ĭ ��ġ
    public float upgrade_Factor; // <<< ���׷��̵� �� ���ݷ� ���� ���� 


    //��Ÿ� �߽����� �ݰ�
    public Vector3 center;
    public float radius;


    // ����
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;
    // public string towerName; //Ÿ�� �̸�
    //
    // public string bulletType; //�Ѿ� Ÿ��
    // public float installationCost; //��ġ���

    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate); //�⺻ ���� �ֱ������� 
        /*InvokeRepeating("UseSkill", 0f, skillCastRate); //��ų �ֱ�������*/
    }

    private void Update()
    {
    }

    private void OnMouseOver()
    {
        // ���콺 ���� ��ư�� ������ �� üũ
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Clicked on Object: " + gameObject.name);
            Upgrade();
        }

        // ���콺 ������ ��ư�� ������ �� üũ
        if (Input.GetMouseButtonDown(1))
        {
            if (GoodsData.instance._cookies >= 10)
            { 
                Tower_Manager.Instance.ReRoll(arr_Index);
                Destroy(gameObject);
            }

            Debug.Log("Right Clicked on Object: " + gameObject.name);
        }
    }

    public virtual void Upgrade()  //���׷��̵� �޼���
    {
        if (isUpgraded == false)
        {
            isUpgraded = true;
            Defalt_attackDamage *= upgrade_Factor;
        }
        else
        {
            //���⿡ ���׷��̵尡 �Ұ����� �� �۵��� �Է��ϼ���
        }
    }

    public void Buffed(float newValue)  //���� �ޱ� �޼���
    {
        if (newValue >= 1)
        {
            attackDamage = Defalt_attackDamage*Tower_Manager.Instance.Buff_Value_Arr[arr_Index]; //�⺻���ݷ� * ������
        }

    }


    public virtual void BasicAttack() //�⺻����
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
            }
            else
            {
            }
        }
    }

    public virtual Monster_Controller MonsterTargeting()
    {

        if (Monster_Manager.Instanse._monsters.Count == 0)
        {
            return null;
        }

        Monster_Controller max_moveDistanse_Monster = null;
        float max_moveDistanse = float.MinValue;

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
            {
                // �� ������Ʈ�� ��ġ�� ��������
                Vector3 monsterPosition = monster.transform.position;

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
    


    void LookTargetMonster() //���͸� �ٶ󺸴� �޼���
    {
        Monster_Controller targetMonster = MonsterTargeting();

        if (targetMonster != null)
        {
            Vector3 direction = targetMonster.transform.position - transform.position;
            direction.y = 0f;

            transform.rotation = Quaternion.LookRotation(direction);
        }

    }

    public void Index_Get(int index)
    {
        arr_Index = index;
        if (arr_Index >= 0 && arr_Index <= 7)
        {
            center = new Vector3(70f, 0f, 190f);
            radius = 120f;
        }
        else if (arr_Index >= 8 && arr_Index <= 13)
        {
            center = new Vector3(289f, 0f, 86f);
            radius = 125f;
        }
        else if (arr_Index >= 14 && arr_Index <= 17)
        {
            center = new Vector3(356f, 0f, 279f);
            radius = 110f;
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
}
