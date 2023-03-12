using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChessServer
{
    class CommandHandler
    {
        private static Commands c;
        private static List<MethodInfo> commands;

        public static void InitHandler(TCPServer server)
        {
            c = new Commands(server); //Commands like 'Move', 'GetLobbies', 'CreateLobby', 'ConnectLobby'
            commands = new List<MethodInfo>(c.GetType().GetMethods()); //List of attributes of method of command
        }
        public static void Handler(string msg, TcpClient sender)
        {
            string[] splittedMsg = msg.Split(' '); //Split message into command and operands
            string[] args = splittedMsg.Length == 2 ? splittedMsg[1].Split('&') : new string[] { }; //If array only has two components then split the second component into previousMove and newMove, else args is an empty string
            string command = splittedMsg[0]; //The command is the first component
            foreach (var method in commands) //Look at each method
            {
                foreach (var attribute in method.GetCustomAttributes(false)) //Look at each attribute
                {
                    if (attribute is ClientCommandAttribute commandAttribute) //If commandattribute sent matches one of the commandattributes defined
                    {
                        if (commandAttribute.Command == command) //If command matches
                        {
                            var describedMethodParams = method.GetParameters(); //Get params of method
                            object[] methodParams = new object[describedMethodParams.Length]; //Array of method params
                            methodParams[0] = sender; //The tcp client is the first param
                            if (describedMethodParams.Length > 1) //If more than one param
                            {
                                for (int i = 1; i < describedMethodParams.Length; i++)
                                {
                                    if (describedMethodParams[i].ParameterType.Name == "String")
                                        methodParams[i] = args[i - 1]; //method params takes previousMove and newMove as string
                                    else if (describedMethodParams[i].ParameterType.Name == "Int")
                                        methodParams[i] = int.Parse(args[i - 1]); //method params takes previousMove and newMove as int
                                }
                            }
                            method.Invoke(c, methodParams); //calls the method with these params
                            return;
                        }
                    }
                }
            }
            Console.WriteLine($"Not handled message: {msg}");
        }
    }
}
