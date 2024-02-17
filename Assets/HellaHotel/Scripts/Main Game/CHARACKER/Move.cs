using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    [SerializeField]private float speed;
    private float verticalRotation;
    private float horizontalRotation;
    private float sensitivity = 5;
    private float CurrentRotationX;
    private float CurrentRotationY;
    private float velocityX = 0;
    private float velocityY = 0;
    private bool IsGround = false;
    [SerializeField] 
    private GameObject cameraSocket;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Rotate();
       
    }

    void FixedUpdate()
    {
        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if (vertical != 0 || horizontal != 0)
        {
            _animator.SetBool("walk",true);
        }
        else
        {
            _animator.SetBool("walk",false);
        }
        Vector3 verticalMove = transform.forward * vertical;
        Vector3 horizontalMove = transform.right * horizontal;
        Vector3 direction = (verticalMove + horizontalMove).normalized;
        //Vector3 move = new Vector3();
        _rb.velocity = new Vector3(direction.x * speed,0,direction.z * speed);
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            _rb.AddForce(0,100000,0);
            Debug.Log("we jmuoepd");
        }
       
    }

    private void Rotate()
    {
        verticalRotation += Input.GetAxis("Mouse X") * sensitivity; 
        horizontalRotation += Input.GetAxis("Mouse Y") * sensitivity;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -75, 75);
        CurrentRotationX = Mathf.SmoothDamp(horizontalRotation, verticalRotation, ref velocityX, 20);
        CurrentRotationY = Mathf.SmoothDamp(verticalRotation, horizontalRotation, ref velocityY, 20);
        gameObject.transform.rotation = Quaternion.Euler(0,CurrentRotationY,0);
        cameraSocket.transform.rotation = Quaternion.Euler(-CurrentRotationX,CurrentRotationY,0);
       
    }
   
    private void OnCollisionEnter(Collision collision )
    {
        if (collision.collider.gameObject.tag == "ground" )
        {
       
            IsGround = true;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "ground" )
        {
            IsGround = false;
        }
    }
}
