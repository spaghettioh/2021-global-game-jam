using UnityEngine;

public class HeroStateMoving : ByTheTale.StateMachine.State
{
    Vector2 previousVelocity;

    public Hero Ball { get { return (Hero)machine; } }

    public override void PhysicsExecute()
    {
        if (Mathf.Abs(Vector2.Distance(Ball.body.velocity, previousVelocity)) < .5f)
        {
            Ball.body.Sleep();
            Ball.ChangeState<HeroStateSettingAngle>();
        }
    }
}
