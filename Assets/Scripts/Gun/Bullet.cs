using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speedBullet;
    void Start()
    {
        
    }

    void Update()
    {

        transform.Translate(Vector3.right *Time.deltaTime * speedBullet);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
