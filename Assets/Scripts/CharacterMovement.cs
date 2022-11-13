using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    Rigidbody2D player;

    float horizontal;
    float vertical;

    public float runSpeed = 5.0f;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        player.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

}
