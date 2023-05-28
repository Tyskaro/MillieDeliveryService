using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCrystal2_NPC : NPC
{
    public LoadRegion teleporter;
    public override void EndDialogEvent()
    {
        base.EndDialogEvent();
        teleporter.TeleportFade();
    }
}
