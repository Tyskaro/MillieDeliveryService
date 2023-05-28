using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Millie_1 : NPC
{
    public PlayerInteractSystem player;
    public void Start()
    {
        player.interactable = gameObject;
        StartCoroutine(StartDialog());
    }
    private IEnumerator StartDialog()
    {
        yield return new WaitForSeconds(0.3f);
        CreateDialog();
    }
    public override void EndDialogEvent()
    {
        StartCoroutine(END());
    }
    private IEnumerator END()
    {
        yield return 0;
        GameManager.canWalk = true;
    }
}
