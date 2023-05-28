using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRigidBody;
    private float playerSpeed;
    [SerializeField] private float playerWalkSpeed = 5f;//Speed for player walking
    [SerializeField] private float playerRunSpeed = 10f;//Speed for player running
    [SerializeField] private float dashTimerMultiplier = 1f;
    private float dashTime;
    private bool bCanDash = true;
    private bool bVertical;
    [SerializeField]private Camera cam;
    private bool bInteracting;
    private NPC_Base npcInteracted;
    private int dialogInt=0;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerSpeed = playerWalkSpeed;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (bInteracting == false && hit)
            {
                if (hit.collider.gameObject.tag == "Interactable" && hit.collider.gameObject.GetComponent<NPC_Base>().bInteractable == true)
                {
                    npcInteracted = hit.collider.gameObject.gameObject.GetComponent<NPC_Base>();
                    hit.collider.gameObject.GetComponent<NPC_Base>().ShowNpcHud(true);
                    bInteracting = true;
                }
            }
            else if(npcInteracted != null)
            {
                dialogInt++;
                npcInteracted.Dialog(dialogInt);
                if (npcInteracted.DialogEnded(dialogInt))
                {
                    dialogInt = 0;
                    npcInteracted = null;
                    bInteracting = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.canWalk)
        {
            if (Input.GetAxisRaw("PRETO0") != 0 && bCanDash == true)
            {
                StartCoroutine(Dash());
            }
            playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("HORIZONTAL0") * playerSpeed, Input.GetAxisRaw("VERTICAL0") * playerSpeed);
            if (Input.GetAxisRaw("HORIZONTAL0") > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (Input.GetAxisRaw("HORIZONTAL0") < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else
        {
            playerRigidBody.velocity = new Vector2(0, 0);
        }
        if (Input.GetKey("r"))
        {
            Application.Quit();
            print("F");
        }
      
    }
    public void StopAllMovement()
    {
        playerRigidBody.velocity = new Vector2(0,0);
    }
    private IEnumerator Dash()
    {
        if(Input.GetAxisRaw("RunKey") != 0 && playerRigidBody.velocity != new Vector2(0, 0))
        {
            playerSpeed = playerRunSpeed;
        }
        yield return new WaitForSeconds(0.1f);
        dashTime += dashTimerMultiplier;
        if(Input.GetAxisRaw("RunKey") == 0 || playerRigidBody.velocity == new Vector2(0, 0) || dashTime >= 1)
        {
            if (bCanDash == true)
            {
                StartCoroutine(ResetDash(true));
            }
        }
    }
    private IEnumerator SpeedDecrease()
    {
        yield return new WaitForSeconds(0.1f);
        if (playerSpeed > playerWalkSpeed)
        {
            playerSpeed -= 1f;
            StartCoroutine(SpeedDecrease());
        }
        else
        {
            playerSpeed = playerWalkSpeed;
        }
    }
    private IEnumerator ResetDash(bool start) 
    {
        if(start == true)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(SpeedDecrease());
            bCanDash = false;
            dashTime += 3;
        }
        if(bCanDash == false) 
        {
            dashTime -= dashTimerMultiplier;
        }
        if(dashTime < 1.2)
        {
            dashTime = 0;
            bCanDash = true;
            GetComponent<SpriteRenderer>().color = Color.white;
            print("Can Dash");
        }
            yield return new WaitForSeconds(0.1f);
        if(bCanDash == false)
        {
            StartCoroutine(ResetDash(false));
        }
    }
}
