using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform groundChecker; 
    public LayerMask groundMask; //Ground 레이어마스크

    public float moveSpeed = 5f; //움직이는 속도
    public float jumpHeight = 7f;//점프 높이
    public float groundRadius = 0.5f;//

    [Range(1.0f, 3.0f)]
    public float gravityScale = 1f;//중력 1~3배

    Vector3 velocity;
    float gravity => -9.8f * gravityScale;//실제 중력값 적용
    bool isGrounded;//땅에 닿았는가

    CharacterController controller; //캐릭터 컨트롤러
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//커서 화면 안에 있게하기
        controller = GetComponent<CharacterController>(); //캐릭터 컨트롤러 컴포넌트 받아오기  
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();

        Movement();
        Jump();
        Gravity();

    }
    void CheckGround()//땅에 닿아있는가 (캐릭터 컨트롤러 isGrounded가 판정이 구려서 만듬)
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundRadius, groundMask);//그라운더체크 위치가 구모양 안에있고 그라운드마스크이면 isGrounded true
    }
    void Movement()
    {

        float inputX = Input.GetAxis("Horizontal");//키보드 좌 우
        float inputZ = Input.GetAxis("Vertical");//키보드 상 하

        Vector3 direction = (transform.right * inputX) + (transform.forward * inputZ);//앞 옆 보는 기준으로 더해주기
        
        controller.Move(direction * moveSpeed * Time.deltaTime); //캐릭터 컨트롤러로 움직이기
    }
    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);//스페이스를 누르면 velocity y 조정
        }
    }
    void Gravity()
    {
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;//velocity y를 중력값만큼 더하기
        controller.Move(velocity * Time.deltaTime);//velocity만큼 움직이기
    }
}
