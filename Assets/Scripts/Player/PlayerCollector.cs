using System.Xml.Serialization;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        //check if the other game object has the ICollectible interface
        if (col.gameObject.TryGetComponent<ICollectible>(out ICollectible collectible))
        {
            //if it does , call the Collect method
            collectible.Collect();
        }
    }
}
