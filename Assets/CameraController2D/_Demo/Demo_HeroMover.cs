using UnityEngine;

public class Demo_HeroMover : MonoBehaviour
{
    public float moveSpeed = 6f;

    Vector2 velocity;
    float smoothX;
    float smoothY;
    float acceleration = .3f;

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 targetVelocity = input * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocity.x, ref smoothX, acceleration);
        velocity.y = Mathf.SmoothDamp(velocity.y, targetVelocity.y, ref smoothY, acceleration);

        transform.Translate(velocity * Time.deltaTime);
    }
}
