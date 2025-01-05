using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Newtonsoft.Json;
using System.IO;
using TurboGCD.Windows;

namespace TurboGCD;

public sealed class Plugin : IDalamudPlugin
{
    [PluginService] internal static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
    public Configuration Configuration { get; init; }

    public readonly WindowSystem WindowSystem = new("TurboGCD");
    private ConfigWindow ConfigWindow { get; init; }
    private DebugConfigWindow debugConfigWindow { get; init; }
    public static GamePad GamePad { get; private set; }
    private bool hasLoggedIn { get; set; }

    public Plugin()
    {
        Services.Init(PluginInterface);
        Configuration = PluginInterface.GetPluginConfig() as Configuration;
        if (Configuration == null)
            Configuration = new Configuration();
        else
        {
            var configFile = $"{PluginInterface.GetPluginConfigDirectory()}.json";
            if (File.Exists(configFile))
            {
                var jsonString = File.ReadAllText(configFile);
                var setting = new JsonSerializerSettings();
                setting.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
                setting.ContractResolver = new ContractResolverWithPrivates();
                var aux = JsonConvert.DeserializeObject<Configuration>(jsonString, setting);
                if (aux != null)
                    Configuration = aux;
            }
        }

        Services.Command.AddHandler("/turbogcd", new Dalamud.Game.Command.CommandInfo(ToggleSettingCommand) { HelpMessage = "Open Settings for TurboGCD" });
        Services.Command.AddHandler("/turbogcddebug", new Dalamud.Game.Command.CommandInfo(ToggleDebugCommand) { HelpMessage = "Open Debug Settings for TurboGCD", ShowInHelp = false });


        // you might normally want to embed resources and load them from the manifest stream
        //var goatImagePath = Path.Combine(PluginInterface.AssemblyLocation.Directory?.FullName!, "goat.png");
        if (ConfigWindow == null)
            ConfigWindow = new ConfigWindow(this);
        if (debugConfigWindow == null)
            debugConfigWindow = new DebugConfigWindow(this);

        WindowSystem.AddWindow(ConfigWindow);
        WindowSystem.AddWindow(debugConfigWindow);

        PluginInterface.UiBuilder.Draw += DrawUI;

        // This adds a button to the plugin installer entry of this plugin which allows
        // to toggle the display status of the configuration ui
        PluginInterface.UiBuilder.OpenConfigUi += ToggleConfigUI;

        if (GamePad == null)
            GamePad = new GamePad();

        Services.ClientState.Login += ClientState_Login;
        Services.ClientState.Logout += ClientState_Logout;
        Services.ClientState.ClassJobChanged += ClassJobChanged;
        hasLoggedIn = Services.ClientState.IsLoggedIn;
        Services.PostInit(this);

        if (hasLoggedIn)
            Services.Framework.GetTaskFactory().StartNew(() =>
        {
            GamePad.UpdateJobMatrix();
            GamePad.Initialize();
        });
    }

    private void ToggleDebugCommand(string command, string arguments)
    {
        debugConfigWindow?.Toggle();
    }

    private void ToggleSettingCommand(string command, string arguments)
    {
        ToggleConfigUI();
    }

    private void ClientState_Logout(int type, int code)
    {
        hasLoggedIn = false;
        GamePad.Disable();
    }

    private void ClientState_Login()
    {
        hasLoggedIn = true;
        GamePad.UpdateJobMatrix();
        GamePad.Initialize();
    }

    private unsafe void ClassJobChanged(uint classJobId)
    {
        if (!hasLoggedIn)
            return;
        GamePad.UpdateJobMatrix((JobID)classJobId);
        //Services.PrintInfo($"{classJobId} {Services.ClientState.LocalPlayer.ClassJob.Value.RowId} {Services.ClientState.LocalPlayer.ClassJob.Value.NameEnglish}\tD-Pad Up L2 slot action {FFXIVClientStructs.FFXIV.Client.UI.Misc.RaptureHotbarModule.Instance()->CrossHotbars[0].Slots[1].ApparentActionId}");

    }

    public void Dispose()
    {
        WindowSystem.RemoveAllWindows();

        ConfigWindow.Dispose();
        Services.Command.RemoveHandler("/turbogcd");

        GamePad.Dispose();
    }

    private void DrawUI() => WindowSystem.Draw();

    public void ToggleConfigUI() => ConfigWindow.Toggle();
}
