using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : Life
{
    public override void ReceiveDamage(float damage)
    {
        base.ReceiveDamage(damage);
        Debug.Log(life);
    }
    public override void Death()
    {
        Destroy(gameObject);
    }

}
