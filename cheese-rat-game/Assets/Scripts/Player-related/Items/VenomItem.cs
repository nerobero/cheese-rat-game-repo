using System.Collections;
using UnityEngine;

public class VenomItem : ManualPickupItem
{
    private GunHandler _gunHandler = null;
    private GameObject _originalProjectile = null;
    [SerializeField] private GameObject _poisonProjectile;
    public override void UseItem()
    {
        if (IsUsable())
        {
            _gunHandler = _playerObject.transform.
                Find("Shooter").GetComponent<GunHandler>();
            if (_gunHandler)
            {
                _originalProjectile = _gunHandler.GetProjectilePrefab();
                _gunHandler.ChangeProjectileType(_poisonProjectile);
                StartCoroutine(ResetProjectile(10f));
            } else
            {
                Debug.Log("Invalid Gun Handler");
            }
        } else
        {
            Debug.Log("Cannot use this item for this character: " + _playerObject.name);
        }
    }

    private IEnumerator ResetProjectile(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        Debug.Log("projectile reset to original");
        _gunHandler.ChangeProjectileType(_originalProjectile);
        _playerHealth = null;
        _playerMovement = null;
        _playerObject = null;
        ShowItem();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        if (_playerObject != null)
        {
            _gunHandler = _playerObject.transform.
                Find("Shooter").GetComponent<GunHandler>();
            _originalProjectile = _gunHandler.GetProjectilePrefab();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
