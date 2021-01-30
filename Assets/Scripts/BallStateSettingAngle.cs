using UnityEngine;

public class BallStateSettingAngle : ByTheTale.StateMachine.State
{
    public BallFSM Ball { get { return (BallFSM)machine; } }

    public override void Enter()
    {
        Ball.transform.rotation = Quaternion.Euler(Vector3.zero);
        Ball.strokeAngleIndicator.SetActive(true);
    }

    public override void Execute()
    {
        // Change the push angle based on player input
        Ball.pushAngle += Ball.inputH * 90f * Time.deltaTime;
        Ball.pushPitch += -Ball.inputV * 90f * Time.deltaTime;
        Ball.pushPitch = Mathf.Clamp(Ball.pushPitch, -90, 0);
        Ball.strokeAngleIndicator.transform.rotation = Quaternion.Euler(Ball.pushPitch, Ball.pushAngle, 0);

        if (Ball.setPressed)
        {
            Ball.ChangeState<BallStateSettingStrength>();
        }
    }
}
