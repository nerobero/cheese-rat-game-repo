using System.Collections;
using UnityEngine;

public class SpeedItem : ManualPickupItem
{
    
    [SerializeField] private float _speedChangeFactor;
    private float _originalSpeed;
    public override void UseItem()
    {
        _originalSpeed = _playerMovement.moveSpeed;
        _playerMovement.moveSpeed = _originalSpeed 
                                    * _speedChangeFactor;
        Debug.Log("movement speed buffed");
        StartCoroutine(ResetSpeed(10f));
    }

    private IEnumerator ResetSpeed(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        Debug.Log("movement speed reset to original");
        _playerMovement.moveSpeed = _originalSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_playerObject != null)
        {
            _playerMovement = _playerObject.GetComponent<PlayerMovement>(); ;
            _originalSpeed = _playerMovement.moveSpeed;
        }

        _speedChangeFactor = 2f;
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
