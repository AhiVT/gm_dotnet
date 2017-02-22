﻿using GSharp;
using GSharp.NativeClasses;
using GSharp.NativeClasses.VCR;
using RGiesecke.DllExport;
using System;
using System.Runtime.InteropServices;

namespace dotnet
{
    enum PacketType
    {
        Ignore = -1,
        Good,
        Info,
        Player,
        Fake,
    };

    public unsafe static class Module
    {
		//const string net_sockets_sig = "\x2A\x2A\x2A\x2A\x80\x7E\x04\x00\x0F\x84\x2A\x2A\x2A\x2A\xA1\x2A\x2A\x2A\x2A\xC7\x45\xF8\x10";
		static byte[] net_sockets_sig = new byte[] {
			0x2A, 0x2A, 0x2A, 0x2A, 0x80, 0x7E, 0x04, 0x00, 0x0F, 0x84, 0x2A, 0x2A, 0x2A, 0x2A, 0xA1, 0x2A, 0x2A, 0x2A, 0x2A, 0xC7, 0x45, 0xF8, 0x10
		};


        [DllExport("gmod13_open", CallingConvention = CallingConvention.Cdecl)]
        public static int Open(lua_state L)
        {
			//VCR_t* VCR = (VCR_t*)InterfaceLoader.LoadVariable<VCR_t>("tier0.dll", "g_pVCR");

			//OHook_recvfrom = InterfaceLoader.OverwriteVCRHook(VCR, new_Hook_recvfrom = Hook_recvfrom_detour);
			//old_Hook_Cmd_Exec = InterfaceLoader.OverwriteVCRHook(VCR, new_Hook_Cmd_Exec = Hook_Cmd_Exec);


			IntPtr engine = InterfaceLoader.LoadLibrary("engine.dll");
            var netsockptr = SymbolFinder.ResolveOnBinary("engine.dll", net_sockets_sig);
			//netsockptr - enginedll: 0x0017e422
			IntPtr diff = netsockptr - (int)engine;

			//SymbolFinder.ResolveOnBinary("engine.dll", net_sockets_sig);


			Console.WriteLine("DotNet loaded");
            return 0;
        }

        static Hook_recvfrom new_Hook_recvfrom;
        static Hook_recvfrom OHook_recvfrom;
        public static int Hook_recvfrom_detour(int s, byte* buf, int len, int flags, IntPtr from, IntPtr fromlen)
        {
            var channel = (int*)buf;
            var challenge = (int*)(buf + 5);
            var type = (byte*)(buf + 4);
            if (*channel == -1)
            {
                if (*challenge != -1)
                {
                    if (*type == 'T')
                    {

                    }
                }
            }

            return OHook_recvfrom(s, buf, len, flags, from, fromlen);
        }

        static Hook_Cmd_Exec new_Hook_Cmd_Exec;
        static Hook_Cmd_Exec old_Hook_Cmd_Exec;
        public static void Hook_Cmd_Exec(string[] Args)
        {
            old_Hook_Cmd_Exec(Args);
        }

        [DllExport("gmod13_close", CallingConvention = CallingConvention.Cdecl)]
        public static int Close(IntPtr L)
        {
            return 0;
        }
    }
}
