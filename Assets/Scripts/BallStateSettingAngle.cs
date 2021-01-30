using UnityEngine;

public class BallStateSettingAngle : ByTheTale.StateMachine.State
{
    public BallFSM Ball { get { return (BallFSM)machine; } }

    public override void Enter()
    {
        Ball.strokeAngleIndicator.SetActive(true);
    }

    public override void Execute()
    {
        // Change the push angle based on player input
        Ball.pushPitch = Time.time * 100;
        Ball.pushAngle = 90;
        Ball.strokeAngleIndicator.transform.rotation = Quaternion.Euler(Ball.pushPitch, Ball.pushAngle, 0);

        if (Ball.setButtonPressed)
        {
            Ball.ChangeState<BallStateSettingStrength>();
        }
    }
}
