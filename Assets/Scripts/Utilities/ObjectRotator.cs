using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float rotationSpeed;

    private void Start()
    {
        rotationSpeed = Random.Range(rotationSpeed * .8f, rotationSpeed * 1.2f) * .1f;
    }

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
}
