using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
