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
        }
    }
}
