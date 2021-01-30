using UnityEngine;

public class BallStateRolling : ByTheTale.StateMachine.State
{
    Vector2 previousVelocity;

    public BallFSM Ball { get { return (BallFSM)machine; } }

    public override void PhysicsExecute()
    {
        if (Mathf.Abs(Vector2.Distance(Ball.body.velocity, previousVelocity)) < .5f)
        {
            Ball.body.Sleep();
            Ball.ChangeState<BallStateSettingAngle>();
        }
    }
}
