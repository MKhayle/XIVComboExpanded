using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class GNB
    {
        public const byte JobID = 37;

        public const uint
            KeenEdge = 16137,
            NoMercy = 16138,
            BrutalShell = 16139,
            DemonSlice = 16141,
            SolidBarrel = 16145,
            GnashingFang = 16146,
            DemonSlaughter = 16149,
            SonicBreak = 16153,
            Continuation = 16155,
            JugularRip = 16156,
            AbdomenTear = 16157,
            EyeGouge = 16158,
            BowShock = 16159,
            BurstStrike = 16162,
            FatedCircle = 16163,
            Bloodfest = 16164,
            Hypervelocity = 25759,
            DoubleDown = 25760;

        public static class Buffs
        {
            public const ushort
                NoMercy = 1831,
                ReadyToRip = 1842,
                ReadyToTear = 1843,
                ReadyToGouge = 1844,
                ReadyToBlast = 2686;
        }

        public static class Debuffs
        {
            public const ushort
                BowShock = 1838;
        }

        public static class Levels
        {
            public const byte
                NoMercy = 2,
                BrutalShell = 4,
                SolidBarrel = 26,
                DemonSlaughter = 40,
                SonicBreak = 54,
                BowShock = 62,
                Continuation = 70,
                FatedCircle = 72,
                Bloodfest = 76,
                EnhancedContinuation = 86,
                CartridgeCharge2 = 88,
                DoubleDown = 90;
        }
    }

    internal class GunbreakerSolidBarrelCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerSolidBarrelCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { GNB.SolidBarrel };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.SolidBarrel)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == GNB.BrutalShell && level >= GNB.Levels.SolidBarrel)
                        return GNB.SolidBarrel;

                    if (lastComboMove == GNB.KeenEdge && level >= GNB.Levels.BrutalShell)
                        return GNB.BrutalShell;
                }

                return GNB.KeenEdge;
            }

            return actionID;
        }
    }

    internal class GunbreakerGnashingFangContinuation : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerGnashingFangCont;

        protected internal override uint[] ActionIDs { get; } = new[] { GNB.GnashingFang };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.GnashingFang)
            {
                if (level >= GNB.Levels.Continuation)
                {
                    if (HasEffect(GNB.Buffs.ReadyToGouge))
                        return GNB.EyeGouge;

                    if (HasEffect(GNB.Buffs.ReadyToTear))
                        return GNB.AbdomenTear;

                    if (HasEffect(GNB.Buffs.ReadyToRip))
                        return GNB.JugularRip;
                }

                // Gnashing Fang > Savage Claw > Wicked Talon
                return OriginalHook(GNB.GnashingFang);
            }

            return actionID;
        }
    }

    internal class GunbreakerBurstStrikeFatedCircle : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GnbAny;

        protected internal override uint[] ActionIDs { get; } = new[] { GNB.BurstStrike, GNB.FatedCircle };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.BurstStrike)
            {
                if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont))
                {
                    if (level >= GNB.Levels.EnhancedContinuation && HasEffect(GNB.Buffs.ReadyToBlast))
                        return GNB.Hypervelocity;
                }
            }

            if (actionID == GNB.BurstStrike || actionID == GNB.FatedCircle)
            {
                var gauge = GetJobGauge<GNBGauge>();

                if (IsEnabled(CustomComboPreset.GunbreakerDoubleDownFeature))
                {
                    if (level >= GNB.Levels.DoubleDown && gauge.Ammo >= 2)
                    {
                        var doubleDown = GetCooldown(GNB.DoubleDown);
                        if (!doubleDown.IsCooldown)
                            return GNB.DoubleDown;
                    }
                }

                if (IsEnabled(CustomComboPreset.GunbreakerEmptyBloodfestFeature))
                {
                    if (level >= GNB.Levels.Bloodfest && gauge.Ammo == 0)
                        return GNB.Bloodfest;
                }
            }

            return actionID;
        }
    }

    internal class GunbreakerBowShockSonicBreakFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerBowShockSonicBreakFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { GNB.BowShock, GNB.SonicBreak };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.BowShock || actionID == GNB.SonicBreak)
            {
                if (level >= GNB.Levels.BowShock)
                    return CalcBestAction(actionID, GNB.BowShock, GNB.SonicBreak);
            }

            return actionID;
        }
    }

    internal class GunbreakerDemonSlaughterCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerDemonSlaughterCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { GNB.DemonSlaughter };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.DemonSlaughter)
            {
                if (comboTime > 0 && lastComboMove == GNB.DemonSlice && level >= GNB.Levels.DemonSlaughter)
                {
                    if (IsEnabled(CustomComboPreset.GunbreakerFatedCircleFeature))
                    {
                        var gauge = GetJobGauge<GNBGauge>();
                        var maxAmmo = level >= GNB.Levels.CartridgeCharge2 ? 3 : 2;

                        if (level >= GNB.Levels.FatedCircle && gauge.Ammo == maxAmmo)
                            return GNB.FatedCircle;
                    }

                    return GNB.DemonSlaughter;
                }

                return GNB.DemonSlice;
            }

            return actionID;
        }
    }

    internal class GunbreakerNoMercyFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerNoMercyFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { GNB.NoMercy };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == GNB.NoMercy)
            {
                if (level >= GNB.Levels.NoMercy && HasEffect(GNB.Buffs.NoMercy))
                {
                    if (level >= GNB.Levels.BowShock)
                        return CalcBestAction(GNB.SonicBreak, GNB.SonicBreak, GNB.BowShock);

                    if (level >= GNB.Levels.SonicBreak)
                        return GNB.SonicBreak;
                }
            }

            return actionID;
        }
    }
}