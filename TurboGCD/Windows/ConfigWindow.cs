using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Textures;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using Dalamud.Interface.Textures.TextureWraps;

namespace TurboGCD.Windows;

public sealed class NewConfigWindow : Window, IDisposable
{
    private const float JobIconHeight = 32f, ActionIconHeight = 24f;
    private Configuration Configuration;
    private JobCollapser[] jobs_collapser;
    bool[] jobs_selected;
    int index_job_selected = -1;
    private bool finished_initializing = false;
    static char[] loading_chars = { '-', '\\', '|', '/' };
    static uint load_tick = 0;

    public NewConfigWindow(Plugin plugin) : base("Turbo GCD Config Window")
    {
        Size = new Vector2(500, 500);
        SizeCondition = ImGuiCond.FirstUseEver;

        Configuration = plugin.Configuration;

        try
        {
            var actionSheet = Services.DataManager.GameData.GetExcelSheet<Lumina.Excel.Sheets.Action>();
            jobs_collapser = new JobCollapser[]
            {
                new (Configuration.PLDConfig, actionSheet),
                new (Configuration.WARConfig, actionSheet),
                new (Configuration.DRKConfig, actionSheet),
                new (Configuration.GNBConfig, actionSheet),
                new (Configuration.SCHConfig, actionSheet),
                new (Configuration.WHMConfig, actionSheet),
                new (Configuration.ASTConfig, actionSheet),
                new (Configuration.SGEConfig, actionSheet),
                new (Configuration.DRGConfig, actionSheet),
                new (Configuration.MNKConfig, actionSheet),
                new (Configuration.NINConfig, actionSheet),
                new (Configuration.SAMConfig, actionSheet),
                new (Configuration.RPRConfig, actionSheet),
                new (Configuration.VPRConfig, actionSheet),
                new (Configuration.BLMConfig, actionSheet),
                new (Configuration.SMNConfig, actionSheet),
                new (Configuration.RDMConfig, actionSheet),
                new (Configuration.PCTConfig, actionSheet),
                new (Configuration.BRDConfig, actionSheet),
                new (Configuration.MCHConfig, actionSheet),
                new (Configuration.DNCConfig, actionSheet),
            };
            jobs_selected = new bool[jobs_collapser.Length];
            finished_initializing = true;
            Services.Log.Info($"INIT DONE");
        }
        catch (System.Exception e)
        {
            Services.Log.Fatal($"{e.Message}\t{e.StackTrace}");
        }
    }

    public override void OnOpen()
    {
        base.OnOpen();

        if (!Services.ClientState.IsLoggedIn)
            return;
        var jobIndex = (JobID)Services.ClientState.LocalPlayer.ClassJob.RowId;
        if (jobIndex != JobID.None)
        {
            for (int i = jobs_collapser.Length - 1; i > -1; i--)
            {
                if (jobs_collapser[i].JobID == jobIndex)
                {
                    SelectJobIndex(i);
                    Services.PrintInfo($"Selecting job {jobIndex} on settings window");
                    return;
                }
            }
        }
    }

    public void Dispose() { }

    public override void OnClose()
    {
        base.OnClose();

        Configuration.Save();
    }

