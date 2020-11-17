﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerVisualState
{
    public string StateName;
    public SpriteAnimation BodyAnimation;
    public HeadState HeadState;
    public HandsState HandsState;
    public CarryItemState CarryItemState;
    public AnimationPickaxeState PickaxeState;
}

public enum HeadState
{
    Integrated, Dynamic
}

public enum HandsState
{
    Integrated, Conditional
}

public enum CarryItemState
{
    Hidden, Conditional, ConditionalBehindPlayer
}

public enum AnimationPickaxeState
{
    Integrated, Behind, Conditional
}

[DefaultExecutionOrder(-20)]
public class PlayerStateMachine : MonoBehaviour, IStateMachineUser
{
    
    StateMachine stateMachine;

    StateMachine.State s_idle, s_jump, s_fall, s_walk, s_slowWalk, s_climb, s_climbIde, s_inventory, s_death, s_hit, s_longIdle, s_disabled;


    private void Start()
    {
        SetupStateMachine();
        stateMachine.Start();
    }

    private void OnGUI()
    {
        float y = 10;
        for (int i = 0; i < stateMachine.States.Count; i++)
        {
            var s = stateMachine.States[i];

            if (GUI.Button(new Rect(10, y, 200, 25), s.Name))
            {
                stateMachine.ForceTransitionTo(s);
            }

            y += 30;
        }
    }

    private void SetupStateMachine()
    {
        stateMachine = new StateMachine("PlayerStateMachine");

        s_idle = stateMachine.AddState("Idle", null);
        s_jump = stateMachine.AddState("Jump", null);
        s_walk = stateMachine.AddState("Walk", null);
        s_slowWalk = stateMachine.AddState("SlowWalk", null);
        s_climb = stateMachine.AddState("Climb", null);
        s_climbIde = stateMachine.AddState("ClimbIdle", null);
        s_inventory = stateMachine.AddState("Inventory", null);
        s_death = stateMachine.AddState("Death", null);
        s_hit = stateMachine.AddState("Hit", null);
        s_longIdle = stateMachine.AddState("LongIdle", null);
        s_disabled = stateMachine.AddState("Disabled", null);
        s_fall = stateMachine.AddState("Fall", null);

        return;
        s_idle.AddTransition(InInventory, s_inventory);
        s_inventory.AddTransition(() => !InInventory(), s_idle);

        s_idle.AddTransition(IsProlongedIdle, s_longIdle);
        s_longIdle.AddTransition(() => !IsProlongedIdle(), s_idle);

        s_idle.AddTransition(IsFalling, s_fall);
        s_fall.AddTransition(IsGrounded, s_idle);

        s_idle.AddTransition(ShouldJump, s_jump);

        s_idle.AddTransition(IsMoving, s_walk);
        s_walk.AddTransition(IsIdle, s_idle);

        s_idle.AddTransition(ShouldClimb, s_climb);
        s_climb.AddTransition(IsNotClimbing, s_idle);

        s_climb.AddTransition(IsIdle, s_climbIde);
        s_climbIde.AddTransition(IsMoving, s_climb);
    }

    private void Update()
    {
        stateMachine.Update();
    }



    private bool ShouldClimb()
    {
        throw new NotImplementedException();
    }

    private bool IsNotClimbing()
    {
        throw new NotImplementedException();
    }

    private bool IsIdle()
    {
        throw new NotImplementedException();
    }

    private bool IsMoving()
    {
        throw new NotImplementedException();
    }

    private bool ShouldJump()
    {
        throw new NotImplementedException();
    }

    private bool IsGrounded()
    {
        throw new NotImplementedException();
    }

    private bool IsFalling()
    {
        throw new NotImplementedException();
    }

    private bool IsProlongedIdle()
    {
        throw new NotImplementedException();
    }

    private bool InInventory()
    {
        throw new NotImplementedException();
    }

    public StateMachine GetStateMachine()
    {
        return stateMachine;
    }
}
