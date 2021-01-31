﻿// COMMENT TO SILENCE
//#define BYTHETALE_STATEMACHINE_VERBOSE

using UnityEngine;

namespace ByTheTale.StateMachine
{
    [System.Serializable]
    public abstract class State : StateInterface
    {
        public virtual void Execute() { }
        public virtual void PhysicsExecute() { }
        public virtual void PostExecute() { }

        public virtual void OnCollisionEnter(Collision collision)
        {
#if (BYTHETALE_STATEMACHINE_VERBOSE)
            Debug.Log(machine.name + "." + GetType().Name + "::" + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif // BYTHETALE_STATEMACHINE_VERBOSE
        }
        public virtual void OnCollisionEnter2D(Collision2D collision)
        {
#if (BYTHETALE_STATEMACHINE_VERBOSE)
            Debug.Log(machine.name + "." + GetType().Name + "::" + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif // BYTHETALE_STATEMACHINE_VERBOSE
        }
        public virtual void OnCollisionStay(Collision collision) {}
        public virtual void OnCollisionExit(Collision collision)
        {
#if (BYTHETALE_STATEMACHINE_VERBOSE)
            Debug.Log(machine.name + "." + GetType().Name + "::" + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif // BYTHETALE_STATEMACHINE_VERBOSE
        }

        public virtual void OnTriggerEnter(Collider collider)
        {
#if (BYTHETALE_STATEMACHINE_VERBOSE)
            Debug.Log(machine.name + "." + GetType().Name + "::" + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif // BYTHETALE_STATEMACHINE_VERBOSE
        }
        public virtual void OnTriggerStay(Collider collider) {}
        public virtual void OnTriggerExit(Collider collider)
        {
#if (BYTHETALE_STATEMACHINE_VERBOSE)
            Debug.Log(machine.name + "." + GetType().Name + "::" + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif // BYTHETALE_STATEMACHINE_VERBOSE
        }

        public virtual void OnAnimatorIK(int layerIndex) { }

        public virtual void Initialize()
        {
#if (BYTHETALE_STATEMACHINE_VERBOSE)
            Debug.Log(machine.name + "." + GetType().Name + "::" + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif // BYTHETALE_STATEMACHINE_VERBOSE
        }

        public virtual void Enter()
        {
#if (BYTHETALE_STATEMACHINE_VERBOSE)
            Debug.Log(machine.name + "." + GetType().Name + "::" + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif // BYTHETALE_STATEMACHINE_VERBOSE
        }

        public virtual void Exit()
        {
#if (BYTHETALE_STATEMACHINE_VERBOSE)
            Debug.Log(machine.name + "." + GetType().Name + "::" + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif // BYTHETALE_STATEMACHINE_VERBOSE
        }

        public T GetMachine<T>() where T : MachineInterface
        {
            try
            {
                return (T)machine;
            }
            catch (System.InvalidCastException e)
            {
                if (typeof(T) == typeof(MachineState) || typeof(T).IsSubclassOf(typeof(MachineState)))
                {
                    throw new System.Exception(machine.name + ".GetMachine() cannot return the type you requested!\tYour machine is derived from MachineBehaviour not MachineState!" + e.Message);
                }
                else if (typeof(T) == typeof(MachineBehaviour) || typeof(T).IsSubclassOf(typeof(MachineBehaviour)))
                {
                    throw new System.Exception(machine.name + ".GetMachine() cannot return the type you requested!\tYour machine is derived from MachineState not MachineBehaviour!" + e.Message);
                }
                else
                {
                    throw new System.Exception(machine.name + ".GetMachine() cannot return the type you requested!\n" + e.Message);
                }
            }
        }

        public MachineInterface machine { get; internal set; }

        public bool isActive { get { return machine.IsCurrentState(GetType()); } }
    }
}