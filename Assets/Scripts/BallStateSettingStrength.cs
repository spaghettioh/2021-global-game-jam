using UnityEngine;

public class BallStateSettingStrength : ByTheTale.StateMachine.State
{
    public BallFSM Ball { get { return (BallFSM)machine; } }

    float pushStrength;
    bool shouldPush;
    float timer = 0;

    public override void Enter()
    {
        timer = 0;
        pushStrength = 0;
    }

    public override void Execute()
    {
        // Wait for user input or for the power meter to fall back to 0
        if (Ball.setPressed)
        {
            shouldPush = true;
        }
        else if (timer > 1 && pushStrength < .1f)
        {
            pushStrength = 0;
            shouldPush = true;
        }

        GetPushMultiplier();
    }

    public override void PhysicsExecute()
    {
        if (shouldPush)
        {
            shouldPush = false;
            Push();
        }
    }

    public override void Exit()
    {
        pushStrength = 0;
    }

    void GetPushMultiplier()
    {
        // Get a normalized value to make the power meter go up/down
        timer += (float)System.Math.Round(Time.deltaTime, 2);
        float pushStrengthNormalized = 0;

        if (timer > 0 && timer < 1)
        {
            pushStrengthNormalized += timer;
        }
        else if (timer > 1 && timer < 2)
        {
            pushStrengthNormalized = 2 - timer;
        }

        // Update the strength meter
        Ball.pushStrengthMeter.value = pushStrengthNormalized;

        pushStrength = pushStrengthNormalized * Ball.pushModifier;
    }

    void Push()
    {
        // Turn off the angle arrow and shot graph
        Ball.strokeAngleIndicator.SetActive(false);
        Ball.shotGraphUI.gameObject.SetActive(false);

        Vector3 pushVector = Vector3.forward * (Ball.pushAmount + pushStrength);

        Ball.body.AddForce(Quaternion.Euler(Ball.pushPitch, Ball.pushAngle, 0) * pushVector);
        Ball.ChangeState<BallStateRolling>();
    }
}
