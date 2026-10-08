using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] public float health = 100.0f;

    private Rigidbody2D rigidbody;

    private PlayerInput playerInput;
    private InputAction inputAction;
    private UI canvas;

    private Vector2 moveDir;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

        rigidbody.MovePosition(rigidbody.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }
}
