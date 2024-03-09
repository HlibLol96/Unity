using System;
using UnityEngine;


public class MovementScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField]private float speed;
    [SerializeField]private CharacterController capsule;
    [SerializeField]private float jumpHeight;
    [SerializeField]private GameObject cameraSocket;
    private float _verticalRotation;
    private float _horizontalRotation;
    private float _sensitivity = 5;
    private float _currentRotationX;
    private float _currentRotationY;
    private float _velocityX = 0;
    private float _velocityY = 0;
    private bool _isGround = true;
    private int gravity = 4;
    private float horizontalInput;
    private float verticalInput;
    private float _runSpeed = 1;

    private void Update()
    {
        Move();
        Rotate();
        Gravity();
        Animator();
        Debug.Log(_isGround);
    }
    void Animator()
    {
        if ((horizontalInput != 0 || verticalInput != 0 )&& Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Run",true);
        }
        else if (verticalInput != 0 || horizontalInput != 0)
        {
            animator.SetBool("walk",true);
        }
        else
        {
            animator.SetBool("walk",false);
            animator.SetBool("Run",false);
        }
    }
    void Gravity()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            capsule.Move(new Vector3(0, jumpHeight * gravity, 0));
        }
        else
        {
            capsule.Move(new Vector3(0,-0.1f,0));
        }
    }
    private void Move()
    {
        horizontalInput = Input.GetAxis ("Horizontal");
        verticalInput = Input.GetAxis ("Vertical");
        if ((horizontalInput != 0 || verticalInput != 0 )&& Input.GetKeyDown(KeyCode.LeftShift))
        {
            _runSpeed = 10;
        }
        else
        {
            _runSpeed = 1;
        }
        Vector3 forwardMove = transform.forward * verticalInput;
        Vector3 sideMove = transform.right * horizontalInput;
        Vector3 direction = (forwardMove + sideMove).normalized;
        Vector3 distance = direction * speed * _runSpeed * Time.deltaTime;
        capsule.Move (distance);
    }
    private void Rotate()
    {
        _verticalRotation += Input.GetAxis("Mouse X") * _sensitivity; 
        _horizontalRotation += Input.GetAxis("Mouse Y") * _sensitivity;
        _horizontalRotation = Mathf.Clamp(_horizontalRotation, -75, 75);
        _currentRotationX = Mathf.SmoothDamp(_horizontalRotation, _verticalRotation, ref _velocityX, 20);
        _currentRotationY = Mathf.SmoothDamp(_verticalRotation, _horizontalRotation, ref _velocityY, 20);
        gameObject.transform.rotation = Quaternion.Euler(0,_currentRotationY,0);
        cameraSocket.transform.rotation = Quaternion.Euler(-_currentRotationX,_currentRotationY,0);
                   
    }
    void OnControllerColliderHit (ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "Respawn")
        {
            Debug.Log("Enter");
            _isGround = true;
        }
        else if (hit.collider.gameObject.tag != "Respawn")
        {
            _isGround = true;
        }
    }
}
