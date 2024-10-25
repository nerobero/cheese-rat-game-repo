using UnityEngine;

public class SpeedItem : ManualPickupItem
{
    private PlayerMovement _playerMovement = null;
    public override bool UseItem()
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_playerObject != null)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
