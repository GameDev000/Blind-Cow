using UnityEngine;

public class runner : MonoBehaviour
{
     [SerializeField] private float speed = 3f;
    [SerializeField] private float directionChangeInterval = 2f;

    private Vector2 moveDirection;
    private float directionTimer;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ChooseNewDirection();
    }

    private void Update()
    {
        directionTimer -= Time.deltaTime;
        if (directionTimer <= 0f)
            ChooseNewDirection();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    private void ChooseNewDirection()
    {
        float angle = Random.Range(0f, 360f);
        float rad = angle * Mathf.Deg2Rad;

        moveDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;

        directionTimer = directionChangeInterval;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            ChooseNewDirection();
        }
    }
}
