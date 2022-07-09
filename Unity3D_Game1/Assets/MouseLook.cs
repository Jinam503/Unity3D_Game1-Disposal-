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

        float mouseX = Input.GetAxis("Mouse X");//마우스 x좌표
        float mouseY = Input.GetAxis("Mouse Y");//마우스 y좌표

        OnMouseLook(new Vector2(mouseX, mouseY));
    }
    void OnMouseLook(Vector2 vec)//vec2 방향 바라보기
    {
        playerBody.Rotate(Vector2.up * vec.x);//상하

        xRotation -= vec.y;//좌우

        xRotation = Mathf.Clamp(xRotation, -60f, 60f);//60 -60 안에서만
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//쿼터니언으로 회전

    }
}
