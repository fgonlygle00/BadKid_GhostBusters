using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invasion_Controller : MonoBehaviour  //�浹ü ���� ����
{
    [SerializeField]private float Health;


    public float ReturnHealth()
    {
        return Health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Health -= other.gameObject.GetComponent<Monster_Controller>().Attack();
            Destroy(other.gameObject);
        }
    }
}
