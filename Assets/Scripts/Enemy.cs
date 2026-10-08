using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private UI canvas;

    private Vector2 moveDir;

    public Transform targetTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        canvas = FindFirstObjectByType<UI>();

        targetTransform = FindFirstObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform)
        {
            moveDir = (targetTransform.position - transform.position).normalized;

            rigidbody.MovePosition(rigidbody.position + moveDir * moveSpeed * Time.fixedDeltaTime);

            if (moveDir.x < 0) spriteRenderer.flipX = true;
            else if(moveDir.x > 0) spriteRenderer.flipX = false;
        }
        else
        {
            moveDir = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();

            player.health -= 5f;

            canvas.UpdateHealth(player.health);
        }
    }
}
