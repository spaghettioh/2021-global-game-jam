using UnityEngine;

public class HeroStateMoving : ByTheTale.StateMachine.State
{
    Vector2 previousVelocity;
    float timeSlow;

    public Hero Hero { get { return (Hero)machine; } }

    public override void PhysicsExecute()
    {
        //if (Mathf.Abs(Vector2.Distance(Hero.body.velocity, previousVelocity)) < .5f)
        //{
        //    Hero.body.Sleep();
        //    Hero.ChangeState<HeroStateSettingStrength>();
        //}

    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Hero.lastCollidedWith = collision.gameObject;
            Hero.ChangeState<HeroStateRepositioning>();
        }
        if (collision.gameObject.tag == "FinishPlanet")
        {
            Hero.finished = true;
        }
    }
}
