using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface
{
    public interface IDamageble
    {
        public void TakeDamage(float damage);
        public void Die();
    }
}
