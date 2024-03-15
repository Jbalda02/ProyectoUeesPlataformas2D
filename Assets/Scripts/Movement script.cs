using UnityEngine;

public class Movementscript : MonoBehaviour
{
    public LayerMask Ground;
    [SerializeField] private float bulletOffset;
    [SerializeField] private float BulletForce;
    [SerializeField] public float jumpForce;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float dirX;
    [SerializeField] private GameObject BulletPrefab;
    private Animator anim;
    private PolygonCollider2D coll;
    private bool isGrounded;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector3 BulletSpawn;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        BulletSpawn = transform.position;
    }

    private void Update()
    {
        MovementRoutine();
        UpdateAnimationState();
    }

    private void MovementRoutine()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        if (Input.GetKeyDown(KeyCode.E))
        {
            BulletSpawn =new Vector3(transform.position.x +  bulletOffset ,transform.position.y,transform.position.z);
            GameObject BulletInstace = (GameObject) Instantiate(BulletPrefab, BulletSpawn,  BulletPrefab.transform.rotation);
            Rigidbody2D projectileRb = BulletInstace.GetComponent<Rigidbody2D>();
            projectileRb.velocity = new Vector2(BulletForce,0);
            
        
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
            state = MovementState.jumping;
        else if (rb.velocity.y < -.1f) state = MovementState.falling;

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, Ground);
    }

    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    }
}