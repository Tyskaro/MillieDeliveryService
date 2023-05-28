using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCrytal_2 : NPC
{
    public LoadRegion load;
    public override void EndDialogEvent()
    {
        base.EndDialogEvent();
        load.Teleport();
    }
}
