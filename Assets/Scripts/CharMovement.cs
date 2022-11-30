using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public GameObject cam;
    Quaternion StartRotation;
    float Ver, Hor, Jump, RotHor, RotVer, CurentSpeed = 0f;
    public float MoveSpeed = 5f, RunSpeed = 10f, CrawlSpeed = 2f, JumpSpeed = 110f, Sens = 10 , smoothBlend = 0.1f;
    bool IsGrounded = true;
    private Animator _animator;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
        }
    }

    /*void Move(float x, float y)
    {
        _animator.SetFloat("HorVelocity", CurentSpeed, smoothBlend, Time.deltaTime);
    }*/

    private void Start()
    {
        StartRotation = transform.rotation;
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        RotHor += Input.GetAxis("Mouse X") * Sens;
        RotVer += Input.GetAxis("Mouse Y") * Sens;
        RotVer = Mathf.Clamp(RotVer, -60, 60);
        Quaternion RotY = Quaternion.AngleAxis(RotHor, Vector3.up);
        Quaternion RotX = Quaternion.AngleAxis(-RotVer, Vector3.right);
        if (IsGrounded)
        {
            Ver = Input.GetAxis("Vertical") * Time.deltaTime * CurentSpeed;
            Hor = Input.GetAxis("Horizontal") * Time.deltaTime * CurentSpeed;
            Jump = Input.GetAxis("Jump") * Time.deltaTime * JumpSpeed;
            GetComponent<Rigidbody>().AddForce(transform.up * Jump, ForceMode.Impulse);
        }
        transform.Translate(new Vector3(Hor, 0, Ver));
        cam.transform.rotation = StartRotation * transform.rotation * RotX;
        transform.rotation = StartRotation * RotY;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            CurentSpeed = RunSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            CurentSpeed = CrawlSpeed;
        }
        else 
        {
            CurentSpeed = MoveSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("IsRuning", true);
        }
        else
        {
            _animator.SetBool("IsRuning", false);
        }
        _animator.SetFloat("HorVelocity", Ver/Time.deltaTime/CurentSpeed, smoothBlend, Time.deltaTime);
    }
}
