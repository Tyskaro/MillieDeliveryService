using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject objectiveA;
    public GameObject objectiveB;
    public GameObject reset;
    public float speed;
    private bool negative = false;
    private IEnumerator WalkTo()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        if(transform.position.y >= objectiveB.transform.position.y && negative == false)
        {
            negative = true;
            speed = speed * -1;
            transform.Rotate(0, 0, 180);
        }else if(transform.position.y <= objectiveA.transform.position.y && negative)
        {
            negative = false;
            speed = speed * -1;
            transform.Rotate(0, 0, 180);
        }
        yield return 0;
        StartCoroutine(WalkTo());


    }
    private void Start()
    {
        StartCoroutine(WalkTo());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameManager.player)
        {
            GameManager.player.transform.position = reset.transform.position;
        }
    }
}
