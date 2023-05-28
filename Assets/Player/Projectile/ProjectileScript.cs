using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interface;

public class ProjectileScript : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    private Rigidbody2D rigidBody;
    [SerializeField] private float force;
    [SerializeField] private float damage;
    public string ownPlayerTag;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rigidBody= GetComponent<Rigidbody2D>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rigidBody.velocity = new Vector2(direction.x, direction.y).normalized*force;
        float rot = Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        StartCoroutine(AutoDestroy());
    }
    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageble damagebleObject) && !collision.gameObject.CompareTag(ownPlayerTag))
        {
            damagebleObject.TakeDamage(damage);
        }
        if(!collision.gameObject.CompareTag(ownPlayerTag))
        {
            Destroy(gameObject);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
