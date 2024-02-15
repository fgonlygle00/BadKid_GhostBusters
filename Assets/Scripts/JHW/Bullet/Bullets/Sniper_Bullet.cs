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
                        float currentHP = monsterStatus.ReturnHP();
                        float maxHP = monsterStatus.maxHP();

                        float damageMultiplier = 1.0f + (1.0f - currentHP / maxHP); 
                        float calculatedDamage = bulletDamage * damageMultiplier; //���� ü�� ��� ���� ���� (�ִ� ���� �Ѿ� �������� 2��)

                        // ���� ü�°� �ִ� ü���� ���̿��� ���� ������ ����Ͽ� ���ظ� ����

                        // ���� ���ظ� ���Ϳ��� ������. �ѵ�����: �Ѿ� �������� 100~200%������ + ��ü�� ���� 5%
                        monsterStatus.Hit(calculatedDamage); 
                        monsterStatus.Hit((maxHP - currentHP) * 0.5f);
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
