using System;
using Dalamud.Configuration;

namespace TurboGCD;

[Serializable]
public sealed class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 1;

    public JobSave PLDConfig { get; private set; } = new JobSave(JobID.PLD);
    public JobSave WARConfig { get; private set; } = new JobSave(JobID.WAR);
    public JobSave DRKConfig { get; private set; } = new JobSave(JobID.DRK);
    public JobSave GNBConfig { get; private set; } = new JobSave(JobID.GNB);
    public JobSave WHMConfig { get; private set; } = new JobSave(JobID.WHM);
    public JobSave SCHConfig { get; private set; } = new JobSave(JobID.SCH);
    public JobSave ASTConfig { get; private set; } = new JobSave(JobID.AST);
    public JobSave SGEConfig { get; private set; } = new JobSave(JobID.SGE);
    public JobSave MNKConfig { get; private set; } = new JobSave(JobID.MNK);
    public JobSave DRGConfig { get; private set; } = new JobSave(JobID.DRG);
    public JobSave NINConfig { get; private set; } = new JobSave(JobID.NIN);
    public JobSave SAMConfig { get; private set; } = new JobSave(JobID.SAM);
    public JobSave RPRConfig { get; private set; } = new JobSave(JobID.RPR);
    public JobSave VPRConfig { get; private set; } = new JobSave(JobID.VPR);
    public JobSave BRDConfig { get; private set; } = new JobSave(JobID.BRD);
    public JobSave MCHConfig { get; private set; } = new JobSave(JobID.MCH);
    public JobSave DNCConfig { get; private set; } = new JobSave(JobID.DNC);
    public JobSave BLMConfig { get; private set; } = new JobSave(JobID.BLM);
    public JobSave SMNConfig { get; private set; } = new JobSave(JobID.SMN);
    public JobSave RDMConfig { get; private set; } = new JobSave(JobID.RDM);
    public JobSave PCTConfig { get; private set; } = new JobSave(JobID.PCT);

    // the below exist just to make saving less cumbersome

    public void Save()
    {
        Plugin.PluginInterface.SavePluginConfig(this);
    }

    public bool GetIsEnabledJob(JobID jobID)
    {
        bool is_enabled = false;
        switch (jobID)
        {
            case JobID.PLD: is_enabled = Services.GlobalConfiguration.PLDConfig.IsEnabled; break;
            case JobID.WAR: is_enabled = Services.GlobalConfiguration.WARConfig.IsEnabled; break;
            case JobID.GNB: is_enabled = Services.GlobalConfiguration.GNBConfig.IsEnabled; break;
            case JobID.DRK: is_enabled = Services.GlobalConfiguration.DRKConfig.IsEnabled; break;
            case JobID.WHM: is_enabled = Services.GlobalConfiguration.WHMConfig.IsEnabled; break;
            case JobID.SCH: is_enabled = Services.GlobalConfiguration.SCHConfig.IsEnabled; break;
            case JobID.SGE: is_enabled = Services.GlobalConfiguration.SGEConfig.IsEnabled; break;
            case JobID.AST: is_enabled = Services.GlobalConfiguration.ASTConfig.IsEnabled; break;
            case JobID.MNK: is_enabled = Services.GlobalConfiguration.MNKConfig.IsEnabled; break;
            case JobID.NIN: is_enabled = Services.GlobalConfiguration.NINConfig.IsEnabled; break;
            case JobID.DRG: is_enabled = Services.GlobalConfiguration.DRGConfig.IsEnabled; break;
            case JobID.SAM: is_enabled = Services.GlobalConfiguration.SAMConfig.IsEnabled; break;
            case JobID.RPR: is_enabled = Services.GlobalConfiguration.RPRConfig.IsEnabled; break;
            case JobID.VPR: is_enabled = Services.GlobalConfiguration.VPRConfig.IsEnabled; break;
            case JobID.DNC: is_enabled = Services.GlobalConfiguration.DNCConfig.IsEnabled; break;
            case JobID.BRD: is_enabled = Services.GlobalConfiguration.BRDConfig.IsEnabled; break;
            case JobID.MCH: is_enabled = Services.GlobalConfiguration.MCHConfig.IsEnabled; break;
            case JobID.BLM: is_enabled = Services.GlobalConfiguration.BLMConfig.IsEnabled; break;
            case JobID.RDM: is_enabled = Services.GlobalConfiguration.RDMConfig.IsEnabled; break;
            case JobID.PCT: is_enabled = Services.GlobalConfiguration.PCTConfig.IsEnabled; break;
            case JobID.SMN: is_enabled = Services.GlobalConfiguration.SMNConfig.IsEnabled; break;
        }
        return is_enabled;
    }

    public void SetIsEnabledJob(JobID jobID, bool is_enabled)
    {
        switch (jobID)
        {
            case JobID.PLD: Services.GlobalConfiguration.PLDConfig.IsEnabled =  is_enabled; break;
            case JobID.WAR: Services.GlobalConfiguration.WARConfig.IsEnabled =  is_enabled; break;
            case JobID.GNB: Services.GlobalConfiguration.GNBConfig.IsEnabled =  is_enabled; break;
            case JobID.DRK: Services.GlobalConfiguration.DRKConfig.IsEnabled =  is_enabled; break;
            case JobID.WHM: Services.GlobalConfiguration.WHMConfig.IsEnabled =  is_enabled; break;
            case JobID.SCH: Services.GlobalConfiguration.SCHConfig.IsEnabled =  is_enabled; break;
            case JobID.SGE: Services.GlobalConfiguration.SGEConfig.IsEnabled =  is_enabled; break;
            case JobID.AST: Services.GlobalConfiguration.ASTConfig.IsEnabled =  is_enabled; break;
            case JobID.MNK: Services.GlobalConfiguration.MNKConfig.IsEnabled =  is_enabled; break;
            case JobID.NIN: Services.GlobalConfiguration.NINConfig.IsEnabled =  is_enabled; break;
            case JobID.DRG: Services.GlobalConfiguration.DRGConfig.IsEnabled =  is_enabled; break;
            case JobID.SAM: Services.GlobalConfiguration.SAMConfig.IsEnabled =  is_enabled; break;
            case JobID.RPR: Services.GlobalConfiguration.RPRConfig.IsEnabled =  is_enabled; break;
            case JobID.VPR: Services.GlobalConfiguration.VPRConfig.IsEnabled =  is_enabled; break;
            case JobID.DNC: Services.GlobalConfiguration.DNCConfig.IsEnabled =  is_enabled; break;
            case JobID.BRD: Services.GlobalConfiguration.BRDConfig.IsEnabled =  is_enabled; break;
            case JobID.MCH: Services.GlobalConfiguration.MCHConfig.IsEnabled =  is_enabled; break;
            case JobID.BLM: Services.GlobalConfiguration.BLMConfig.IsEnabled =  is_enabled; break;
            case JobID.RDM: Services.GlobalConfiguration.RDMConfig.IsEnabled =  is_enabled; break;
            case JobID.PCT: Services.GlobalConfiguration.PCTConfig.IsEnabled =  is_enabled; break;
            case JobID.SMN: Services.GlobalConfiguration.SMNConfig.IsEnabled = is_enabled; break;
        }
    }
}

[Serializable]
public sealed class JobSave
{
    public readonly JobID JobID;
    public bool IsEnabled { get; set; } = true;
    public uint[] PVE { get; private set; }
    public uint[] PVP { get; private set; }

    public JobSave(JobID id)
    {
        JobID = id;
        PVP = new uint[0];
        PVE = JobStuff.RequestDefaultGCD(JobID);
    }

    public void UpdatePVE(uint[] newPVE)
    {
        PVE = newPVE;
        if (Services.ClientState.IsLoggedIn && Services.PlayerState.ClassJob.RowId == (uint)JobID && !Services.ClientState.IsPvP)
            Plugin.GamePad.UpdateJobMatrix(JobID, IsEnabled);
    }

    public void UpdatePVP(uint[] newPVP)
    {
        PVP = newPVP;
        if (Services.ClientState.IsLoggedIn && Services.PlayerState.ClassJob.RowId == (uint)JobID && Services.ClientState.IsPvP)
            Plugin.GamePad.UpdateJobMatrix(JobID, IsEnabled);
    }

    public uint[] GetDataForGamepad()
    {
        if (Services.ClientState.IsPvP)
            return PVP;
        return PVE;
    }
}
