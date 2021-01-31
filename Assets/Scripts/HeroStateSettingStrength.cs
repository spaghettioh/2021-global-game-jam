using UnityEngine;

public class HeroStateSettingStrength : ByTheTale.StateMachine.State
{
    public Hero Hero { get { return (Hero)machine; } }

    float extraPushStrength;
    bool shouldPush;
    float timer = 0;

    public override void Enter()
    {
        timer = 0;
        extraPushStrength = 0;
        Hero.strokeAngleIndicator.SetActive(true);

        //Hero.shotGraphUI.gameObject.SetActive(true);
    }

    public override void Execute()
    {

        // Wait for user input or for the power meter to fall back to 0
        //if (Hero.setButtonPressed)
        if (Hero.triggeredFromTutorial)
        {
            shouldPush = true;
            Hero.triggeredFromTutorial = false;
        }
        //else if (timer > 1 && pushStrength < .1f)
        //{
        //    //pushStrength = 0;
        //    shouldPush = true;
        //}

        //GetPushMultiplier();
    }

    public override void PhysicsExecute()
    {
        Transform nextShot = Hero.lastCollidedWith.GetComponent<Planet>().nextShotPosition;

        Hero.transform.position = nextShot.position;
        Hero.transform.rotation = nextShot.rotation;
        Hero.body.Sleep();
        Hero.body.velocity = Vector2.zero;
        Hero.body.angularVelocity = 0;
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
        extraPushStrength = pushStrengthNormalized * Hero.pushMultiplier;

        // Update the strength meter
        Hero.pushStrengthMeter.value = pushStrengthNormalized;
    }

    void Push()
    {
        // Turn off the angle arrow and shot graph
        Hero.strokeAngleIndicator.SetActive(false);
        Hero.shotGraphUI.gameObject.SetActive(false);

        // Add any extra force to the default push amount and
        // push in the direction chosen
        float finalPushAmount = Hero.pushAmount + extraPushStrength;
        Vector3 pushVector = Vector3.up * finalPushAmount;
        Hero.body.AddRelativeForce(pushVector, ForceMode2D.Impulse);
        Hero.ChangeState<HeroStateMoving>();
    }
}
