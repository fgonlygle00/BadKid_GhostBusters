using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Sniper_Bullet : Bullet_Prototype
{

    private void Update()
    {
        if (targetMonster != null)
        {
            // Ÿ�� ���� ���ϱ�
            Vector3 direction = (targetMonster.transform.position - transform.position).normalized;

            // Ÿ�� �������� ȸ��
            transform.LookAt(targetMonster.transform);

            // Ÿ�� �������� �̵�
            transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) // �浹ü�� ���� �±��� ���
        {
            Monster_Controller monsterStatus = other.GetComponent<Monster_Controller>(); // �ش� ������ �������ͽ��� ����
            if (targetMonster != null && monsterStatus != null)
            {
                if (targetMonster == monsterStatus)
                {
                    if (isUpgraded == true)   //���׷��̵� �� �� ���� ���ݷ� ��� + ���� ü�� ��� �߰� ����
                    {
                        monsterStatus.Hit(bulletDamage * 1.5f);

                        float currentHP = monsterStatus.ReturnHP();
                        float maxHP = monsterStatus.maxHP();

                        // ���� ü�°� �ִ� ü���� ���̿��� ���� ������ ����Ͽ� ���ظ� ����
                        float damagePercentage = 0.25f; // ���� ü���� 25% ����
                        float damage = (maxHP - currentHP) * damagePercentage;

                        // ���� ���ظ� ���Ϳ��� ������
                        monsterStatus.Hit(damage);
                    }
                    else
                    {
                        monsterStatus.Hit(bulletDamage);
                    }

                    //�浹ü�� 'Ÿ�� ����'�� ��쿡��
                    Destroy(gameObject);

 

                }
            }
        }
    }
}
