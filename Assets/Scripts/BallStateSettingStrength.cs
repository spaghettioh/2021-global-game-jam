using UnityEngine;

public class BallStateSettingStrength : ByTheTale.StateMachine.State
{
    public BallFSM Ball { get { return (BallFSM)machine; } }

    float extraPushStrength;
    bool shouldPush;
    float timer = 0;

    public override void Enter()
    {
        timer = 0;
        extraPushStrength = 0;
        Ball.shotGraphUI.gameObject.SetActive(true);
    }

    public override void Execute()
    {

        // Wait for user input or for the power meter to fall back to 0
        if (Ball.setButtonPressed)
        {
            shouldPush = true;
        }
        //else if (timer > 1 && pushStrength < .1f)
        //{
        //    //pushStrength = 0;
        //    shouldPush = true;
        //}

        GetPushMultiplier();
        Debug.Log(Ball.pushPitch);
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
        extraPushStrength = 0;
    }

    void GetPushMultiplier()
    {
        // Get a normalized value to make the power meter go up/down
        timer += Time.deltaTime;
        float pushStrengthNormalized = Mathf.PingPong(timer, 1);
        extraPushStrength = pushStrengthNormalized * Ball.pushMultiplier;

        // Update the strength meter
        Ball.pushStrengthMeter.value = pushStrengthNormalized;
    }

    void Push()
    {
        // Turn off the angle arrow and shot graph
        Ball.strokeAngleIndicator.SetActive(false);
        Ball.shotGraphUI.gameObject.SetActive(false);

        // Add any extra force to the default push amount and
        // push in the direction chosen
        float finalPushAmount = Ball.pushAmount + extraPushStrength;
        Vector3 pushVector = Vector3.right * finalPushAmount;
        Ball.body.AddRelativeForce(pushVector, ForceMode2D.Impulse);
        Ball.ChangeState<BallStateRolling>();
    }
}
