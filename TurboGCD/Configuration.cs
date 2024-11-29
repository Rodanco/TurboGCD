using Dalamud.Configuration;
using Dalamud.Plugin;
using System;
using System.Runtime.Serialization;

namespace TurboGCD;

[Serializable]
public sealed class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 1;

    public JobSave PLDConfig {get; private set;} = new JobSave(JobID.PLD);
    public JobSave WARConfig {get; private set;} = new JobSave(JobID.WAR);
    public JobSave DRKConfig {get; private set;} = new JobSave(JobID.DRK);
    public JobSave GNBConfig {get; private set;} = new JobSave(JobID.GNB);
    public JobSave WHMConfig {get; private set;} = new JobSave(JobID.WHM);
    public JobSave SCHConfig {get; private set;} = new JobSave(JobID.SCH);
    public JobSave ASTConfig {get; private set;} = new JobSave(JobID.AST);
    public JobSave SGEConfig {get; private set;} = new JobSave(JobID.SGE);
    public JobSave MNKConfig {get; private set;} = new JobSave(JobID.MNK);
    public JobSave DRGConfig {get; private set;} = new JobSave(JobID.DRG);
    public JobSave NINConfig {get; private set;} = new JobSave(JobID.NIN);
    public JobSave SAMConfig {get; private set;} = new JobSave(JobID.SAM);
    public JobSave RPRConfig {get; private set;} = new JobSave(JobID.RPR);
    public JobSave VPRConfig {get; private set;} = new JobSave(JobID.VPR);
    public JobSave BRDConfig {get; private set;} = new JobSave(JobID.BRD);
    public JobSave MCHConfig {get; private set;} = new JobSave(JobID.MCH);
    public JobSave DNCConfig {get; private set;} = new JobSave(JobID.DNC);
    public JobSave BLMConfig {get; private set;} = new JobSave(JobID.BLM);
    public JobSave SMNConfig {get; private set;} = new JobSave(JobID.SMN);
    public JobSave RDMConfig {get; private set;} = new JobSave(JobID.RDM);
    public JobSave PCTConfig { get; private set; } = new JobSave(JobID.PCT);

    // the below exist just to make saving less cumbersome

    public void Save()
    {
        Plugin.PluginInterface.SavePluginConfig(this);
    }
}

[Serializable]
public sealed class JobSave
{
    public readonly JobID JobID;
    public uint[] PVE { get; private set;}
    public uint[] PVP { get; private set;}

    public JobSave(JobID id)
    {
        JobID = id;
        PVP = new uint[0];
        PVE = JobStuff.RequestDefaultGCD(JobID);
    }

    public void UpdatePVE(uint[] newPVE)
    {
        PVE = newPVE;
        if (Services.ClientState.IsLoggedIn && Services.ClientState.LocalPlayer.ClassJob.RowId == (uint)JobID && !Services.ClientState.IsPvP)
            Plugin.GamePad.UpdateJobMatrix(JobID);
    }

    public void UpdatePVP(uint[] newPVP)
    {
        PVP = newPVP;
        if (Services.ClientState.IsLoggedIn && Services.ClientState.LocalPlayer.ClassJob.RowId == (uint)JobID && Services.ClientState.IsPvP)
            Plugin.GamePad.UpdateJobMatrix(JobID);
    }

    public uint[] GetDataForGamepad()
    {
        if (Services.ClientState.IsPvP)
            return PVP;
        return PVE;
    }
}
