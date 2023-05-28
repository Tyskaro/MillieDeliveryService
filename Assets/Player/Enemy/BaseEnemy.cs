using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    private GameObject player;
    private bool bSeePlayer;
    [SerializeField] private Vector2 speed = new Vector2(0.75f, 0.1f);
    private Rigidbody2D rigidBodyEnemy;
    private void Start()
    {
        rigidBodyEnemy = GetComponent<Rigidbody2D>();
        StartCoroutine(FollowPlayer());
        player = GameManager.player;
    }
    public virtual void SeePlayer(GameObject playerReference)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            bSeePlayer = true;
        }
    }
    private IEnumerator FollowPlayer()
    {
        yield return 0;
        transform.LookAt(player.transform.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        rigidBodyEnemy.MovePosition(player.GetComponent<Rigidbody2D>().position + speed*Time.fixedDeltaTime);
        StartCoroutine(FollowPlayer());

    }
}
