using UnityEngine;

public class GunHandler : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Vector2 _mousePosition;
    private Vector2 _mouseDirection;
    
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private GameObject _owner;
    [SerializeField] private Camera _camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Input.mousePosition;
        _mouseDirection = _camera.ScreenToWorldPoint(_mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if (_projectilePrefab)
            {
                GameObject bullet = Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(
                    _shootPoint.up * _projectileSpeed, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.position = _owner.GetComponent<Rigidbody2D>().position;

        Vector2 lookDirection = _mouseDirection - _rigidBody.position;
        float angle  = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        _rigidBody.rotation = angle;
    }
}
