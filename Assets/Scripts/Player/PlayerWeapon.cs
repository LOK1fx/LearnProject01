using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _shootSound01;
    [SerializeField] private LayerMask _shootableLayerMask;

    private Player _currentPlayer;

    public void Construct(Player player)
    {
        _currentPlayer = player;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var cameraTransform = _currentPlayer.Camera.CameraTransform;

            _source.PlayOneShot(_shootSound01);
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 10000f, Color.red, 1f);

            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, 10000f, _shootableLayerMask))
            {
                if (hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    enemy.TakeDamage();
                }
            }
        }
    }
}