using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Interface;

public class NPC_Base : MonoBehaviour
{
    [SerializeField] private string npcName;
    public bool bInteractable;
    [SerializeField] private string[] text;
    [SerializeField] private bool bLoop;
    [SerializeField] private bool bCanInteractJustOneTime;
    private bool canInteract = true;
    private int textPhase = 0;
    public Sprite npcImage;
    public PuzzleOne puzzle;
    public bool puzzleCan;
    private bool canClickOnScreen;
    void Start()
    {
        if(gameObject.tag == "Interactable")
        {
            print("Npc");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (canClickOnScreen && Input.GetMouseButtonDown(0))
        {
            if (bInteractable && canInteract)
            {
                StartCoroutine(DelayInteract());
                Dialog(textPhase);
                textPhase++;
                GameManager.canWalk = false;
            }
            else
            {
                canClickOnScreen = false;
                ShowNpcHud(false);
                GameManager.canWalk = true;
            }
        }
       RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right * 1.2f);
       RaycastHit2D hitt = Physics2D.Raycast(transform.position, transform.right * 1.2f);
       Debug.DrawRay(transform.position, transform.right * 1.2f, Color.green);
        
    }
    private IEnumerator DelayInteract()
    {
        canClickOnScreen = false;
        yield return new WaitForSeconds(0.1f);
        canClickOnScreen = true;
    }
    private void OnMouseDown()
    {
        if (bInteractable && canInteract)
        {
            Dialog(textPhase);
            canClickOnScreen= true;
            textPhase++;
            GameManager.canWalk = false;
        }
        else
        {
            canClickOnScreen = false;
            ShowNpcHud(false);
            GameManager.canWalk = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Errado");
            bInteractable = true;
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bInteractable = false;
        }
    }

    public void ShowNpcHud(bool show)
    {
        if (show)
        {
            GameManager.npcWidget.text = npcName;
            GameManager.npcText.text = text[0];
            GameManager.npcImage = npcImage;
            GameManager.ShowNpcHud(true);
        }
        else
        {
            GameManager.ShowNpcHud(false);
            GameManager.canWalk = true;
        }
    }
    public void Dialog(int dial)
    {
        if (dial < text.Length)
        {
            GameManager.npcText.text = text[dial];
            GameManager.npcWidget.text = npcName;
            GameManager.npcImage = npcImage;
            GameManager.ShowNpcHud(true);
        }
        else
        {
            GameManager.ShowNpcHud(false);
            StartCoroutine(Walk());
            NpcEndOverridable();
            if (bLoop)
            {
                textPhase = 0;
            }
            textPhase = (text.Length - 1);
            if (bCanInteractJustOneTime)
            {
                canInteract = false;
            }
            if (puzzleCan)
            {
                StartCoroutine(puzzle.CreatePuzzle());
		canInteract = false;
            }
        }
    }
    public virtual void NpcEndOverridable()
    {

    }
    public bool DialogEnded(int dial)
    {
        if(dial >= text.Length)
        {
            return (true);
        }
        else
        {
            return(false);
        }
    }
    private IEnumerator Walk()
    {
        yield return 0;
        GameManager.canWalk = true;

    }
}
