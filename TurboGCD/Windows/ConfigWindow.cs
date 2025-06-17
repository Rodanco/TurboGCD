using Dalamud.Interface.Textures;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using Lumina.Data.Parsing.Scd;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;

namespace TurboGCD.Windows;

public class ConfigWindow : Window, IDisposable
{    
    private const float JobHeight = 30f, ActionHeight = 28.5f;
    private const float JobIconHeight = 21f, ActionIconHeight = 24f;
    private Configuration Configuration;
    private RoleCollapser[] Roles;

    private string[] childrenOpen;
    // We give this window a constant ID using ###
    // This allows for labels being dynamic, like "{FPS Counter}fps###XYZ counter window",
    // and the window ID will always be "###XYZ counter window" for ImGui
    public ConfigWindow(Plugin plugin) : base("TurboGCD Config Window")
    {
        Size = new Vector2(500, 500);
        SizeCondition = ImGuiCond.FirstUseEver;

        Configuration = plugin.Configuration;

        Services.Framework.GetTaskFactory().StartNew(() =>
        {
            try
            {
                var actionSheet = Services.DataManager.GameData.GetExcelSheet<Lumina.Excel.Sheets.Action>();
                Roles = new RoleCollapser[]
                {
                    new RoleCollapser(JobID.PLD, "TANK", new JobCollapser[]
                                              {
                                                  new (Configuration.PLDConfig, actionSheet),
                                                  new (Configuration.WARConfig, actionSheet),
                                                  new (Configuration.DRKConfig, actionSheet),
                                                  new (Configuration.GNBConfig, actionSheet)
                                              }),
                    new RoleCollapser(JobID.WHM, "HEALER", new JobCollapser[]
                                              {
                                                  new (Configuration.SCHConfig, actionSheet),
                                                  new (Configuration.WHMConfig, actionSheet),
                                                  new (Configuration.ASTConfig, actionSheet),
                                                  new (Configuration.SGEConfig, actionSheet)
                                              }),
                    new RoleCollapser(JobID.SAM, "MELEE", new JobCollapser[]
                                              {
                                                  new (Configuration.DRGConfig, actionSheet),
                                                  new (Configuration.MNKConfig, actionSheet),
                                                  new (Configuration.NINConfig, actionSheet),
                                                  new (Configuration.SAMConfig, actionSheet),
                                                  new (Configuration.RPRConfig, actionSheet),
                                                  new (Configuration.VPRConfig, actionSheet)
                                              }),
                    new RoleCollapser(JobID.MCH, "P.RANGE", new JobCollapser[]
                                              {
                                                  new (Configuration.BRDConfig, actionSheet),
                                                  new (Configuration.MCHConfig, actionSheet),
                                                  new (Configuration.DNCConfig, actionSheet)
                                              }),
                    new RoleCollapser(JobID.BLM, "CASTER", new JobCollapser[]
                                              {
                                                  new (Configuration.BLMConfig, actionSheet),
                                                  new (Configuration.SMNConfig, actionSheet),
                                                  new (Configuration.RDMConfig, actionSheet),
                                                  new (Configuration.PCTConfig, actionSheet)
                                              }),
                };
                childrenOpen = new[] { "", "", "", "", "" };
            }
            catch (System.Exception e)
            {
                Services.Log.Fatal($"{e.Message}\t{e.StackTrace}");
            }
        });
    }

    public void Dispose()
    {
    }

    public override void OnClose()
    {
        base.OnClose();

        Configuration.Save();
    }

    public override void PreDraw()
    {
        //// Flags must be added or removed before Draw() is being called, or they won't apply
        //if (Configuration.IsConfigWindowMovable)
        //{
        //    Flags &= ~ImGuiWindowFlags.NoMove;
        //}
        //else
        //{
        //    Flags |= ImGuiWindowFlags.NoMove;
        //}
    }

