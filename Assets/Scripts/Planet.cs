using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlanetType { Static, Moving, Circling, Rotating }

public class Planet : MonoBehaviour
{
    public GameEventVariable onCollisionWithPlayer;
    public Transform nextShotPosition;

    public PlanetType type = PlanetType.Static;

    public Vector3 nextShotAngle;
    Vector3 nextShotAngleGlobal;

    [Header("Moving type")]
    public Vector3[] movingTypeLocalWaypoints;
    Vector3[] movingTypeGlobalWaypoints;

    public float movingSpeed = 10;
    public bool cyclic = true;
    public float waitTime = 0;
    [Range(0, 2)]
    public float movingEaseAmount = 1;

    int fromWaypointIndex;
    float percentBetweenWaypoints;
    float nextMoveTime;

    [Header("Circling type")]
    public Vector3 circlingAround;
    public float circlingSpeed = 1;
    Vector3 circlingAroundGlobal;


    [Header("Rotating type")]
    public float rotatingSpeed = 1;

    public void Start()
    {
        movingTypeGlobalWaypoints = new Vector3[movingTypeLocalWaypoints.Length];

        for (int i = 0; i < movingTypeLocalWaypoints.Length; i++)
        {
            movingTypeGlobalWaypoints[i] = movingTypeLocalWaypoints[i] + transform.position;
        }

        circlingAroundGlobal = transform.position + circlingAround;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == PlanetType.Moving)
        {
            Vector3 velocity = CalculatePlatformMovement();
            transform.Translate(velocity);

        }
        if (type == PlanetType.Rotating)
        {
            transform.Rotate(Vector3.forward * rotatingSpeed);

        }
        if (type == PlanetType.Circling)
        {
            transform.RotateAround(circlingAroundGlobal, Vector3.forward, circlingSpeed);
        }

    }

    float Ease(float x)
    {
        float a = movingEaseAmount + 1;
        return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
    }

    Vector3 CalculatePlatformMovement()
    {
        if (Time.time < nextMoveTime)
        {
            return Vector3.zero;
        }

        fromWaypointIndex %= movingTypeGlobalWaypoints.Length;
        int toWaypointIndex = (fromWaypointIndex + 1) % movingTypeGlobalWaypoints.Length;
        float distanceBetweenWaypoints = Vector3.Distance(movingTypeGlobalWaypoints[fromWaypointIndex], movingTypeGlobalWaypoints[toWaypointIndex]);
        percentBetweenWaypoints += Time.deltaTime * movingSpeed / distanceBetweenWaypoints;
        percentBetweenWaypoints = Mathf.Clamp01(percentBetweenWaypoints);
        float easedPercentBetweenWaypoints = Ease(percentBetweenWaypoints);

        Vector3 newPosition = Vector3.Lerp(movingTypeGlobalWaypoints[fromWaypointIndex], movingTypeGlobalWaypoints[toWaypointIndex], easedPercentBetweenWaypoints);

        if (percentBetweenWaypoints >= 1)
        {
            percentBetweenWaypoints = 0;
            fromWaypointIndex++;

            if (!cyclic)
            {
                if (fromWaypointIndex >= movingTypeGlobalWaypoints.Length - 1)
                {
                    fromWaypointIndex = 0;
                    System.Array.Reverse(movingTypeGlobalWaypoints);
                }

            }

            nextMoveTime = Time.time + waitTime;
        }

        return newPosition - transform.position;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float size = .3f;
        if (type == PlanetType.Moving && movingTypeLocalWaypoints != null)
        {

            for (int i = 0; i < movingTypeLocalWaypoints.Length; i++)
            {
                Vector3 globalWaypointPosition = (Application.isPlaying) ? movingTypeGlobalWaypoints[i] : movingTypeLocalWaypoints[i] + transform.position;
                Gizmos.DrawLine(globalWaypointPosition - Vector3.up * size, globalWaypointPosition + Vector3.up * size);
                Gizmos.DrawLine(globalWaypointPosition - Vector3.left * size, globalWaypointPosition + Vector3.left * size);
            }
        }

        if (type == PlanetType.Circling)
        {
            Vector3 globalWaypointPosition = (Application.isPlaying) ? circlingAroundGlobal : circlingAround + transform.position;
            Gizmos.DrawLine(globalWaypointPosition - Vector3.up * size, globalWaypointPosition + Vector3.up * size);
            Gizmos.DrawLine(globalWaypointPosition - Vector3.left * size, globalWaypointPosition + Vector3.left * size);
        }

        Gizmos.color = Color.cyan;
        size = .3f;

        Vector3 targetAnglePosition = (Application.isPlaying) ? nextShotAngleGlobal : nextShotAngle + transform.position;
        Gizmos.DrawLine(targetAnglePosition - Vector3.up * size, targetAnglePosition + Vector3.up * size);
        Gizmos.DrawLine(targetAnglePosition - Vector3.left * size, targetAnglePosition + Vector3.left * size);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onCollisionWithPlayer.Raise();
        }
    }

}
