using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.StateMachine
{

    public interface IStateContext
    {

    }

    public abstract class StateMachineBase<T> where T : IStateContext
    {
        private static EmptyState<T> emptyState;

        public static IState<T> Empty()
        {
            return emptyState;
        }

        public abstract void Update(float dt);

    }

    public interface IState<T> where T: IStateContext
    {
        void Update(float dt);
        void Enter(T context);
        void Exit();
    }

    class EmptyState<T> : IState<T> where T: IStateContext
    {
        public void Enter(T context)
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