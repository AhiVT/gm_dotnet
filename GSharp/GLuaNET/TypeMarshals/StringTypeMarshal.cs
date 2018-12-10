using Libraria.Native;
using System;

namespace GSharp.GLuaNET.TypeMarshals
{
    public class StringTypeMarshal : ILuaTypeMarshal
    {
        public object Get(GLua GLua, int stackPos = -1)
        {
            if (GLua.IsType(stackPos, LuaType.String))
            {
                return InteropHelp.DecodeUTF8String(GLua.LuaBase.GetString(stackPos, IntPtr.Zero));
            }
            return null;
        }

        public void Push(GLua GLua, object obj)
        {
            if (obj is string str)
            {
                IntPtr ptr = InteropHelp.EncodeUTF8String(str, out var handle);
                try
                {
                    GLua.LuaBase.PushString(ptr/*, Convert.ToUInt32(Encoding.UTF8.GetByteCount(str))*/);
                }
                finally
                {
                    InteropHelp.FreeString(ref handle);
                }
            }
        }
    }
}
