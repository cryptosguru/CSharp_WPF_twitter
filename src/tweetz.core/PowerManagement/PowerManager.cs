﻿using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

#pragma warning disable 8605

namespace tweetz.core.PowerManagement
{
    internal static class PowerManager
    {
        private static Guid MonitorPowerStatus = new(0x02731015, 0x4510, 0x4526, 0x99, 0xe6, 0xe5, 0xa1, 0x7e, 0xbd, 0x1a, 0xea);

        public static void RegisterMonitorStatusChange(Window window)
        {
            _ = PowerManagementNativeMethods.RegisterPowerSettingNotification(new WindowInteropHelper(window).Handle, ref MonitorPowerStatus, 0);
        }

        public static int MonitorStatus(IntPtr _, IntPtr lParam)
        {
            var ps            = (PowerManagementNativeMethods.PowerBroadcastSetting)Marshal.PtrToStructure(lParam, typeof(PowerManagementNativeMethods.PowerBroadcastSetting));
            var pData         = new IntPtr(lParam.ToInt64() + Marshal.SizeOf(ps));
            var monitorStatus = -1;

            if (ps.PowerSetting == MonitorPowerStatus && ps.DataLength == Marshal.SizeOf(typeof(int)))
            {
                monitorStatus = (int)Marshal.PtrToStructure(pData, typeof(int));
            }

            return monitorStatus;
        }
    }
}