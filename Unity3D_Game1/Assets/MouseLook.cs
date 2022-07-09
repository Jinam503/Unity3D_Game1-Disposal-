using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");//���콺 x��ǥ
        float mouseY = Input.GetAxis("Mouse Y");//���콺 y��ǥ

        OnMouseLook(new Vector2(mouseX, mouseY));
    }
    void OnMouseLook(Vector2 vec)//vec2 ���� �ٶ󺸱�
    {
        playerBody.Rotate(Vector2.up * vec.x);//����

        xRotation -= vec.y;//�¿�

        xRotation = Mathf.Clamp(xRotation, 30f, 150f);//60 -60 �ȿ�����
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//���ʹϾ����� ȸ��

    }
}
