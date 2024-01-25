using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(PlayerCamera), typeof(PlayerWeapon))]
[RequireComponent(typeof(PlayerInteraction), typeof(PlayerInteractableInfo))]
public class Player : MonoBehaviour
{
    public PlayerCamera Camera { get; private set; }
    public PlayerWeapon Weapon { get; private set; }
    public PlayerInteraction Interaction { get; private set; }
    public PlayerInteractableInfo InteractableInfo { get; private set; }


    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundChecherRadius;
    [SerializeField] private LayerMask _groundLayerMask;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _movementSprintSpeed;
    [SerializeField] private float _jumpStrength;

    private bool _isOnGround;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Camera = GetComponent<PlayerCamera>();
        Weapon = GetComponent<PlayerWeapon>();
        Interaction = GetComponent<PlayerInteraction>();
        InteractableInfo = GetComponent<PlayerInteractableInfo>();

        Weapon.Construct(this);
        Interaction.Construct(this);
        InteractableInfo.Construct(this);
    }

    private void Update()
    {
        Vector3 jumpVector = new Vector3(0, _jumpStrength, 0);

        if (_isOnGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rigidbody.AddForce(jumpVector, ForceMode.Impulse);

                _isOnGround = false;
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _isOnGround = Physics.CheckSphere(_groundChecker.position, _groundChecherRadius, _groundLayerMask);

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        direction.Normalize();
        direction = transform.TransformDirection(direction);
        
        if (_isOnGround)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _rigidbody.velocity = direction * _movementSprintSpeed;
            }
            else
            {
                _rigidbody.velocity = direction * _movementSpeed;
            }
        }
        else
        {
            float projectVelocity = Vector3.Dot(_rigidbody.velocity, direction);
            float accelerationVelocity = _movementSpeed * Time.fixedDeltaTime * 2f;

            if (projectVelocity + accelerationVelocity > _movementSpeed)
            {
                accelerationVelocity = _movementSpeed - projectVelocity;
            }

            _rigidbody.velocity += direction * accelerationVelocity;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_groundChecker.position, _groundChecherRadius);
    }
}