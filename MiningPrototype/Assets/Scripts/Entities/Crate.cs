﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MineableObject
{
    [SerializeField] SpriteRenderer spriteRenderer;

    public void Pack(ItemAmountPair toPack)
    {
        contains = toPack;
    }
    public override Vector2 GetPosition()
    {
        return transform.position + (spriteRenderer.size.y / 2) * Vector3.up;
    }
}