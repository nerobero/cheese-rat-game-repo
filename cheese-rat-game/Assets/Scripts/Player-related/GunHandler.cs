using UnityEngine;

public class GunHandler : MonoBehaviour
{
    private Vector2 _mousePosition;
    private float _horizontalSpeed = 2f;
    private float _verticalSpeed = 2f;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _projectileSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = _horizontalSpeed * Input.GetAxis("Mouse X");
        float v = _verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(v, h, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            GameObject bullet = Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(
                _shootPoint.up * _projectileSpeed, ForceMode2D.Impulse);
        }
    }
}
