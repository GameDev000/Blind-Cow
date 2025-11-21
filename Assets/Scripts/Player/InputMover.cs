// using UnityEngine;
// using UnityEngine.InputSystem;

// /**
//  * This component moves its object when the player clicks the arrow keys.
//  */
// public class InputMover : MonoBehaviour
// {
//     [Tooltip("Speed of movement, in meters per second")]
//     [SerializeField] float speed = 10f;

//     [SerializeField]
//     InputAction move = new InputAction(type: InputActionType.Value, expectedControlType: nameof(Vector2));

//     void OnEnable()
//     {
//         move.Enable();
//     }

//     void OnDisable()
//     {
//         move.Disable();
//     }

//     void Update()
//     {
//         Vector2 moveDirection = move.ReadValue<Vector2>();
//         Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
//         transform.position += movementVector;
//     }
// }


using UnityEngine;
using UnityEngine.InputSystem;

public class InputMover : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    [SerializeField]
    InputAction move = new InputAction(
        type: InputActionType.Value,
        expectedControlType: nameof(Vector2));

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = move.ReadValue<Vector2>();
        Vector2 movement = moveDirection * speed;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
