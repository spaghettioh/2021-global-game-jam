using UnityEngine;


public class ObjectRotator : MonoBehaviour
{
    public enum Axis { X, Y, Z };
    public float rotationSpeed;
    public Axis axis;
    [Range (1, 5)]
    public float seed;


    private void Start()
    {
        rotationSpeed = Random.Range(0, seed) * seed;
    }

    void Update()
    {
        if (axis == Axis.X)
        {
            gameObject.transform.Rotate(new Vector3(rotationSpeed, 0, 0));

        }
        else if (axis == Axis.Y)
        {
            gameObject.transform.Rotate(new Vector3(0, rotationSpeed, 0));

        }
        else
        {
            gameObject.transform.Rotate(new Vector3(0, 0, rotationSpeed));

        }
    }
}
