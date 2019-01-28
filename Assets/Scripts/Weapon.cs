﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    private int damage;

    public int Damage { get { return damage; } }

    public Weapon(int id, string name, int damage) : base(id, name)
    {
        this.damage = damage;
    }

    public override bool Use(Player player)
    {
        player.Weapon = this;
        return false;
    }
}