    public override void Draw()
    {
        if (!finished_initializing)
        {
            ImGui.Text($"Loading {loading_chars[load_tick++ % loading_chars.Length]}");
            return;
        }
        float global_scale = ImGuiHelpers.GlobalScaleSafe;
        if (ImGui.BeginChild("Jobs Buttons", new Vector2(110 * global_scale, ImGui.GetScrollY()), true))
        {
            int current_index = 0;
            for (current_index = 0; current_index < jobs_selected.Length; current_index++)
            {
                switch (current_index)
                {
                    case 0:
                        ImGui.Text("Tank");
                        break;
                    case 4:
                        ImGui.NewLine();
                        ImGui.Text("Healer");
                        break;
                    case 8:
                        ImGui.NewLine();
                        ImGui.Text("Melee");
                        break;
                    case 14:
                        ImGui.NewLine();
                        ImGui.Text("Caster");
                        break;
                    case 18:
                        ImGui.NewLine();
                        ImGui.Text("Ranged");
                        break;
                }
                if (current_index % 2 == 1)
                    ImGui.SameLine(0, 10 * global_scale);

                bool selected = ImGui.ImageButton(jobs_collapser[current_index].GetIcon(jobs_selected[current_index]), new Vector2(JobIconHeight * global_scale, JobIconHeight * global_scale));
                if (current_index + 1 >= jobs_selected.Length)
                    continue;
                if (selected && index_job_selected != current_index)
                {
                    SelectJobIndex(current_index);
                    // jobs_selected[current_index] = true;
                    // Services.Log.Info($"{index_job_selected}, {current_index}");
                    // if (index_job_selected > -1)
                    //     jobs_selected[index_job_selected] = false;
                    // index_job_selected = current_index;
                }
            }
            ImGui.EndChild();
        }
        ImGui.SameLine();
        int disableCount = 0;
        if (ImGui.BeginChild("Jobs Actions", new Vector2(ImGui.GetWindowWidth() - 110 * global_scale - ImGui.GetStyle().WindowPadding.X * 3, ImGui.GetScrollY()), true))
        {
            if (index_job_selected > -1)
            {
                var job = jobs_collapser[index_job_selected];
                bool enabled = job.IsEnabled;
                ImGui.Image(job.GetIcon(enabled), new Vector2(ActionIconHeight * global_scale, ActionIconHeight * global_scale));
                ImGui.SameLine(0, 20 * global_scale);
                bool changed = ImGui.Checkbox("Is Enabled?", ref enabled);
                job.IsEnabled = enabled;
                if (changed && Plugin.GamePad.CurrentJob == job.JobID)
                    Plugin.GamePad.SetEnableForCurrentJob(enabled);

                if (!enabled)
                    ImGui.BeginDisabled();

                if (ImGui.BeginChild("job gcds", new Vector2(ImGui.GetColumnWidth() * .5f, ImGui.GetScrollY()), true))
                {
                    ImGui.SetCursorPosX((ImGui.GetColumnWidth() - ImGui.CalcTextSize("GCDs").X) * .5f);
                    ImGui.Text("GCDs");
                    foreach (var action in job.GCDActionsData)
                        DrawActionData(job, action, ref disableCount);
                    ImGui.EndChild();
                }
                ImGui.SameLine();
                if (ImGui.BeginChild("job ogcds", new Vector2(ImGui.GetColumnWidth(), ImGui.GetScrollY()), true))
                {
                    ImGui.SetCursorPosX((ImGui.GetColumnWidth() - ImGui.CalcTextSize("oGCDs").X) * .5f);
                    ImGui.Text("oGCDs");
                    foreach (var action in job.OGCDActionsData)
                        DrawActionData(job, action, ref disableCount);
                    ImGui.EndChild();
                }
                if (!enabled)
                    ImGui.EndDisabled();
            }
            ImGui.EndChild();
        }
        for (int i = 0; i < disableCount; i++)
            ImGui.EndDisabled();
    }

    private void SelectJobIndex(int job_index)
    {
        jobs_selected[job_index] = true;
        Services.Log.Info($"{index_job_selected}, {job_index}");
        if (index_job_selected > -1)
            jobs_selected[index_job_selected] = false;
        index_job_selected = job_index;
    }

    private void DrawActionData(in JobCollapser job, in ActionData action, ref int disableCount)
    {
        float global_scale = ImGuiHelpers.GlobalScaleSafe;
        bool check = action.IsSelected;
        ImGui.BeginDisabled(!check);
        disableCount++;
        ImGui.Image(action.Texture.GetWrapOrEmpty().Handle, new(ActionIconHeight * global_scale, ActionIconHeight * global_scale), new(0, 0), new Vector2(1, 1));
        ImGui.EndDisabled();
        disableCount--;
        ImGui.SameLine(0, 1 * ImGui.GetStyle().ItemSpacing.X);
        if (ImGui.Checkbox(action.Name, ref check))
        {
            if (check)
                job.AddAction(action);
            else
                job.RemoveAction(action);
            action.IsSelected = check;
            Configuration.Save();
        }
    }


    class JobCollapser
    {
        public readonly TurboGCD.JobSave JobSave;
        public readonly ISharedImmediateTexture JobIconActive, JobIconInactive;
        public readonly uint[] defaultOGCD, defaultGCD;
        public readonly IList<ActionData> OGCDActionsData, GCDActionsData;
        private readonly List<uint> allCurrent;
        public readonly JobID JobID;

