using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WaterCrystal_NPC : NPC
{
    private bool canInteract;
    public GameObject collision;
    public NPC npc;
    [SerializeField] private PostProcessProfile profile;
    [SerializeField] private PostProcessVolume postProcessVolume;
    [SerializeField] private WaterCrystal2_NPC npcFinal;
    [SerializeField] private GameObject crystal;

    public void SetCanInteract(bool b)
    {
        canInteract = b;
        if (b)
        {
            npc.CreateDialog();
            collision.SetActive(false);
        }
    }
    public override bool CanTalk()
    {
        return canInteract;
    }
    public override void EndDialogEvent()
    {
        base.EndDialogEvent();
        StartCoroutine(DelayDialogEnd());

    }
    private IEnumerator DelayDialogEnd()
    {
        yield return 0;
        postProcessVolume.profile = profile;
        crystal.SetActive(false);
        npcFinal.CreateDialog();
    }

}
