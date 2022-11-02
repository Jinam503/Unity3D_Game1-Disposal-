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
    [SerializeField]  private Animator anim;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerRotate = GetComponent<PlayerRotate>();
        movement = GetComponent<CharacterControllerMove>();
        status = GetComponent<Status>();

        movement.MoveSpeed = status.WalkSpeed;
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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
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
