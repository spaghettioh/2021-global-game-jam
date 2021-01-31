using UnityEngine;

public class HeroStateSettingStrength : ByTheTale.StateMachine.State
{
    public Hero Hero { get { return (Hero)machine; } }

    bool shouldPush;

    public override void Enter()
    {
        Hero.triggeredFromTutorial = false;
    }

    public override void Execute()
    {
        Hero.print("saasdfkljh");

        // Wait for user input or for the power meter to fall back to 0
        if (Hero.triggeredFromTutorial)
        {
            shouldPush = true;
            Hero.triggeredFromTutorial = false;
        }
    }

    public override void PhysicsExecute()
    {
        Transform nextShot = Hero.lastCollidedWith.GetComponent<Planet>().nextShotPosition;

        // Keep hero on moving planets
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

    void Push()
    {
        // Add any extra force to the default push amount and
        // push in the direction chosen
        float finalPushAmount = Hero.pushAmount;
        Vector3 pushVector = Vector3.up * finalPushAmount;
        Hero.body.AddRelativeForce(pushVector, ForceMode2D.Impulse);
        Hero.ChangeState<HeroStateMoving>();
    }
}
