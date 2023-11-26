using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField]  Rigidbody2D rb2D;

    [SerializeField]  float speed = 5f;

    [SerializeField] Vector2 movPlayer;

    [SerializeField] SpriteRenderer spritePlayer;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spritePlayer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        movPlayer.x = Input.GetAxisRaw("Horizontal");
        movPlayer.y = Input.GetAxisRaw("Vertical");        
    }

    private void FixedUpdate()
    {
        MovePlayer();

        spritePlayer.flipX = movPlayer.x < 0 ? true : false;

    }

    public void MovePlayer()
    {
        rb2D.MovePosition(rb2D.position + movPlayer * speed * Time.fixedDeltaTime);        
    }
}
