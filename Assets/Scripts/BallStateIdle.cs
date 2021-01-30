using UnityEngine;

public class BallStateIdle : ByTheTale.StateMachine.State
{
    public BallFSM Ball { get { return (BallFSM)machine; } }

    public override void Execute()
    {
        if (Ball.body.IsSleeping())
        {
            Ball.ChangeState<BallStateSettingAngle>();

        }
    }
}
