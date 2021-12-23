using System;
using UnityEngine;

namespace Ambush
{
    
    public class ActionSystem : MonoBehaviour
    {
        
        public static void Add(IAction action)
        {
            action.Do();
        }
    }

    // public class AttackInstance
    // {
    //     
    // // }
    // public interface ICommandSystem
    // {
    //     
    // }
    //
    // public class CommandSystem
    // {
    //     public static bool Request(ICommand command)
    //     {
    //         if (!command.Validate())
    //             return false;
    //         
    //         //Send command to all clients
    //         command.Do();
    //         return true;
    //     }
    //
    //     public void DoOnClients () {
    //         
    //     }
    //
    // }
    //
    //
    // public interface ICommand
    // {
    //     bool Validate();
    //     void Do();
    //     void Undo();
    // }
    //
    // public class Command : ICommand
    // {
    //     public bool Validate()
    //     {
    //         return true;
    //     }
    //
    //     public void Do()
    //     {
    //         Debug.Log("Do Command");
    //     }
    //
    //     public void Undo()
    //     {
    //         Debug.Log("Undo Command");
    //     }
    // }
}