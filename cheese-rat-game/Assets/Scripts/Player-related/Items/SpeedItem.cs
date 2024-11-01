using System.Collections;
using UnityEngine;

public class SpeedItem : ManualPickupItem
{
    
    [SerializeField] private float _speedChangeFactor;
    private float _originalSpeed;
    public override void UseItem()
    {
        if (IsUsable())
        {
            _originalSpeed = _playerMovement.GetMovementSpeed();
            _playerMovement.SetMovementSpeed(_originalSpeed * _speedChangeFactor);
            Debug.Log("movement speed buffed");
            StartCoroutine(ResetSpeed(10f));
        } else
        {
            Debug.Log("Cannot use this item for this character: " + _playerObject.name);
        }
    }

    private IEnumerator ResetSpeed(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        Debug.Log("movement speed reset to original");
        _playerMovement.SetMovementSpeed(_originalSpeed);
        _playerHealth = null;
        _playerMovement = null;
        _playerObject = null;
        ShowItem();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_playerObject != null)
        {
            _playerMovement = _playerObject.GetComponent<PlayerMovement>(); ;
            _originalSpeed = _playerMovement.GetMovementSpeed();
        }

        _speedChangeFactor = 2f;
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
