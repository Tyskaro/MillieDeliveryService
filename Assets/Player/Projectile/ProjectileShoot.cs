using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    [SerializeField] private GameObject projectile;
    public Transform projectileTransform;
    public bool bCanFire;
    private float timer;
    public float timeBetweenFiring;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);
        if (!bCanFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                bCanFire = true;
                timer = 0;
            }
        }
        if(Input.GetMouseButtonDown(0)&& bCanFire)
        {
            bCanFire = false;
            Instantiate(projectile, projectileTransform.position, Quaternion.identity);
        }
    }
}
