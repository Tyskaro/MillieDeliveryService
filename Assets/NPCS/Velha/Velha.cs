using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velha : NPC
{
    public GameObject pacote;
    public GameObject portal;
    public override void EndDialogEvent()
    {
        base.EndDialogEvent();
        pacote.SetActive(false);
        portal.SetActive(true);
    }
}
