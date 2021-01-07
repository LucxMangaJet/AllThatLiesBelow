﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MirrorWorldFollower
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite bloody;

    [Zenject.Inject] PlayerStateMachine playerStateMachine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.velocity.y < -5 && collision.attachedRigidbody.GetComponent<PlayerInteractionHandler>() != null)
        {
            playerStateMachine.TakeDamage(DamageStrength.Strong);
            spriteRenderer.sprite = bloody;
        }
    }
}
