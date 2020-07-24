using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    Character character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<Character>();
    }

    void Attack()
    {
        character.DoDamageToTarget();
    }

    void AttackEnd()
    {
        character.SetState(Character.State.RunningFromEnemy);
    }

    void Shoot()
    {
        character.DoDamageToTarget();
    }

    void ShootEnd()
    {
        character.SetState(Character.State.Idle);
    }
}
