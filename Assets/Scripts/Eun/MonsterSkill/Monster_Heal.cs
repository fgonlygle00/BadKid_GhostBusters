using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Heal : MonoBehaviour
{
    public int[] Healindex;
    [SerializeField]private float healPersent;
    [SerializeField]private float _curHealPersent;

    public GameObject particleObject;
    private void Start()
    {
        _curHealPersent = healPersent;
        particleObject.SetActive(false);
    }


    public float Heal()
    {
        particleObject.SetActive(true);

        Invoke("PaticlrStop", 2f);
        return (_curHealPersent / 100);

    }

    public void ReturnHealPersent(float down)
    {
        _curHealPersent *= down;
    }

    public void ResetHeal()
    {
        _curHealPersent = healPersent;
    }

    void PaticlrStop()
    {
        particleObject.SetActive(false); 
    }
}
