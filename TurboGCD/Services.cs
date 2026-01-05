using Dalamud.Game;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using TurboGCD.Windows;

namespace TurboGCD
{
#nullable disable
    public sealed class Services
    {
        internal static bool Inistialized { get; private set; }
        [PluginService] public static IDataManager DataManager { get; private set; }
        [PluginService] public static IClientState ClientState { get; private set; }
        [PluginService] public static IPlayerState PlayerState { get; private set; }
        [PluginService] public static ICommandManager Command { get; private set; }
        [PluginService] public static ICondition Condition { get; private set; }
        [PluginService] public static IGameConfig GameConfig { get; private set; }
        [PluginService] public static IGameGui GameGui { get; private set; }
        [PluginService] public static IGameInteropProvider Hooks { get; private set; }
        [PluginService] public static IGamepadState GamepadState { get; private set; }
        [PluginService] public static IFramework Framework { get; private set; }
        [PluginService] public static IKeyState KeyState { get; private set; }
        [PluginService] public static IPluginLog Log { get; private set; }
        [PluginService] public static ISigScanner SigScanner { get; private set; }
        [PluginService] public static ITextureProvider Textures { get; private set; }
        public static Lumina.GameData Lumina => DataManager?.GameData;

        public static Configuration GlobalConfiguration { get; private set; }
        public static void Init(IDalamudPluginInterface pluginInterface)
        {            
            if (Inistialized)
            {
                Log.Warning("Services already initialized!");
                return;
            }
            Inistialized = true;
            try
            {                
                pluginInterface.Create<Services>();
            }
            catch (System.Exception ex)
            {
                Log.Fatal($"{ex.Message}\n\nStack Trace:\n{ex.StackTrace}");
            }
        }

        internal static void PostInit(Plugin plugin)
        {
            GlobalConfiguration = plugin.Configuration;
        }

        internal static void PrintInfo(string message, bool forcePrint = false)
        {
            if(DebugConfigWindow.PrintLogs || forcePrint)
                Log.Info(message);
        }
        internal static void PrintFatal(string message, bool forcePrint = false)
        {
            if (DebugConfigWindow.PrintLogs || forcePrint)
                Log.Info(message);
        }
    }
}
