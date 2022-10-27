using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Vector3 moveForce;

    [SerializeField] private float jumpForce;
    [SerializeField] private float climbForce;
    [SerializeField] private float gravity;
    public float defaultGravity = 20f;

    public CharacterController characterController;
    private RaycastHit hit;
    private bool canClimb;
    private int canJumpCount = 0;

    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (!characterController.isGrounded) moveForce.y += gravity * Time.deltaTime * -1;
        else
        {
            gravity = defaultGravity;
            canJumpCount = 0;
        }

        characterController.Move(moveForce * Time.deltaTime);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            canClimb = false;
            if (hit.transform.tag == "Wall")
            {
                canClimb = true;
            }
        }
    }
    public void MoveTo(Vector3 dir)
    {
        dir = transform.rotation * new Vector3(dir.x, 0, dir.z);
        moveForce = new Vector3(dir.x * moveSpeed, moveForce.y, dir.z * moveSpeed);
    }
    public void Jump()
    {
        if (characterController.isGrounded)
        {
            moveForce.y = jumpForce;
            canJumpCount++;
        }
        else if (canJumpCount == 0)
        {
            moveForce.y = jumpForce;
            canJumpCount++;
        }
    }
    public bool Q()
    {
        return true;
    }
    public void Climb()
    {
        if (canClimb)
        {
            gravity = 0f;
            moveForce.y = climbForce;

        }
        else gravity = defaultGravity;
    }
}
