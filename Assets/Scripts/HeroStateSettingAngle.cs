using UnityEngine;

public class HeroStateSettingAngle : ByTheTale.StateMachine.State
{
    public Hero Ball { get { return (Hero)machine; } }

    public override void Enter()
    {
        Ball.strokeAngleIndicator.SetActive(true);
    }

    public override void Execute()
    {
        // Change the push angle based on player input
        Ball.pushPitch = Time.time * 100;
        Ball.pushAngle = 90;
        Ball.transform.rotation = Quaternion.Euler(0, 0, Ball.pushPitch);

        if (Ball.setButtonPressed)
        {
            Ball.ChangeState<HeroStateSettingStrength>();
        }
    }
}