    public override void Draw()
    {
        int disableCount = 0, childCount = 0;
        try
        {
            ImGui.Text($"By default, all GCDs actions (Weaponskills and Spells) are enabled and all oGCDs actions (Abilities) are disabled.");

            float scaleMult = ImGui.GetIO().FontGlobalScale;
            // can't ref a property, so use a local copy
            int roleLength = Roles.Length;
            for (int roleIndex = 0; roleIndex < roleLength; roleIndex++)
            {
                var role = Roles[roleIndex];
                //ImGui.SetNextItemOpen(false);
                if (ImGui.CollapsingHeader(role.CollapserName))
                {
                    ImGui.SameLine(0, 3 * ImGui.GetStyle().ItemSpacing.X);
                    ImGui.Image(role.RoleIcon.GetWrapOrEmpty().ImGuiHandle, new(JobIconHeight * scaleMult, JobIconHeight * scaleMult), new(0, 0), new(1, 1));

                    float height = role.Jobs.Length * JobHeight;
                    //This serves to calculate the height since Dalamud had not updated yet ImGui.Net to at least 1.90.9.1
                    if (childrenOpen[roleIndex].Length > 0)
                    {
                        var childrenNames = childrenOpen[roleIndex];

                        foreach (var ch in childrenNames)
                        {
                            int indexJob = (int)Char.GetNumericValue(ch);
                            int ogcdCount = role.Jobs[indexJob].OGCDActionsData.Count;
                            int gcdCount = role.Jobs[indexJob].GCDActionsData.Count;
                            height += ((ogcdCount + gcdCount) * ActionHeight) + 22;
                        }
                    }
                    ImGui.BeginChild($"{role.CollapserName}_child", new(0, height * scaleMult), true, ImGuiWindowFlags.AlwaysAutoResize);

                    childCount++;

                    int length = role.Jobs.Length;
                    for (int jobIndex = 0; jobIndex < length; jobIndex++)
                    {
                        var job = role.Jobs[jobIndex];
                        //ImGui.SetNextItemOpen(false);
                        string idString = job.JobSave.JobID.ToString();
                        if (ImGui.CollapsingHeader(idString))
                        {
                            ImGui.SameLine(0, 3 * ImGui.GetStyle().ItemSpacing.X);
                            ImGui.Image(job.JobIcon.GetWrapOrEmpty().ImGuiHandle, new(JobIconHeight * scaleMult, JobIconHeight * scaleMult), new(0, 0), new(1, 1));

                            if (ImGui.Button($"Reset to default for {idString}"))
                            {
                                foreach (var action in job.OGCDActionsData)
                                    job.RemoveAction(action);
                                foreach (var action in job.GCDActionsData)
                                    job.AddAction(action);
                            }
                            string jistr = jobIndex.ToString();
                            if (!childrenOpen[roleIndex].Contains(jistr))
                                childrenOpen[roleIndex] = string.Concat(jistr, childrenOpen[roleIndex]);

                            ImGui.BeginChild($"{role.CollapserName}_{idString}_child", new(0, (job.OGCDActionsData.Count + job.GCDActionsData.Count) * ActionHeight * scaleMult), true);
                            childCount++;

                            ImGui.Text("oGCDs");
                            //if (ImGui.CollapsingHeader("oGCDs"))
                            {
                                foreach (var action in job.OGCDActionsData)
                                {
                                    DrawActionData(job, action, scaleMult, ref disableCount);
                                }
                            }
                            ImGui.Text("GCDs");
                            //if (ImGui.CollapsingHeader("GCDs"))
                            {
                                foreach (var action in job.GCDActionsData)
                                {
                                    DrawActionData(job, action, scaleMult, ref disableCount);
                                }
                            }
                            ImGui.EndChild();
                            childCount--;
                        }
                        else
                        {
                            childrenOpen[roleIndex] = childrenOpen[roleIndex].Replace(jobIndex.ToString(), "");
                            ImGui.SameLine(0, 3 * ImGui.GetStyle().ItemSpacing.X);
                            ImGui.Image(job.JobIcon.GetWrapOrEmpty().ImGuiHandle, new(JobIconHeight * scaleMult, JobIconHeight * scaleMult), new(0, 0), new(1, 1));
                        }
                    }

                    ImGui.EndChild();
                    childCount--;
                }
                else
                {
                    ImGui.SameLine(0, 3 * ImGui.GetStyle().ItemSpacing.X);
                    ImGui.Image(role.RoleIcon.GetWrapOrEmpty().ImGuiHandle, new(JobIconHeight * scaleMult, JobIconHeight * scaleMult), new(0, 0), new(1, 1));
                }
            }
        }
        catch (System.Exception e)
        {
            Services.Log.Fatal($"{e.Message}\n{e.StackTrace}");
            for (int i = childCount; i > 0; i--)
                ImGui.EndChild();
            for (int i = disableCount; i > 0; i--)
                ImGui.EndDisabled();
        }
        //var configValue = Configuration.SomePropertyToBeSavedAndWithADefault;
        //if (ImGui.Checkbox("Random Config Bool", ref configValue))
        //{
        //    Configuration.SomePropertyToBeSavedAndWithADefault = configValue;
        //    // can save immediately on change, if you don't want to provide a "Save and Close" button
        //    Configuration.Save();
        //}

        //var movable = Configuration.IsConfigWindowMovable;
        //if (ImGui.Checkbox("Movable Config Window", ref movable))
        //{
        //    Configuration.IsConfigWindowMovable = movable;
        //    Configuration.Save();
        //}
    }

