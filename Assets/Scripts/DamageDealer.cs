using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public int GetDamage() // Returns the damage value
    {
        return damage;
    }

    public void Hit() // Destroys the game object that this script is attached to
    {
        Destroy(gameObject);
    }
}
