using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Rigidbody2D rb;
    private float dirX, dirY, moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        dirY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }
}
