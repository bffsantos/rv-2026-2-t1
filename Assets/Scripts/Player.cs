using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] public float health = 100.0f;

    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private PlayerInput playerInput;
    private InputAction inputAction;
    private UI canvas;

    private Vector2 moveDir;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions["Move"];

        canvas = FindFirstObjectByType<UI>();

        canvas.UpdateHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = inputAction.ReadValue<Vector2>();
        float vertical = moveInput.y;
        float horizontal = moveInput.x;

        moveDir = new Vector2(horizontal, vertical);

        Movement();

        PlayerAnimation();
    }

    private void PlayerAnimation()
    {
        if (moveDir != Vector2.zero)
        {
            SetAnimationParam("Move", true);

            if (moveDir.x < 0) spriteRenderer.flipX = false;
            else if (moveDir.x > 0) spriteRenderer.flipX = true;
        }
        else
        {
            SetAnimationParam("Move", false);
        }
    }

    private void Movement()
    {
        rigidbody.MovePosition(rigidbody.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }
    
    private void SetAnimationParam(string key, bool value)
    {
        if(animator != null)
            animator.SetBool(key, value);
    }
}
