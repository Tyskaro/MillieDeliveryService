using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : NPC
{
    public GameObject botao;
    public PlayerInteractSystem system;
    public override void EndDialogEvent()
    {
        base.EndDialogEvent();
        system.interactable = null;
        botao.SetActive(true);
    }

}
