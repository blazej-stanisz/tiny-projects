using AutoIt;
using System;
using System.Windows.Forms;

namespace LightroomActionKeyMapper
{
    class Program
    {
        private static IntPtr WindowHandle { get; set; }
        private static IntPtr TempHandle { get; set; }
        private static IntPtr TintHandle { get; set; }
        private static IntPtr ExposureHandle { get; set; }
        private static IntPtr ContrastHandle { get; set; }
        private static IntPtr HighlightsHandle { get; set; }
        private static IntPtr ShadowsHandle { get; set; }
        private static IntPtr WhitesHandle { get; set; }
        private static IntPtr BlacksHandle { get; set; }
        private static IntPtr ClarityHandle { get; set; }
        private static IntPtr DehazeHandle { get; set; }
        private static IntPtr VibranceHandle { get; set; }
        private static IntPtr SaturationHandle { get; set; }

        private static IntPtr[] Actions { get; set; }
        private static int Counter { get; set; }
        private static int ActionsCount { get; set; }

        private const string UP_BUTTON = "Q"; // go up through actions
        private const string DOWN_BUTTON = "W"; // go down trough actions
        private const string RESET_BUTTON = "D1"; // reset current action value
        private const string Title = "Lightroom Catalog - Adobe Photoshop Lightroom Classic - Develop"; // window title

        static void Main(string[] args)
        {
            HotKeyManager.RegisterHotKey(Keys.Q, KeyModifiers.Alt);
            HotKeyManager.RegisterHotKey(Keys.W, KeyModifiers.Alt);
            HotKeyManager.RegisterHotKey(Keys.D1, KeyModifiers.Alt);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(ChangeActionUp_HotKeyPressed);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(ResetAction_HotKeyPressed);

            RefreshHandles();
            ClickControl();
            ActionsCount = Actions.Length;

            Console.ReadLine();
        }

        static void RefreshHandles()
        {
            if (WindowHandle != IntPtr.Zero)
            {
                return;
            }

            WindowHandle = AutoItX.WinGetHandle(Title);
            TempHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:95]");
            TintHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:96]");
            ExposureHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:107]");
            ContrastHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:108]");
            HighlightsHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:109]");
            ShadowsHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:110]");
            WhitesHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:111]");
            BlacksHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:112]");
            ClarityHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:115]");
            DehazeHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:116]");
            VibranceHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:117]");
            SaturationHandle = AutoItX.ControlGetHandle(WindowHandle, "[CLASS:Static; INSTANCE:118]");

            Actions = new IntPtr[] 
                { 
                    TempHandle, TintHandle, 
                    ExposureHandle, ContrastHandle, 
                    HighlightsHandle, ShadowsHandle, WhitesHandle, BlacksHandle, 
                    ClarityHandle, DehazeHandle, VibranceHandle, SaturationHandle 
                };
        }

        static void ChangeActionUp_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            RefreshHandles();
            SetCounter(e.Key.ToString());
            ClickControl();
        }

        static void ClickControl(int numberOfClicks = 1)
        {
            var controlHandle = Actions[Counter];
            AutoItX.ControlClick(WindowHandle, controlHandle, "left", numberOfClicks);
        }

        static void ResetAction_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            if (e.Key.ToString() == RESET_BUTTON)
            {
                ClickControl(2);
            }
        }

        private static void SetCounter(string key)
        {
            if (key == UP_BUTTON)
            {
                Counter--;
            }
            else if (key == DOWN_BUTTON)
            {
                Counter++;
            }
            else
            {
                return;
            }

            if (Counter == ActionsCount)
            {
                Counter = 0;
            }

            if (Counter == -1)
            {
                Counter = ActionsCount - 1;
            }
        }
    }
}
