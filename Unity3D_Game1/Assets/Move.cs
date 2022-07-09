using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public Transform groundChecker; 
    public LayerMask groundMask; //Ground ���̾��ũ

    public float moveSpeed = 5f; //�����̴� �ӵ�
    public float jumpHeight = 7f;//���� ����
    public float groundRadius = 0.5f;//

    [Range(1.0f, 3.0f)]
    public float gravityScale = 1f;//�߷� 1~3��

    Vector3 velocity;
    float gravity => -9.8f * gravityScale;//람다식
    bool isGrounded;//���� ��Ҵ°�

    CharacterController controller; //ĳ���� ��Ʈ�ѷ�
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//Ŀ�� ȭ�� �ȿ� �ְ��ϱ�
        controller = GetComponent<CharacterController>(); //ĳ���� ��Ʈ�ѷ� ������Ʈ �޾ƿ���  
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();

        Movement();
        Jump();
        Gravity();

    }
    void CheckGround()//���� ����ִ°� (ĳ���� ��Ʈ�ѷ� isGrounded�� ������ ������ ����)
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundRadius, groundMask);//�׶���üũ ��ġ�� ����� �ȿ��ְ� �׶��帶��ũ�̸� isGrounded true
    }
    void Movement()
    {

        float inputX = Input.GetAxis("Horizontal");//Ű���� �� ��
        float inputZ = Input.GetAxis("Vertical");//Ű���� �� ��

        Vector3 direction = (transform.right * inputX) + (transform.forward * inputZ);//�� �� ���� �������� �����ֱ�

        Vector3 vec = new Vector3(inputX, 0, inputZ);
        anim.SetBool("Walk", vec.magnitude > 0);    

        controller.Move(direction * moveSpeed * Time.deltaTime); //ĳ���� ��Ʈ�ѷ��� �����̱�
    }
    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);//움직임 자연스럽게 하기위해 sqrt사용 
        }
    }
    void Gravity()
    {
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;//velocity y�� �߷°���ŭ ���ϱ�
        controller.Move(velocity * Time.deltaTime);//velocity��ŭ �����̱�
    }
}
