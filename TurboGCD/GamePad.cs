using System;
using System.Linq;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.GamePad;
using Dalamud.Hooking;
using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace TurboGCD
{
    public unsafe sealed class GamePad//
    {
        private const int randomRange = 25;
        private const long minimalDelayChangeSet = 16L, quickSwapChangeSet = 250;
        private const CrossHotbarFlags FlagsToRemove = CrossHotbarFlags.EditMode | CrossHotbarFlags.FadeRestOfScreen | CrossHotbarFlags.PetHotbarActive;
        private const CrossHotbarFlags FirstBar = CrossHotbarFlags.LeftSideToggleFocus | CrossHotbarFlags.LeftSideHoldFocus | CrossHotbarFlags.LeftSideFocus | CrossHotbarFlags.RightSideToggleFocus | CrossHotbarFlags.RightSideHoldFocus | CrossHotbarFlags.RightSideFocus;
        private const CrossHotbarFlags SecondBar = CrossHotbarFlags.ExpandedHoldLeftFocus | CrossHotbarFlags.ExpandedHoldRightFocus;
        private const CrossHotbarFlags ThirdBar = CrossHotbarFlags.WXHBLeftFocus | CrossHotbarFlags.WXHBRightFocus;
        private const CrossHotbarFlags LeftSide = CrossHotbarFlags.LeftSideFocus | CrossHotbarFlags.ExpandedHoldLeftFocus | CrossHotbarFlags.WXHBLeftFocus;
        private const CrossHotbarFlags RightSide = CrossHotbarFlags.RightSideFocus | CrossHotbarFlags.ExpandedHoldRightFocus | CrossHotbarFlags.WXHBRightFocus;
        private static readonly GamepadButtons[] Buttons =
        {
            GamepadButtons.DpadLeft,
            GamepadButtons.DpadUp,
            GamepadButtons.DpadRight,
            GamepadButtons.DpadDown,
            GamepadButtons.West,
            GamepadButtons.North,
            GamepadButtons.East,
            GamepadButtons.South
        };
        private static readonly GamepadButtons[] ChangeSet =
        {
            GamepadButtons.North,
            GamepadButtons.West,
            GamepadButtons.South,
            GamepadButtons.East,
            GamepadButtons.DpadUp,
            GamepadButtons.DpadRight,
            GamepadButtons.DpadDown,
            GamepadButtons.DpadLeft
        };
        private static GamepadButtons LeftWXHB { get; set; } = GamepadButtons.L2;
        private static GamepadButtons RightWXHB { get; set; } = GamepadButtons.R2;


        private readonly int ButtonsLength = Buttons.Length;

        /// <summary>
        /// This is the value used for math when holding a button normally. 
        /// </summary>
        private long fixedThrottleDelay { get; set; } = 200;
        /// <summary>
        /// This is the value used for math when you hold a button, it executes an action and that CrossBar Slot changes to another action that has less than 1s recast time
        /// </summary>
        //private long forcedThrottleDelay { get; set; } = 1500;
        /// <summary>
        /// This is the actual time need to wait for normal holding button.
        /// </summary>
        private long currentThrottleDelay { get; set; } = 200;
        /// <summary>
        /// This is the actual time need to wait for when you hold a button for too long that it executes an action and changes to another action with recast time less than 1s (and you never release it)
        /// </summary>
        //private long dynamicForcedThrottle { get; set; } = 500;


        private Hook<ControllerPoll>? gamepadPoll;
        private delegate int ControllerPoll(IntPtr controllerInput);
        //private Hook<ActionManager.Delegates.UseAction>? useActionDetour {  get; set; }
        private RaptureHotbarModule* HotbarModule { get; set; }
        //private ActionManager* ActionMan { get; set; }

        //private  bool[,] possiblesInputs;
        private int offsetCrossbar = 0;
        private uint[] gcdsToCheck { get; set; }
        private bool is_job_enabled { get; set; } = true;
        private Random RandomRange { get; set; }
        public JobID CurrentJob { get; private set; }

        private GamepadButtons lastButtonHold { get; set; }
        private uint lastActionHold { get; set; }

        public AddonActionCross* AddonCross { get; set; }

        public void Initialize()
        {
            if (RandomRange == null)
                RandomRange = new Random();
            try
            {
                if (gamepadPoll == null)
                    gamepadPoll = Services.Hooks.HookFromSignature<ControllerPoll>("40 55 53 57 41 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC ?? ?? ?? ?? 44 0F 29 B4 24 ?? ?? ?? ??", GamepadPool);
            }
            catch (Exception e)
            {
                Services.Log.Error(e.Message);
            }
            if (AddonCross == null)
                AddonCross = (AddonActionCross*)Services.GameGui.GetAddonByName("_ActionCross");
            gamepadPoll?.Enable();

            if (HotbarModule == null)
                HotbarModule = RaptureHotbarModule.Instance();
        }

        public void UpdateJobMatrix(JobID jobIndex = JobID.None, bool is_enabled = true)//
        {
            Services.PrintInfo($"Starting updating job matrix with jobIndex {jobIndex}");
            is_job_enabled = is_enabled;
            if (jobIndex == JobID.None)
            {
                jobIndex = (JobID)Services.ClientState.LocalPlayer.ClassJob.RowId;
                is_job_enabled = Services.GlobalConfiguration.GetIsEnabledJob(jobIndex);
                Services.PrintInfo($"Updating job matrix to {jobIndex}");
            }
            CurrentJob = jobIndex;
            gcdsToCheck = JobStuff.RequestActionsFromJobId(jobIndex);
        }

        public void SetEnableForCurrentJob(bool is_enabled)
        {
            is_job_enabled = is_enabled;
            Services.GlobalConfiguration.SetIsEnabledJob(CurrentJob, is_enabled);
        }

        private int GamepadPool(IntPtr requestInput)
        {
            if (!is_job_enabled)
                return gamepadPoll!.Original(requestInput);
            int crossBarIndex = 0, buttonIndex = 0;
            try
            {
                if (AddonCross->RaptureHotbarId < 10)
                    return gamepadPoll!.Original(requestInput);
                var gamepadInput = (PadDevice*)requestInput;
                if (HotbarModule == null)
                    HotbarModule = RaptureHotbarModule.Instance();
                var flags = HotbarModule->CrossHotbarFlags;

                bool inCombat = Services.Condition[ConditionFlag.InCombat];
                bool flagsAreGood = IsHotbarFlagGood(flags);
                if (!inCombat || !flagsAreGood || gcdsToCheck == null || gcdsToCheck.Length == 0)
                {
                    if (Environment.TickCount64 >= currentThrottleDelay)
                    {
                        Services.PrintInfo($"InCombat: {inCombat}\tIsHotbarFlagGood: {flagsAreGood}\tgdcsToCheck: {(gcdsToCheck == null ? 0 : gcdsToCheck.Length)} length  Flags: {flags.ToString()}");
                        currentThrottleDelay = Environment.TickCount64 + fixedThrottleDelay;
                    }
                    return gamepadPoll!.Original(requestInput);
                }

                if ((flags & FirstBar) > 0)
                {
                    //crossBarIndex = 0 + offsetCrossbar;
                    crossBarIndex = AddonCross->RaptureHotbarId - 10;
                }
                else if ((flags & SecondBar) > 0)
                {
                    //crossBarIndex = 1;
                    if (AddonCross->ExpandedHoldMapValue < 1u)
                    {
                        Services.PrintFatal($"Expanded Hold Map Value = 0 ({AddonCross->ExpandedHoldMapValue})");
                        return gamepadPoll!.Original(requestInput);
                    }
                    crossBarIndex = (int)((AddonCross->ExpandedHoldMapValue - 1u) / 2);
                }
                else if ((flags & ThirdBar) > 0)
                {
                    if (AddonCross->ExpandedHoldMapValue < 1u)
                    {
                        Services.PrintFatal($"Expanded Hold Map Value = 0 ({AddonCross->ExpandedHoldMapValue})");
                        return gamepadPoll!.Original(requestInput);
                    }
                    crossBarIndex = (int)((AddonCross->ExpandedHoldMapValue - 1u) / 2);
                }
                else
                {
                    Services.PrintInfo($"Returning before check loop");
                    return gamepadPoll!.Original(requestInput);
                }
                Services.PrintInfo($"Crossbar Number {crossBarIndex + 1}");
                int indexToPrint = (HotbarModule != null && !HotbarModule->CrossHotbars.IsEmpty) ? HotbarModule->CrossHotbars.Length : -1;
                Services.PrintInfo($"HotbarModule {HotbarModule != null}   CrossHotBars.Length {indexToPrint}");
                int sumButtom = (flags & RightSide) > 0 ? ButtonsLength : 0;
                var crossbar = HotbarModule->CrossHotbars[crossBarIndex];
                for (int i = 0; i < ButtonsLength; i++)
                {
                    buttonIndex = i + sumButtom;
                    var slot = crossbar.Slots[i + sumButtom];
                    var button = Buttons[i];
                    if (IsButtonHeld(button) && slot.ApparentSlotType == RaptureHotbarModule.HotbarSlotType.Action && gcdsToCheck.Contains(slot.ApparentActionId))
                    {
                        if (Environment.TickCount64 >= currentThrottleDelay)
                        {
                            float randomness = ((RandomRange.Next(randomRange) - (randomRange * 0.5f)) * 0.01f) + 1f;
                            currentThrottleDelay = Environment.TickCount64 + (long)Math.Round(fixedThrottleDelay * randomness);

                            gamepadInput->GamepadInputData.Buttons &= ~(GamepadButtonsFlags)Buttons[i];
                            lastButtonHold = button;
                            lastActionHold = slot.ApparentActionId;
                        }
                    }
                }
                return gamepadPoll.Original((IntPtr)gamepadInput);
            }
            catch (Exception e)
            {
                Services.Log.Fatal($"Bar {crossBarIndex} Slot {buttonIndex}\t{e.Message}\tStack Trace:\n{e.StackTrace}");
            }
            return gamepadPoll.Original(requestInput);
        }

        /*private bool UseActionDetour(ActionManager* self, ActionType actionType, uint actionId, ulong targetId, uint extraParam, ActionManager.UseActionMode mode, uint comboRouteId, bool* outOptAreaTargeted)
        {
            bool willExecute = useActionDetour.Original(self, actionType, actionId, targetId, extraParam, mode, comboRouteId, outOptAreaTargeted);
            if (willExecute)
            {
                dynamicForcedThrottle = Environment.TickCount64/* + (long)(Math.Round(forcedThrottleDelay * 1.05f));
                checkForDynamicThrottle = true;
                Services.PrintInfo($"EXECUTED - mode: {mode}\tlastAction: {lastActionHold}\taction: {actionId}\tdynamicTime: {dynamicForcedThrottle}");
            }
            return willExecute;
        }*/

        private bool IsHotbarFlagGood(CrossHotbarFlags flags)
        {
            return (flags & FlagsToRemove) == 0 && flags > CrossHotbarFlags.Active;
        }

        private bool IsButtonHeld(GamepadButtons button) => Services.GamepadState.Raw(button) == 1;
        private bool IsButtonPressed(GamepadButtons button) => Services.GamepadState.Pressed(button) == 1;
        private bool IsButtonReleased(GamepadButtons button) => Services.GamepadState.Released(button) == 1;

        public void Enable()
        {
            gamepadPoll?.Enable();
            var other = (AddonActionCross*)Services.GameGui.GetAddonByName("_ActionCross");
            if (AddonCross == null || AddonCross->IsVisible != other->IsVisible)
                AddonCross = other;
            Services.PrintInfo("Enabling GamePad.cs");
            //useActionDetour?.Enable();
        }

        public void Disable()
        {
            gamepadPoll?.Disable();
            Services.PrintInfo("Disabling GamePad.cs");
            //useActionDetour?.Disable();
        }

        public void Dispose()
        {
            gamepadPoll?.Dispose();
            Services.PrintInfo("Disposing GamePad.cs");
            //useActionDetour?.Dispose();
        }

        internal void RecheckStuff()
        {
            if (HotbarModule == null)
                HotbarModule = RaptureHotbarModule.Instance();
            if (gamepadPoll == null)
                gamepadPoll = Services.Hooks.HookFromSignature<ControllerPoll>("40 55 53 57 41 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC ?? ?? ?? ?? 44 0F 29 B4 24 ?? ?? ?? ??", GamepadPool);
            var addon = (AddonActionCross*)Services.GameGui.GetAddonByName("_ActionCross");
            if (AddonCross == null || AddonCross != addon)
            {
                AddonCross = addon;
                Services.PrintInfo($"Had to update AddonCross");
            }
        }
    }
}
