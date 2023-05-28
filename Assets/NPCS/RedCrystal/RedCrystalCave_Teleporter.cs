using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCrystalCave_Teleporter : LoadRegion
{
    [SerializeField] private NPC npc;
    [SerializeField] private PlayerInteractSystem player;
    public override void TeleportExtra()
    {
        base.TeleportExtra();
        StartCoroutine(WaitToTeleport());
    }
    private IEnumerator WaitToTeleport()
    {
        yield return 0;
        player.interactable = npc.gameObject;
        npc.CreateDialog();
    }
}
