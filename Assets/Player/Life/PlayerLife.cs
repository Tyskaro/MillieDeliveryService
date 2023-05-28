using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Interface;

public class PlayerLife : Life
{
    [SerializeField] private Image image;
    private void UpdateDamage()
    {
        image.fillAmount = life / maxLife;
    }
    public override void Death()
    {
        Debug.Log("Player Morreu");
    }
    public override void ReceiveDamage(float damage)
    {
        base.ReceiveDamage(damage);
        UpdateDamage();
    }
}
