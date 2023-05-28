using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GreenCrystal : NPC
{
    [SerializeField] private GameObject crystal;
    [SerializeField] private PostProcessProfile profile;
    [SerializeField] private PostProcessVolume postProcessVolume;
    [SerializeField] private PlayerInteractSystem player;
    [SerializeField] private NPC npc;

    public override void EndDialogEvent()
    {
        base.EndDialogEvent();
        postProcessVolume.profile = profile;
        StartCoroutine(Dialogue());
    }

    private IEnumerator Dialogue()
    {
        yield return 0;
        player.interactable = npc.gameObject;
        Destroy(crystal);
        npc.CreateDialog();
    }

}
