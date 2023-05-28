using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCrystal2 : NPC
{
    [SerializeField] private LoadRegion region;
    public override void EndDialogEvent()
    {
        base.EndDialogEvent();
        region.Teleport();

    }

}
