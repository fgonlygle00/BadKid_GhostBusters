using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invasion_Controller : MonoBehaviour  //충돌체 갖고 있음
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
