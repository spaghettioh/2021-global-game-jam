using UnityEngine;

public class BallStateRolling : ByTheTale.StateMachine.State
{
    Vector2 previousVelocity;

    public BallFSM Ball { get { return (BallFSM)machine; } }

    public override void PhysicsExecute()
    {
        if (Ball.body.IsSleeping())
        {
            Ball.ChangeState<BallStateSettingAngle>();
        }
        else
        {
            if (Mathf.Abs(Vector2.Distance(Ball.body.velocity, previousVelocity)) < .5f)
            {
                Ball.body.Sleep();
            }
            // TODO: finish this with LookAt()?
            //Vector3 direction = Ball.transform.position - Ball.lastPosition;
            //Vector3 localDirection = transform.InverseTransformDirection(direction);
            //lastPosition = transform.position;
            //Vector3 currentPosition = transform.position;
            //pushAngle = currentPosition.y - previousPosition.y;
            //previousPosition = transform.position;
        }
    }
}
