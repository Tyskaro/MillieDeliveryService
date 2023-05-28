using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evellyn : NPC
{
    [SerializeField] private GameObject screenItem;
    public override void EndDialogEvent()
    {
        screenItem.SetActive(true);
    }
}
