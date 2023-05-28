using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class RedCrystal : NPC
{
    [SerializeField] private PostProcessProfile profile;
    [SerializeField] private PostProcessVolume postProcessVolume;
    [SerializeField] private RedCrytal_2 second;
    [SerializeField] private PlayerInteractSystem player;
    [SerializeField] private GameObject gem;
    public override void EndDialogEvent()
    {
        base.EndDialogEvent();
        postProcessVolume.profile = profile;
        StartCoroutine(Dialogue());
    }
    private IEnumerator Dialogue()
    {
        yield return 0;
        player.interactable = gameObject;
        Destroy(gem);
        second.CreateDialog();
    }
}
