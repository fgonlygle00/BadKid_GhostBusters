using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Heal : MonoBehaviour
{
    public int[] Healindex;
    [SerializeField]private float healPersent;
    [SerializeField]private float _curHealPersent;

    public GameObject particleSystem;
    private void Start()
    {
        _curHealPersent = healPersent;
        particleSystem.SetActive(false);
    }


    public float Heal()
    {
        Debug.Log("Èú");
        particleSystem.SetActive(true);

        Debug.Log((_curHealPersent / 100));
        return (_curHealPersent / 100);

        Invoke("PaticlrStop", 2f);
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
        particleSystem.SetActive(false); 
    }
}
