﻿using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;

namespace Console_Games
{
    public class Plugin
    {

        [PluginEntryPoint("Console Games", "1.0.0", "Console games to play while spectating in SCP SL", "SpiderBuh")]
        public void OnPluginStart()
        {

            Log.Info($"Loading Console Games...");

            EventManager.RegisterEvents<Events>(this);

        }
    }
}