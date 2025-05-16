using DungeonRPG.Scripts.General;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public partial class PlayerState : Node
    {

        protected Player characterNode;
        public override void _Ready()
        {
            characterNode = GetOwner<Player>(); // to access the player animation method
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }



        public override void _Notification(int what)
        {
            base._Notification(what); // passes on the what parameter

            if (what == 5001)
            {
                EnterState();
                SetPhysicsProcess(true); // reactives the _PhysicsProcess
                SetProcessInput(true);
            }
            else if (what == 5002)
            {
                SetPhysicsProcess(false);
                SetProcessInput(false);
            }
        }

        protected virtual void EnterState()
        {
            

        }

    }

