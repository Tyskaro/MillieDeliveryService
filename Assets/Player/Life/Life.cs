using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using static Interface;

public abstract class Life : MonoBehaviour, IDamageble
{
    public float maxLife;
    public float life;
    private float damageTimer;
    protected bool bDead;
    void Start()
    {
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        ReceiveDamage(damage);
    }
    public virtual void ReceiveDamage(float damage)
    {
        if (!bDead)
        {
            life -= damage;
            if (life <= 0)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        Death();
        bDead = true;
    }
    public virtual void Death()
    {
        Debug.Log("Morreu");
    }
}
