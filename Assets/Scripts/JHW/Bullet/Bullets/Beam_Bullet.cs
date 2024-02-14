using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Beam_Bullet : Bullet_Prototype
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) // �浹ü�� ���� �±��� ���
        {
            Monster_Controller monsterStatus = other.GetComponent<Monster_Controller>(); // �ش� ������ �������ͽ��� ����
            if (targetMonster != null && monsterStatus != null)
            {
                if (targetMonster == monsterStatus)
                {
                    monsterStatus.Hit(bulletDamage); //�浹ü�� 'Ÿ�� ����'�� ��쿡��
                }
            }
            Destroy(gameObject);
        }
    }
}
