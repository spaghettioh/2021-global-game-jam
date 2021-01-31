using UnityEngine;

public class HeroStateRepositioning : ByTheTale.StateMachine.State
{
    public Hero Hero { get { return (Hero)machine; } }
    float moveTime;
    bool ready;

    float currentAngle;

    public override void Enter()
    {
        moveTime = 0;
        Hero.body.velocity = Vector2.zero;
        Hero.body.angularVelocity = 0;
    }

    public override void Execute()
    {

    }

    public override void PhysicsExecute()
    {
        Transform nextShot = Hero.lastCollidedWith.GetComponent<Planet>().nextShotPosition;

        Hero.transform.position = nextShot.position;
        Hero.transform.rotation = nextShot.rotation;
        Hero.body.Sleep();
        Hero.body.velocity = Vector2.zero;
        Hero.body.angularVelocity = 0;
        Hero.ChangeState<HeroStateSettingStrength>();
        //moveTime += Time.deltaTime;
        //currentAngle = Vector3.Angle(Hero.transform.position, Hero.lastCollidedWith.transform.position);
        //float nextShotAngle = Vector3.Angle(Hero.lastCollidedWith.GetComponent<Planet>().nextShotAngle, Hero.lastCollidedWith.transform.position);
        //float targetAngle = Mathf.Lerp(currentAngle, nextShotAngle, moveTime);
        //Hero.transform.RotateAround(Hero.lastCollidedWith.transform.position, Vector3.forward, targetAngle);
        //Hero.body.velocity = Vector2.zero;
        //Hero.body.angularVelocity = 0;
        //Debug.Log(currentAngle);

        //if (currentAngle == targetAngle)
        //{
        //    Hero.ChangeState<HeroStateSettingStrength>();
        //}
    }

    public override void Exit()
    {
        ready = false;
    }

}
