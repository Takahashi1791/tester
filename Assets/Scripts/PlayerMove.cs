using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 50f;
    private float cameraSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //プレイヤーの移動処理
        //前に進む
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * moveSpeed);
        }
        //後ろに進む
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * moveSpeed);
        }
        //右に進む
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * moveSpeed);
        }
        //左に進む
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * moveSpeed);
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.A) )
        {
            rb.velocity = Vector3.zero;
        }

        //マウスでカメラの視点を操作する
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X") * cameraSpeed;
            if (Mathf.Abs(x) > 0.1f)
            {
                transform.RotateAround(transform.position, Vector3.up, x);
            }
        }
    }
}
