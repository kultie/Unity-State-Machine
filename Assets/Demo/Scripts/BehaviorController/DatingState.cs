using Kultie.StateMachine.Behavior;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatingState : StateComponent
{
    public override string ID => "Dating";
    float currentTime;
    public override void OnEnter(StateMachineComponent stateMachine, StateContextComponent context)
    {
        Debug.Log(GetContext<DemoContext>(context).sentence);
        currentTime = 0;
    }

    public override void OnExit(StateMachineComponent stateMachine, StateContextComponent context)
    {
        Debug.Log("After dinner we say eachother goodbye");
    }

    public override void OnUpdate(StateMachineComponent stateMachine, StateContextComponent context)
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 5)
        {
            GetContext<DemoContext>(context).sentence = "Goodbye";
            stateMachine.ChangeState("Goodbye");
        }
    }
}

