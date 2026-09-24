using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float spd = 5f;

    private Move controls;
    private Vector2 moveinput;

    private Animator anim;
    private Rigidbody2D rb;

    public bool FacingRight { get; private set; } = false;

    private void Awake()
    {
        controls = new Move();

        controls.Player.Move.performed += ctx =>
        {
            moveinput = ctx.ReadValue<Vector2>();
        };

        controls.Player.Move.canceled += ctx =>
        {
            moveinput = Vector2.zero;
        };
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void EnableControls()
    {
        controls.Enable();
    }

    public void DisableControls()
    {
        controls.Disable();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        anim.SetFloat("spd", moveinput.sqrMagnitude);

        if (moveinput.sqrMagnitude > 0.01f)
        {
            anim.SetFloat("Horizontal", moveinput.x);

            // Simpan arah terakhir player
            if (moveinput.x > 0)
            {
                FacingRight = true;
            }
            else if (moveinput.x < 0)
            {
                FacingRight = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveinput * spd;
    }
}