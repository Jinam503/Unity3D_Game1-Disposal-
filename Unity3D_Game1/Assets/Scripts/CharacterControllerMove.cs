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
    [SerializeField] private float gravity;
    public float defaultGravity = 20f;

    public CharacterController characterController;

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
        else gravity = defaultGravity;
        characterController.Move(moveForce * Time.deltaTime);
    }
    public void MoveTo(Vector3 dir)
    {
        dir = transform.rotation * new Vector3(dir.x, 0, dir.z);
        moveForce = new Vector3(dir.x * moveSpeed, moveForce.y, dir.z * moveSpeed);
    }
    public void Jump()
    {
        if (characterController.isGrounded) moveForce.y = jumpForce;
    }
    public void FallAfterJump()
    {
        RaycastHit hit;
        if (!characterController.isGrounded && PlayerData.Instance.PlayerSkill[0])
        {
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 1000f))
            {
                if (hit.collider.tag == "Wall")
                {
                    MoveTo(new Vector3(hit.point.x , hit.point.y, hit.point.z * -1));
                    Debug.Log(hit.point);
                    Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * hit.distance, Color.red);
                }
            }
            //gravity *= 10;
        }
    }


}
