using UnityEngine;

internal class MovementScript : MonoBehaviour
{
    #region Serializable Stuff
    [Header("GameObjects")]
    [Space(10)]
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController capsule;
    [SerializeField] private GameObject cameraSocket;
    [Header("Values")]
    [Space(10)]
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;
    #endregion
    #region Variables
    private float _verticalRotation;
    private float _horizontalRotation;
    private float _sensitivity = 5;
    private float _currentRotationX;
    private float _currentRotationY;
    private float _velocityX = 0;
    private float _velocityY = 0;
    private float _downVelocity = 0;
    private bool _isGround = true;
    private RaycastHit _raycastHit;
    private float _horizontalInput;
    private float _verticalInput;
    public bool Ability { get; set; }
    #endregion
    #region Main Code
    private void Start()
    {
        Ability = true;
    }
    private void Update()
    {
        
        
        if (Ability)
        {
            Rotate();
            Move();
            Gravity();
            Animator();
        }
        
    }
    void Animator()
    { 
            if ((_horizontalInput != 0 || _verticalInput != 0) && Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Run", true);
            }
            else if (_verticalInput != 0 || _horizontalInput != 0)
            {
                animator.SetBool("walk", true);
            }
            else
            {
                animator.SetBool("walk", false);
                animator.SetBool("Run", false);
            }
    }
    void Gravity()
    {
        _isGround = Physics.Raycast(transform.position, - transform.up, 2);
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _downVelocity += jumpHeight * Time.deltaTime;
        }
        else if (!_isGround)
        {
            _downVelocity -= gravity * Time.deltaTime;
        }
    }
    private void Move()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        Vector3 _upMove = new Vector3(0, _downVelocity, 0);
        Vector3 _forwardMove = transform.forward * _verticalInput;
        Vector3 _sideMove = transform.right * _horizontalInput;
        Vector3 _direction = (_forwardMove + _sideMove).normalized;
        Vector3 _distance = _direction * speed * Time.deltaTime;
        capsule.Move(_distance);
        capsule.Move(_upMove);
    }
    private void Rotate()
    {
        _verticalRotation += Input.GetAxis("Mouse X") * _sensitivity;
        _horizontalRotation += Input.GetAxis("Mouse Y") * _sensitivity;
        _horizontalRotation = Mathf.Clamp(_horizontalRotation, -75, 75);
        _currentRotationX = Mathf.SmoothDamp(_horizontalRotation, _verticalRotation, ref _velocityX, 20);
        _currentRotationY = Mathf.SmoothDamp(_verticalRotation, _horizontalRotation, ref _velocityY, 20);
        gameObject.transform.rotation = Quaternion.Euler(0, _currentRotationY, 0);
        cameraSocket.transform.rotation = Quaternion.Euler(-_currentRotationX, _currentRotationY, 0);

    }
    #endregion

}
