using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface InteractableInterface
{
    void Interact();
}
public class NPC : MonoBehaviour, InteractableInterface
{
    public string[] dialogs;
    public Sprite npcFace;
    public string npcName;
    private int currentDialog = 0;
    public bool loopDialog;
    public void Start()
    {

    }
    public void CreateDialog()
    {
        if (CanTalk())
        {
            if (currentDialog + 1 <= dialogs.Length)
            {
                GameManager.npcWidget.text = npcName;
                GameManager.npcText.text = dialogs[currentDialog];
                GameManager.npcImage = npcFace;
                currentDialog++;
                GameManager.canWalk = false;
                GameManager.ShowNpcHud(true);
            }
            else
            {
                GameManager.canWalk = true;
                EndDialogEvent();
                GameManager.ShowNpcHud(false);
                if (loopDialog)
                {
                    currentDialog = 0;
                }
            }
        }
    } 
    public virtual bool CanTalk()
    {
        return true;
    }
    public virtual void Interact()
    {
        if (Vector2.Distance(GameManager.player.transform.position, gameObject.transform.position) < 100.4f)
        {
            Debug.Log("Da pra interagir");
            CreateDialog();
        }
    }
    public virtual void EndDialogEvent()
    {

    }
}
