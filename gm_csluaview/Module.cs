using GSharp;
using GSharp.Generated.NativeClasses;
using GSharp.GLuaNET;
using GSharp.Native;
using GSharp.Native.Classes;
using GSharp.Native.StringTable;
using Libraria.Native;
using RGiesecke.DllExport;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace gm_csluaview
{
    public static class Module
    {
        private static readonly object stateLock = new object();
        private static GLua Lua;
        [DllExport("gmod13_open", CallingConvention = CallingConvention.Cdecl)]
        public static int Open(ref lua_State state)
        {
            ClientConsole.RerouteConsole();
            ClientConsole.Color = new Color(0, 150, 255);
            Lua = GLua.Get(state);

            Lua.CreateTable();

            Lua.Push<Action<string>>(Dump);
            Lua.SetField(-2, "Dump");

            // Send our C# method to the Lua stack
            Lua.Push<Action>(HelloWorld);
            // Set the name of our Lua function
            Lua.SetField(-2, "HelloWorld");

            Lua.Push<Action<string>>(GreetPerson);
            Lua.SetField(-2, "GreetPerson");

            Lua.Push<Action>(SecretPhrase);
            Lua.SetField(-2, "GetSecretPhrase");

            Lua.SetField(GLua.LUA_GLOBALSINDEX, "csluaview");

            var container = NativeInterface.Load<INetworkStringTableContainer>("engine", StringTableInterfaceName.CLIENT);
            var tablePtr = container.FindTable("client_lua_files");
            var table = JIT.ConvertInstance<INetworkStringTable>(tablePtr);
            Console.WriteLine($"dotnet table ptr: {tablePtr.ToString("X8")}");
            //var path0 = table.GetString(0); //hangs here

            //for (int i = 0; i < table.GetNumStrings(); i++)
            //{
            //}

            //var stringTable = StringTable.FindTable<int>("client_lua_files");
            //var luaFiles = stringTable.Select(s => new LuaFile { Path = s.String, CRC = s.UserData }).ToList();

            Console.WriteLine("DotNet Clientside Lua Viewer Loaded!");
            return 0;
        }

        private static void Dump(string path)
        {
            Console.WriteLine(Path.GetFullPath("./Dumps")); 
        }

        /// <summary>
        /// Prints a basic Hello world to the C# realm console.
        /// </summary>
        private static void HelloWorld()
        {
            Console.WriteLine("Hello from C#, world!");
        }

        /// <summary>
        /// Greets a person in C# given a name from Lua.
        /// </summary>
        /// <param name="name">Name of person to greet. Data is received by the TypeMarshals</param>
        private static void GreetPerson(string name)
        {
            // Did we receive an argument from Lua, and is it a string?
            if (Lua.CheckType(1, LuaType.String))
            {
                // Greet the person.
                Console.WriteLine($"Hey there, {name}!");
            }
            // Incorrect argument, or no arguments passed.
            // Lua will have already received an argument error here.
        }

        // Arguments in C# methods are optional.
        // To elaborate, a Lua script can execute the below function
        // with two arguments, despite the fact that there is only one
        // C# argument. This is because we must check for the existance
        // of the Lua arguments within this C# method. So if Lua
        // executes this method without argument 1 of type string and
        // argument 2 of type function, a Lua error is emitted to VM.
        // If you choose to add arguments to a C# function, the GLua
        // type marshals will attempt to cast the Lua arguments to
        // its equivalent C# type. If a cast fails, the C# argument uses
        // defaults.
        private static void SecretPhrase()
        {
            lock(stateLock)
            {
                if (Lua.CheckType(1, LuaType.String) && Lua.CheckType(2, LuaType.Function))
                {
                    Console.WriteLine("Finding the secret phrase...");

                    int callback = -1;
                    // Push the callback function to the stack
                    Lua.Push(2);
                    // Create the Lua reference after all arguments are passed
                    callback = Lua.ReferenceCreate();

                    Task.Run(() => SecretPhraseWork(callback));

                    IntPtr userData = Lua.GetUserdata(3);
                    
                }
            }
        }

        private static void CallCallback(int callback, dynamic data)
        {
            // Push our completed reference back to the stack
            Lua.ReferencePush(callback);
            // Push argument 1 to the stack
            Lua.Push(data);
            // Call the callback function with our secret phrase as argument 1
            Lua.Call(1, 0);
        }

        private static void SecretPhraseWork(int callback)
        {
            Console.WriteLine("Beginning the search...");

            // Simulate some hard work!
            Thread.Sleep(5000);

            Console.WriteLine("Found the phrase!");
            CallCallback(callback, "rusty bullet hole");
        }

        [DllExport("gmod13_close", CallingConvention = CallingConvention.Cdecl)]
        public static int Close(IntPtr L)
        {
            return 0;
        }
    }
}
