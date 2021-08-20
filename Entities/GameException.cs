using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest_Code.Entities
{
    public class GameException : Exception
    {
        public int ErrorCode { get; set; }
        
        public GameException(int errorCode, string message):base(message)
        {
            ErrorCode = errorCode;
        }
           
    }
}
