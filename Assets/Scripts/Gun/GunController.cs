using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spRendererWeapon;
    [SerializeField] GameObject prefabBullet;
    [SerializeField] GameObject aimLock;

    [SerializeField] bool attack = false;
    [SerializeField] float timeToAttack = 0.50f;
    [SerializeField] float timer = 0.50f;

    private void Start()
    {
        spRendererWeapon = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        Aim();
        
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= timeToAttack)
        {
            timer = 0;
            Instantiate(prefabBullet, aimLock.transform.position, aimLock.transform.rotation);
        }
    }    

    void Aim() 
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offSet = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offSet.y, offSet.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        //spRendererWeapon.flipY = (mousePos.x < screenPoint.x);
    }
}
