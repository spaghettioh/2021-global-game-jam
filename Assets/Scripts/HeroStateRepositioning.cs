using UnityEngine;

public class HeroStateRepositioning : ByTheTale.StateMachine.State
{
    public Hero Hero { get { return (Hero)machine; } }

    public override void Enter()
    {
        Hero.body.velocity = Vector2.zero;
        Hero.body.angularVelocity = 0;
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
    }

}
