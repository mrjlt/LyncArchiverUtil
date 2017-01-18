﻿using System;
using System.Windows.Forms;
using System.Reflection;

namespace Lync.ArchiverUtil
{
    //http://stackoverflow.com/questions/579665/how-can-i-show-a-systray-tooltip-longer-than-63-chars
    public static class Fixes
    {
        public static void SetNotifyIconText(this NotifyIcon ni, string text)
        {
            if (text.Length >= 128) throw new ArgumentOutOfRangeException("Text limited to 127 characters");
            Type t = typeof(NotifyIcon);
            BindingFlags hidden = BindingFlags.NonPublic | BindingFlags.Instance;
            t.GetField("text", hidden).SetValue(ni, text);
            if ((bool)t.GetField("added", hidden).GetValue(ni))
                t.GetMethod("UpdateIcon", hidden).Invoke(ni, new object[] { true });
        }
    }
}

