using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Heal : MonoBehaviour
{
    public int[] Healindex;
    [SerializeField]private float healPersent;
    [SerializeField]private float _curHealPersent;

    public ParticleSystem particleSystem;
    private void Start()
    {
        _curHealPersent = healPersent;
        particleSystem.Stop();
    }


    public float Heal()
    {
        EffectHeal();

        Debug.Log((_curHealPersent / 100));
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

    IEnumerator EffectHeal()
    {
        particleSystem.Play();

        yield return new WaitForSeconds(2f);

        particleSystem.Stop();

        yield break;
    }
}
