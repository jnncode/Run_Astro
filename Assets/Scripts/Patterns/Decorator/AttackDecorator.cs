using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Decorator
public abstract class AttackDecorator : IPlayerAttack {
    protected IPlayerAttack attack;

    public AttackDecorator(IPlayerAttack attack) {
        this.attack = attack;
    }

    public virtual void Attack() {
        attack.Attack();
    }

    public virtual string GetDescription() {
        return attack.GetDescription();
    }
}


