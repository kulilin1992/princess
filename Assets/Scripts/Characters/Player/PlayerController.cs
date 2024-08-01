using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;

    Rigidbody rigidBody;

    PlayerGroundDetector playerGroundDetector;

    public float MoveSpeed => Mathf.Abs(rigidBody.velocity.x);

    public bool IsGrounded => playerGroundDetector.IsGrounded;

    public bool IsFalling => rigidBody.velocity.y < 0 && !IsGrounded;

    public bool CanAirJump;
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
        playerGroundDetector = GetComponentInChildren<PlayerGroundDetector>();
    }

    void Start()
    {
        playerInput.EnableGamePlayInputs();
    }

    public void Move(float speed)
    {
        if (playerInput.StartMove)
        {
            transform.localScale = new Vector3(playerInput.AxisX, 1, 1);
        }
        SetVelocityX(speed * playerInput.AxisX);
    }

    public void SetVelocity(Vector3 velocity)
    {
        rigidBody.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rigidBody.velocity = new Vector3(velocityX, rigidBody.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, velocityY);
    }

    public void SetUseGravity(bool useGravity)
    {
        rigidBody.useGravity = useGravity;
    }
}
