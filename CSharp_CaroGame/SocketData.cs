using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_CaroGame
{
    [Serializable]
    public class SocketData
    {
        private int command;

        public int Command
        {
            get
            {
                return command;
            }

            set
            {
                command = value;
            }
        }

        public Point Point
        {
            get
            {
                return point;
            }

            set
            {
                point = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        private string message;
        private Point point;
        public SocketData(int command, string message, Point point)
        {
            this.Command = command;
            this.Point = point;
            this.Message = message;
        }
    }

    public enum SocketCommand
    {
        SEND_POINT,
        NEW_GAME,
        QUIT,
        END_GAME,
        UNDO,
        REDO,
        CALL_NEW_GAME
    }
}
