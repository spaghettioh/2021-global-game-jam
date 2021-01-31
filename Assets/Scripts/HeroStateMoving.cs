using UnityEngine;

public class HeroStateMoving : ByTheTale.StateMachine.State
{
    public Hero Hero { get { return (Hero)machine; } }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Hero.lastCollidedWith = collision.gameObject;
            Hero.ChangeState<HeroStateRepositioning>();
        }
    }
}
