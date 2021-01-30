using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public GameObject collisionWith;
    public UnityEvent onTriggerEntered;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject == FindObjectOfType<Hero>().gameObject)
        {
            onTriggerEntered.Invoke();
        }
    }
}