    private void DrawActionData(in JobCollapser job, in ActionData action, in float scaleMult, ref int disableCount)
    {
        bool check = action.IsSelected;
        ImGui.BeginDisabled(!check);
        disableCount++;
        ImGui.Image(action.Texture.GetWrapOrEmpty().ImGuiHandle, new(ActionIconHeight * scaleMult, ActionIconHeight * scaleMult), new(0, 0), new(1, 1));
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

    class RoleCollapser
    {
        public readonly string CollapserName;
        public readonly ISharedImmediateTexture RoleIcon;
        public readonly JobCollapser[] Jobs;

        public RoleCollapser(JobID mainJob, string collapserName, JobCollapser[] jobs)
        {
            CollapserName = collapserName;
            Jobs = jobs;
            RoleIcon = Utilities.GetRoleIcon(mainJob);
        }
    }

    class JobCollapser
    {
        public readonly JobSave JobSave;
        public readonly ISharedImmediateTexture JobIcon;
        public readonly uint[] defaultOGCD, defaultGCD;
        public readonly IList<ActionData> OGCDActionsData, GCDActionsData;
        private readonly List<uint> allCurrent;
        public JobCollapser(JobSave jobSave, Lumina.Excel.ExcelSheet<Lumina.Excel.Sheets.Action>? actionSheet)
        {
            JobSave = jobSave;
            JobIcon = Utilities.GetJobIcon(JobSave.JobID);
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


public sealed class NewConfigWindow : Window, IDisposable
{
    private const float JobIconHeight = 21f, ActionIconHeight = 24f;
    private Configuration Configuration;
    private JobCollapser[] jobs_collapser;
    bool[] jobs_selected;
    int index_job_selected = -1;

    public NewConfigWindow(Plugin plugin) : base("Turbo GCD Config Window")
    {
        Size = new Vector2(500, 500);
        SizeCondition = ImGuiCond.FirstUseEver;

        Configuration = plugin.Configuration;

        Services.Framework.GetTaskFactory().StartNew(() =>
        {
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
            }
            catch (System.Exception e)
            {
                Services.Log.Fatal($"{e.Message}\t{e.StackTrace}");
            }
        });
    }

    public void Dispose() { }

    public override void OnClose()
    {
        base.OnClose();

        Configuration.Save();
    }

    public override void Draw()
    {
        float scaleMult = ImGui.GetIO().FontGlobalScale;
        if(ImGui.BeginChild("Jobs Buttons", new Vector2(150, ImGui.GetScrollY()), true))
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
                    ImGui.SameLine(0, 10);
                
                bool selected = ImGui.ImageButton(jobs_collapser[current_index].GetIcon(jobs_selected[current_index]), new Vector2(48, 48));
                if (current_index + 1 >= jobs_selected.Length)
                    continue;
                if (selected && index_job_selected != current_index)
                {
                    jobs_selected[current_index] = true;
                    Services.Log.Info($"{index_job_selected}, {current_index}");
                    if (index_job_selected > -1)
                        jobs_selected[index_job_selected] = false;
                    index_job_selected = current_index;
                }
            }
            ImGui.EndChild();
        }
        ImGui.SameLine();
        int disableCount = 0;
        if (ImGui.BeginChild("Jobs Actions", new Vector2(ImGui.GetWindowWidth() - 150 - ImGui.GetStyle().WindowPadding.X * 3, ImGui.GetScrollY()), true))
        {
            if (index_job_selected > -1)
            {
                var job = jobs_collapser[index_job_selected];
                bool enabled = job.IsEnabled;
                ImGui.Image(job.GetIcon(enabled), new Vector2(32, 32));
                ImGui.SameLine(0, 20);
                bool changed = ImGui.Checkbox("Is Enabled?", ref enabled);
                job.IsEnabled = enabled;
                if (changed && Plugin.GamePad.CurrentJob == job.JobID)
                    Plugin.GamePad.SetEnableForCurrentJob(enabled);

                if (!enabled)
                    ImGui.BeginDisabled();

                if(ImGui.BeginChild("job gcds", new Vector2(ImGui.GetColumnWidth() * .5f, ImGui.GetScrollY()), true))
                {
                    ImGui.SetCursorPosX((ImGui.GetColumnWidth() - ImGui.CalcTextSize("GCDs").X) * .5f);
                    ImGui.Text("GCDs");
                    foreach (var action in job.GCDActionsData)
                        DrawActionData(job, action, scaleMult, ref disableCount);
                    ImGui.EndChild();
                }
                ImGui.SameLine();
                if (ImGui.BeginChild("job ogcds", new Vector2(ImGui.GetColumnWidth(), ImGui.GetScrollY()), true))
                {
                    ImGui.SetCursorPosX((ImGui.GetColumnWidth() - ImGui.CalcTextSize("oGCDs").X) * .5f);
                    ImGui.Text("oGCDs");
                    foreach (var action in job.OGCDActionsData)
                        DrawActionData(job, action, scaleMult, ref disableCount);
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

    private void DrawActionData(in JobCollapser job, in ActionData action, in float scaleMult, ref int disableCount)
    {
        bool check = action.IsSelected;
        ImGui.BeginDisabled(!check);
        disableCount++;
        ImGui.Image(action.Texture.GetWrapOrEmpty().ImGuiHandle, new(ActionIconHeight * scaleMult, ActionIconHeight * scaleMult), new(0, 0), new(1, 1));
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

        public IntPtr GetIcon(bool is_selected) => is_selected ? JobIconActive.GetWrapOrDefault().ImGuiHandle : JobIconInactive.GetWrapOrDefault().ImGuiHandle;
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
