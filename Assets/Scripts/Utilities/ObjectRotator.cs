using UnityEngine;


public class ObjectRotator : MonoBehaviour
{
    public enum Axis { X, Y, Z };
    public float speed;
    public Axis axis;
    [Range (0.1f, 5)]
    public float randomizer;

    float rotationSpeed;

    private void Start()
    {
        rotationSpeed += speed * Random.Range(0, randomizer);
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
