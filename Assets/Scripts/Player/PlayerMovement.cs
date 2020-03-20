using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3.0f;

    public float zSpeed = 1.5f;

    private CharacterAnimation playerAnimation;
    private Rigidbody myBody;

    private float rotationSpeed = 15.0f;
    private float rotationY = -90f;

    private void DetectMovement()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * -walkSpeed,
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * -zSpeed
        );
    }

    private void FixedUpdate()
    {
        DetectMovement();
    }

    private void RotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(rotationY), 0f);
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, +Mathf.Abs(rotationY), 0f);
        }

        if (Input.GetAxisRaw(Axis.VERTICAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw(Axis.VERTICAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void Start()
    {
        playerAnimation = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }

    void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            playerAnimation.Walk(true);
        }
        else
        {
            playerAnimation.Walk(false);
        }
    }
}