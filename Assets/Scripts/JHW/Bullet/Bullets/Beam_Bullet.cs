using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Beam_Bullet : MonoBehaviour
{
    public float bulletSpeed = 1f;
    public float bulletDamage; // Ÿ�� ���ݷ¿� ����ϴ� ��
    public float bulletWeight;
    public Vector3 target_Point;

    public void SetAttackDamage(float damage)
    {
        bulletDamage = damage;
    }

    // Set the target monster for the bullet
    public void SetTargetMonster(Monster_Controller target)
    {
        target_Point = target.transform.position;
    }

    private void Update()
    {
        if (target_Point != null)
        {
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
            if (monsterStatus != null)
            {
                monsterStatus.Hit(bulletDamage);
            }

            Destroy(gameObject);
        }
    }
}
