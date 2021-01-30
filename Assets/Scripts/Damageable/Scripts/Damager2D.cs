using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Damager2D : MonoBehaviour
{
    [Header("Damage")]
    public int attackPoints = 1;
    public LayerMask hitableLayers;
    public bool ignoresInvincibility;
    public bool damagesTriggers;

    [Header("After damage dealt")]
    [Tooltip("Perform when this object collides with a Damageable object.")]
    public UnityEvent OnDamageableHit;
    [Tooltip("Perform when this object collides with a non-Damageable object.")]
    public UnityEvent OnNonDamageableHit;

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (CheckForHitbox(c.collider))
        {
            DealDamage(c.gameObject);
        }
        else
        {
            OnNonDamageableHit.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (CheckForHitbox(c) && damagesTriggers)
        {
            DealDamage(c.gameObject);
        }
        else
        {
            OnNonDamageableHit.Invoke();
        }
    }

    private bool CheckForHitbox(Collider2D c)
    {
        Damageable2D d = c.gameObject.GetComponent<Damageable2D>();

        if (c == d.hitbox)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DealDamage(GameObject g)
    {
        Damageable2D damageable = g.GetComponent<Damageable2D>();

        if (damageable != null)
        {
            // TODO: Add check for hitable layer match.
            damageable.TakeDamage(attackPoints);
            if (!damageable.invincible || ignoresInvincibility)
            {
                OnDamageableHit.Invoke();
            }
        }
        else
        {
            OnNonDamageableHit.Invoke();
        }
    }
}
