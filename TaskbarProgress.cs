﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
// ReSharper disable UnusedMember.Global

namespace Leaf.Forms
{
    public static class TaskbarProgress
    {
        public enum TaskbarStates
        {
            NoProgress = 0,
            Indeterminate = 0x1,
            Normal = 0x2,
            Error = 0x4,
            Paused = 0x8
        }

        [ComImport]
        [Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface ITaskbarList3
        {
            // ITaskbarList
            [PreserveSig]
            void HrInit();
            [PreserveSig]
            void AddTab(IntPtr hwnd);
            [PreserveSig]
            void DeleteTab(IntPtr hwnd);
            [PreserveSig]
            void ActivateTab(IntPtr hwnd);
            [PreserveSig]
            void SetActiveAlt(IntPtr hwnd);

            // ITaskbarList2
            [PreserveSig]
            void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

            // ITaskbarList3
            [PreserveSig]
            void SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);
            [PreserveSig]
            void SetProgressState(IntPtr hwnd, TaskbarStates state);
        }

        [Guid("56FDF344-FD6D-11d0-958A-006097C9A090")]
        [ClassInterface(ClassInterfaceType.None)]
        [ComImport]
        private class TaskbarInstance {}

        // ReSharper disable once SuspiciousTypeConversion.Global
        private static readonly ITaskbarList3 Instance = (ITaskbarList3)new TaskbarInstance();
        private static readonly bool TaskbarSupported = Environment.OSVersion.Version >= new Version(6, 1);

        public static void SetProgressState(this Form form, TaskbarStates taskbarState)
        {
            if (TaskbarSupported)
                Instance.SetProgressState(form.Handle, taskbarState);
        }

        public static void SetProgressValue(this Form form, double progressValue, double progressMax)
        {
            if (TaskbarSupported)
                Instance.SetProgressValue(form.Handle, (ulong)progressValue, (ulong)progressMax);
        }
    }
}