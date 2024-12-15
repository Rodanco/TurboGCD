using Dalamud.Game.Config;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using Lumina.Excel.Sheets;
using System;

namespace TurboGCD.Windows
{
    internal class DebugConfigWindow : Window, IDisposable
    {
        private static bool printLogs = false;
        public static bool PrintLogs => printLogs;
        public DebugConfigWindow(Plugin plugin) : base("TurboGCD debug config window")
        {
        }

        public void Dispose()
        {
        }

        public override void Draw()
        {
            ImGui.Checkbox("Enable Debug Logs", ref printLogs);
            try
            {
                if (ImGui.Button("Print Thing"))
                {
                    DoThing();
                }
            }
            catch (System.Exception ex) 
            {
                Services.PrintFatal(ex.Message, true);
            }
        }

        private unsafe void DoThing()
        {
            var addon = (FFXIVClientStructs.FFXIV.Client.UI.AddonActionCross*)Services.GameGui.GetAddonByName("_ActionCross");
            var aux = Services.GameConfig.TryGet(UiConfigOption.HotbarWXHBSetLeft, out uint value);
            Services.Log.Info($"{addon->RaptureHotbarId.ToString()} {addon->ExpandedHoldMapValue} {aux}? {value}");
        }
    }
}
