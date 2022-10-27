using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField] private KeyCode keyCodeRun = KeyCode.LeftShift;
    [SerializeField] private KeyCode keyCodeJump = KeyCode.Space;
    [SerializeField] private KeyCode keyCodeQSkill = KeyCode.Q;
    [SerializeField] private KeyCode keyCodeESkill = KeyCode.E;
    [SerializeField] private BoxCollider climbArea;

    private PlayerRotate playerRotate;
    private CharacterControllerMove movement;
    private Status status;
    private bool isSkill = false;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerRotate = GetComponent<PlayerRotate>();
        movement = GetComponent<CharacterControllerMove>();
        status = GetComponent<Status>();
    }
    private void Update()
    {
        if (!isSkill)
        {
            UpdateMove();
            UpdateJump();
        }
        UpdateRotate();
        UseSkill(); 
        
        
        
    }
    private void UseSkill()
    {
        if (Input.GetKey(keyCodeQSkill))
        {
            isSkill = movement.Q();
        }
            
    }
    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        if( x != 0 || z != 0)
        {
            bool isRun = false;

            if (z > 0) isRun = Input.GetKey(keyCodeRun);

            movement.MoveSpeed = isRun == true ? status.RunSpeed : status.WalkSpeed;
        }

        movement.MoveTo(new Vector3(x, 0, z));
    }
    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        playerRotate.UpdateRotate(mouseX, mouseY);
    }
    private void UpdateJump()
    {
        if (Input.GetKeyDown(keyCodeJump))
        {
            movement.Jump();
        }
        if (Input.GetKey(keyCodeJump))
        {
            movement.Climb();
        }
    }
}
