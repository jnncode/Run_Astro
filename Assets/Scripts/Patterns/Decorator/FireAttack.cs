using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Concrete Decorator
public class FireAttack : AttackDecorator {
    public FireAttack(IPlayerAttack attack) : base(attack) { }

    public override void Attack() {
        base.Attack();
        Debug.Log("Fire Attack!");
    }

    public override string GetDescription() {
        return attack.GetDescription() + " with Fire";
    }
}