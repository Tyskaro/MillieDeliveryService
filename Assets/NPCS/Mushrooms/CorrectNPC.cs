using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectNPC : NPC
{
    public PlayerInteractSystem system;
    public override void EndDialogEvent()
    {
        GreenCave.Correct();
        system.interactable = null;
        
    }
}
