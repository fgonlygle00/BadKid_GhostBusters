using System.Collections;
using System.Threading;
using UnityEngine;

public class Cannon_Bullet : Bullet_Prototype
{
    private Vector3 target_Point;
    private bool hasReachedTarget = false;
    private float arrivalTime;
    private float explosionRadius = 50f;

    public GameObject paticleObject;
    GameObject _paticle;

    public override void SetTargetMonster(Monster_Controller target)
    {
        target_Point = target.transform.position;
    }

    public override void Upgraded(bool _isUpgraded)
    {
        isUpgraded = _isUpgraded;
        if (isUpgraded == true)
        {
            explosionRadius = 70f;
        }
    }




    private void Update()
    {
        if (!hasReachedTarget)
        {
            Vector3 direction = (target_Point - transform.position).normalized;
            transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);

            // ���� Ȯ��
            if (Vector3.Distance(transform.position, target_Point) < 5f)
            {
                hasReachedTarget = true;
                arrivalTime = Time.time;
            }
        }
        else
        {
            // ���� �� 2.5�ʰ� ������ splash_Damage ȣ��
            if (Time.time - arrivalTime >= 2f)
            {
                splash_Damage();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Monster_Controller monsterStatus = other.GetComponent<Monster_Controller>();
            if (monsterStatus != null)
            {
                monsterStatus.Hit(bulletDamage*0.75f);
            }
            splash_Damage();
        }
    }

    void splash_Damage()
    {
        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
            {
                // ���� ��ġ�� �����´�
                Vector3 monsterPosition = monster.transform.position;

                // ��ǥ ���� ���� �ִ� ���͵鿡�� ���÷��� ���ظ� �ش�
                if (Vector3.Distance(transform.position, monsterPosition) <= explosionRadius)
                {
                    monster.Hit(bulletDamage *1f);

                }
            }
        }
        Destroy(gameObject);
    }

    IEnumerator CannonBullet()
    {
        _paticle = Instantiate(paticleObject);
        _paticle.transform.position = transform.position;
        yield return new WaitForSeconds(2f);
        Destroy(_paticle);
    }
}