        public JobCollapser(TurboGCD.JobSave jobSave, Lumina.Excel.ExcelSheet<Lumina.Excel.Sheets.Action>? actionSheet)
        {
            JobID = jobSave.JobID;
            JobSave = jobSave;
            JobIconActive = Utilities.GetJobIcon(JobSave.JobID);
            JobIconInactive = Utilities.GetJobIconSimple(JobSave.JobID);
            defaultOGCD = JobStuff.RequestDefaultOGCD(JobSave.JobID);
            defaultGCD = JobStuff.RequestDefaultGCD(JobSave.JobID);
            allCurrent = new List<uint>(JobSave.PVE);
            var ogcdList = new List<ActionData>(defaultOGCD.Length);
            var gcdList = new List<ActionData>(defaultGCD.Length);
            if (JobStuff.JobsEquivalentActions.TryGetValue(JobSave.JobID, out var collapsedActions))
            {
                List<uint> idsAlreadyAdded = new List<uint>(20);
                foreach (var ogcd in defaultOGCD)
                {
                    if (idsAlreadyAdded.Contains(ogcd))
                        continue;
                    if (collapsedActions.TryGetValue(ogcd, out var equivalents))
                    {
                        bool allAdded = true;
                        int length = equivalents.Length;
                        List<string> names = new List<string>(length);
                        uint icon = 0;
                        for (int i = 0; i < length; i++)
                        {
                            uint id = equivalents[i];
                            allAdded &= allCurrent.Contains(id);
                            var action = actionSheet[id];
                            var name = action.Name.ToString();
                            if (!names.Contains(name))
                                names.Add(name);
                            icon = action.Icon;
                        }
                        ogcdList.Add(new ActionData(equivalents, Utilities.GetIcon(icon), names.ToArray(), allAdded));
                        idsAlreadyAdded.AddRange(equivalents);
                    }
                    else
                    {
                        var action = actionSheet[ogcd];
                        bool inList = JobSave.PVE.Contains(ogcd);
                        ogcdList.Add(new ActionData(new[] { ogcd }, Utilities.GetIcon(action.Icon), new[] { action.Name.ToString() }, inList));
                    }
                }
                foreach (var gcd in defaultGCD)
                {
                    if (idsAlreadyAdded.Contains(gcd))
                        continue;
                    if (collapsedActions.TryGetValue(gcd, out var equivalents))
                    {
                        bool allAdded = true;
                        int length = equivalents.Length;
                        List<string> names = new List<string>(length);
                        uint icon = 0;
                        for (int i = 0; i < length; i++)
                        {
                            uint id = equivalents[i];
                            allAdded &= allCurrent.Contains(id);
                            var action = actionSheet[id];
                            var name = action.Name.ToString();
                            if (!names.Contains(name))
                                names.Add(name);
                            icon = action.Icon;
                        }
                        gcdList.Add(new ActionData(equivalents, Utilities.GetIcon(icon), names.ToArray(), allAdded));
                        idsAlreadyAdded.AddRange(equivalents);
                    }
                    else
                    {
                        var action = actionSheet[gcd];
                        bool inList = JobSave.PVE.Contains(gcd);
                        gcdList.Add(new ActionData(new[] { gcd }, Utilities.GetIcon(action.Icon), new[] { action.Name.ToString() }, inList));
                    }
                }
            }
            else
            {
                foreach (var ogcd in defaultOGCD)
                {
                    var action = actionSheet[ogcd];
                    bool inList = JobSave.PVE.Contains(ogcd);
                    ogcdList.Add(new ActionData(new[] { ogcd }, Utilities.GetIcon(action.Icon), new[] { action.Name.ToString() }, inList));
                }
                foreach (var gcd in defaultGCD)
                {
                    var action = actionSheet[gcd];
                    bool inList = JobSave.PVE.Contains(gcd);
                    gcdList.Add(new ActionData(new[] { gcd }, Utilities.GetIcon(action.Icon), new[] { action.Name.ToString() }, inList));
                }
            }
            OGCDActionsData = ogcdList.ToArray();
            GCDActionsData = gcdList.ToArray();
        }

        public ImTextureID GetIcon(bool is_selected)
        {
            if (is_selected)
            {
                return JobIconActive.GetWrapOrEmpty().Handle;
            }            
            return JobIconInactive.GetWrapOrEmpty().Handle;
        }
        public void AddAction(in ActionData data)
        {
            var ids = data.ActionIds;
            foreach (var id in ids)
            {
                if (!allCurrent.Contains(id))
                    allCurrent.Add(id);
            }
            data.IsSelected = true;
            JobSave.UpdatePVE(allCurrent.ToArray());
        }

        public void RemoveAction(in ActionData data)
        {
            var ids = data.ActionIds;
            foreach (var id in ids)
            {
                if (allCurrent.Contains(id))
                    allCurrent.RemoveAll(i => i == id);
            }
            data.IsSelected = false;
            JobSave.UpdatePVE(allCurrent.ToArray());
        }

        public void SetIsEnabled(bool enabled) => JobSave.IsEnabled = enabled;
        public bool IsEnabled { get => JobSave.IsEnabled; set => JobSave.IsEnabled = value; }
    }

    sealed class ActionData
    {
        public readonly uint[] ActionIds;
        public readonly ISharedImmediateTexture Texture;
        public readonly string Name;
        public bool IsSelected { get; set; }
        public ActionData(uint[] ids, ISharedImmediateTexture texture, string[] names, bool selected)
        {
            ActionIds = ids;
            Texture = texture;
            var builder = new StringBuilder();
            foreach (var n in names)
                builder.Append(n).Append('/');
            builder.Remove(builder.Length - 1, 1);
            Name = builder.ToString();
            IsSelected = selected;
        }
    }
}
