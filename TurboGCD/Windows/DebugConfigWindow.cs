using System;
using System.Collections;
using System.Linq;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using Dalamud.Bindings.ImGui;

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
        }
    }
}
