using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Header("Footsteps")]
    public AudioSource footstepSource;
    public AudioClip footstepClip;
    public float stepInterval = 0.4f;
    private float stepTimer = 0f;

    [Header("Interaction")]
    private Collider2D currentInteractable;

    [Header("Animation")]
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");

        // Set IsMoving animation parameter
        bool isMoving = Mathf.Abs(moveInput.x) > 0.1f;
        animator.SetBool("IsMoving", isMoving);

        // Footstep sound timing
        if (rb.velocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer > stepInterval)
            {
                footstepSource.PlayOneShot(footstepClip);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }

        // Interaction input
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.SendMessage("OnInteract", SendMessageOptions.DontRequireReceiver);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            currentInteractable = other;
            animator.SetBool("isNearInteractable", true); 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            currentInteractable = null;
            animator.SetBool("isNearInteractable", false); 
        }
    }
}
