using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRPG.Scripts.General
{
    public class GameConstants
    {
        // convert strings into constants that are game breaking behaviors
        
        // animations constants to reduce likelyhood of an error
        public const string ANIM_IDLE = "Idle";
        public const string ANIM_MOVE = "Move";
        public const string ANIM_DASH = "Dash";
        
        // movement constants to reduce the likelyhood of an error
        public const string INPUT_MOVE_LEFT = "MoveLeft";
        public const string INPUT_MOVE_RIGHT = "MoveRight";
        public const string INPUT_MOVE_FORWARD = "MoveForward";
        public const string INPUT_MOVE_BACKWARD = "MoveBackward";

        public const string INPUT_DASH = "Dash";

    }
}
