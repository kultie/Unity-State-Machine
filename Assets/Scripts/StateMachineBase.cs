using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.StateMachine
{

    public interface IStateContext
    {

    }

    public abstract class StateMachineBase
    {
        private static EmptyState emptyState;

        public static IState Empty()
        {
            return emptyState;
        }

        public abstract void Update(float dt);
       
    }

    public interface IState
    {
        void Update(float dt);
        void Enter(IStateContext context);
        void Exit();
    }

    class EmptyState : IState
    {
        public void Enter(IStateContext context)
        { 
        }

        public void Exit()
        {
        }

        public void Update(float dt)
        { 
        }
    }
}