using System;
using System.Collections.Generic;
using System.Linq;


namespace TurboGCD
{
    public enum JobID : uint
    {
        None = 0,
        PLD = 19,
        WAR = 21,
        DRK = 32,
        GNB = 37,
        WHM = 24,
        SCH = 28,
        AST = 33,
        SGE = 40,
        MNK = 20,
        DRG = 22,
        NIN = 30,
        SAM = 34,
        RPR = 39,
        VPR = 41,
        BRD = 23,
        MCH = 31,
        DNC = 38,
        BLM = 25,
        SMN = 26,
        RDM = 35,
        PCT = 42
    }
    public static class JobStuff
    {
        public static readonly Dictionary<JobID, Dictionary<uint, uint[]>> JobsEquivalentActions;

        static JobStuff()
        {
            JobsEquivalentActions = new Dictionary<JobID, Dictionary<uint, uint[]>>(21);
            //PLD
            {
                var royal    = stackalloc uint[] { (uint)JobActions.PLD.GCD.RageOfHalone,   (uint)JobActions.PLD.GCD.RoyalAuthority }.ToArray();
                var req      = stackalloc uint[] { (uint)JobActions.PLD.oGCD.Requiescat,    (uint)JobActions.PLD.oGCD.Imperator     }.ToArray();
                var guardian = stackalloc uint[] { (uint)JobActions.PLD.oGCD.Sentinel,      (uint)JobActions.PLD.oGCD.Guardian      }.ToArray();
                var spirits  = stackalloc uint[] { (uint)JobActions.PLD.oGCD.SpiritsWithin, (uint)JobActions.PLD.oGCD.Expiacion     }.ToArray();
                var sheltron = stackalloc uint[] { (uint)JobActions.PLD.oGCD.Sheltron,      (uint)JobActions.PLD.oGCD.HolySheltron  }.ToArray();
                var lb       = stackalloc uint[] { (uint)JobActions.PLD.oGCD.ShieldWall,    (uint)JobActions.PLD.oGCD.Stronghold  , (uint)JobActions.PLD.oGCD.LastBastion }.ToArray();
                var dic = new Dictionary<uint, uint[]>(13)
                {
                    { (uint)JobActions.PLD.GCD.RageOfHalone     , royal    },
                    { (uint)JobActions.PLD.GCD.RoyalAuthority   , royal    },
                    { (uint)JobActions.PLD.oGCD.Requiescat      , req      },
                    { (uint)JobActions.PLD.oGCD.Imperator       , req      },
                    { (uint)JobActions.PLD.oGCD.Sentinel        , guardian },
                    { (uint)JobActions.PLD.oGCD.Guardian        , guardian },
                    { (uint)JobActions.PLD.oGCD.SpiritsWithin   , spirits  },
                    { (uint)JobActions.PLD.oGCD.Expiacion       , spirits  },
                    { (uint)JobActions.PLD.oGCD.Sheltron        , sheltron },
                    { (uint)JobActions.PLD.oGCD.HolySheltron    , sheltron },
                    { (uint)JobActions.PLD.oGCD.ShieldWall      , lb       },
                    { (uint)JobActions.PLD.oGCD.Stronghold      , lb       },
                    { (uint)JobActions.PLD.oGCD.LastBastion     , lb       }
                };
                JobsEquivalentActions.Add(JobID.PLD, dic);
            }
            //WAR
            {
                var fel = stackalloc uint[]{(uint)JobActions.WAR.GCD.InnerBeast     , (uint)JobActions.WAR.GCD.FellCleave       }.ToArray();
                var dec = stackalloc uint[]{(uint)JobActions.WAR.GCD.SteelCyclone   , (uint)JobActions.WAR.GCD.Decimate         }.ToArray();
                var inn = stackalloc uint[]{(uint)JobActions.WAR.oGCD.Berserk       , (uint)JobActions.WAR.oGCD.InnerRelease    }.ToArray();
                var raw = stackalloc uint[]{(uint)JobActions.WAR.oGCD.RawIntuition  , (uint)JobActions.WAR.oGCD.Bloodwhetting   }.ToArray();
                var ven = stackalloc uint[]{(uint)JobActions.WAR.oGCD.Vengeance     , (uint)JobActions.WAR.oGCD.Damnation       }.ToArray();
                var lb  = stackalloc uint[]{(uint)JobActions.WAR.oGCD.ShieldWall    , (uint)JobActions.WAR.oGCD.Stronghold   , (uint)JobActions.WAR.oGCD.LandWaker }.ToArray();
                var dic = new Dictionary<uint, uint[]>(13)
                {
                    { (uint)JobActions.WAR.GCD.InnerBeast       , fel },
                    { (uint)JobActions.WAR.GCD.FellCleave       , fel },
                    { (uint)JobActions.WAR.GCD.SteelCyclone     , dec },
                    { (uint)JobActions.WAR.GCD.Decimate         , dec },
                    { (uint)JobActions.WAR.oGCD.Berserk         , inn },
                    { (uint)JobActions.WAR.oGCD.InnerRelease    , inn },
                    { (uint)JobActions.WAR.oGCD.RawIntuition    , raw },
                    { (uint)JobActions.WAR.oGCD.Bloodwhetting   , raw },
                    { (uint)JobActions.WAR.oGCD.Vengeance       , ven },
                    { (uint)JobActions.WAR.oGCD.Damnation       , ven },
                    { (uint)JobActions.WAR.oGCD.ShieldWall      , lb  },
                    { (uint)JobActions.WAR.oGCD.Stronghold      , lb  },
                    { (uint)JobActions.WAR.oGCD.LandWaker       , lb  }
                };
                JobsEquivalentActions.Add(JobID.WAR, dic);
            }
            //DRK
            {
                var flood = stackalloc uint[] { (uint)JobActions.DRK.oGCD.FloodOfDarkness   , (uint)JobActions.DRK.oGCD.FloodOfShadow }.ToArray();
                var shado = stackalloc uint[] { (uint)JobActions.DRK.oGCD.ShadowWall        , (uint)JobActions.DRK.oGCD.ShadowedVigil }.ToArray();
                var edgeo = stackalloc uint[] { (uint)JobActions.DRK.oGCD.EdgeOfDarkness    , (uint)JobActions.DRK.oGCD.EdgeOfShadow  }.ToArray();
                var lb    = stackalloc uint[] { (uint)JobActions.DRK.oGCD.ShieldWall        , (uint)JobActions.DRK.oGCD.Stronghold   , (uint)JobActions.DRK.oGCD.DarkForce }.ToArray();
                var dic = new Dictionary<uint, uint[]>(9)
                {
                    { (uint)JobActions.DRK.oGCD.FloodOfDarkness , flood },
                    { (uint)JobActions.DRK.oGCD.FloodOfShadow   , flood },
                    { (uint)JobActions.DRK.oGCD.ShadowWall      , shado },
                    { (uint)JobActions.DRK.oGCD.ShadowedVigil   , shado },
                    { (uint)JobActions.DRK.oGCD.EdgeOfDarkness  , edgeo },
                    { (uint)JobActions.DRK.oGCD.EdgeOfShadow    , edgeo },
                    { (uint)JobActions.DRK.oGCD.ShieldWall      , lb    },
                    { (uint)JobActions.DRK.oGCD.Stronghold      , lb    },
                    { (uint)JobActions.DRK.oGCD.DarkForce       , lb    }
                };
                JobsEquivalentActions.Add(JobID.DRK, dic);
            }
            //GNB
            {
                var zone         = stackalloc uint[] { (uint)JobActions.GNB.oGCD.DangerZone  , (uint)JobActions.GNB.oGCD.BlastingZone    }.ToArray();
                var nebula       = stackalloc uint[] { (uint)JobActions.GNB.oGCD.Nebula      , (uint)JobActions.GNB.oGCD.GreatNebula     }.ToArray();
                var heart        = stackalloc uint[] { (uint)JobActions.GNB.oGCD.HeartOfStone, (uint)JobActions.GNB.oGCD.HeartOfCorundum }.ToArray();
                var continuation = stackalloc uint[] {
                    (uint)JobActions.GNB.oGCD.Continuation, (uint)JobActions.GNB.oGCD.JugularRip, (uint)JobActions.GNB.oGCD.AbdomenTear, (uint)JobActions.GNB.oGCD.EyeGouge, (uint)JobActions.GNB.oGCD.Hypervelocity, (uint)JobActions.GNB.oGCD.FatedBrand        }.ToArray();
                var lb           = stackalloc uint[] { (uint)JobActions.GNB.oGCD.ShieldWall  , (uint)JobActions.GNB.oGCD.Stronghold    , (uint)JobActions.GNB.oGCD.GunmetalSoul }.ToArray();
                var dic = new Dictionary<uint, uint[]>(15)
                {
                    { (uint)JobActions.GNB.oGCD.DangerZone      , zone          },
                    { (uint)JobActions.GNB.oGCD.BlastingZone    , zone          },
                    { (uint)JobActions.GNB.oGCD.Nebula          , nebula        },
                    { (uint)JobActions.GNB.oGCD.GreatNebula     , nebula        },
                    { (uint)JobActions.GNB.oGCD.HeartOfStone    , heart         },
                    { (uint)JobActions.GNB.oGCD.HeartOfCorundum , heart         },
                    { (uint)JobActions.GNB.oGCD.Continuation    , continuation  },
                    { (uint)JobActions.GNB.oGCD.JugularRip      , continuation  },
                    { (uint)JobActions.GNB.oGCD.AbdomenTear     , continuation  },
                    { (uint)JobActions.GNB.oGCD.EyeGouge        , continuation  },
                    { (uint)JobActions.GNB.oGCD.Hypervelocity   , continuation  },
                    { (uint)JobActions.GNB.oGCD.FatedBrand      , continuation  },
                    { (uint)JobActions.GNB.oGCD.ShieldWall      , lb            },
                    { (uint)JobActions.GNB.oGCD.Stronghold      , lb            },
                    { (uint)JobActions.GNB.oGCD.GunmetalSoul    , lb            }
                };
                JobsEquivalentActions.Add(JobID.GNB, dic);
            }
            //SGE
            {
                var dos  = stackalloc uint[]{ (uint)JobActions.SGE.GCD.Dosis1       , (uint)JobActions.SGE.GCD.Dosis2, (uint)JobActions.SGE.GCD.Dosis3 }.ToArray();
                var pro  = stackalloc uint[]{ (uint)JobActions.SGE.GCD.EukrasianPrognosis1, (uint)JobActions.SGE.GCD.EukrasianPrognosis2}.ToArray();
                var eud  = stackalloc uint[]{ (uint)JobActions.SGE.GCD.EukrasianDosis1, (uint)JobActions.SGE.GCD.EukrasianDosis2, (uint)JobActions.SGE.GCD.EukrasianDosis3}.ToArray();
                var phl  = stackalloc uint[]{ (uint)JobActions.SGE.GCD.Phlegma1     , (uint)JobActions.SGE.GCD.Phlegma2, (uint)JobActions.SGE.GCD.Phlegma3 }.ToArray();
                var dys  = stackalloc uint[]{ (uint)JobActions.SGE.GCD.Dyskrasia    , (uint)JobActions.SGE.GCD.DyskrasiaII }.ToArray();
                var tox  = stackalloc uint[]{ (uint)JobActions.SGE.GCD.Toxikon      , (uint)JobActions.SGE.GCD.ToxikonII }.ToArray();
                var phys = stackalloc uint[]{ (uint)JobActions.SGE.oGCD.Physis      , (uint)JobActions.SGE.oGCD.PhysisII }.ToArray();
                var lbs  = stackalloc uint[]{ (uint)JobActions.SGE.oGCD.HealingWind , (uint)JobActions.SGE.oGCD.BreathOfTheEarth, (uint)JobActions.SGE.oGCD.TechneMakre }.ToArray();
                
                var dic = new Dictionary<uint, uint[]>(20)
                {
                    { (uint)JobActions.SGE.GCD.EukrasianPrognosis1, pro  },
                    { (uint)JobActions.SGE.GCD.EukrasianPrognosis2, pro  },
                    { (uint)JobActions.SGE.GCD.EukrasianDosis1    , eud  },
                    { (uint)JobActions.SGE.GCD.EukrasianDosis2    , eud  },
                    { (uint)JobActions.SGE.GCD.EukrasianDosis3    , eud  },
                    { (uint)JobActions.SGE.GCD.Dosis1             , dos  },
                    { (uint)JobActions.SGE.GCD.Dosis2             , dos  },
                    { (uint)JobActions.SGE.GCD.Dosis3             , dos  },
                    { (uint)JobActions.SGE.GCD.Phlegma1           , phl  },
                    { (uint)JobActions.SGE.GCD.Phlegma2           , phl  },
                    { (uint)JobActions.SGE.GCD.Phlegma3           , phl  },
                    { (uint)JobActions.SGE.GCD.Dyskrasia          , dys  },
                    { (uint)JobActions.SGE.GCD.DyskrasiaII        , dys  },
                    { (uint)JobActions.SGE.GCD.Toxikon            , tox  },
                    { (uint)JobActions.SGE.GCD.ToxikonII          , tox  },
                    { (uint)JobActions.SGE.oGCD.Physis            , phys },
                    { (uint)JobActions.SGE.oGCD.PhysisII          , phys },
                    { (uint)JobActions.SGE.oGCD.HealingWind       , lbs  },
                    { (uint)JobActions.SGE.oGCD.BreathOfTheEarth  , lbs  },
                    { (uint)JobActions.SGE.oGCD.TechneMakre       , lbs  }
                };
                JobsEquivalentActions.Add(JobID.SGE, dic);
            }
            //WHM
            {
                var dia  = stackalloc uint[]{ (uint)JobActions.WHM.GCD.Aero1 , (uint)JobActions.WHM.GCD.Aero2, (uint)JobActions.WHM.GCD.Dia}.ToArray();
                var hol  = stackalloc uint[]{ (uint)JobActions.WHM.GCD.Holy1, (uint)JobActions.WHM.GCD.Holy3}.ToArray();
                var med  = stackalloc uint[]{ (uint)JobActions.WHM.GCD.Medica2, (uint)JobActions.WHM.GCD.Medica3}.ToArray();
                var gla  = stackalloc uint[]{ (uint)JobActions.WHM.GCD.Stone1, (uint)JobActions.WHM.GCD.Stone2, (uint)JobActions.WHM.GCD.Stone3, (uint)JobActions.WHM.GCD.Stone4, (uint)JobActions.WHM.GCD.Glare1, (uint)JobActions.WHM.GCD.Glare3}.ToArray();
                var lbs  = stackalloc uint[]{ (uint)JobActions.WHM.oGCD.HealingWind , (uint)JobActions.WHM.oGCD.BreathOfTheEarth, (uint)JobActions.WHM.oGCD.PulseOfLife }.ToArray();

                var dic = new Dictionary<uint, uint[]>(16)
                {
                    { (uint)JobActions.WHM.GCD.Aero1            , dia  },
                    { (uint)JobActions.WHM.GCD.Aero2            , dia  },
                    { (uint)JobActions.WHM.GCD.Dia              , dia  },
                    { (uint)JobActions.WHM.GCD.Holy1            , hol  },
                    { (uint)JobActions.WHM.GCD.Holy3            , hol  },
                    { (uint)JobActions.WHM.GCD.Medica1          , hol  },
                    { (uint)JobActions.WHM.GCD.Medica3          , hol  },
                    { (uint)JobActions.WHM.GCD.Stone1           , gla  },
                    { (uint)JobActions.WHM.GCD.Stone2           , gla  },
                    { (uint)JobActions.WHM.GCD.Stone3           , gla  },
                    { (uint)JobActions.WHM.GCD.Stone4           , gla  },
                    { (uint)JobActions.WHM.GCD.Glare1           , gla  },
                    { (uint)JobActions.WHM.GCD.Glare3           , gla  },

                    { (uint)JobActions.WHM.oGCD.HealingWind     , lbs  },
                    { (uint)JobActions.WHM.oGCD.BreathOfTheEarth, lbs  },
                    { (uint)JobActions.WHM.oGCD.PulseOfLife     , lbs  }
                };
                JobsEquivalentActions.Add(JobID.WHM, dic);
            }
            //SCH
            {
                var lbs  = stackalloc uint[]{ (uint)JobActions.SCH.oGCD.HealingWind , (uint)JobActions.SCH.oGCD.BreathOfTheEarth, (uint)JobActions.SCH.oGCD.AngelFeathers }.ToArray();
                var bio  = stackalloc uint[]{ (uint)JobActions.SCH.GCD.Bio1     , (uint)JobActions.SCH.GCD.Bio2, (uint)JobActions.SCH.GCD.Biolysis }.ToArray();
                var art  = stackalloc uint[]{ (uint)JobActions.SCH.GCD.ArtOfWar1, (uint)JobActions.SCH.GCD.ArtOfWar2}.ToArray();
                var suc  = stackalloc uint[]{ (uint)JobActions.SCH.GCD.Succor   , (uint)JobActions.SCH.GCD.Concitation}.ToArray();
                var bro  = stackalloc uint[]{ (uint)JobActions.SCH.GCD.Ruin1    , (uint)JobActions.SCH.GCD.Broil1, (uint)JobActions.SCH.GCD.Broil2, (uint)JobActions.SCH.GCD.Broil3, (uint)JobActions.SCH.GCD.Broil4 }.ToArray();

                var dic = new Dictionary<uint, uint[]>(15)
                {
                    { (uint)JobActions.SCH.GCD.Succor           , suc  },
                    { (uint)JobActions.SCH.GCD.Concitation      , suc  },
                    { (uint)JobActions.SCH.GCD.Bio1             , bio  },
                    { (uint)JobActions.SCH.GCD.Bio2             , bio  },
                    { (uint)JobActions.SCH.GCD.Biolysis         , bio  },
                    { (uint)JobActions.SCH.GCD.ArtOfWar1        , art  },
                    { (uint)JobActions.SCH.GCD.Ruin1            , bro  },
                    { (uint)JobActions.SCH.GCD.Broil1           , bro  },
                    { (uint)JobActions.SCH.GCD.Broil2           , bro  },
                    { (uint)JobActions.SCH.GCD.Broil3           , bro  },
                    { (uint)JobActions.SCH.GCD.Broil4           , bro  },
                    { (uint)JobActions.SCH.GCD.ArtOfWar2        , art  },
                    { (uint)JobActions.SCH.oGCD.HealingWind     , lbs  },
                    { (uint)JobActions.SCH.oGCD.BreathOfTheEarth, lbs  },
                    { (uint)JobActions.SCH.oGCD.AngelFeathers   , lbs  }
                };
                JobsEquivalentActions.Add(JobID.SCH, dic);
            }
            //AST
            {
                var com = stackalloc uint[] { (uint)JobActions.AST.GCD.Combust1      , (uint)JobActions.AST.GCD.Combust2, (uint)JobActions.AST.GCD.Combust3}.ToArray();
                var gra = stackalloc uint[] { (uint)JobActions.AST.GCD.Gravity1      , (uint)JobActions.AST.GCD.Gravity2          }.ToArray();
                var asp = stackalloc uint[] { (uint)JobActions.AST.GCD.AspectedHelios, (uint)JobActions.AST.GCD.HeliosConjunction }.ToArray();
                var mal = stackalloc uint[] { (uint)JobActions.AST.GCD.Malefic1, (uint)JobActions.AST.GCD.Malefic2, (uint)JobActions.AST.GCD.Malefic3, (uint)JobActions.AST.GCD.Malefic4, (uint)JobActions.AST.GCD.FallMalefic}.ToArray();
                var pl1 = stackalloc uint[] { (uint)JobActions.AST.oGCD.Play1       , (uint)JobActions.AST.oGCD.TheBalance, (uint)JobActions.AST.oGCD.TheSpear }.ToArray();
                var pl2 = stackalloc uint[] { (uint)JobActions.AST.oGCD.Play2       , (uint)JobActions.AST.oGCD.TheArrow  , (uint)JobActions.AST.oGCD.TheBole  }.ToArray();
                var pl3 = stackalloc uint[] { (uint)JobActions.AST.oGCD.Play3       , (uint)JobActions.AST.oGCD.TheSpire  , (uint)JobActions.AST.oGCD.TheEwer }.ToArray();
                var lbs = stackalloc uint[] { (uint)JobActions.AST.oGCD.HealingWind , (uint)JobActions.AST.oGCD.BreathOfTheEarth, (uint)JobActions.AST.oGCD.AstralStasis }.ToArray();

                var dic = new Dictionary<uint, uint[]>(24)
                {
                    { (uint)JobActions.AST.GCD.Combust1         , com  },
                    { (uint)JobActions.AST.GCD.Combust2         , com  },
                    { (uint)JobActions.AST.GCD.Combust3         , com  },
                    { (uint)JobActions.AST.GCD.Gravity1         , gra  },
                    { (uint)JobActions.AST.GCD.Gravity2         , gra  },
                    { (uint)JobActions.AST.GCD.AspectedHelios   , asp  },
                    { (uint)JobActions.AST.GCD.HeliosConjunction, asp  },
                    { (uint)JobActions.AST.GCD.Malefic1         , mal  },
                    { (uint)JobActions.AST.GCD.Malefic2         , mal  },
                    { (uint)JobActions.AST.GCD.Malefic3         , mal  },
                    { (uint)JobActions.AST.GCD.Malefic4         , mal  },
                    { (uint)JobActions.AST.GCD.FallMalefic      , mal  },

                    { (uint)JobActions.AST.oGCD.HealingWind     , lbs  },
                    { (uint)JobActions.AST.oGCD.BreathOfTheEarth, lbs  },
                    { (uint)JobActions.AST.oGCD.AstralStasis    , lbs  },
                    { (uint)JobActions.AST.oGCD.Play1           , pl1  },
                    { (uint)JobActions.AST.oGCD.TheBalance      , pl1  },
                    { (uint)JobActions.AST.oGCD.TheSpear        , pl1  },
                    { (uint)JobActions.AST.oGCD.Play2           , pl2  },
                    { (uint)JobActions.AST.oGCD.TheArrow        , pl2  },
                    { (uint)JobActions.AST.oGCD.TheBole         , pl2  },
                    { (uint)JobActions.AST.oGCD.Play3           , pl3  },
                    { (uint)JobActions.AST.oGCD.TheSpire        , pl3  },
                    { (uint)JobActions.AST.oGCD.TheEwer         , pl3  },

                };
                JobsEquivalentActions.Add(JobID.AST, dic);
            }
            //MNK
            {                
                var destro = stackalloc uint[]{ (uint)JobActions.MNK.GCD.ArmOfTheDestroyer     , (uint)JobActions.MNK.GCD.ShadowOfTheDestroyer     }.ToArray();
                var bootsh = stackalloc uint[]{ (uint)JobActions.MNK.GCD.Bootshine             , (uint)JobActions.MNK.GCD.LeapingOpo               }.ToArray();
                var raptor = stackalloc uint[]{ (uint)JobActions.MNK.GCD.TrueStrike            , (uint)JobActions.MNK.GCD.RisingRaptor             }.ToArray();
                var coeurl = stackalloc uint[]{ (uint)JobActions.MNK.GCD.SnapPunch             , (uint)JobActions.MNK.GCD.PouncingCoeurl           }.ToArray();

                var mediCo = stackalloc uint[]{ (uint)JobActions.MNK.oGCD.SteeledMeditation    , (uint)JobActions.MNK.oGCD.ForbiddenMeditation     }.ToArray();
                var mediOf = stackalloc uint[]{ (uint)JobActions.MNK.oGCD.InspiritedMeditation , (uint)JobActions.MNK.oGCD.EnlightenedMeditation   }.ToArray();
                var chakra = stackalloc uint[]{ (uint)JobActions.MNK.oGCD.SteelPeak            , (uint)JobActions.MNK.oGCD.ForbiddenChakra         }.ToArray();
                var lbs    = stackalloc uint[]{ (uint)JobActions.MNK.oGCD.Braver               , (uint)JobActions.MNK.oGCD.Bladedance, (uint)JobActions.MNK.oGCD.FinalHeaven }.ToArray();

                var dic = new Dictionary<uint, uint[]>(17)
                {
                    { (uint)JobActions.MNK.GCD.ArmOfTheDestroyer        , destro },
                    { (uint)JobActions.MNK.GCD.ShadowOfTheDestroyer     , destro },
                    { (uint)JobActions.MNK.GCD.Bootshine                , bootsh },
                    { (uint)JobActions.MNK.GCD.LeapingOpo               , bootsh },
                    { (uint)JobActions.MNK.GCD.TrueStrike               , raptor },
                    { (uint)JobActions.MNK.GCD.RisingRaptor             , raptor },
                    { (uint)JobActions.MNK.GCD.SnapPunch                , coeurl },
                    { (uint)JobActions.MNK.GCD.PouncingCoeurl           , coeurl },

                    { (uint)JobActions.MNK.oGCD.SteeledMeditation       , mediCo },
                    { (uint)JobActions.MNK.oGCD.ForbiddenMeditation     , mediCo },
                    { (uint)JobActions.MNK.oGCD.InspiritedMeditation    , mediOf },
                    { (uint)JobActions.MNK.oGCD.EnlightenedMeditation   , mediOf },
                    { (uint)JobActions.MNK.oGCD.SteelPeak               , chakra },
                    { (uint)JobActions.MNK.oGCD.ForbiddenChakra         , chakra },
                    { (uint)JobActions.MNK.oGCD.Braver                  , lbs    },
                    { (uint)JobActions.MNK.oGCD.Bladedance              , lbs    },
                    { (uint)JobActions.MNK.oGCD.FinalHeaven             , lbs    },//
                };
                JobsEquivalentActions.Add(JobID.MNK, dic);
            }
            //DRG
            {
                var barr = stackalloc uint[]{ (uint)JobActions.DRG.GCD.VorpalThrust , (uint)JobActions.DRG.GCD.LanceBarrage  }.ToArray();
                var thru = stackalloc uint[]{ (uint)JobActions.DRG.GCD.FullThrust   , (uint)JobActions.DRG.GCD.HeavensThrust }.ToArray();
                var blow = stackalloc uint[]{ (uint)JobActions.DRG.GCD.Disembowel   , (uint)JobActions.DRG.GCD.SpiralBlow    }.ToArray();
                var chao = stackalloc uint[]{ (uint)JobActions.DRG.GCD.ChaosThrust  , (uint)JobActions.DRG.GCD.ChaoticSpring }.ToArray();

                var jump = stackalloc uint[]{ (uint)JobActions.DRG.oGCD.Jump        , (uint)JobActions.DRG.oGCD.HighJump  }.ToArray();
                var geir = stackalloc uint[]{ (uint)JobActions.DRG.oGCD.Geirskogul  , (uint)JobActions.DRG.oGCD.Nastrond  }.ToArray();
                var lbs  = stackalloc uint[]{ (uint)JobActions.DRG.oGCD.Braver      , (uint)JobActions.DRG.oGCD.Bladedance, (uint)JobActions.DRG.oGCD.DragonsongDive }.ToArray();

                var dic = new Dictionary<uint, uint[]>(15)
                {
                    { (uint)JobActions.DRG.GCD.VorpalThrust     , barr },
                    { (uint)JobActions.DRG.GCD.LanceBarrage     , barr },
                    { (uint)JobActions.DRG.GCD.FullThrust       , thru },
                    { (uint)JobActions.DRG.GCD.HeavensThrust    , thru },
                    { (uint)JobActions.DRG.GCD.Disembowel       , blow },
                    { (uint)JobActions.DRG.GCD.SpiralBlow       , blow },
                    { (uint)JobActions.DRG.GCD.ChaosThrust      , chao },
                    { (uint)JobActions.DRG.GCD.ChaoticSpring    , chao },

                    { (uint)JobActions.DRG.oGCD.Jump            , jump },
                    { (uint)JobActions.DRG.oGCD.HighJump        , jump },
                    { (uint)JobActions.DRG.oGCD.Geirskogul      , geir },
                    { (uint)JobActions.DRG.oGCD.Nastrond        , geir },
                    { (uint)JobActions.DRG.oGCD.Braver          , lbs  },
                    { (uint)JobActions.DRG.oGCD.Bladedance      , lbs  },
                    { (uint)JobActions.DRG.oGCD.DragonsongDive  , lbs  },
                };
                JobsEquivalentActions.Add(JobID.DRG, dic);
            }
            //NIN
            {
                var mug = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Mug           , (uint)JobActions.NIN.oGCD.Dokumori           }.ToArray();
                var tri = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.TrickAttack   , (uint)JobActions.NIN.oGCD.KunaisBane         }.ToArray();
                var hel = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.HellfrogMedium, (uint)JobActions.NIN.oGCD.DeathfrogMedium    }.ToArray();
                var bav = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Bhavacakra    , (uint)JobActions.NIN.oGCD.ZeshoMeppo         }.ToArray();
                var ass = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Assassinate   , (uint)JobActions.NIN.oGCD.DreamWithinADream  }.ToArray();
                var ten = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Ten1          , (uint)JobActions.NIN.oGCD.Ten2               }.ToArray();
                var chi = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Chi1          , (uint)JobActions.NIN.oGCD.Chi2               }.ToArray();
                var jin = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Jin1          , (uint)JobActions.NIN.oGCD.Jin2               }.ToArray();
                var rai = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Raiton        , (uint)JobActions.NIN.oGCD.TCJRaiton          }.ToArray();
                var hut = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Huton         , (uint)JobActions.NIN.oGCD.TCJHuton           }.ToArray();
                var dot = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Doton         , (uint)JobActions.NIN.oGCD.TCJDoton           }.ToArray();
                var kat = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Katon         , (uint)JobActions.NIN.oGCD.TCJKaton, (uint)JobActions.NIN.oGCD.GokaMekkyaku    }.ToArray();                   
                var hyo = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Hyoton        , (uint)JobActions.NIN.oGCD.TCJHyoton, (uint)JobActions.NIN.oGCD.HyoshoRanryu}.ToArray();                       
                var fum = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.FumaShuriken  , (uint)JobActions.NIN.oGCD.FumaTen, (uint)JobActions.NIN.oGCD.FumaChi, (uint)JobActions.NIN.oGCD.FumaJin }.ToArray();                             
                var lbs  = stackalloc uint[]{ (uint)JobActions.NIN.oGCD.Braver       , (uint)JobActions.NIN.oGCD.Bladedance, (uint)JobActions.NIN.oGCD.Chimatsuri }.ToArray();

                var dic = new Dictionary<uint, uint[]>(32)
                {
                    { (uint)JobActions.NIN.oGCD.Mug                 , mug },
                    { (uint)JobActions.NIN.oGCD.Dokumori            , mug },
                    { (uint)JobActions.NIN.oGCD.TrickAttack         , tri },
                    { (uint)JobActions.NIN.oGCD.KunaisBane          , tri },
                    { (uint)JobActions.NIN.oGCD.HellfrogMedium      , hel },
                    { (uint)JobActions.NIN.oGCD.DeathfrogMedium     , hel },
                    { (uint)JobActions.NIN.oGCD.DreamWithinADream   , ass },
                    { (uint)JobActions.NIN.oGCD.Assassinate         , ass },
                    { (uint)JobActions.NIN.oGCD.Bhavacakra          , bav },
                    { (uint)JobActions.NIN.oGCD.ZeshoMeppo          , bav },
                    { (uint)JobActions.NIN.oGCD.Ten1                , ten },
                    { (uint)JobActions.NIN.oGCD.Ten2                , ten },
                    { (uint)JobActions.NIN.oGCD.Chi1                , chi },
                    { (uint)JobActions.NIN.oGCD.Chi2                , chi },
                    { (uint)JobActions.NIN.oGCD.Jin1                , jin },
                    { (uint)JobActions.NIN.oGCD.Jin2                , jin },
                    { (uint)JobActions.NIN.oGCD.Raiton              , rai },
                    { (uint)JobActions.NIN.oGCD.TCJRaiton           , rai },
                    { (uint)JobActions.NIN.oGCD.Huton               , hut },
                    { (uint)JobActions.NIN.oGCD.TCJHuton            , hut },
                    { (uint)JobActions.NIN.oGCD.Doton               , dot },
                    { (uint)JobActions.NIN.oGCD.TCJDoton            , dot },
                    { (uint)JobActions.NIN.oGCD.Katon               , kat },
                    { (uint)JobActions.NIN.oGCD.TCJKaton            , kat },
                    { (uint)JobActions.NIN.oGCD.GokaMekkyaku        , kat },
                    { (uint)JobActions.NIN.oGCD.Hyoton              , hyo },
                    { (uint)JobActions.NIN.oGCD.TCJHyoton           , hyo },
                    { (uint)JobActions.NIN.oGCD.HyoshoRanryu        , hyo },
                    { (uint)JobActions.NIN.oGCD.FumaShuriken        , fum },
                    { (uint)JobActions.NIN.oGCD.FumaTen             , fum },
                    { (uint)JobActions.NIN.oGCD.FumaChi             , fum },
                    { (uint)JobActions.NIN.oGCD.FumaJin             , fum },
                    { (uint)JobActions.NIN.oGCD.Braver              , lbs },
                    { (uint)JobActions.NIN.oGCD.Bladedance          , lbs },
                    { (uint)JobActions.NIN.oGCD.Chimatsuri          , lbs },
                };
                JobsEquivalentActions.Add(JobID.NIN, dic);
            }
            //SAM
            {
                var gyo  = stackalloc uint[]{ (uint)JobActions.SAM.GCD.Hakaze   , (uint)JobActions.SAM.GCD.Gyofu      }.ToArray();
                var fuk  = stackalloc uint[]{ (uint)JobActions.SAM.GCD.Fuga     , (uint)JobActions.SAM.GCD.Fuko       }.ToArray();

                var eye  = stackalloc uint[]{ (uint)JobActions.SAM.oGCD.ThirdEye, (uint)JobActions.SAM.oGCD.Tengentsu }.ToArray();
                var lbs  = stackalloc uint[]{ (uint)JobActions.SAM.oGCD.Braver  , (uint)JobActions.SAM.oGCD.Bladedance, (uint)JobActions.SAM.oGCD.DoomOfTheLiving }.ToArray();

                var dic = new Dictionary<uint, uint[]>(5)
                {
                    { (uint)JobActions.SAM.GCD.Hakaze           , gyo },
                    { (uint)JobActions.SAM.GCD.Gyofu            , gyo },
                    { (uint)JobActions.SAM.GCD.Fuga             , fuk },
                    { (uint)JobActions.SAM.GCD.Fuko             , fuk },

                    { (uint)JobActions.SAM.oGCD.ThirdEye        , eye },
                    { (uint)JobActions.SAM.oGCD.Tengentsu       , eye },
                    { (uint)JobActions.SAM.oGCD.Braver          , lbs },
                    { (uint)JobActions.SAM.oGCD.Bladedance      , lbs },
                    { (uint)JobActions.SAM.oGCD.DoomOfTheLiving , lbs },
                };
                JobsEquivalentActions.Add(JobID.SAM, dic);
            }
            //RPR
            {
                var grims = stackalloc uint[]{ (uint)JobActions.RPR.oGCD.GrimSwathe, (uint)JobActions.RPR.oGCD.LemuresScythe }.ToArray();
                var stalk = stackalloc uint[]{ (uint)JobActions.RPR.oGCD.BloodStalk, (uint)JobActions.RPR.oGCD.UnveiledGibbet, (uint)JobActions.RPR.oGCD.UnveiledGallows, (uint)JobActions.RPR.oGCD.LemuresSlice }.ToArray();
                var lbs   = stackalloc uint[]{ (uint)JobActions.RPR.oGCD.Braver    , (uint)JobActions.RPR.oGCD.Bladedance    , (uint)JobActions.RPR.oGCD.TheEnd }.ToArray();

                var dic = new Dictionary<uint, uint[]>(9)
                {
                    { (uint)JobActions.RPR.oGCD.BloodStalk      , stalk },
                    { (uint)JobActions.RPR.oGCD.UnveiledGibbet  , stalk },
                    { (uint)JobActions.RPR.oGCD.UnveiledGallows , stalk },
                    { (uint)JobActions.RPR.oGCD.LemuresSlice    , stalk },
                    { (uint)JobActions.RPR.oGCD.GrimSwathe      , grims },
                    { (uint)JobActions.RPR.oGCD.LemuresScythe   , grims },
                    { (uint)JobActions.RPR.oGCD.Braver          , lbs },
                    { (uint)JobActions.RPR.oGCD.Bladedance      , lbs },
                    { (uint)JobActions.RPR.oGCD.TheEnd          , lbs },
                };
                JobsEquivalentActions.Add(JobID.RPR, dic);
            }
            //BRD
            {
                var poi  = stackalloc uint[]{ (uint)JobActions.BRD.GCD.VenomousBite, (uint)JobActions.BRD.GCD.CausticBite       }.ToArray();
                var win  = stackalloc uint[]{ (uint)JobActions.BRD.GCD.Windbite    , (uint)JobActions.BRD.GCD.Stormbite         }.ToArray();
                var sho  = stackalloc uint[]{ (uint)JobActions.BRD.GCD.StraightShot, (uint)JobActions.BRD.GCD.RefulgentArrow    }.ToArray();
                var sha  = stackalloc uint[]{ (uint)JobActions.BRD.GCD.WideVolley  , (uint)JobActions.BRD.GCD.Shadowbite        }.ToArray();
                var bur  = stackalloc uint[]{ (uint)JobActions.BRD.GCD.HeavyShot   , (uint)JobActions.BRD.GCD.BurstShot         }.ToArray();
                var qui  = stackalloc uint[]{ (uint)JobActions.BRD.GCD.QuickNock   , (uint)JobActions.BRD.GCD.Ladonsbite        }.ToArray();


                var blood = stackalloc uint[]{ (uint)JobActions.BRD.oGCD.Bloodletter, (uint)JobActions.BRD.oGCD.HeartbreakShot  }.ToArray();
                var lbs   = stackalloc uint[]{ (uint)JobActions.BRD.oGCD.BigShot    , (uint)JobActions.BRD.oGCD.Desperado, (uint)JobActions.BRD.oGCD.SagittariusArrow }.ToArray();

                var dic = new Dictionary<uint, uint[]>(17)
                {
                    { (uint)JobActions.BRD.GCD.VenomousBite     , poi   },
                    { (uint)JobActions.BRD.GCD.CausticBite      , poi   },
                    { (uint)JobActions.BRD.GCD.Windbite         , win   },
                    { (uint)JobActions.BRD.GCD.Stormbite        , win   },
                    { (uint)JobActions.BRD.GCD.StraightShot     , sho   },
                    { (uint)JobActions.BRD.GCD.RefulgentArrow   , sho   },
                    { (uint)JobActions.BRD.GCD.WideVolley       , sha   },
                    { (uint)JobActions.BRD.GCD.Shadowbite       , sha   },
                    { (uint)JobActions.BRD.GCD.HeavyShot        , bur   },
                    { (uint)JobActions.BRD.GCD.BurstShot        , bur   },
                    { (uint)JobActions.BRD.GCD.QuickNock        , qui   },
                    { (uint)JobActions.BRD.GCD.Ladonsbite       , qui   },

                    { (uint)JobActions.BRD.oGCD.Bloodletter     , blood },
                    { (uint)JobActions.BRD.oGCD.HeartbreakShot  , blood },
                    { (uint)JobActions.BRD.oGCD.BigShot         , lbs   },
                    { (uint)JobActions.BRD.oGCD.Desperado       , lbs   },
                    { (uint)JobActions.BRD.oGCD.SagittariusArrow, lbs   },
                };
                JobsEquivalentActions.Add(JobID.BRD, dic);
            }
            //DNC
            {
                var lbs = stackalloc uint[]{ (uint)JobActions.DNC.oGCD.BigShot    , (uint)JobActions.DNC.oGCD.Desperado, (uint)JobActions.DNC.oGCD.CrimsonLotus }.ToArray();

                var dic = new Dictionary<uint, uint[]>(3)
                {
                    { (uint)JobActions.DNC.oGCD.BigShot     , lbs   },
                    { (uint)JobActions.DNC.oGCD.Desperado   , lbs   },
                    { (uint)JobActions.DNC.oGCD.CrimsonLotus, lbs   },
                };
                JobsEquivalentActions.Add(JobID.DNC, dic);
            }
            //MCH
            {
                var spli = stackalloc uint[]{ (uint)JobActions.MCH.GCD.SplitShot        , (uint)JobActions.MCH.GCD.HeatedSplitShot }.ToArray();
                var slug = stackalloc uint[]{ (uint)JobActions.MCH.GCD.SlugShot         , (uint)JobActions.MCH.GCD.HeatedSlugShot  }.ToArray();
                var clea = stackalloc uint[]{ (uint)JobActions.MCH.GCD.CleanShot        , (uint)JobActions.MCH.GCD.HeatedCleanShot }.ToArray();
                var airs = stackalloc uint[]{ (uint)JobActions.MCH.GCD.HotShot          , (uint)JobActions.MCH.GCD.AirAnchor       }.ToArray();
                var blas = stackalloc uint[]{ (uint)JobActions.MCH.GCD.HeatBlast        , (uint)JobActions.MCH.GCD.BlazingShot     }.ToArray();
                var scat = stackalloc uint[]{ (uint)JobActions.MCH.GCD.SpreadShot       , (uint)JobActions.MCH.GCD.Scattergun      }.ToArray();

                var gaus = stackalloc uint[]{ (uint)JobActions.MCH.oGCD.GaussRound      , (uint)JobActions.MCH.oGCD.DoubleCheck    }.ToArray();
                var rico = stackalloc uint[]{ (uint)JobActions.MCH.oGCD.Ricochet        , (uint)JobActions.MCH.oGCD.Checkmate      }.ToArray();
                var rook = stackalloc uint[]{ (uint)JobActions.MCH.oGCD.RookAutoturret  , (uint)JobActions.MCH.oGCD.AutomatonQueen }.ToArray();
                var over = stackalloc uint[]{ (uint)JobActions.MCH.oGCD.RookOverdrive   , (uint)JobActions.MCH.oGCD.QueenOverdrive }.ToArray();
                var lbs  = stackalloc uint[]{ (uint)JobActions.MCH.oGCD.BigShot         , (uint)JobActions.MCH.oGCD.Desperado, (uint)JobActions.MCH.oGCD.SatelliteBeam }.ToArray();

                var dic = new Dictionary<uint, uint[]>(23)
                {
                    { (uint)JobActions.MCH.GCD.SplitShot      , spli },
                    { (uint)JobActions.MCH.GCD.HeatedSplitShot, spli },
                    { (uint)JobActions.MCH.GCD.SlugShot       , slug },
                    { (uint)JobActions.MCH.GCD.HeatedSlugShot , slug },
                    { (uint)JobActions.MCH.GCD.CleanShot      , clea },
                    { (uint)JobActions.MCH.GCD.HeatedCleanShot, clea },
                    { (uint)JobActions.MCH.GCD.HotShot        , airs },
                    { (uint)JobActions.MCH.GCD.AirAnchor      , airs },
                    { (uint)JobActions.MCH.GCD.HeatBlast      , blas },
                    { (uint)JobActions.MCH.GCD.BlazingShot    , blas },
                    { (uint)JobActions.MCH.GCD.SpreadShot     , scat },
                    { (uint)JobActions.MCH.GCD.Scattergun     , scat },

                    { (uint)JobActions.MCH.oGCD.GaussRound    , gaus },
                    { (uint)JobActions.MCH.oGCD.DoubleCheck   , gaus },
                    { (uint)JobActions.MCH.oGCD.Ricochet      , rico },
                    { (uint)JobActions.MCH.oGCD.Checkmate     , rico },
                    { (uint)JobActions.MCH.oGCD.RookAutoturret, rook },
                    { (uint)JobActions.MCH.oGCD.AutomatonQueen, rook },
                    { (uint)JobActions.MCH.oGCD.RookOverdrive , over },
                    { (uint)JobActions.MCH.oGCD.QueenOverdrive, over },
                    { (uint)JobActions.MCH.oGCD.BigShot       , lbs  },
                    { (uint)JobActions.MCH.oGCD.Desperado     , lbs  },
                    { (uint)JobActions.MCH.oGCD.SatelliteBeam , lbs  },
                };
                JobsEquivalentActions.Add(JobID.MCH, dic);
            }
            //SMN
            {
                var necro = stackalloc uint[]{ (uint)JobActions.SMN.oGCD.Fester  , (uint)JobActions.SMN.oGCD.Necrotize }.ToArray();
                var lbs   = stackalloc uint[]{ (uint)JobActions.SMN.oGCD.Skyshard, (uint)JobActions.SMN.oGCD.Starstorm, (uint)JobActions.SMN.oGCD.Teraflare }.ToArray();

                var dic = new Dictionary<uint, uint[]>(5)
                {
                    { (uint)JobActions.SMN.oGCD.Fester      , necro },
                    { (uint)JobActions.SMN.oGCD.Necrotize   , necro },
                    { (uint)JobActions.SMN.oGCD.Skyshard    , lbs  },
                    { (uint)JobActions.SMN.oGCD.Starstorm   , lbs  },
                    { (uint)JobActions.SMN.oGCD.Teraflare   , lbs  },
                };
                JobsEquivalentActions.Add(JobID.SMN, dic);
            }
            //BLM
            {
                var fir   = stackalloc uint[]{ (uint)JobActions.BLM.GCD.Fire2    , (uint)JobActions.BLM.GCD.HighFire2     }.ToArray();
                var bli   = stackalloc uint[]{ (uint)JobActions.BLM.GCD.Blizzard2, (uint)JobActions.BLM.GCD.HighBlizzard2 }.ToArray();
                var hth   = stackalloc uint[]{ (uint)JobActions.BLM.GCD.Thunder2 , (uint)JobActions.BLM.GCD.HighThunder2 }.ToArray();
                var thu   = stackalloc uint[]{ (uint)JobActions.BLM.GCD.Thunder1 , (uint)JobActions.BLM.GCD.HighThunder1 }.ToArray();

                var lbs   = stackalloc uint[]{ (uint)JobActions.BLM.oGCD.Skyshard, (uint)JobActions.BLM.oGCD.Starstorm, (uint)JobActions.BLM.oGCD.Meteor }.ToArray();

                var dic = new Dictionary<uint, uint[]>(11)
                {
                    { (uint)JobActions.BLM.GCD.Fire2        , fir  },
                    { (uint)JobActions.BLM.GCD.HighFire2    , fir  },
                    { (uint)JobActions.BLM.GCD.Blizzard2    , bli  },
                    { (uint)JobActions.BLM.GCD.HighBlizzard2, bli  },
                    { (uint)JobActions.BLM.GCD.Thunder2     , hth  },
                    { (uint)JobActions.BLM.GCD.HighThunder2 , hth  },
                    { (uint)JobActions.BLM.GCD.Thunder1     , thu  },
                    { (uint)JobActions.BLM.GCD.HighThunder1 , thu  },

                    { (uint)JobActions.BLM.oGCD.Skyshard    , lbs  },
                    { (uint)JobActions.BLM.oGCD.Starstorm   , lbs  },
                    { (uint)JobActions.BLM.oGCD.Meteor      , lbs  },
                };
                JobsEquivalentActions.Add(JobID.BLM, dic);
            }
            //RDM
            {
                var imp   = stackalloc uint[]{ (uint)JobActions.RDM.GCD.Scatter    , (uint)JobActions.RDM.GCD.Impact }.ToArray();
                var thu   = stackalloc uint[]{ (uint)JobActions.RDM.GCD.Verthunder1, (uint)JobActions.RDM.GCD.Verthunder3 }.ToArray();
                var aer   = stackalloc uint[]{ (uint)JobActions.RDM.GCD.Veraero1   , (uint)JobActions.RDM.GCD.Veraero3 }.ToArray();
                var jol   = stackalloc uint[]{ (uint)JobActions.RDM.GCD.Jolt1, (uint)JobActions.RDM.GCD.Jolt2, (uint)JobActions.RDM.GCD.Jolt3 }.ToArray();
                var lbs   = stackalloc uint[]{ (uint)JobActions.RDM.oGCD.Skyshard, (uint)JobActions.RDM.oGCD.Starstorm, (uint)JobActions.RDM.oGCD.VermilionScourge }.ToArray();

                var dic = new Dictionary<uint, uint[]>(12)
                {
                    { (uint)JobActions.RDM.GCD.Scatter          , imp  },
                    { (uint)JobActions.RDM.GCD.Impact           , imp  },
                    { (uint)JobActions.RDM.GCD.Verthunder1      , thu  },
                    { (uint)JobActions.RDM.GCD.Verthunder3      , thu  },
                    { (uint)JobActions.RDM.GCD.Veraero1         , aer  },
                    { (uint)JobActions.RDM.GCD.Veraero3         , aer  },
                    { (uint)JobActions.RDM.GCD.Jolt1            , jol  },
                    { (uint)JobActions.RDM.GCD.Jolt2            , jol  },
                    { (uint)JobActions.RDM.GCD.Jolt3            , jol  },

                    { (uint)JobActions.RDM.oGCD.Skyshard        , lbs  },
                    { (uint)JobActions.RDM.oGCD.Starstorm       , lbs  },
                    { (uint)JobActions.RDM.oGCD.VermilionScourge, lbs  },
                };
                JobsEquivalentActions.Add(JobID.RDM, dic);
            }
            //PCT
            {
                var lbs   = stackalloc uint[]{ (uint)JobActions.PCT.oGCD.Skyshard, (uint)JobActions.PCT.oGCD.Starstorm, (uint)JobActions.PCT.oGCD.ChromaticFantasy }.ToArray();

                var dic = new Dictionary<uint, uint[]>(5)
                {
                    { (uint)JobActions.PCT.oGCD.Skyshard        , lbs  },
                    { (uint)JobActions.PCT.oGCD.Starstorm       , lbs  },
                    { (uint)JobActions.PCT.oGCD.ChromaticFantasy, lbs  },
                };
                JobsEquivalentActions.Add(JobID.PCT, dic);
            }

        }

        public static uint[] RequestActionsFromJobId(JobID newJobId)
        {
            uint[] toReturn;
            switch (newJobId)
            {
                case JobID.PLD: //PLD
                    toReturn = Services.GlobalConfiguration.PLDConfig.GetDataForGamepad();
                    break;
                case JobID.WAR: //WAR
                    toReturn = Services.GlobalConfiguration.WARConfig.GetDataForGamepad();
                    break;
                case JobID.DRK: //DRK
                    toReturn = Services.GlobalConfiguration.DRKConfig.GetDataForGamepad();
                    break;
                case JobID.GNB: //GNB
                    toReturn = Services.GlobalConfiguration.GNBConfig.GetDataForGamepad();
                    break;


                case JobID.WHM: //WHM
                    toReturn = Services.GlobalConfiguration.WHMConfig.GetDataForGamepad();
                    break;
                case JobID.SCH: //SCH
                    toReturn = Services.GlobalConfiguration.SCHConfig.GetDataForGamepad();
                    break;
                case JobID.AST: //AST
                    toReturn = Services.GlobalConfiguration.ASTConfig.GetDataForGamepad();
                    break;
                case JobID.SGE: //SGE
                    toReturn = Services.GlobalConfiguration.SGEConfig.GetDataForGamepad();
                    break;


                case JobID.MNK: //MNK
                    toReturn = Services.GlobalConfiguration.MNKConfig.GetDataForGamepad();
                    break;
                case JobID.DRG: //DRG
                    toReturn = Services.GlobalConfiguration.DRGConfig.GetDataForGamepad();
                    break;
                case JobID.NIN: //NIN
                    toReturn = Services.GlobalConfiguration.NINConfig.GetDataForGamepad();
                    break;
                case JobID.SAM: //SAM
                    toReturn = Services.GlobalConfiguration.SAMConfig.GetDataForGamepad();
                    break;
                case JobID.RPR:
                    toReturn = Services.GlobalConfiguration.RPRConfig.GetDataForGamepad();
                    break;
                case JobID.VPR: //VPR
                    toReturn = Services.GlobalConfiguration.VPRConfig.GetDataForGamepad();
                    break;


                case JobID.BRD: //BRD
                    toReturn = Services.GlobalConfiguration.BRDConfig.GetDataForGamepad();
                    break;
                case JobID.MCH: //MCH
                    toReturn = Services.GlobalConfiguration.MCHConfig.GetDataForGamepad();
                    break;
                case JobID.DNC: //DNC
                    toReturn = Services.GlobalConfiguration.DNCConfig.GetDataForGamepad();
                    break;


                case JobID.BLM: //BLM
                    toReturn = Services.GlobalConfiguration.BLMConfig.GetDataForGamepad();
                    break;
                case JobID.SMN: //ARC
                    toReturn = Services.GlobalConfiguration.SMNConfig.GetDataForGamepad();
                    break;
                case JobID.RDM: //RDM
                    toReturn = Services.GlobalConfiguration.RDMConfig.GetDataForGamepad();
                    break;
                case JobID.PCT: //PCT
                    toReturn = Services.GlobalConfiguration.PCTConfig.GetDataForGamepad();
                    break;
                default:
                    toReturn = new uint[0];
                    break;
            }
            Services.PrintInfo($"#{toReturn.Length} gcds");
            return toReturn;
        }



        public unsafe static void Test()
        {
            var hotbars = FFXIVClientStructs.FFXIV.Client.UI.Misc.RaptureHotbarModule.Instance()->CrossHotbars;
            uint count = 0;
            Services.PrintInfo($"Hotbars count: {hotbars.Length}");
            int barIndex = 0;
            foreach (var hotbar in hotbars)
            {
                int slotIndex = 0;
                foreach (var slot in hotbar.Slots)
                {
                    if (slot.CommandType == FFXIVClientStructs.FFXIV.Client.UI.Misc.RaptureHotbarModule.HotbarSlotType.Action)
                    {
                        Services.PrintInfo($"BarId: {barIndex}\tSlotId: {slotIndex}\tAction Id: {slot.ApparentActionId}\tIcon ID: {slot.GetIconIdForSlot(slot.CommandType, slot.ApparentActionId)}");
                        count++;
                    }
                    slotIndex++;
                }
                barIndex++;
            }
            Services.PrintInfo($"Slots count:{count}");
        }

        public static uint[] RequestDefaultGCD(JobID jobID)
        {
            jobID = Utilities.SanitizeJob(jobID);
            switch (jobID)
            {
                case JobID.PLD: //PLD
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.PLD.GCD>();
                case JobID.WAR: //WAR
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.WAR.GCD>();
                case JobID.DRK: //DRK
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.DRK.GCD>();
                case JobID.GNB: //GNB
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.GNB.GCD>();


                case JobID.WHM: //WHM
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.WHM.GCD>();
                case JobID.SCH: //SCH
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.SCH.GCD>();
                case JobID.AST: //AST
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.AST.GCD>();
                case JobID.SGE: //SGE
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.SGE.GCD>();


                case JobID.MNK: //MNK
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.MNK.GCD>();
                case JobID.DRG: //DRG
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.DRG.GCD>();
                case JobID.NIN: //NIN
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.NIN.GCD>();
                case JobID.SAM: //SAM
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.SAM.GCD>();
                case JobID.RPR:
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.RPR.GCD>();
                case JobID.VPR: //VPR
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.VPR.GCD>();


                case JobID.BRD: //BRD
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.BRD.GCD>();
                case JobID.MCH: //MCH
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.MCH.GCD>();
                case JobID.DNC: //DNC
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.DNC.GCD>();


                case JobID.BLM: //BLM
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.BLM.GCD>();
                case JobID.SMN: //ARC
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.SMN.GCD>();
                case JobID.RDM: //RDM
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.RDM.GCD>();
                case JobID.PCT: //PCT
                    return (uint[])System.Enum.GetValuesAsUnderlyingType<JobActions.PCT.GCD>();
                default:
                    return new uint[0];
            }
        }

        public static uint[] RequestDefaultOGCD(JobID jobID)
        {
            jobID = Utilities.SanitizeJob(jobID);
            switch (jobID)
            {
                case JobID.PLD: //PLD
                    return Utilities.OrderedByDeclarationEnum<JobActions.PLD.oGCD>().Cast<uint>().ToArray();
                case JobID.WAR: //WAR                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.WAR.oGCD>().Cast<uint>().ToArray();
                case JobID.DRK: //DRK                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.DRK.oGCD>().Cast<uint>().ToArray();
                case JobID.GNB: //GNB                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.GNB.oGCD>().Cast<uint>().ToArray();


                case JobID.WHM: //WHM                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.WHM.oGCD>().Cast<uint>().ToArray();
                case JobID.SCH: //SCH                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.SCH.oGCD>().Cast<uint>().ToArray();
                case JobID.AST: //AST                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.AST.oGCD>().Cast<uint>().ToArray();
                case JobID.SGE: //SGE                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.SGE.oGCD>().Cast<uint>().ToArray();


                case JobID.MNK: //MNK                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.MNK.oGCD>().Cast<uint>().ToArray();
                case JobID.DRG: //DRG                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.DRG.oGCD>().Cast<uint>().ToArray();
                case JobID.NIN: //NIN                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.NIN.oGCD>().Cast<uint>().ToArray();
                case JobID.SAM: //SAM                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.SAM.oGCD>().Cast<uint>().ToArray();
                case JobID.RPR:
                    return Utilities.OrderedByDeclarationEnum<JobActions.RPR.oGCD>().Cast<uint>().ToArray();
                case JobID.VPR: //VPR                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.VPR.oGCD>().Cast<uint>().ToArray();


                case JobID.BRD: //BRD                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.BRD.oGCD>().Cast<uint>().ToArray();
                case JobID.MCH: //MCH                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.MCH.oGCD>().Cast<uint>().ToArray();
                case JobID.DNC: //DNC                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.DNC.oGCD>().Cast<uint>().ToArray();


                case JobID.BLM: //BLM                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.BLM.oGCD>().Cast<uint>().ToArray();
                case JobID.SMN: //ARC                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.SMN.oGCD>().Cast<uint>().ToArray();
                case JobID.RDM: //RDM                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.RDM.oGCD>().Cast<uint>().ToArray();
                case JobID.PCT: //PCT                                                  
                    return Utilities.OrderedByDeclarationEnum<JobActions.PCT.oGCD>().Cast<uint>().ToArray();
                default:
                    return new uint[0];
            }
        }
    }

    namespace JobActions
    {
        namespace PLD
        {
            public enum GCD : uint
            {
                FastBlade = 9, // L1, instant, GCD, range 3, single-target, targets=hostile
                RiotBlade = 15, // L4, instant, GCD, range 3, single-target, targets=hostile
                ShieldBash = 16, // L10, instant, GCD, range 3, single-target, targets=hostile
                RageOfHalone = 21, // L26, instant, GCD, range 3, single-target, targets=hostile
                ShieldLob = 24, // L15, instant, GCD, range 20, single-target, targets=hostile
                GoringBlade = 3538, // L54, instant, GCD, 60.0s CD (group 12/57), range 3, single-target, targets=hostile
                RoyalAuthority = 3539, // L60, instant, GCD, range 3, single-target, targets=hostile
                Clemency = 3541, // L58, 1.5s cast, GCD, range 30, single-target, targets=self/party/alliance/friendly
                TotalEclipse = 7381, // L6, instant, GCD, range 0, AOE 5 circle, targets=self
                HolySpirit = 7384, // L64, 1.5s cast, GCD, range 25, single-target, targets=hostile
                Prominence = 16457, // L40, instant, GCD, range 0, AOE 5 circle, targets=self
                HolyCircle = 16458, // L72, 1.5s cast, GCD, range 0, AOE 5 circle, targets=self
                Confiteor = 16459, // L80, instant, GCD, range 25, AOE 5 circle, targets=hostile
                Atonement = 16460, // L76, instant, GCD, range 3, single-target, targets=hostile
                BladeOfFaith = 25748, // L90, instant, GCD, range 25, AOE 5 circle, targets=hostile
                BladeOfTruth = 25749, // L90, instant, GCD, range 25, AOE 5 circle, targets=hostile
                BladeOfValor = 25750, // L90, instant, GCD, range 25, AOE 5 circle, targets=hostile
                Supplication = 36918, // L76, instant, GCD, range 3, single-target, targets=hostile
                Sepulchre = 36919, // L76, instant, GCD, range 3, single-target, targets=hostile
            }
            public enum oGCD : uint
            {
                [Order(0)]  HallowedGround = 30, // L50, instant, 420.0s CD (group 24), range 0, single-target, targets=self
                [Order(1)]  Rampart = 7531, // L8, instant, 90.0s CD (group 46), range 0, single-target, targets=self
                [Order(2)]  Sentinel = 17, // L38, instant, 120.0s CD (group 19), range 0, single-target, targets=self
                [Order(3)]  Guardian = 36920,
                [Order(4)]  Bulwark = 22, // L52, instant, 90.0s CD (group 15), range 0, single-target, targets=self
                [Order(5)]  Sheltron = 3542, // L35, instant, 5.0s CD (group 0), range 0, single-target, targets=self
                [Order(6)]  HolySheltron = 25746, // L82, instant, 5.0s CD (group 2), range 0, single-target, targets=self
                [Order(7)]  Cover = 27, // L45, instant, 120.0s CD (group 20), range 10, single-target, targets=party
                [Order(8)]  Intervention = 7382, // L62, instant, 10.0s CD (group 1), range 30, single-target, targets=party
                [Order(9)]  Reprisal = 7535, // L22, instant, 60.0s CD (group 44), range 0, AOE 5 circle, targets=self
                [Order(10)] PassageOfArms = 7385, // L70, instant, 120.0s CD (group 21), range 0, ???, targets=self
                [Order(11)] DivineVeil = 3540, // L56, instant, 90.0s CD (group 14), range 0, AOE 30 circle, targets=self
                [Order(12)] FightOrFlight = 20, // L2, instant, 60.0s CD (group 10), range 0, single-target, targets=self
                [Order(13)] CircleOfScorn = 23, // L50, instant, 30.0s CD (group 4), range 0, AOE 5 circle, targets=self
                [Order(14)] SpiritsWithin = 29, // L30, instant, 30.0s CD (group 5), range 3, single-target, targets=hostile
                [Order(15)] Expiacion = 25747, // L86, instant, 30.0s CD (group 5), range 3, AOE 5 circle, targets=hostile
                [Order(16)] Requiescat = 7383, // L68, instant, 60.0s CD (group 11), range 3, single-target, targets=hostile
                [Order(17)] Imperator = 36921,
                [Order(18)] Intervene = 16461, // L74, instant, 30.0s CD (group 9/70) (2 charges), range 20, single-target, targets=hostile
                [Order(19)] BladeOfHonor = 36922,
                [Order(20)] IronWill = 28, // L10, instant, 2.0s CD (group 3), range 0, single-target, targets=self
                [Order(21)] ReleaseIronWill = 32065, // L10, instant, 1.0s CD (group 3), range 0, single-target, targets=self
                [Order(22)] LowBlow = 7540, // L12, instant, 25.0s CD (group 41), range 3, single-target, targets=hostile
                [Order(23)] Provoke = 7533, // L15, instant, 30.0s CD (group 42), range 25, single-target, targets=hostile
                [Order(24)] Interject = 7538, // L18, instant, 30.0s CD (group 43), range 3, single-target, targets=hostile
                [Order(25)] Shirk = 7537, // L48, instant, 120.0s CD (group 49), range 25, single-target, targets=party
                [Order(26)] ShieldWall = 197, // LB1, instant, range 0, AOE 50 circle, targets=self, animLock=1.930
                [Order(27)] Stronghold = 198, // LB2, instant, range 0, AOE 50 circle, targets=self, animLock=3.860
                [Order(28)] LastBastion = 199, // LB3, instant, range 0, AOE 50 circle, targets=self, animLock=3.860s?
            }
            public enum PVP : uint
            {
                FastBlade = 29058,
                RiotBlade = 29059,
                RoyalAuthority = 29060,
                ShieldSmite = 41430,
                HolySpirit = 29062,
                Imperator = 41431,
                Intervene = 29065,
                HolySheltron = 29067,
                Guardian = 29066,
                Phalanx = 29069,
                BladeOfFaith = 29071,
                BladeOfTruth = 29072,
                BladeOfValor = 29073
            }
        }

        namespace WAR
        {
            public enum GCD : uint
            {
                HeavySwing = 31, // L1, instant, GCD, range 3, single-target, targets=Hostile
                Maim = 37, // L4, instant, GCD, range 3, single-target, targets=Hostile
                Overpower = 41, // L10, instant, GCD, range 0, AOE 5 circle, targets=Self
                StormPath = 42, // L26, instant, GCD, range 3, single-target, targets=Hostile
                StormEye = 45, // L50, instant, GCD, range 3, single-target, targets=Hostile
                Tomahawk = 46, // L15, instant, GCD, range 20, single-target, targets=Hostile
                InnerBeast = 49, // L35, instant, GCD, range 3, single-target, targets=Hostile
                SteelCyclone = 51, // L45, instant, GCD, range 0, AOE 5 circle, targets=Self
                FellCleave = 3549, // L54, instant, GCD, range 3, single-target, targets=Hostile
                Decimate = 3550, // L60, instant, GCD, range 0, AOE 5 circle, targets=Self                
                MythrilTempest = 16462, // L40, instant, GCD, range 0, AOE 5 circle, targets=Self
                ChaoticCyclone = 16463, // L72, instant, GCD, range 0, AOE 5 circle, targets=Self
                InnerChaos = 16465, // L80, instant, GCD, range 3, single-target, targets=Hostile
                PrimalRend = 25753, // L90, instant, GCD, range 20, AOE 5 circle, targets=Hostile, animLock=1.150
                PrimalRuination = 36925, // L100, instant, GCD, range 3, AOE 5 circle, targets=Hostile
            }

            public enum oGCD : uint
            {
                [Order(0)]  Holmgang = 43, // L42, instant, 240.0s CD (group 24), range 6, single-target, targets=Self/Hostile
                [Order(1)]  Rampart = 7531, // L8, instant, 90.0s CD (group 46), range 0, single-target, targets=self
                [Order(2)]  Vengeance = 44, // L38, instant, 120.0s CD (group 21), range 0, single-target, targets=Self
                [Order(3)]  Damnation = 36923, // L92, instant, 120.0s CD (group 21), range 0, single-target, targets=Self
                [Order(4)]  RawIntuition = 3551, // L56, instant, 25.0s CD (group 6), range 0, single-target, targets=Self
                [Order(5)]  Bloodwhetting = 25751, // L82, instant, 25.0s CD (group 6), range 0, single-target, targets=Self
                [Order(6)]  ThrillOfBattle = 40, // L30, instant, 90.0s CD (group 15), range 0, single-target, targets=Self
                [Order(7)]  Equilibrium = 3552, // L58, instant, 60.0s CD (group 13), range 0, single-target, targets=Self
                [Order(8)]  NascentFlash = 16464, // L76, instant, 25.0s CD (group 6), range 30, single-target, targets=Party
                [Order(9)]  Reprisal = 7535, // L22, instant, 60.0s CD (group 44), range 0, AOE 5 circle, targets=self
                [Order(10)] ShakeItOff = 7388, // L68, instant, 90.0s CD (group 14), range 0, AOE 30 circle, targets=Self
                [Order(11)] Berserk = 38, // L6, instant, 60.0s CD (group 10), range 0, single-target, targets=Self
                [Order(12)] InnerRelease = 7389, // L70, instant, 60.0s CD (group 11), range 0, single-target, targets=Self
                [Order(13)] Infuriate = 52, // L50, instant, 60.0s CD (group 19/70) (2 charges), range 0, single-target, targets=Self
                [Order(14)] Onslaught = 7386, // L62, instant, 30.0s CD (group 7/71) (2-3 charges), range 20, single-target, targets=Hostile
                [Order(15)] Upheaval = 7387, // L64, instant, 30.0s CD (group 8), range 3, single-target, targets=Hostile
                [Order(16)] Orogeny = 25752, // L86, instant, 30.0s CD (group 8), range 0, AOE 5 circle, targets=Self
                [Order(17)] PrimalWrath = 36924, // L96, instant, 1.0s CD (group 0), range 0, AOE 5 circle, targets=Self
                [Order(18)] Defiance = 48, // L10, instant, 2.0s CD (group 1), range 0, single-target, targets=Self
                [Order(19)] ReleaseDefiance = 32066, // L10, instant, 1.0s CD (group 1), range 0, single-target, targets=Self
                [Order(20)] LowBlow = 7540, // L12, instant, 25.0s CD (group 41), range 3, single-target, targets=hostile
                [Order(21)] Provoke = 7533, // L15, instant, 30.0s CD (group 42), range 25, single-target, targets=hostile
                [Order(22)] Interject = 7538, // L18, instant, 30.0s CD (group 43), range 3, single-target, targets=hostile
                [Order(23)] Shirk = 7537, // L48, instant, 120.0s CD (group 49), range 25, single-target, targets=party
                [Order(24)] ShieldWall = 197, // LB1, instant, range 0, AOE 50 circle, targets=self, animLock=1.930
                [Order(25)] Stronghold = 198, // LB2, instant, range 0, AOE 50 circle, targets=self, animLock=3.860
                [Order(26)] LandWaker = 4240, // LB3, instant, range 0, AOE 50 circle, targets=Self, animLock=3.860
            }   

            public enum PVP : uint
            {
                HeavySwing = 29074u,
                Maim = 29075u,
                StormsPath = 29076u,
                PrimalRend = 29084u,
                Onslaught = 29079u,
                Orogeny = 29080u,
                Blota = 29081u,
                Bloodwhetting = 29082u,
                PrimalScream = 29083u,
                PrimalWrath = 41433u
            }
        }       

        namespace GNB
        {
            public enum GCD : uint
            {
                KeenEdge = 16137, // L1, instant, GCD, range 3, single-target, targets=hostile
                BrutalShell = 16139, // L4, instant, GCD, range 3, single-target, targets=hostile
                DemonSlice = 16141, // L10, instant, GCD, range 0, AOE 5 circle, targets=self
                LightningShot = 16143, // L15, instant, GCD, range 20, single-target, targets=hostile
                SolidBarrel = 16145, // L26, instant, GCD, range 3, single-target, targets=hostile
                BurstStrike = 16162, // L30, instant, GCD, range 3, single-target, targets=hostile
                DemonSlaughter = 16149, // L40, instant, GCD, range 0, AOE 5 circle, targets=self
                SonicBreak = 16153, // L54, instant, 60.0s CD (group 13/57), range 3, single-target, targets=hostile
                GnashingFang = 16146, // L60, instant, 30.0s CD (group 5/57), range 3, single-target, targets=hostile, animLock=0.700
                SavageClaw = 16147, // L60, instant, GCD, range 3, single-target, targets=hostile, animLock=0.500
                WickedTalon = 16150, // L60, instant, GCD, range 3, single-target, targets=hostile, animLock=0.770
                FatedCircle = 16163, // L72, instant, GCD, range 0, AOE 5 circle, targets=self
                DoubleDown = 25760, // L90, instant, 60.0s CD (group 12/57), range 0, AOE 5 circle, targets=self
                ReignOfBeasts = 36937, // L100, instant, GCD, range 3, single-target, targets=hostile
                NobleBlood = 36938, // L100, instant, GCD, range 3, single-target, targets=hostile
                LionHeart = 36939, // L100, instant, GCD, range 3, single-target, targets=hostile
            }
            public enum oGCD : uint
            {
                [Order(0)]  Rampart = 7531, // L8, instant, 90.0s CD (group 46), range 0, single-target, targets=self
                [Order(1)]  NoMercy = 16138, // L2, instant, 60.0s CD (group 10), range 0, single-target, targets=self
                [Order(2)]  Camouflage = 16140, // L6, instant, 90.0s CD (group 15), range 0, single-target, targets=self
                [Order(3)]  RoyalGuard = 16142, // L10, instant, 2.0s CD (group 1), range 0, single-target, targets=self
                [Order(4)]  DangerZone = 16144, // L18, instant, 30.0s CD (group 4), range 3, single-target, targets=hostile
                [Order(5)]  Nebula = 16148, // L38, instant, 120.0s CD (group 21), range 0, single-target, targets=self
                [Order(6)]  Aurora = 16151, // L45, instant, 60.0s CD (group 19/71), range 30, single-target, targets=self/party/alliance/friendly
                [Order(7)]  Superbolide = 16152, // L50, instant, 360.0s CD (group 24), range 0, single-target, targets=self
                [Order(8)]  Continuation = 16155, // L70, instant, 1.0s CD (group 0), range 0, single-target, targets=self, animLock=???
                [Order(9)]  JugularRip = 16156, // L70, instant, 1.0s CD (group 0), range 5, single-target, targets=hostile
                [Order(10)] AbdomenTear = 16157, // L70, instant, 1.0s CD (group 0), range 5, single-target, targets=hostile
                [Order(11)] EyeGouge = 16158, // L70, instant, 1.0s CD (group 0), range 5, single-target, targets=hostile
                [Order(12)] BowShock = 16159, // L62, instant, 60.0s CD (group 11), range 0, AOE 5 circle, targets=self
                [Order(13)] HeartOfLight = 16160, // L64, instant, 90.0s CD (group 16), range 0, AOE 30 circle, targets=self
                [Order(14)] HeartOfStone = 16161, // L68, instant, 25.0s CD (group 3), range 30, single-target, targets=self/party
                [Order(15)] Bloodfest = 16164, // L76, instant, 120.0s CD (group 14), range 25, single-target, targets=hostile
                [Order(16)] BlastingZone = 16165, // L80, instant, 30.0s CD (group 4), range 3, single-target, targets=hostile
                [Order(17)] HeartOfCorundum = 25758, // L82, instant, 25.0s CD (group 3), range 30, single-target, targets=self/party
                [Order(18)] Hypervelocity = 25759, // L86, instant, 1.0s CD (group 0), range 5, single-target, targets=hostile
                [Order(19)] ReleaseRoyalGuard = 32068, // L10, instant, 1.0s CD (group 1), range 0, single-target, targets=self
                [Order(20)] Trajectory = 36934, // L56, instant, 30.0s CD (group 9/70) (2? charges), range 20, single-target, targets=hostile
                [Order(21)] GreatNebula = 36935, // L92, instant, 120.0s CD, range 0, single-target, targeets=self
                [Order(22)] FatedBrand = 36936, // L96, instant, 1.0s CD, (group 0), range 5, AOE, targets=hostile
                [Order(23)] LowBlow = 7540, // L12, instant, 25.0s CD (group 41), range 3, single-target, targets=hostile
                [Order(24)] Provoke = 7533, // L15, instant, 30.0s CD (group 42), range 25, single-target, targets=hostile
                [Order(25)] Interject = 7538, // L18, instant, 30.0s CD (group 43), range 3, single-target, targets=hostile
                [Order(26)] Reprisal = 7535, // L22, instant, 60.0s CD (group 44), range 0, AOE 5 circle, targets=self
                [Order(27)] Shirk = 7537, // L48, instant, 120.0s CD (group 49), range 25, single-target, targets=party
                [Order(28)] ShieldWall = 197, // LB1, instant, range 0, AOE 50 circle, targets=self, animLock=1.930
                [Order(29)] Stronghold = 198, // LB2, instant, range 0, AOE 50 circle, targets=self, animLock=3.860
                [Order(30)] GunmetalSoul = 17105, // LB3, instant, range 0, AOE 50 circle, targets=self, animLock=3.860
            }

            public enum PVP : uint
            {
                KeenEdge = 29098,
                BrutalShell = 29099,
                SolidBarrel = 29100,
                BurstStrike = 29101,
                GnashingFang = 29102,
                SavageClaw = 29103,
                WickedTalon = 29104,
                Continuation = 29106,
                JugularRip = 29108,
                AbdomenTear = 29109,
                EyeGouge = 29110,
                RoughDivide = 29123,
                RelentlessRush = 29130,
                TerminalTrigger = 29131,
                FatedCircle = 41511,
                FatedBrand = 41442,
                BlastingZone = 29128,
                HeartOfCorundum = 41443
            }
        }

        namespace DRK
        {
            public enum GCD : uint
            {
                HardSlash = 3617, // L1, instant, GCD, range 3, single-target, targets=Hostile
                SyphonStrike = 3623, // L2, instant, GCD, range 3, single-target, targets=Hostile
                Unleash = 3621, // L6, instant, GCD, range 0, AOE 5 circle, targets=Self
                Unmend = 3624, // L15, instant, GCD, range 20, single-target, targets=Hostile
                Souleater = 3632, // L26, instant, GCD, range 3, single-target, targets=Hostile
                StalwartSoul = 16468, // L40, instant, GCD, range 0, AOE 5 circle, targets=Self                
                Bloodspiller = 7392, // L62, instant, GCD, range 3, single-target, targets=Hostile
                Quietus = 7391, // L64, instant, GCD, range 0, AOE 5 circle, targets=Self                
                ScarletDelirium = 36928, // L96, instant, GCD, range 3, single-target, targets=Hostile, animLock=???
                Comeuppance = 36929, // L96, instant, GCD, range 3, single-target, targets=Hostile, animLock=???
                Torcleaver = 36930, // L96, instant, GCD, range 3, single-target, targets=Hostile, animLock=???
                Impalement = 36931, // L96, instant, GCD, range 0, AOE 5 circle, targets=Self, animLock=???
                Disesteem = 36932, // L100, instant, GCD, range 10, AOE 10+R width 4 rect, targets=Hostile, animLock=???
            }
            public enum oGCD : uint
            {
                [Order(0)] LivingDead = 3638, // L50, instant, 300.0s CD (group 24), range 0, single-target, targets=Self
                [Order(1)] Rampart = 7531, // L8, instant, 90.0s CD (group 46), range 0, single-target, targets=self
                [Order(2)] ShadowWall = 3636, // L38, instant, 120.0s CD (group 20), range 0, single-target, targets=Self
                [Order(3)] ShadowedVigil = 36927, // L92, instant, 120.0s CD (group 20), range 0, single-target, targets=Self, animLock=???
                [Order(4)] DarkMind = 3634, // L45, instant, 60.0s CD (group 8), range 0, single-target, targets=Self
                [Order(5)] Oblation = 25754, // L82, instant, 60.0s CD (group 18/71) (2 charges), range 30, single-target, targets=Self/Party
                [Order(6)] TheBlackestNight = 7393, // L70, instant, 15.0s CD (group 2), range 30, single-target, targets=Self/Party
                [Order(7)] Reprisal = 7535, // L22, instant, 60.0s CD (group 44), range 0, AOE 5 circle, targets=self
                [Order(8)] DarkMissionary = 16471, // L76, instant, 90.0s CD (group 14), range 0, AOE 30 circle, targets=Self
                [Order(9)] BloodWeapon = 3625, // L35, instant, 60.0s CD (group 10), range 0, single-target, targets=Self
                [Order(10)] Delirium = 7390, // L68, instant, 60.0s CD (group 10), range 0, single-target, targets=Self
                [Order(11)] SaltedEarth = 3639, // L52, instant, 90.0s CD (group 15), range 0, AOE 5 circle, targets=Self
                [Order(12)] AbyssalDrain = 3641, // L56, instant, 60.0s CD (group 9), range 20, AOE 5 circle, targets=Hostile
                [Order(13)] CarveAndSpit = 3643, // L60, instant, 60.0s CD (group 9), range 3, single-target, targets=Hostile
                [Order(14)] FloodOfShadow = 16469, // L74, instant, 1.0s CD (group 0), range 10, AOE 10+R width 4 rect, targets=Hostile
                [Order(15)] EdgeOfShadow = 16470, // L74, instant, 1.0s CD (group 0), range 3, single-target, targets=Hostile
                [Order(16)] FloodOfDarkness = 16466, // L30, instant, 1.0s CD (group 0), range 10, AOE 10+R width 4 rect, targets=Hostile
                [Order(17)] EdgeOfDarkness = 16467, // L40, instant, 1.0s CD (group 0), range 3, single-target, targets=Hostile
                [Order(18)] SaltAndDarkness = 25755, // L86, instant, 20.0s CD (group 5), range 0, single-target, targets=Self
                [Order(19)] LivingShadow = 16472, // L80, instant, 120.0s CD (group 21), range 0, single-target, targets=Self
                [Order(20)] Shadowbringer = 25757, // L90, instant, 60.0s CD (group 22/72) (2 charges), range 10, AOE 10+R width 4 rect, targets=Hostile
                [Order(21)] Grit = 3629, // L10, instant, 2.0s CD (group 1), range 0, single-target, targets=Self
                [Order(22)] ReleaseGrit = 32067, // L10, instant, 1.0s CD (group 1), range 0, single-target, targets=Self
                [Order(23)] Shadowstride = 36926, // L54, instant, 30.0s CD (group 7/70) (2? charges), range 20, single-target, targets=Hostile, animLock=???
                [Order(24)] LowBlow = 7540, // L12, instant, 25.0s CD (group 41), range 3, single-target, targets=hostile
                [Order(25)] Provoke = 7533, // L15, instant, 30.0s CD (group 42), range 25, single-target, targets=hostile
                [Order(26)] Interject = 7538, // L18, instant, 30.0s CD (group 43), range 3, single-target, targets=hostile
                [Order(27)] Shirk = 7537, // L48, instant, 120.0s CD (group 49), range 25, single-target, targets=party
                [Order(28)] ShieldWall = 197, // LB1, instant, range 0, AOE 50 circle, targets=self, animLock=1.930
                [Order(29)] Stronghold = 198, // LB2, instant, range 0, AOE 50 circle, targets=self, animLock=3.860
                [Order(30)] DarkForce = 4241, // LB3, instant, range 0, AOE 50 circle, targets=Self, animLock=3.860s?
            }
            public enum PVP : uint
            {
                HardSlash = 29085,
                SyphonStrike = 29086,
                Souleater = 29087,
                Shadowbringer = 29091,
                Plunge = 29092,
                BlackestNight = 29093,
                SaltedEarth = 29094,
                Bloodspiller = 29088,
                SaltAndDarkness = 29095,
                Impalement = 41438,
                Eventide = 29097
            }
        }

        namespace SGE
        {
            public enum GCD : uint
            {
                Esuna = 7568, // L10, 1.0s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Repose = 16560, // L8, 2.5s cast, GCD, range 30, single-target, targets=Hostile
                Dosis1 = 24283, // L1, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Diagnosis = 24284, // L2, 1.5s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Prognosis = 24286, // L10, 2.0s cast, GCD, range 0, AOE 15 circle, targets=Self
                Egeiro = 24287, // L12, 8.0s cast, GCD, range 30, single-target, targets=Party/Alliance/Friendly/Dead
                Phlegma1 = 24289, // L26, instant, 40.0s CD (group 13/57) (2 charges), range 6, AOE 5 circle, targets=Hostile
                Eukrasia = 24290, // L30, instant, GCD, range 0, single-target, targets=Self
                EukrasianDiagnosis = 24291, // L30, instant, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                EukrasianPrognosis1 = 24292, // L30, instant, GCD, range 0, AOE 15 circle, targets=Self
                EukrasianDosis1 = 24293, // L30, instant, GCD, range 25, single-target, targets=Hostile
                Dyskrasia = 24297, // L46, instant, GCD, range 0, AOE 5 circle, targets=Self
                Toxikon = 24304, // L66, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                Dosis2 = 24306, // L72, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Phlegma2 = 24307, // L72, instant, 40.0s CD (group 13/57) (2 charges), range 6, AOE 5 circle, targets=Hostile
                EukrasianDosis2 = 24308, // L72, instant, GCD, range 25, single-target, targets=Hostile
                Dosis3 = 24312, // L82, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Phlegma3 = 24313, // L82, instant, 40.0s CD (group 13/57) (2 charges), range 6, AOE 5 circle, targets=Hostile
                EukrasianDosis3 = 24314, // L82, instant, GCD, range 25, single-target, targets=Hostile
                DyskrasiaII = 24315, // L82, instant, GCD, range 0, AOE 5 circle, targets=Self
                ToxikonII = 24316, // L82, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                Pneuma = 24318, // L90, 1.5s cast, 120.0s CD (group 22/57), range 25, AOE 25+R width 4 rect, targets=Hostile
                EukrasianDyskrasia = 37032, // L82, instant, GCD, range 0, AOE 5 circle, targets=Self, animLock=???
                EukrasianPrognosis2 = 37034, // L96, instant, GCD, range 0, AOE 15 circle, targets=Self, animLock=???
            }
            public enum oGCD : uint
            {
                [Order(0)]  Kardia = 24285, // L4, instant, 5.0s CD (group 1), range 30, single-target, targets=Self/Party
                [Order(1)]  Physis = 24288, // L20, instant, 60.0s CD (group 10), range 0, AOE 15 circle, targets=Self
                [Order(2)]  Soteria = 24294, // L35, instant, 90.0s CD (group 14), range 0, single-target, targets=Self
                [Order(3)]  Icarus = 24295, // L40, instant, 45.0s CD (group 6), range 25, single-target, targets=Party/Hostile, animLock=0.700s?
                [Order(4)]  Druochole = 24296, // L45, instant, 1.0s CD (group 0), range 30, single-target, targets=Self/Party/Alliance/Friendly
                [Order(5)]  Kerachole = 24298, // L50, instant, 30.0s CD (group 3), range 0, AOE 30 circle, targets=Self
                [Order(6)]  Ixochole = 24299, // L52, instant, 30.0s CD (group 4), range 0, AOE 15 circle, targets=Self
                [Order(7)]  Zoe = 24300, // L56, instant, 120.0s CD (group 19), range 0, single-target, targets=Self
                [Order(8)]  Pepsis = 24301, // L58, instant, 30.0s CD (group 2), range 0, AOE 15 circle, targets=Self
                [Order(9)]  PhysisII = 24302, // L60, instant, 60.0s CD (group 11), range 0, AOE 30 circle, targets=Self
                [Order(10)] Taurochole = 24303, // L62, instant, 45.0s CD (group 7), range 30, single-target, targets=Self/Party
                [Order(11)] Haima = 24305, // L70, instant, 120.0s CD (group 20), range 30, single-target, targets=Self/Party
                [Order(12)] Rhizomata = 24309, // L74, instant, 90.0s CD (group 15), range 0, single-target, targets=Self
                [Order(13)] Holos = 24310, // L76, instant, 120.0s CD (group 18), range 0, AOE 30 circle, targets=Self
                [Order(14)] Panhaima = 24311, // L80, instant, 120.0s CD (group 21), range 0, AOE 30 circle, targets=Self
                [Order(15)] Krasis = 24317, // L86, instant, 60.0s CD (group 12), range 30, single-target, targets=Self/Party
                [Order(16)] KardiaEnd = 28119, // L4, instant, range 30, single-target, targets=Self/Party
                [Order(17)] Psyche = 37033, // L92, instant, 60.0s CD (group 9), range 25, AOE 5 circle, targets=Hostile, animLock=???
                [Order(18)] Philosophia = 37035, // L100, instant, 180.0s CD (group 24), range 0, AOE 20 circle, targets=Self, animLock=???
                [Order(19)] Eudaimonia = 37036, // L100, instant, range 30, single-target, targets=Self/Party, animLock=???
                [Order(20)] HealingWind = 206, // LB1, 2.0s cast, range 0, AOE 50 circle, targets=self, castAnimLock=2.100
                [Order(21)] BreathOfTheEarth = 207, // LB2, 2.0s cast, range 0, AOE 50 circle, targets=self, castAnimLock=5.130
                [Order(22)] TechneMakre = 24859, // LB3, 2.0s cast, range 0, AOE 50 circle, targets=Self, animLock=8.100s?
            }   
            public enum PVP : uint
            {
                Dosis = 29256,
                Phlegma = 29259,
                Pneuma = 29260,
                Eukrasia = 29258,
                Icarus = 29261,
                Toxikon = 29262,
                Kardia = 29264,
                EukrasianDosis = 29257,
                Toxicon2 = 29263,
                Psyche = 41658
            }
        }       
                
        namespace WHM
        {
            public enum GCD : uint
            {
                Stone1 = 119, // L1, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Cure1 = 120, // L2, 1.5s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Aero1 = 121, // L4, instant, GCD, range 25, single-target, targets=Hostile
                Medica1 = 124, // L10, 2.0s cast, GCD, range 0, AOE 15 circle, targets=Self
                Raise = 125, // L12, 8.0s cast, GCD, range 30, single-target, targets=Party/Alliance/Friendly/Dead
                Stone2 = 127, // L18, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Cure2 = 135, // L30, 2.0s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Regen = 137, // L35, instant, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Cure3 = 131, // L40, 2.0s cast, GCD, range 30, AOE 10 circle, targets=Self/Party
                Holy1 = 139, // L45, 2.5s cast, GCD, range 0, AOE 8 circle, targets=Self
                Aero2 = 132, // L46, instant, GCD, range 25, single-target, targets=Hostile
                Medica2 = 133, // L50, 2.0s cast, GCD, range 0, AOE 20 circle, targets=Self
                Stone3 = 3568, // L54, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Stone4 = 7431, // L64, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Esuna = 7568, // L10, 1.0s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                AfflatusSolace = 16531, // L52, instant, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Dia = 16532, // L72, instant, GCD, range 25, single-target, targets=Hostile
                Glare1 = 16533, // L72, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Repose = 16560, // L8, 2.5s cast, GCD, range 30, single-target, targets=Hostile
                AfflatusRapture = 16534, // L76, instant, GCD, range 0, AOE 20 circle, targets=Self
                AfflatusMisery = 16535, // L74, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                Glare3 = 25859, // L82, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Holy3 = 25860, // L82, 2.5s cast, GCD, range 0, AOE 8 circle, targets=Self
                GlareIV = 37009, // L92, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                Medica3 = 37010, // L96, 2.0s cast, GCD, range 0, AOE 20 circle, targets=Self, animLock=???
            }
            public enum oGCD : uint
            {
                [Order(0)]  PresenceOfMind = 136, // L30, instant, 120.0s CD (group 20), range 0, single-target, targets=Self
                [Order(1)]  Benediction = 140, // L50, instant, 180.0s CD (group 23), range 30, single-target, targets=Self/Party/Alliance/Friendly
                [Order(2)]  Asylum = 3569, // L52, instant, 90.0s CD (group 14), range 30, ???, targets=Area
                [Order(3)]  Tetragrammaton = 3570, // L60, instant, 60.0s CD (group 19/72), range 30, single-target, targets=Self/Party/Alliance/Friendly
                [Order(4)]  Assize = 3571, // L56, instant, 40.0s CD (group 7), range 0, AOE 15 circle, targets=Self
                [Order(5)]  ThinAir = 7430, // L58, instant, 60.0s CD (group 18/70) (2 charges), range 0, single-target, targets=Self
                [Order(6)]  DivineBenison = 7432, // L66, instant, 30.0s CD (group 9/71) (1-2 charges), range 30, single-target, targets=Self/Party
                [Order(7)]  PlenaryIndulgence = 7433, // L70, instant, 60.0s CD (group 10), range 0, AOE 20 circle, targets=Self
                [Order(8)]  Temperance = 16536, // L80, instant, 120.0s CD (group 21), range 0, single-target, targets=Self
                [Order(9)]  Aquaveil = 25861, // L86, instant, 60.0s CD (group 11), range 30, single-target, targets=Self/Party
                [Order(10)] LiturgyOfTheBell = 25862, // L90, instant, 180.0s CD (group 22), range 30, ???, targets=Area
                [Order(11)] AetherialShift = 37008, // L40, instant, 60.0s CD (group 12), range 0, single-target, targets=Self, animLock=???
                [Order(12)] DivineCaress = 37011, // L100, instant, 1.0s CD (group 1), range 0, AOE 15 circle, targets=Self
                [Order(13)] HealingWind = 206, // LB1, 2.0s cast, range 0, AOE 50 circle, targets=self, castAnimLock=2.100
                [Order(14)] BreathOfTheEarth = 207, // LB2, 2.0s cast, range 0, AOE 50 circle, targets=self, castAnimLock=5.130
                [Order(15)] PulseOfLife = 208, // LB3, 2.0s cast, range 0, AOE 50 circle, targets=Self, animLock=8.100s?
            }   
            public enum PVP : uint 
            {
                Glare = 29223,
                Cure2 = 29224,
                Cure3 = 29225,
                AfflatusMisery = 29226,
                Aquaveil = 29227,
                MiracleOfNature = 29228,
                SeraphStrike = 29229,
                AfflatusPurgation = 29230
            }
        }  

        namespace SCH
        {
            public enum GCD : uint
            {
                Ressurection = 173,// L12, 8.0s cast, GCD, range 30, single-target, targets=Party/Alliance/Friendly/Dead
                Adloquium = 185, // L30, 2.0s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Succor = 186, // L35, 2.0s cast, GCD, range 0, AOE 15 circle, targets=Self
                Physick = 190, // L4, 1.5s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Broil1 = 3584, // L54, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Broil2 = 7435, // L64, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Esuna = 7568, // L10, 1.0s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                ArtOfWar1 = 16539, // L46, instant, GCD, range 0, AOE 5 circle, targets=Self
                Broil3 = 16541, // L72, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Biolysis = 16540, // L72, instant, GCD, range 25, single-target, targets=Hostile
                Repose = 16560, // L8, 2.5s cast, GCD, range 30, single-target, targets=Hostile
                SummonEos = 17215, // L4, 1.5s cast, GCD, range 0, single-target, targets=Self
                Bio1 = 17864, // L2, instant, GCD, range 25, single-target, targets=Hostile
                Bio2 = 17865, // L26, instant, GCD, range 25, single-target, targets=Hostile
                Ruin1 = 17869, // L1, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Ruin2 = 17870, // L38, instant, GCD, range 25, single-target, targets=Hostile
                Broil4 = 25865, // L82, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                ArtOfWar2 = 25866, // L82, instant, GCD, range 0, AOE 5 circle, targets=Self
                Concitation = 37013, // L96, 2.0s cast, GCD, range 0, AOE 15 circle, targets=Self, animLock=???
                Manifestation = 37015, // L100, instant, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly, animLock=???
                Accession = 37016, // L100, instant, GCD, range 0, AOE 15 circle, targets=Self, animLock=???
            }
            public enum oGCD : uint
            {
                [Order(0)]  Aetherflow = 166, // L45, instant, 60.0s CD (group 13), range 0, single-target, targets=Self
                [Order(1)]  EnergyDrain = 167, // L45, instant, 1.0s CD (group 3), range 25, single-target, targets=Hostile
                [Order(2)]  Lustrate = 189, // L45, instant, 1.0s CD (group 0), range 30, single-target, targets=Self/Party/Alliance/Friendly
                [Order(3)]  SacredSoil = 188, // L50, instant, 30.0s CD (group 7), range 30, ???, targets=Area
                [Order(4)]  Indomitability = 3583, // L52, instant, 30.0s CD (group 8), range 0, AOE 15 circle, targets=Self
                [Order(5)]  DeploymentTactics = 3585, // L56, instant, 120.0s CD (group 19), range 30, AOE 30 circle, targets=Self/Party
                [Order(6)]  EmergencyTactics = 3586, // L58, instant, 15.0s CD (group 6), range 0, single-target, targets=Self
                [Order(7)]  Dissipation = 3587, // L60, instant, 180.0s CD (group 24), range 0, single-target, targets=Self
                [Order(8)]  Excogitation = 7434, // L62, instant, 45.0s CD (group 9), range 30, single-target, targets=Self/Party
                [Order(9)]  ChainStratagem = 7436, // L66, instant, 120.0s CD (group 20), range 25, single-target, targets=Hostile
                [Order(10)] Aetherpact = 7437, // L70, instant, 3.0s CD (group 5), range 30, single-target, targets=Self/Party
                [Order(11)] DissolveUnion = 7869, // L70, instant, 1.0s CD (group 1), range 0, single-target, targets=Self
                [Order(12)] WhisperingDawn = 16537, // L20, instant, 60.0s CD (group 14), range 0, single-target, targets=Self
                [Order(13)] FeyIllumination = 16538, // L40, instant, 120.0s CD (group 21), range 0, single-target, targets=Self
                [Order(14)] Recitation = 16542, // L74, instant, 90.0s CD (group 15), range 0, single-target, targets=Self
                [Order(15)] FeyBlessing = 16543, // L76, instant, 60.0s CD (group 11), range 0, single-target, targets=Self
                [Order(16)] SummonSeraph = 16545, // L80, instant, 120.0s CD (group 22), range 0, single-target, targets=Self
                [Order(17)] Consolation = 16546, // L80, instant, 30.0s CD (group 10/70) (2 charges), range 0, single-target, targets=Self
                [Order(18)] Protraction = 25867, // L86, instant, 60.0s CD (group 12), range 30, single-target, targets=Self/Party
                [Order(19)] Expedient = 25868, // L90, instant, 120.0s CD (group 18), range 0, AOE 30 circle, targets=Self
                [Order(20)] BanefulImpaction = 37012, // L92, instant, 1.0s CD (group 2), range 25, AOE 5 circle, targets=Hostile, animLock=???
                [Order(21)] Seraphism = 37014, // L100, instant, 180.0s CD (group 23), range 0, single-target, targets=Self, animLock=???
                [Order(22)] EmergencyTactics1 = 37037, // L100, instant, 1.0s CD (group 4), range 0, single-target, targets=Self, animLock=???
                [Order(23)] HealingWind = 206, // LB1, 2.0s cast, range 0, AOE 50 circle, targets=self, castAnimLock=2.100
                [Order(24)] BreathOfTheEarth = 207, // LB2, 2.0s cast, range 0, AOE 50 circle, targets=self, castAnimLock=5.130
                [Order(25)] AngelFeathers = 4247, // LB3, 2.0s cast, range 0, AOE 50 circle, targets=Self, animLock=8.100s?
            }
            public enum PVP : uint
            {
                Broil = 29231,
                Adloquilum = 29232,
                Biolysis = 29233,
                DeploymentTactics = 29234,
                Expedient = 29236,
                ChainStratagem = 29716
            }
        }
                
        namespace AST
        {
            public enum GCD : uint
            {
                Malefic1 = 3596, // L1, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Benefic = 3594, // L2, 1.5s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Combust1 = 3599, // L4, instant, GCD, range 25, single-target, targets=Hostile
                Helios = 3600, // L10, 1.5s cast, GCD, range 0, AOE 15 circle, targets=Self
                Ascend = 3603, // L12, 8.0s cast, GCD, range 30, single-target, targets=Party/Alliance/Friendly/Dead
                EssentialDignity = 3614, // L15, instant, 40.0s CD (group 10/70) (1-2 charges), range 30, single-target, targets=Self/Party/Alliance/Friendly
                BeneficII = 3610, // L26, 1.5s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                AspectedBenefic = 3595, // L34, instant, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                AspectedHelios = 3601, // L40, 1.5s cast, GCD, range 0, AOE 15 circle, targets=Self
                Gravity1 = 3615, // L45, 1.5s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Combust2 = 3608, // L46, instant, GCD, range 25, single-target, targets=Hostile
                Malefic2 = 3598, // L54, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Malefic3 = 7442, // L64, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Esuna = 7568, // L10, 1.0s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Repose = 16560, // L8, 2.5s cast, GCD, range 30, single-target, targets=Hostile
                Malefic4 = 16555, // L72, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Combust3 = 16554, // L72, instant, GCD, range 25, single-target, targets=Hostile
                FallMalefic = 25871, // L82, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                Gravity2 = 25872, // L82, 1.5s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Macrocosmos = 25874, // L90, instant, 180.0s CD (group 22/57), range 0, AOE 20 circle, targets=Self
                HeliosConjunction = 37030, // L96, 1.5s cast, GCD, range 0, AOE 15 circle, targets=Self
            }
            public enum oGCD : uint
            {
                [Order(0)]  Lightspeed = 3606, // L6, instant, 90.0s CD (group 18/71) (2 charges), range 0, single-target, targets=Self
                [Order(1)]  Synastry = 3612, // L50, instant, 120.0s CD (group 19), range 30, single-target, targets=Party
                [Order(2)]  CollectiveUnconscious = 3613, // L58, instant, 60.0s CD (group 11), range 0, AOE 30 circle, targets=Self
                [Order(3)]  EarthlyStar = 7439, // L62, instant, 60.0s CD (group 12), range 30, ???, targets=Area
                [Order(4)]  StellarDetonation = 8324, // L62, instant, 3.0s CD (group 8), range 0, AOE 20 circle, targets=Self
                [Order(5)]  LordOfCrowns = 7444, // L70, instant, 1.0s CD (group 6), range 0, AOE 20 circle, targets=Self
                [Order(6)]  LadyOfCrowns = 7445, // L70, instant, 1.0s CD (group 6), range 0, AOE 20 circle, targets=Self
                [Order(7)]  Divination = 16552, // L50, instant, 120.0s CD (group 20), range 0, AOE 30 circle, targets=Self
                [Order(8)]  CelestialOpposition = 16553, // L60, instant, 60.0s CD (group 13), range 0, AOE 15 circle, targets=Self
                [Order(9)]  CelestialIntersection = 16556, // L74, instant, 30.0s CD (group 9/72) (1-2 charges), range 30, single-target, targets=Self/Party
                [Order(10)] Horoscope = 16557, // L76, instant, 60.0s CD (group 14), range 0, AOE 20 circle, targets=Self
                [Order(11)] HoroscopeEnd = 16558, // L76, instant, 1.0s CD (group 5), range 0, AOE 20 circle, targets=Self
                [Order(12)] NeutralSect = 16559, // L80, instant, 120.0s CD (group 21), range 0, single-target, targets=Self
                [Order(13)] Exaltation = 25873, // L86, instant, 60.0s CD (group 15), range 30, single-target, targets=Self/Party
                [Order(14)] MicrocosmosEnd = 25875, // L90, instant, 1.0s CD (group 0), range 0, AOE 20 circle, targets=Self
                [Order(15)] AstralDraw = 37017, // L30, instant, 55.0s CD (group 16), range 0, single-target, targets=Self
                [Order(16)] UmbralDraw = 37018, // L30, instant, 55.0s CD (group 16), range 0, single-target, targets=Self
                [Order(17)] Play1 = 37019, // L30, instant, 1.0s CD (group 1), range 0, single-target, targets=Self
                [Order(18)] Play2 = 37020, // L30, instant, 1.0s CD (group 2), range 0, single-target, targets=Self
                [Order(19)] Play3 = 37021, // L30, instant, 1.0s CD (group 3), range 0, single-target, targets=Self
                [Order(20)] TheBalance = 37023, // L30, instant, 1.0s CD (group 1), range 30, single-target, targets=Self/Party
                [Order(21)] TheArrow = 37024, // L30, instant, 1.0s CD (group 2), range 30, single-target, targets=Self/Party
                [Order(22)] TheSpire = 37025, // L30, instant, 1.0s CD (group 3), range 30, single-target, targets=Self/Party
                [Order(23)] TheSpear = 37026, // L30, instant, 1.0s CD (group 1), range 30, single-target, targets=Self/Party
                [Order(24)] TheBole = 37027, // L30, instant, 1.0s CD (group 2), range 30, single-target, targets=Self/Party
                [Order(25)] TheEwer = 37028, // L30, instant, 1.0s CD (group 3), range 30, single-target, targets=Self/Party
                [Order(26)] Oracle = 37029, // L92, instant, 1.0s CD (group 4), range 25, AOE 5 circle, targets=Hostile
                [Order(27)] SunSign = 37031, // L100, instant, 1.0s CD (group 7), range 0, AOE 30 circle, targets=Self
                [Order(28)] MinorArcana = 37022, // L70, instant, 1.0s CD (group 6), range 0, single-target, targets=Self
                [Order(29)] HealingWind = 206, // LB1, 2.0s cast, range 0, AOE 50 circle, targets=self, castAnimLock=2.100
                [Order(30)] BreathOfTheEarth = 207, // LB2, 2.0s cast, range 0, AOE 50 circle, targets=self, castAnimLock=5.130
                [Order(31)] AstralStasis = 4248, // LB3, 2.0s cast, range 0, AOE 50 circle, targets=Self, animLock=8.100s?
            }
            public enum PVP : uint
            {
                Malefic = 29242,
                AspectedBenefic = 29243,
                Gravity = 29244,
                DoubleCast = 29245,
                DoubleMalefic = 29246,
                NocturnalBenefic = 29247,
                DoubleGravity = 29248,
                Draw = 29249,
                Macrocosmos = 29253,
                Microcosmos = 29254,
                MinorArcana = 41503,
                Epicycle = 41506
            }
        }

        namespace BRD
        {
            public enum GCD : uint
            {
                HeavyShot = 97, // L1, instant, GCD, range 25, single-target, targets=Hostile
                StraightShot = 98, // L2, instant, GCD, range 25, single-target, targets=Hostile
                VenomousBite = 100, // L6, instant, GCD, range 25, single-target, targets=Hostile
                QuickNock = 106, // L18, instant, GCD, range 12, AOE 12+R ?-degree cone, targets=Hostile
                WideVolley = 36974, // L25, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                Windbite = 113, // L30, instant, GCD, range 25, single-target, targets=Hostile
                IronJaws = 3560, // L56, instant, GCD, range 25, single-target, targets=Hostile
                Stormbite = 7407, // L64, instant, GCD, range 25, single-target, targets=Hostile
                CausticBite = 7406, // L64, instant, GCD, range 25, single-target, targets=Hostile
                RefulgentArrow = 7409, // L70, instant, GCD, range 25, single-target, targets=Hostile
                Shadowbite = 16494, // L72, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                BurstShot = 16495, // L76, instant, GCD, range 25, single-target, targets=Hostile
                ApexArrow = 16496, // L80, instant, GCD, range 25, AOE 25+R width 4 rect, targets=Hostile
                Ladonsbite = 25783, // L82, instant, GCD, range 12, AOE 12+R ?-degree cone, targets=Hostile
                BlastArrow = 25784, // L86, instant, GCD, range 25, AOE 25+R width 4 rect, targets=Hostile
                ResonantArrow = 36976, // L96, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                RadiantEncore = 36977, // L100, instant, GCD, range 25, AOE 5 circle, targets=Hostile
            }
            public enum oGCD : uint
            {
                [Order(0)]  RagingStrikes = 101, // L4, instant, 120.0s CD (group 14), range 0, single-target, targets=Self
                [Order(1)]  Barrage = 107, // L38, instant, 120.0s CD (group 19), range 0, single-target, targets=Self
                [Order(2)]  Bloodletter = 110, // L12, instant, 15.0s CD (group 9/70) (2-3 charges), range 25, single-target, targets=Hostile
                [Order(3)]  RepellingShot = 112, // L15, instant, 30.0s CD (group 5), range 15, single-target, targets=Hostile, animLock=0.800s
                [Order(4)]  MagesBallad = 114, // L30, instant, 120.0s CD (group 15), range 0, single-target, targets=Self
                [Order(5)]  ArmysPaeon = 116, // L40, instant, 120.0s CD (group 16), range 0, single-target, targets=Self
                [Order(6)]  RainOfDeath = 117, // L45, instant, 15.0s CD (group 9/70) (2-3 charges), range 25, AOE 8 circle, targets=Hostile
                [Order(7)]  BattleVoice = 118, // L50, instant, 120.0s CD (group 18), range 0, AOE 30 circle, targets=Self
                [Order(8)]  EmpyrealArrow = 3558, // L54, instant, 15.0s CD (group 2), range 25, single-target, targets=Hostile
                [Order(9)]  WanderersMinuet = 3559, // L52, instant, 120.0s CD (group 17), range 0, single-target, targets=Self
                [Order(10)] WardensPaean = 3561, // L35, instant, 45.0s CD (group 10), range 30, single-target, targets=Self/Party
                [Order(11)] Sidewinder = 3562, // L60, instant, 60.0s CD (group 12), range 25, single-target, targets=Hostile
                [Order(13)] PitchPerfect = 7404, // L52, instant, 1.0s CD (group 0), range 25, AOE 5 circle, targets=Hostile
                [Order(14)] Troubadour = 7405, // L62, instant, 120.0s CD (group 20), range 0, AOE 30 circle, targets=Self
                [Order(15)] NaturesMinne = 7408, // L66, instant, 120.0s CD (group 21), range 0, AOE 30 circle, targets=Self
                [Order(16)] RadiantFinale = 25785, // L90, instant, 110.0s CD (group 13), range 0, AOE 30 circle, targets=Self
                [Order(17)] HeartbreakShot = 36975, // L92, instant, 15.0s CD (group 9/70) (3 charges), range 25, single-target, targets=Hostile
                [Order(18)] BigShot = 4238, // LB1, 2.0s cast, range 30, AOE 30+R width 4 rect, targets=hostile, castAnimLock=3.100
                [Order(19)] Desperado = 4239, // LB2, 3.0s cast, range 30, AOE 30+R width 5 rect, targets=hostile, castAnimLock=3.100
                [Order(20)] SagittariusArrow = 4244, // LB3, 4.5s cast, range 30, AOE 30+R width 8 rect, targets=Hostile, animLock=3.700s?
            }   
            public enum PVP : uint
            {
                PowerfulShot = 29391,
                ApexArrow = 29393,
                SilentNocturne = 29395,
                RepellingShot = 29399,
                WardensPaean = 29400,
                PitchPerfect = 29392,
                BlastArrow = 29394,
                HarmonicArrow = 41464,
                FinalFantasia = 29401
            }
        }     

        namespace DNC
        {
            public enum GCD : uint
            {
                Cascade = 15989, // L1, instant, GCD, range 25, single-target, targets=hostile
                Fountain = 15990, // L2, instant, GCD, range 25, single-target, targets=hostile
                SingleStandardFinish = 16191, // L15, instant, GCD, range 0, AOE 15 circle, targets=self
                DoubleStandardFinish = 16192, // L15, instant, GCD, range 0, AOE 15 circle, targets=self
                StandardFinish = 16003, // L15, instant, GCD, range 0, AOE 15 circle, targets=self
                Pirouette = 16002, // L15, instant, GCD, range 0, single-target, targets=self
                Jete = 16001, // L15, instant, GCD, range 0, single-target, targets=self
                Entrechat = 16000, // L15, instant, GCD, range 0, single-target, targets=self
                Emboite = 15999, // L15, instant, GCD, range 0, single-target, targets=self
                Windmill = 15993, // L15, instant, GCD, range 0, AOE 5 circle, targets=self
                StandardStep = 15997, // L15, instant, 30.0s CD (group 8/57), range 0, single-target, targets=self
                ReverseCascade = 15991, // L20, instant, GCD, range 25, single-target, targets=hostile
                Bladeshower = 15994, // L25, instant, GCD, range 0, AOE 5 circle, targets=self
                RisingWindmill = 15995, // L35, instant, GCD, range 0, AOE 5 circle, targets=self
                Fountainfall = 15992, // L40, instant, GCD, range 25, single-target, targets=hostile
                Bloodshower = 15996, // L45, instant, GCD, range 0, AOE 5 circle, targets=self
                TechnicalStep = 15998, // L70, instant, 120.0s CD (group 19/57), range 0, single-target, targets=self
                TechnicalFinish = 16004, // L70, instant, GCD, range 0, AOE 15 circle, targets=self
                SingleTechnicalFinish = 16193, // L70, instant, GCD, range 0, AOE 15 circle, targets=self
                DoubleTechnicalFinish = 16194, // L70, instant, GCD, range 0, AOE 15 circle, targets=self
                TripleTechnicalFinish = 16195, // L70, instant, GCD, range 0, AOE 15 circle, targets=self
                QuadrupleTechnicalFinish = 16196, // L70, instant, GCD, range 0, AOE 15 circle, targets=self
                SingleTechnicalFinish2 = 33215, // L70, instant, range 0, AOE 30 circle, targets=self, animLock=???
                DoubleTechnicalFinish2 = 33216, // L70, instant, range 0, AOE 30 circle, targets=self, animLock=???
                TripleTechnicalFinish2 = 33217, // L70, instant, range 0, AOE 30 circle, targets=self, animLock=???
                QuadrupleTechnicalFinish2 = 33218, // L70, instant, range 0, AOE 30 circle, targets=self, animLock=???
                Flourish = 16013, // L72, instant, 60.0s CD (group 10), range 0, single-target, targets=self
                SaberDance = 16005, // L76, instant, GCD, range 25, AOE 5 circle, targets=hostile
                Tillana = 25790, // L82, instant, GCD, range 0, AOE 15 circle, targets=self
                StarfallDance = 25792, // L90, instant, GCD, range 25, AOE 25+R width 4 rect, targets=hostile
                LastDance = 36983,
                FinishingMove = 36984,
                DanceOfTheDawn = 36985,
            }
            public enum oGCD : uint
            {
                [Order(0)]  FanDance = 16007, // L30, instant, 1.0s CD (group 1), range 25, single-target, targets=hostile
                [Order(1)]  Improvisation = 16014, // L80, instant, 120.0s CD (group 18), range 0, ???, targets=self
                [Order(2)]  EnAvant = 16010, // L50, instant, 30.0s CD (group 9/70), range 0, single-target, targets=self
                [Order(3)]  FanDanceII = 16008, // L50, instant, 1.0s CD (group 2), range 0, AOE 5 circle, targets=self
                [Order(4)]  CuringWaltz = 16015, // L52, instant, 60.0s CD (group 11), range 0, AOE 3 circle, targets=self
                [Order(5)]  ShieldSamba = 16012, // L56, instant, 120.0s CD (group 22), range 0, AOE 30 circle, targets=self
                [Order(6)]  ClosedPosition = 16006, // L60, instant, 30.0s CD (group 0), range 30, single-target, targets=party
                [Order(7)]  Devilment = 16011, // L62, instant, 120.0s CD (group 20), range 0, single-target, targets=self
                [Order(8)]  FanDanceIII = 16009, // L66, instant, 1.0s CD (group 3), range 25, AOE 5 circle, targets=hostile
                [Order(10)] Ending = 18073, // L60, instant, 1.0s CD (group 0), range 0, single-target, targets=self
                [Order(11)] ImprovisedFinish = 25789, // L80, instant, 1.5s CD (group 5), range 0, AOE 8 circle, targets=self
                [Order(12)] FanDanceIV = 25791, // L86, instant, 1.0s CD (group 4), range 15, AOE 15+R ?-degree cone, targets=hostile
                [Order(18)] BigShot = 4238, // LB1, 2.0s cast, range 30, AOE 30+R width 4 rect, targets=hostile, castAnimLock=3.100
                [Order(19)] Desperado = 4239, // LB2, 3.0s cast, range 30, AOE 30+R width 5 rect, targets=hostile, castAnimLock=3.100
                [Order(20)] CrimsonLotus = 17106, // LB3, 4.5s cast, range 30, AOE 30+R width 8 rect, targets=hostile, animLock=???, castAnimLock=3.700
            }    
            public enum PVP : uint
            {
                FountainCombo = 54,
                Cascade = 29416,
                Fountain = 29417,
                ReverseCascade = 29418,
                Fountainfall = 29419,
                SaberDance = 29420,
                StarfallDance = 29421,
                HoningDance = 29422,
                HoningOvation = 29470,
                FanDance = 29428,
                CuringWaltz = 29429,
                EnAvant = 29430,
                ClosedPosition = 29431,
                Contradance = 29432
            }
        }        
         
        namespace MCH
        {
            public enum GCD : uint
            {
                SplitShot = 2866, // L1, instant, GCD, range 25, single-target, targets=Hostile
                SlugShot = 2868, // L2, instant, GCD, range 25, single-target, targets=Hostile
                HotShot = 2872, // L4, instant, 40.0s CD (group 7/57), range 25, single-target, targets=Hostile
                SpreadShot = 2870, // L18, instant, GCD, range 12, AOE 12+R ?-degree cone, targets=Hostile
                CleanShot = 2873, // L26, instant, GCD, range 25, single-target, targets=Hostile
                HeatBlast = 7410, // L35, instant, GCD, range 25, single-target, targets=Hostile
                AutoCrossbow = 16497, // L52, instant, GCD, range 12, AOE 12+R ?-degree cone, targets=Hostile
                HeatedSplitShot = 7411, // L54, instant, GCD, range 25, single-target, targets=Hostile
                Drill = 16498, // L58, instant, 20.0s CD (group 4/57) (1-2 charges), range 25, single-target, targets=Hostile
                HeatedSlugShot = 7412, // L60, instant, GCD, range 25, single-target, targets=Hostile
                HeatedCleanShot = 7413, // L64, instant, GCD, range 25, single-target, targets=Hostile
                BlazingShot = 36978, // L68, instant, GCD, range 25, single-target, targets=Hostile
                Flamethrower = 7418, // L70, instant, 60.0s CD (group 12/57), range 0, single-target, targets=Self
                Bioblaster = 16499, // L72, instant, 20.0s CD (group 4/57) (1-2 charges), range 12, AOE 12+R ?-degree cone, targets=Hostile
                AirAnchor = 16500, // L76, instant, 40.0s CD (group 8/57), range 25, single-target, targets=Hostile
                Scattergun = 25786, // L82, instant, GCD, range 12, AOE 12+R ?-degree cone, targets=Hostile
                ChainSaw = 25788, // L90, instant, 60.0s CD (group 11/57), range 25, AOE 25+R width 4 rect, targets=Hostile
                Excavator = 36981, // L96, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                FullMetalField = 36982, // L100, instant, GCD, range 25, AOE 5 circle, targets=Hostile
            }
            public enum oGCD : uint
            {
                [Order(0)]  RookAutoturret = 2864, // L40, instant, 6.0s CD (group 2), range 0, single-target, targets=Self
                [Order(1)]  Reassemble = 2876, // L10, instant, 55.0s CD (group 17/72), range 0, single-target, targets=Self
                [Order(2)]  GaussRound = 2874, // L15, instant, 30.0s CD (group 14/70) (2-3 charges), range 25, single-target, targets=Hostile
                [Order(3)]  Wildfire = 2878, // L45, instant, 120.0s CD (group 19), range 25, single-target, targets=Hostile
                [Order(4)]  Dismantle = 2887, // L62, instant, 120.0s CD (group 18), range 25, single-target, targets=Hostile
                [Order(5)]  Ricochet = 2890, // L50, instant, 30.0s CD (group 15/71) (2-3 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(7)]  BarrelStabilizer = 7414, // L66, instant, 120.0s CD (group 20), range 0, single-target, targets=Self
                [Order(8)]  RookOverdrive = 7415, // L40, instant, 15.0s CD (group 3), range 25, single-target, targets=Self
                [Order(9)]  AutomatonQueen = 16501, // L80, instant, 6.0s CD (group 2), range 0, single-target, targets=Self
                [Order(10)] QueenOverdrive = 16502, // L80, instant, 15.0s CD (group 3), range 30, single-target, targets=Self
                [Order(11)] Detonator = 16766, // L45, instant, 1.0s CD (group 0), range 25, single-target, targets=Self
                [Order(12)] Tactician = 16889, // L56, instant, 120.0s CD (group 21), range 0, AOE 30 circle, targets=Self
                [Order(13)] Hypercharge = 17209, // L30, instant, 10.0s CD (group 1), range 0, single-target, targets=Self
                [Order(14)] DoubleCheck = 36979, // L92, instant, 30.0s CD (group 14/70) (3 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(15)] Checkmate = 36980, // L92, instant, 30.0s CD (group 15/71) (3 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(18)] BigShot = 4238, // LB1, 2.0s cast, range 30, AOE 30+R width 4 rect, targets=hostile, castAnimLock=3.100
                [Order(19)] Desperado = 4239, // LB2, 3.0s cast, range 30, AOE 30+R width 5 rect, targets=hostile, castAnimLock=3.100
                [Order(20)] SatelliteBeam = 4245, // LB3, 4.5s cast, range 30, AOE 30+R width 8 rect, targets=Hostile, animLock=3.700s?
            }   
            public enum PVP : uint
            {
                BlastCharge = 29402,
                BlazingShot = 41468,
                Scattergun = 29404,
                Drill = 29405,
                BioBlaster = 29406,
                AirAnchor = 29407,
                ChainSaw = 29408,
                Wildfire = 29409,
                BishopTurret = 29412,
                AetherMortar = 29413,
                Analysis = 29414,
                MarksmanSpite = 29415,
                FullMetalField = 41469
            }
        }  

        namespace BLM
        {
            public enum GCD : uint
            {
                Blizzard1 = 142, // L1, 2.5s cast, GCD, range 25, single-target, targets=Hostile
                Fire1 = 141, // L2, 2.5s cast, GCD, range 25, single-target, targets=Hostile
                Thunder1 = 144, // L6, instant, GCD, range 25, single-target, targets=Hostile
                Blizzard2 = 25793, // L12, 3.0s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Scathe = 156, // L15, instant, GCD, range 25, single-target, targets=Hostile
                Fire2 = 147, // L18, 3.0s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Thunder2 = 7447, // L26, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                UmbralSoul = 16506, // L35, instant, GCD, range 0, single-target, targets=Self
                Fire3 = 152, // L35, 3.5s cast, GCD, range 25, single-target, targets=Hostile
                Blizzard3 = 154, // L35, 3.5s cast, GCD, range 25, single-target, targets=Hostile
                Freeze = 159, // L40, 2.8s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Thunder3 = 153, // L45, instant, GCD, range 25, single-target, targets=Hostile
                Flare = 162, // L50, 4.0s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Blizzard4 = 3576, // L58, 2.5s cast, GCD, range 25, single-target, targets=Hostile
                Fire4 = 3577, // L60, 2.8s cast, GCD, range 25, single-target, targets=Hostile
                Thunder4 = 7420, // L64, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                Foul = 7422, // L70, 2.5s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Despair = 16505, // L72, 3.0s cast, GCD, range 25, single-target, targets=Hostile
                Xenoglossy = 16507, // L80, instant, GCD, range 25, single-target, targets=Hostile
                HighBlizzard2 = 25795, // L82, 3.0s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                HighFire2 = 25794, // L82, 3.0s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Paradox = 25797, // L90, instant, GCD, range 25, single-target, targets=Hostile
                HighThunder1 = 36986, // L92, instant, GCD, range 25, single-target, targets=Hostile, animLock=???
                HighThunder2 = 36987, // L92, instant, GCD, range 25, AOE 5 circle, targets=Hostile, animLock=???
                FlareStar = 36989, // L100, 3.0s cast, GCD, range 25, AOE 5 circle, targets=Hostile, animLock=???
            }
            public enum oGCD : uint
            {
                [Order(0)]  Transpose = 149, // L4, instant, 5.0s CD (group 1), range 0, single-target, targets=Self
                [Order(1)]  AetherialManipulation = 155, // L50, instant, 10.0s CD (group 2), range 25, single-target, targets=Party, animLock=0.800s?
                [Order(2)]  Manaward = 157, // L30, instant, 120.0s CD (group 21), range 0, single-target, targets=Self
                [Order(3)]  Manafont = 158, // L30, instant, 120.0s CD (group 23), range 0, single-target, targets=Self
                [Order(5)]  LeyLines = 3573, // L52, instant, 120.0s CD (group 19), range 0, ???, targets=Area
                [Order(6)]  BetweenTheLines = 7419, // L62, instant, 3.0s CD (group 0), range 25, ???, targets=Area, animLock=0.800
                [Order(7)]  Triplecast = 7421, // L66, instant, 60.0s CD (group 18/71) (2 charges), range 0, single-target, targets=Self
                [Order(8)]  Amplifier = 25796, // L86, instant, 120.0s CD (group 20), range 0, single-target, targets=Self
                [Order(9)]  Retrace = 36988, // L96, instant, 40.0s CD (group 8), range 0, ???, targets=Area, animLock=???
                [Order(21)] Addle = 7560, // L8 BLM/SMN/RDM/BLU, instant, 90.0s CD (group 46), range 25, single-target, targets=hostile
                [Order(22)] Skyshard = 203, // LB1, 2.0s cast, range 25, AOE 8 circle, targets=area, castAnimLock=3.100
                [Order(23)] Starstorm = 204, // LB2, 3.0s cast, range 25, AOE 10 circle, targets=area, castAnimLock=5.100
                [Order(24)]  Meteor = 205, // LB3, 4.5s cast, range 25, AOE 15 circle, targets=Area, animLock=8.100s?
            }    
            public enum PVP
            {
                Fire = 29649,
                Blizzard = 29653,
                Burst = 29657,
                Paradox = 29663,
                AetherialManipulation = 29660,
                Fire3 = 30896,
                Fire4 = 29650,
                Flare = 29651,
                Blizzard3 = 30897,
                Blizzard4 = 29654,
                Freeze = 29655,
                Lethargy = 41510,
                HighFire2 = 41473,
                HighBlizzard2 = 41474,
                ElementalWeave = 41475,
                FlareStar = 41480,
                FrostStar = 41481,
                SoulResonance = 29662,
                Xenoglossy = 29658
            }
        }        
          
        namespace PCT
        {
            public enum GCD : uint
            {
                FireInRed = 34650, // L1, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                AeroInGreen = 34651, // L5, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                WaterInBlue = 34652, // L15, 1.5s cast, GCD, range 25, single-target, targets=Hostile
                FireIIInRed = 34656, // L25, 1.5s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                CreatureMotif = 34689, // L30, 3.0s cast, GCD, range 0, single-target, targets=Self
                WingMotif = 34665, // L30, 3.0s cast, GCD, range 0, single-target, targets=Self
                PomMotif = 34664, // L30, 3.0s cast, GCD, range 0, single-target, targets=Self
                AeroIIInGreen = 34657, // L35, 1.5s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                WaterIIInBlue = 34658, // L45, 1.5s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                WeaponMotif = 34690, // L50, 3.0s cast, GCD, range 0, single-target, targets=Self
                HammerStamp = 34678, // L50, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                HammerMotif = 34668, // L50, 3.0s cast, GCD, range 0, single-target, targets=Self
                ThunderIIInMagenta = 34661, // L60, 2.3s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                StoneInYellow = 34654, // L60, 2.3s cast, GCD, range 25, single-target, targets=Hostile
                BlizzardIIInCyan = 34659, // L60, 2.3s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                ThunderInMagenta = 34655, // L60, 2.3s cast, GCD, range 25, single-target, targets=Hostile
                BlizzardInCyan = 34653, // L60, 2.3s cast, GCD, range 25, single-target, targets=Hostile
                StoneIIInYellow = 34660, // L60, 2.3s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                StarrySkyMotif = 34669, // L70, 3.0s cast, GCD, range 0, single-target, targets=Self
                LandscapeMotif = 34691, // L70, 3.0s cast, GCD, range 0, single-target, targets=Self
                HolyInWhite = 34662, // L80, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                HammerBrush = 34679, // L86, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                PolishingHammer = 34680, // L86, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                CometInBlack = 34663, // L90, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                RainbowDrip = 34688, // L92, 4.0s cast, GCD, range 25, AOE 25+R width 4 rect, targets=Hostile
                MawMotif = 34667, // L96, 3.0s cast, GCD, range 0, single-target, targets=Self
                ClawMotif = 34666, // L96, 3.0s cast, GCD, range 0, single-target, targets=Self
                StarPrism = 34681, // L100, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                StarPrism2 = 34682, // L100, instant, range 100, AOE 30 circle, targets=Hostile
            }
            public enum oGCD : uint
            {
                [Order(0)]  PomMuse = 34670, // L30, instant, 40.0s CD (group 18/70) (2-3 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(1)]  WingedMuse = 34671, // L30, instant, 40.0s CD (group 18/70) (2-3 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(2)]  ClawedMuse = 34672, // L96, instant, 40.0s CD (group 18/70) (2-3 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(3)]  FangedMuse = 34673, // L96, instant, 40.0s CD (group 18/70) (2-3 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(4)]  StrikingMuse = 34674, // L50, instant, 60.0s CD (group 19/71), range 0, single-target, targets=Self
                [Order(5)]  StarryMuse = 34675, // L70, instant, 120.0s CD (group 20), range 0, AOE 30 circle, targets=Area
                [Order(6)]  MogOfTheAges = 34676, // L30, instant, 30.0s CD (group 6), range 25, AOE 25+R width 4 rect, targets=Hostile
                [Order(7)]  RetributionOfTheMadeen = 34677, // L96, instant, 30.0s CD (group 6), range 25, AOE 25+R width 4 rect, targets=Hostile
                [Order(8)]  SubtractivePalette = 34683, // L60, instant, 1.0s CD (group 0), range 0, single-target, targets=Self
                [Order(9)]  Smudge = 34684, // L20, instant, 20.0s CD (group 5), range 0, single-target, targets=Self, animLock=0.800
                [Order(10)] TemperaCoat = 34685, // L10, instant, 120.0s CD (group 21), range 0, single-target, targets=Self
                [Order(11)] TemperaGrassa = 34686, // L88, instant, 1.0s CD (group 1), range 0, AOE 30 circle, targets=Self                
                [Order(13)] LivingMuse = 35347, // L30, instant, 40.0s CD (group 18/70) (2-3 charges), range 0, single-target, targets=Self
                [Order(14)] SteelMuse = 35348, // L50, instant, 60.0s CD (group 19/71), range 0, single-target, targets=Self
                [Order(15)] ScenicMuse = 35349, // L70, instant, 120.0s CD (group 20), range 0, single-target, targets=Self
                [Order(16)] Addle = 7560, // L8 BLM/SMN/RDM/BLU, instant, 90.0s CD (group 46), range 25, single-target, targets=hostile
                [Order(17)] Skyshard = 203, // LB1, 2.0s cast, range 25, AOE 8 circle, targets=area, castAnimLock=3.100
                [Order(18)] Starstorm = 204, // LB2, 3.0s cast, range 25, AOE 10 circle, targets=area, castAnimLock=5.100
                [Order(19)] ChromaticFantasy = 34867, // LB3, 4.5s cast, range 25, AOE 15 circle, targets=Area

            }   
            public enum PVP : uint
            {
                FireInRed = 39191,
                AeroInGreen = 39192,
                WaterInBlue = 39193,
                HolyInWhite = 39198,
                CreatureMotif = 39204,
                LivingMuse = 39209,
                TemperaCoat = 39211,
                SubtractivePalette = 39213,
                StarPrism = 39216,
                MogOfTheAges = 39782
            }
        }       
                           
        namespace RDM
        {
            public enum GCD : uint
            {
                Riposte = 7504, // L1, instant, GCD, range 3, single-target, targets=Hostile
                EnchantedRiposte = 7527, // L1, instant, GCD, range 3, single-target, targets=Hostile
                Jolt1 = 7503, // L2, 2.0s cast, GCD, range 25, single-target, targets=Hostile
                Verthunder1 = 7505, // L4, 5.0s cast, GCD, range 25, single-target, targets=Hostile
                Veraero1 = 7507, // L10, 5.0s cast, GCD, range 25, single-target, targets=Hostile
                Scatter = 7509, // L15, 5.0s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Verthunder2 = 16524, // L18, 2.0s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Veraero2 = 16525, // L22, 2.0s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Verfire = 7510, // L26, 2.0s cast, GCD, range 25, single-target, targets=Hostile
                Verstone = 7511, // L30, 2.0s cast, GCD, range 25, single-target, targets=Hostile
                Zwerchhau = 7512, // L35, instant, GCD, range 3, single-target, targets=Hostile
                EnchantedZwerchhau = 7528, // L35, instant, GCD, range 3, single-target, targets=Hostile
                EnchantedRedoublement = 7529, // L50, instant, GCD, range 3, single-target, targets=Hostile
                Redoublement = 7516, // L50, instant, GCD, range 3, single-target, targets=Hostile
                EnchantedMoulinetTrois = 37003, // L52, instant, GCD, range 8, AOE 8+R ?-degree cone, targets=Hostile, animLock=???
                EnchantedMoulinetDeux = 37002, // L52, instant, GCD, range 8, AOE 8+R ?-degree cone, targets=Hostile, animLock=???
                Moulinet = 7513, // L52, instant, GCD, range 8, AOE 8+R ?-degree cone, targets=Hostile
                EnchantedMoulinet = 7530, // L52, instant, GCD, range 8, AOE 8+R ?-degree cone, targets=Hostile
                Vercure = 7514, // L54, 2.0s cast, GCD, range 30, single-target, targets=Self/Party/Alliance/Friendly
                Jolt2 = 7524, // L62, 2.0s cast, GCD, range 25, single-target, targets=Hostile
                Verraise = 7523, // L64, 10.0s cast, GCD, range 30, single-target, targets=Party/Alliance/Friendly/Dead
                Impact = 16526, // L66, 5.0s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                Verflare = 7525, // L68, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                Verholy = 7526, // L70, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                Reprise = 16529, // L76, instant, GCD, range 3, single-target, targets=Hostile
                EnchantedReprise = 16528, // L76, instant, GCD, range 25, single-target, targets=Hostile
                Scorch = 16530, // L80, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                Verthunder3 = 25855, // L82, 5.0s cast, GCD, range 25, single-target, targets=Hostile
                Veraero3 = 25856, // L82, 5.0s cast, GCD, range 25, single-target, targets=Hostile
                Jolt3 = 37004, // L84, 2.0s cast, GCD, range 25, single-target, targets=Hostile, animLock=???
                Resolution = 25858, // L90, instant, GCD, range 25, AOE 25+R width 4 rect, targets=Hostile
                GrandImpact = 37006, // L96, instant, GCD, range 25, AOE 5 circle, targets=Hostile, animLock=???
            }
            public enum oGCD : uint
            {
                [Order(0)]  CorpsACorps = 7506, // L6, instant, 35.0s CD (group 10/70) (2 charges), range 25, single-target, targets=Hostile
                [Order(1)]  Displacement = 7515, // L40, instant, 35.0s CD (group 9/71) (2 charges), range 5, single-target, targets=Hostile, animLock=0.800s?
                [Order(2)]  Fleche = 7517, // L45, instant, 25.0s CD (group 4), range 25, single-target, targets=Hostile
                [Order(3)]  Acceleration = 7518, // L50, instant, 55.0s CD (group 19/72) (1-2 charges), range 0, single-target, targets=Self
                [Order(4)]  ContreSixte = 7519, // L56, instant, 45.0s CD (group 7), range 25, AOE 6 circle, targets=Hostile
                [Order(5)]  Embolden = 7520, // L58, instant, 120.0s CD (group 20), range 0, AOE 30 circle, targets=Self
                [Order(6)]  Manafication = 7521, // L60, instant, 120.0s CD (group 21), range 0, single-target, targets=Self
                [Order(8)]  Engagement = 16527, // L40, instant, 35.0s CD (group 9/71) (2 charges), range 3, single-target, targets=Hostile
                [Order(9)]  MagickBarrier = 25857, // L86, instant, 120.0s CD (group 18), range 0, AOE 30 circle, targets=Self
                [Order(10)] ViceOfThorns = 37005, // L92, instant, 1.0s CD (group 0), range 25, AOE 5 circle, targets=Hostile, animLock=???
                [Order(11)] Prefulgence = 37007, // L100, instant, 1.0s CD (group 1), range 25, AOE 5 circle, targets=Hostile, animLock=???
                [Order(12)] Addle = 7560, // L8 BLM/SMN/RDM/BLU, instant, 90.0s CD (group 46), range 25, single-target, targets=hostile
                [Order(13)] Skyshard = 203, // LB1, 2.0s cast, range 25, AOE 8 circle, targets=area, castAnimLock=3.100
                [Order(14)] Starstorm = 204, // LB2, 3.0s cast, range 25, AOE 10 circle, targets=area, castAnimLock=5.100
                [Order(15)] VermilionScourge = 7862, // LB3, 4.5s cast, range 25, AOE 15 circle, targets=Area, animLock=8.100s?
            }    
            public enum PVP : uint
            {
                EnchantedRiposte = 41488,
                Resolution = 41492,
                CorpsACorps = 29699,
                Displacement = 29700,
                EnchantedZwerchhau = 41489,
                EnchantedRedoublement = 41490,
                SouthernCross = 41498,
                Embolden = 41494,
                Forte = 41496,
                Scorch = 41491,
                GrandImpact = 41487,
                Jolt3 = 41486,
                ViceOfThorns = 41493,
                Prefulgence = 41495
            }
        }        
        
        namespace SMN
        {
            public enum GCD : uint
            {
                Ruin1 = 163, // L1, 1.5s cast, GCD (0 charges), range 25, single-target, targets=Hostile
                SummonCarbuncle = 25798, // L2, 1.5s cast, GCD (0 charges), range 0, single-target, targets=Self
                Physick = 16230, // L4, 1.5s cast, GCD (0 charges), range 30, single-target, targets=Self/Party/Alliance/Friendly
                SummonRuby = 25802, // L6, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                RubyRuin1 = 25808, // L6, 2.8s cast, GCD (0 charges), range 25, single-target, targets=Hostile
                Gemshine = 25883, // L6, 2.5s cast, GCD (0 charges), range 25, single-target, targets=Hostile
                SummonTopaz = 25803, // L15, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                TopazRuin1 = 25809, // L15, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                EmeraldRuin1 = 25810, // L22, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                SummonEmerald = 25804, // L22, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                Outburst = 16511, // L26, 1.5s cast, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                RubyOutburst = 25814, // L26, 2.8s cast, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                EmeraldOutburst = 25816, // L26, instant, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                PreciousBrilliance = 25884, // L26, 2.5s cast, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                TopazOutburst = 25815, // L26, instant, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                TopazRuin2 = 25812, // L30, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                EmeraldRuin2 = 25813, // L30, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                Ruin2 = 172, // L30, 1.5s cast, GCD (0 charges), range 25, single-target, targets=Hostile
                SummonIfrit1 = 25805, // L30, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                RubyRuin2 = 25811, // L30, 2.8s cast, GCD (0 charges), range 25, single-target, targets=Hostile
                SummonTitan1 = 25806, // L35, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                SummonGaruda1 = 25807, // L45, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                RubyRuin3 = 25817, // L54, 2.8s cast, GCD (0 charges), range 25, single-target, targets=Hostile
                Ruin3 = 3579, // L54, 1.5s cast, GCD (0 charges), range 25, single-target, targets=Hostile
                TopazRuin3 = 25818, // L54, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                EmeraldRuin3 = 25819, // L54, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                AstralImpulse = 25820, // L58, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                AstralFlare = 25821, // L58, instant, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                AstralFlow = 25822, // L60, instant, GCD (0 charges), range 0, single-target, targets=Self
                Ruin4 = 7426, // L62, instant, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                TopazRite = 25824, // L72, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                EmeraldRite = 25825, // L72, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                RubyRite = 25823, // L72, 2.8s cast, GCD (0 charges), range 25, single-target, targets=Hostile
                TriDisaster = 25826, // L74, 1.5s cast, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                RubyDisaster = 25827, // L74, 2.8s cast, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                TopazDisaster = 25828, // L74, instant, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                EmeraldDisaster = 25829, // L74, instant, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                BrandOfPurgatory = 16515, // L80, instant, GCD (0 charges), range 25, AOE 8 circle, targets=Hostile
                FountainOfFire = 16514, // L80, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                RubyCatastrophe = 25832, // L82, 2.8s cast, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                TopazCatastrophe = 25833, // L82, instant, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                EmeraldCatastrophe = 25834, // L82, instant, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                Slipstream = 25837, // L86, 3.0s cast, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile
                CrimsonCyclone = 25835, // L86, instant, GCD (0 charges), range 25, AOE 5 circle, targets=Hostile, animLock=0.750
                CrimsonStrike = 25885, // L86, instant, GCD (0 charges), range 3, AOE 5 circle, targets=Hostile
                SummonIfrit2 = 25838, // L90, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                SummonTitan2 = 25839, // L90, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                SummonGaruda2 = 25840, // L90, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                UmbralImpulse = 36994, // L100, instant, GCD (0 charges), range 25, single-target, targets=Hostile, animLock=???
                UmbralFlare = 36995, // L100, instant, GCD (0 charges), range 25, AOE 8 circle, targets=Hostile, animLock=???
            }
            public enum oGCD : uint
            {
                [Order(0)]  Fester = 181, // L10, instant, 1.0s CD (group 0) (0 charges), range 25, single-target, targets=Hostile
                [Order(1)]  Painflare = 3578, // L40, instant, 1.0s CD (group 1) (0 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(2)]  DreadwyrmTrance = 3581, // L58, instant, 60.0s CD (group 9/57) (0 charges), range 0, single-target, targets=Self
                [Order(3)]  Deathflare = 3582, // L60, instant, 20.0s CD (group 4) (0 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(4)]  SummonBahamut = 7427, // L70, instant, 60.0s CD (group 9/57) (0 charges), range 25, single-target, targets=Hostile
                [Order(5)]  EnkindleBahamut = 7429, // L70, instant, 20.0s CD (group 5) (0 charges), range 25, single-target, targets=Hostile
                [Order(6)]  EnergyDrain = 16508, // L10, instant, 60.0s CD (group 11) (0 charges), range 25, single-target, targets=Hostile
                [Order(7)]  EnergySiphon = 16510, // L52, instant, 60.0s CD (group 11) (0 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(8)]  EnkindlePhoenix = 16516, // L80, instant, 20.0s CD (group 5) (0 charges), range 25, single-target, targets=Hostile
                [Order(9)]  RadiantAegis = 25799, // L2, instant, 60.0s CD (group 20/70) (1-2 charges), range 0, single-target, targets=Self
                [Order(10)] Aethercharge = 25800, // L6, instant, 60.0s CD (group 9/57) (0 charges), range 0, single-target, targets=Self
                [Order(11)] SearingLight = 25801, // L66, instant, 120.0s CD (group 19) (0 charges), range 0, AOE 30 circle, targets=Self
                [Order(12)] Rekindle = 25830, // L80, instant, 20.0s CD (group 4) (0 charges), range 30, single-target, targets=Self/Party
                [Order(13)] SummonPhoenix = 25831, // L80, instant, 60.0s CD (group 9/57) (0 charges), range 25, single-target, targets=Hostile
                [Order(14)] MountainBuster = 25836, // L86, instant, 1.0s CD (group 2) (0 charges), range 25, AOE 5 circle, targets=Hostile
                [Order(15)] Necrotize = 36990, // L92, instant, 1.0s CD (group 0) (0 charges), range 25, single-target, targets=Hostile
                [Order(16)] SearingFlash = 36991, // L96, instant, 1.0s CD (group 3) (0 charges), range 25, AOE 5 circle, targets=Hostile, animLock=???
                [Order(17)] SummonSolarBahamut = 36992, // L100, instant, 60.0s CD (group 9/57) (0 charges), range 25, single-target, targets=Hostile, animLock=???
                [Order(18)] Sunflare = 36996, // L100, instant, 20.0s CD (group 4) (0 charges), range 25, AOE 5 circle, targets=Hostile, animLock=???
                [Order(19)] LuxSolaris = 36997, // L100, instant, 60.0s CD (group 12) (0 charges), range 0, AOE 15 circle, targets=Self, animLock=???
                [Order(20)] EnkindleSolarBahamut = 36998, // L100, instant, 20.0s CD (group 5) (0 charges), range 25, single-target, targets=Hostile, animLock=???
                [Order(21)] Addle = 7560, // L8 BLM/SMN/RDM/BLU, instant, 90.0s CD (group 46), range 25, single-target, targets=hostile
                [Order(22)] Skyshard = 203, // LB1, 2.0s cast, range 25, AOE 8 circle, targets=area, castAnimLock=3.100
                [Order(23)] Starstorm = 204, // LB2, 3.0s cast, range 25, AOE 10 circle, targets=area, castAnimLock=5.100
                [Order(24)] Teraflare = 4246, // LB3, 4.5s cast (0 charges), range 25, AOE 15 circle, targets=Area, animLock=8.100s?
            }   
            public enum PVP : uint
            {
                Ruin3 = 29664,
                AstralImpulse = 29665,
                FountainOfFire = 29666,
                CrimsonCyclone = 29667,
                CrimsonStrike = 29668,
                Slipstream = 29669,
                RadiantAegis = 29670,
                MountainBuster = 29671,
                Necrotize = 41483,
                DeathFlare = 41484,
                Megaflare = 29675,          // not used
                Wyrmwave = 29676,           // not used
                AkhMorn = 29677,            // not used
                EnkindlePhoenix = 29679,       
                ScarletFlame = 29681,       // not used
                Revelation = 29682,         // not used
                Ruin4 = 41482,
                BrandofPurgatory = 41485
            }
        }       
         
        namespace MNK
        {
            public enum GCD : uint
            {
                Bootshine = 53, // L1, instant, range 3, single-target 0/0, targets=hostile, animLock=???
                TrueStrike = 54, // L4, instant, range 3, single-target 0/0, targets=hostile, animLock=???
                SnapPunch = 56, // L6, instant, range 3, single-target 0/0, targets=hostile, animLock=???
                TwinSnakes = 61, // L18, instant, range 3, single-target 0/0, targets=hostile, animLock=0.600s
                ArmOfTheDestroyer = 62, // L26, instant, range 0, AOE circle 5/0, targets=self, animLock=???
                Demolish = 66, // L30, instant, range 3, single-target 0/0, targets=hostile, animLock=0.600s
                Rockbreaker = 70, // L30, instant, range 0, AOE circle 5/0, targets=self, animLock=???
                FourPointFury = 16473, // L45, instant, range 0, AOE circle 5/0, targets=self, animLock=???
                DragonKick = 74, // L50, instant, range 3, single-target 0/0, targets=hostile, animLock=0.600s
                FormShift = 4262, // L52, instant, range 0, single-target 0/0, targets=self, animLock=???
                TornadoKick = 3543, // L60, instant, range 3, AOE circle 5/0, targets=hostile, animLock=???
                FlintStrike = 25882, // L60, instant, range 0, AOE circle 5/0, targets=self, animLock=???
                CelestialRevolution = 25765, // L60, instant, range 3, single-target 0/0, targets=hostile, animLock=???
                MasterfulBlitz = 25764, // L60, instant, range 0, single-target 0/0, targets=self, animLock=???
                ElixirField = 3545, // L60, instant, range 0, AOE circle 5/0, targets=self, animLock=???
                SixSidedStar = 16476, // L80, instant, range 3, single-target 0/0, targets=hostile, animLock=0.600s
                ShadowOfTheDestroyer = 25767, // L82, instant, range 0, AOE circle 5/0, targets=self, animLock=???
                RisingPhoenix = 25768, // L86, instant, range 0, AOE circle 5/0, targets=self, animLock=0.600s
                PhantomRush = 25769, // L90, instant, range 3, AOE circle 5/0, targets=hostile, animLock=???
                LeapingOpo = 36945, // L92, instant, range 3, single-target 0/0, targets=hostile, animLock=0.600s
                RisingRaptor = 36946, // L92, instant, range 3, single-target 0/0, targets=hostile, animLock=0.600s
                PouncingCoeurl = 36947, // L92, instant, range 3, single-target 0/0, targets=hostile, animLock=0.600s
                ElixirBurst = 36948, // L92, instant, range 0, AOE circle 5/0, targets=self, animLock=0.600s
                WindsReply = 36949, // L96, instant, range 10, AOE rect 10/4, targets=hostile, animLock=0.600s
                FiresReply = 36950, // L100, instant, range 20, AOE circle 5/0, targets=hostile, animLock=0.600s
            }
            public enum oGCD : uint
            {
                [Order(1)]  SteelPeak = 25761, // L15, instant, 1.0s CD (group 0), range 3, single-target 0/0, targets=hostile, animLock=???
                [Order(2)]  Thunderclap = 25762, // L35, instant, 30.0s CD (group 14) (3 charges), range 20, single-target 0/0, targets=party/hostile, animLock=???
                [Order(3)]  HowlingFist = 25763, // L40, instant, 1.0s CD (group 2), range 10, AOE rect 10/2, targets=hostile, animLock=???
                [Order(4)]  Mantra = 65, // L42, instant, 90.0s CD (group 15), range 0, AOE circle 30/0, targets=self, animLock=0.600s
                [Order(5)]  PerfectBalance = 69, // L50, instant, 40.0s CD (group 13) (2 charges), range 0, single-target 0/0, targets=self, animLock=0.600s
                [Order(6)]  ForbiddenChakra = 3547, // L54, instant, 1.0s CD (group 0), range 3, single-target 0/0, targets=hostile, animLock=0.600s
                [Order(7)]  RiddleOfEarth = 7394, // L64, instant, 120.0s CD (group 20), range 0, single-target 0/0, targets=self, animLock=0.600s
                [Order(8)]  EarthsReply = 36944, // L64, instant, 1.0s CD (group 1), range 0, AOE circle 5/0, targets=self, animLock=0.600s
                [Order(9)]  RiddleOfFire = 7395, // L68, instant, 60.0s CD (group 11), range 0, single-target 0/0, targets=self, animLock=0.600s
                [Order(10)] Brotherhood = 7396, // L70, instant, 120.0s CD (group 19), range 0, AOE circle 30/0, targets=self, animLock=0.600s
                [Order(11)] RiddleOfWind = 25766, // L72, instant, 90.0s CD (group 16), range 0, single-target 0/0, targets=self, animLock=0.600s
                [Order(12)] Enlightenment = 16474, // L74, instant, 1.0s CD (group 2), range 10, AOE rect 10/4, targets=hostile, animLock=???
                [Order(13)] SteeledMeditation = 36940, // L15, instant, range 0, single-target 0/0, targets=self, animLock=???
                [Order(14)] ForbiddenMeditation = 36942, // L54, instant, range 0, single-target 0/0, targets=self, animLock=???
                [Order(15)] InspiritedMeditation = 36941, // L40, instant, range 0, single-target 0/0, targets=self, animLock=???
                [Order(16)] EnlightenedMeditation = 36943, // L74, instant, range 0, single-target 0/0, targets=self, animLock=???
                [Order(17)] Bloodbath = 7542, // L12, instant, 90.0s CD (group 46), range 0, single-target, targets=self
                [Order(18)] Feint = 7549, // L22, instant, 90.0s CD (group 47), range 10, single-target, targets=hostile
                [Order(19)] TrueNorth = 7546, // L50, instant, 45.0s CD (group 45/50) (2 charges), range 0, single-target, targets=self
                [Order(20)] Braver = 200, // LB1, 2.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(21)] Bladedance = 201, // LB2, 3.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(22)] FinalHeaven = 202, // LB3, 4.5s cast, range 8, single-target, targets=hostile, animLock=???, castAnimLock=3.700
            }   
            public enum PVP : uint
            {
                PhantomRushCombo = 55,
                DragonKick = 29475,
                TwinSnakes = 29476,
                Demolish = 29477,
                PhantomRush = 29478,
                RisingPhoenix = 29481,
                RiddleOfEarth = 29482,
                ThunderClap = 29484,
                EarthsReply = 29483,
                Meteordrive = 29485,
                WindsReply = 41509,
                FlintsReply = 41447,
                LeapingOpo = 41444,
                RisingRaptor = 41445,
                PouncingCoeurl = 41446
            }
        }       
        
        namespace SAM
        {
            public enum GCD : uint
            {
                Hakaze = 7477, // L1, instant, GCD, range 3, single-target, targets=Hostile
                Jinpu = 7478, // L4, instant, GCD, range 3, single-target, targets=Hostile
                Enpi = 7486, // L15, instant, GCD, range 20, single-target, targets=Hostile
                Shifu = 7479, // L18, instant, GCD, range 3, single-target, targets=Hostile
                Fuga = 7483, // L26, instant, GCD, range 8, AOE 8+R ?-degree cone, targets=Hostile
                Iaijutsu = 7867, // L30, 1.8s cast, GCD, range 0, single-target, targets=Self
                Gekko = 7481, // L30, instant, GCD, range 3, single-target, targets=Hostile
                Higanbana = 7489, // L30, 1.8s cast, GCD, range 6, single-target, targets=Hostile, animLock=0.100s?
                Mangetsu = 7484, // L35, instant, GCD, range 0, AOE 5 circle, targets=Self
                Kasha = 7482, // L40, instant, GCD, range 3, single-target, targets=Hostile
                TenkaGoken = 7488, // L40, 1.8s cast, GCD, range 0, AOE 8 circle, targets=Self
                Oka = 7485, // L45, instant, GCD, range 0, AOE 5 circle, targets=Self
                MidareSetsugekka = 7487, // L50, 1.8s cast, GCD, range 6, single-target, targets=Hostile
                Yukikaze = 7480, // L50, instant, GCD, range 3, single-target, targets=Hostile
                TsubameGaeshi = 16483, // L76, instant, GCD (1-2 charges), range 0, single-target, targets=Self
                KaeshiSetsugekka = 16486, // L76, instant, GCD (1-2 charges), range 6, single-target, targets=Hostile
                KaeshiGoken = 16485, // L76, instant, GCD (1-2 charges), range 0, AOE 8 circle, targets=Self
                Fuko = 25780, // L86, instant, GCD, range 0, AOE 5 circle, targets=Self
                OgiNamikiri = 25781, // L90, 1.8s cast, GCD, range 8, AOE 8+R ?-degree cone, targets=Hostile
                KaeshiNamikiri = 25782, // L90, instant, GCD, range 8, AOE 8+R ?-degree cone, targets=Hostile
                Gyofu = 36963, // L92, instant, GCD, range 3, single-target, targets=Hostile, animLock=???
                TendoGoken = 36965, // L100, 1.8s cast, GCD, range 0, AOE 8 circle, targets=Self, animLock=???
                TendoSetsugekka = 36966, // L100, 1.8s cast, GCD, range 6, single-target, targets=Hostile, animLock=???
                TendoKaeshiGoken = 36967, // L100, instant, GCD, range 0, AOE 8 circle, targets=Self, animLock=???
                TendoKaeshiSetsugekka = 36968, // L100, instant, GCD, range 6, single-target, targets=Hostile, animLock=???
            }
            public enum oGCD : uint
            {
                [Order(0)]  HissatsuShinten = 7490, // L52, instant, 1.0s CD (group 1), range 3, single-target, targets=Hostile
                [Order(1)]  HissatsuKyuten = 7491, // L62, instant, 1.0s CD (group 0), range 0, AOE 5 circle, targets=Self
                [Order(2)]  HissatsuGyoten = 7492, // L54, instant, 10.0s CD (group 4), range 20, single-target, targets=Hostile
                [Order(3)]  HissatsuYaten = 7493, // L56, instant, 10.0s CD (group 5), range 5, single-target, targets=Hostile, animLock=0.800
                [Order(4)]  Hagakure = 7495, // L68, instant, 5.0s CD (group 3), range 0, single-target, targets=Self
                [Order(5)]  Meditate = 7497, // L60, instant, 60.0s CD (group 12/57), range 0, single-target, targets=Self
                [Order(6)]  ThirdEye = 7498, // L6, instant, 15.0s CD (group 6), range 0, single-target, targets=Self
                [Order(7)]  MeikyoShisui = 7499, // L50, instant, 55.0s CD (group 18/70) (1-2 charges), range 0, single-target, targets=Self
                [Order(8)]  Ikishoten = 16482, // L68, instant, 120.0s CD (group 19), range 0, single-target, targets=Self
                [Order(9)]  HissatsuGuren = 7496, // L70, instant, 120.0s CD (group 21), range 10, AOE 10+R width 4 rect, targets=Hostile
                [Order(10)] HissatsuSenei = 16481, // L72, instant, 120.0s CD (group 21), range 3, single-target, targets=Hostile
                [Order(11)] Shoha = 16487, // L80, instant, 15.0s CD (group 7), range 10, AOE 10+R width 4 rect, targets=Hostile
                [Order(12)] Tengentsu = 36962, // L82, instant, 15.0s CD (group 6), range 0, single-target, targets=Self
                [Order(13)] Zanshin = 36964, // L96, instant, 1.0s CD (group 2), range 8, AOE 8+R ?-degree cone, targets=Hostile, animLock=???
                [Order(14)] Bloodbath = 7542, // L12, instant, 90.0s CD (group 46), range 0, single-target, targets=self
                [Order(15)] Feint = 7549, // L22, instant, 90.0s CD (group 47), range 10, single-target, targets=hostile
                [Order(16)] TrueNorth = 7546, // L50, instant, 45.0s CD (group 45/50) (2 charges), range 0, single-target, targets=self
                [Order(17)] Braver = 200, // LB1, 2.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(18)] Bladedance = 201, // LB2, 3.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(19)] DoomOfTheLiving = 7861, // LB3, 4.5s cast, range 8, single-target, targets=Hostile, animLock=3.700s?
            }    
            public enum PVP : uint
            {
                KashaCombo = 58,
                Yukikaze = 29523,
                Gekko = 29524,
                Kasha = 29525,
                Hyosetsu = 29526,
                Mangetsu = 29527,
                Oka = 29528,
                OgiNamikiri = 29530,
                Soten = 29532,
                Chiten = 29533,
                Mineuchi = 29535,
                MeikyoShisui = 29536,
                Midare = 29529,
                Kaeshi = 29531,
                Zantetsuken = 29537,
                TendoSetsugekka = 41454,
                TendoKaeshiSetsugekka = 41455,
                Zanshin = 41577
            }
        }        
        
        namespace NIN
        {
            public enum GCD : uint
            {
                SpinningEdge = 2240, // L1, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                GustSlash = 2242, // L4, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                ThrowingDagger = 2247, // L15, instant, GCD (0 charges), range 20, single-target, targets=Hostile
                AeolianEdge = 2255, // L26, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                Ninjutsu = 2260, // L30, instant, GCD (0 charges), range 0, single-target, targets=Self                
                RabbitMedium = 2272, // L30, instant, GCD (0 charges), range 0, single-target, targets=Self
                DeathBlossom = 2254, // L38, instant, GCD (0 charges), range 0, AOE 5 circle, targets=Self                
                HakkeMujinsatsu = 16488, // L52, instant, GCD (0 charges), range 0, AOE 5 circle, targets=Self
                ArmorCrush = 3563, // L54, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                PhantomKamaitachi = 25774, // L82, instant, GCD (0 charges), range 20, single-target, targets=Hostile
                FleetingRaiju = 25778, // L90, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                ForkedRaiju = 25777, // L90, instant, GCD (0 charges), range 20, single-target, targets=Hostile
            }
            public enum oGCD : uint
            {
                [Order(0)]  ShadeShift = 2241, // L2, instant, 120.0s CD (group 20) (0 charges), range 0, single-target, targets=Self
                [Order(1)]  Hide = 2245, // L10, instant, 20.0s CD (group 2) (0 charges), range 0, single-target, targets=Self
                [Order(2)]  Assassinate = 2246, // L40, instant, 60.0s CD (group 9) (0 charges), range 3, single-target, targets=Hostile
                [Order(3)]  Mug = 2248, // L15, instant, 120.0s CD (group 21) (0 charges), range 3, single-target, targets=Hostile
                [Order(4)]  TrickAttack = 2258, // L18, instant, 60.0s CD (group 8) (0 charges), range 3, single-target, targets=Hostile
                [Order(5)]  Ten1 = 2259, // L30, instant, 20.0s CD (group 3/57) (2 charges), range 0, single-target, targets=Self, animLock=0.350
                [Order(6)]  Chi1 = 2261, // L35, instant, 20.0s CD (group 3/57) (2 charges), range 0, single-target, targets=Self, animLock=0.350s?
                [Order(7)]  Jin1 = 2263, // L45, instant, 20.0s CD (group 3/57) (2 charges), range 0, single-target, targets=Self, animLock=0.350s?
                [Order(8)]  Shukuchi = 2262, // L40, instant, 60.0s CD (group 15/70), range 20, ???, targets=Area, animLock=0.800s?
                [Order(9)]  Kassatsu = 2264, // L50, instant, 60.0s CD (group 10) (0 charges), range 0, single-target, targets=Self
                [Order(10)] FumaShuriken = 2265, // L30, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                [Order(11)] Katon = 2266, // L35, instant, GCD (0 charges), range 20, AOE 5 circle, targets=Hostile
                [Order(12)] Raiton = 2267, // L35, instant, GCD (0 charges), range 20, single-target, targets=Hostile
                [Order(13)] Hyoton = 2268, // L45, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                [Order(14)] Huton = 2269, // L45, instant, GCD (0 charges), range 20, AOE 5 circle, targets=Hostile
                [Order(15)] Suiton = 2271, // L45, instant, GCD (0 charges), range 20, single-target, targets=Hostile
                [Order(16)] Doton = 2270, // L45, instant, GCD (0 charges), range 0, ???, targets=Self
                [Order(17)] DreamWithinADream = 3566, // L56, instant, 60.0s CD (group 11) (0 charges), range 3, single-target, targets=Hostile
                [Order(18)] HellfrogMedium = 7401, // L62, instant, 1.0s CD (group 0) (0 charges), range 25, AOE 6 circle, targets=Hostile
                [Order(19)] Bhavacakra = 7402, // L68, instant, 1.0s CD (group 0) (0 charges), range 3, single-target, targets=Hostile
                [Order(20)] TenChiJin = 7403, // L70, instant, 120.0s CD (group 19) (0 charges), range 0, single-target, targets=Self
                [Order(21)] GokaMekkyaku = 16491, // L76, instant, GCD (0 charges), range 20, AOE 5 circle, targets=Hostile
                [Order(22)] HyoshoRanryu = 16492, // L76, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                [Order(23)] Bunshin = 16493, // L80, instant, 90.0s CD (group 14) (0 charges), range 0, single-target, targets=Self
                [Order(24)] Meisui = 16489, // L72, instant, 120.0s CD (group 18) (0 charges), range 0, single-target, targets=Self
                [Order(25)] Ten2 = 18805, // L30, instant, GCD (0 charges), range 0, single-target, targets=Self, animLock=0.350
                [Order(26)] Chi2 = 18806, // L35, instant, GCD (0 charges), range 0, single-target, targets=Self, animLock=0.350
                [Order(27)] Jin2 = 18807, // L45, instant, GCD (0 charges), range 0, single-target, targets=Self, animLock=0.350
                [Order(28)] FumaTen = 18873, // L30, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                [Order(29)] FumaChi = 18874, // L30, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                [Order(30)] FumaJin = 18875, // L30, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                [Order(31)] TCJKaton = 18876, // L35, instant, GCD (0 charges), range 20, AOE 5 circle, targets=Hostile
                [Order(32)] TCJRaiton = 18877, // L35, instant, GCD (0 charges), range 20, single-target, targets=Hostile
                [Order(33)] TCJHyoton = 18878, // L45, instant, GCD (0 charges), range 25, single-target, targets=Hostile
                [Order(34)] TCJHuton = 18879, // L45, instant, GCD (0 charges), range 20, AOE 5 circle, targets=Hostile
                [Order(35)] TCJDoton = 18880, // L45, instant, GCD (0 charges), range 0, ???, targets=Self
                [Order(36)] TCJSuiton = 18881, // L45, instant, GCD (0 charges), range 20, single-target, targets=Hostile
                [Order(37)] HollowNozuchi = 25776, // L86, instant (0 charges), range 100, AOE 5 circle, targets=Self/Area
                [Order(38)] Dokumori = 36957, // L66, instant, 120.0s CD (group 21) (0 charges), range 3, single-target, targets=Hostile
                [Order(39)] KunaisBane = 36958, // L92, instant, 60.0s CD (group 8) (0 charges), range 3, AOE 5 circle, targets=Hostile
                [Order(40)] DeathfrogMedium = 36959, // L96, instant, 1.0s CD (group 0) (0 charges), range 25, AOE 6 circle, targets=Hostile
                [Order(41)] ZeshoMeppo = 36960, // L96, instant, 1.0s CD (group 0) (0 charges), range 3, single-target, targets=Hostile
                [Order(42)] TenriJindo = 36961, // L100, instant, 1.0s CD (group 1) (0 charges), range 20, AOE 5 circle, targets=Hostile
                [Order(43)] Bloodbath = 7542, // L12, instant, 90.0s CD (group 46), range 0, single-target, targets=self
                [Order(44)] Feint = 7549, // L22, instant, 90.0s CD (group 47), range 10, single-target, targets=hostile
                [Order(45)] TrueNorth = 7546, // L50, instant, 45.0s CD (group 45/50) (2 charges), range 0, single-target, targets=self
                [Order(46)] Braver = 200, // LB1, 2.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(47)] Bladedance = 201, // LB2, 3.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(48)] Chimatsuri = 4243, // LB3, 4.5s cast (0 charges), range 8, single-target, targets=Hostile, animLock=3.700s?
            }
            public enum PVP : uint
            {
                SpinningEdge = 29500,
                GustSlash = 29501,
                AeolianEdge = 29502,
                FumaShuriken = 29505,
                Dokumori = 41451,
                ThreeMudra = 29507,
                Bunshin = 29511,
                Shukuchi = 29513,
                SeitonTenchu = 29515,
                ForkedRaiju = 29510,
                FleetingRaiju = 29707,
                HyoshoRanryu = 29506,
                GokaMekkyaku = 29504,
                Meisui = 29508,
                Huton = 29512,
                Doton = 29514,
                Assassinate = 29503,
                ZeshoMeppo = 41452
            }
        }

        namespace VPR
        {
            public enum GCD : uint
            {
                SteelFangs = 34606, // L1, instant, GCD, range 3, single-target, targets=Hostile
                HuntersSting = 34608, // L5, instant, GCD, range 3, single-target, targets=Hostile
                ReavingFangs = 34607, // L10, instant, GCD, range 3, single-target, targets=Hostile
                WrithingSnap = 34632, // L15, instant, GCD, range 20, single-target, targets=Hostile
                SwiftskinsSting = 34609, // L20, instant, GCD, range 3, single-target, targets=Hostile
                SteelMaw = 34614, // L25, instant, GCD, range 0, AOE 5 circle, targets=Self
                FlankstingStrike = 34610, // L30, instant, GCD, range 3, single-target, targets=Hostile
                FlanksbaneFang = 34611, // L30, instant, GCD, range 3, single-target, targets=Hostile
                HindstingStrike = 34612, // L30, instant, GCD, range 3, single-target, targets=Hostile
                HindsbaneFang = 34613, // L30, instant, GCD, range 3, single-target, targets=Hostile
                ReavingMaw = 34615, // L35, instant, GCD, range 0, AOE 5 circle, targets=Self
                HuntersBite = 34616, // L40, instant, GCD, range 0, AOE 5 circle, targets=Self
                SwiftskinsBite = 34617, // L45, instant, GCD, range 0, AOE 5 circle, targets=Self
                JaggedMaw = 34618, // L50, instant, GCD, range 0, AOE 5 circle, targets=Self
                BloodiedMaw = 34619, // L50, instant, GCD, range 0, AOE 5 circle, targets=Self
                HuntersCoil = 34621, // L65, instant, GCD, range 3, single-target, targets=Hostile
                SwiftskinsCoil = 34622, // L65, instant, GCD, range 3, single-target, targets=Hostile
                Vicepit = 34623, // L70, instant, 40.0s CD (group 14/57) (2 charges), range 0, AOE 5 circle, targets=Self
                SwiftskinsDen = 34625, // L70, instant, GCD, range 0, AOE 5 circle, targets=Self
                HuntersDen = 34624, // L70, instant, GCD, range 0, AOE 5 circle, targets=Self
                UncoiledFury = 34633, // L82, instant, GCD, range 20, AOE 5 circle, targets=Hostile
                ThirdGeneration = 34629, // L90, instant, GCD, range 3, AOE 5 circle, targets=Hostile
                FourthGeneration = 34630, // L90, instant, GCD, range 3, AOE 5 circle, targets=Hostile
                SecondGeneration = 34628, // L90, instant, GCD, range 3, AOE 5 circle, targets=Hostile
                FirstGeneration = 34627, // L90, instant, GCD, range 3, AOE 5 circle, targets=Hostile
                Reawaken = 34626, // L90, instant, GCD, range 0, AOE 5 circle, targets=Self
                Ouroboros = 34631, // L96, instant, GCD, range 3, AOE 5 circle, targets=Hostile
            }
            public enum oGCD : uint
            {
                [Order(0)]  Vicewinder = 34620, // L65, instant, 40.0s CD (group 14/57) (2 charges), range 3, single-target, targets=Hostile
                [Order(1)]  DeathRattle = 34634, // L55, instant, 1.0s CD (group 0), range 5, single-target, targets=Hostile
                [Order(2)]  LastLash = 34635, // L60, instant, 1.0s CD (group 0), range 0, AOE 5 circle, targets=Self
                [Order(3)]  TwinfangBite = 34636, // L75, instant, 1.0s CD (group 1), range 5, single-target, targets=Hostile
                [Order(4)]  TwinbloodBite = 34637, // L75, instant, 1.0s CD (group 2), range 5, single-target, targets=Hostile
                [Order(5)]  TwinfangThresh = 34638, // L80, instant, 1.0s CD (group 1), range 0, AOE 5 circle, targets=Self
                [Order(6)]  TwinbloodThresh = 34639, // L80, instant, 1.0s CD (group 2), range 0, AOE 5 circle, targets=Self
                [Order(7)]  FirstLegacy = 34640, // L100, instant, 1.0s CD (group 0), range 5, AOE 5 circle, targets=Hostile
                [Order(8)]  SecondLegacy = 34641, // L100, instant, 1.0s CD (group 0), range 5, AOE 5 circle, targets=Hostile
                [Order(9)]  ThirdLegacy = 34642, // L100, instant, 1.0s CD (group 0), range 5, AOE 5 circle, targets=Hostile
                [Order(10)] FourthLegacy = 34643, // L100, instant, 1.0s CD (group 0), range 5, AOE 5 circle, targets=Hostile
                [Order(11)] UncoiledTwinfang = 34644, // L92, instant, 1.0s CD (group 1), range 20, AOE 5 circle, targets=Hostile
                [Order(12)] UncoiledTwinblood = 34645, // L92, instant, 1.0s CD (group 2), range 20, AOE 5 circle, targets=Hostile
                [Order(13)] Slither = 34646, // L40, instant, 30.0s CD (group 13/70) (2-3 charges), range 20, single-target, targets=Party/Hostile
                [Order(14)] SerpentsIre = 34647, // L86, instant, 120.0s CD (group 19), range 0, single-target, targets=Self
                [Order(15)] SerpentsTail = 35920, // L55, instant, 1.0s CD (group 0), range 0, single-target, targets=Self
                [Order(16)] Twinfang = 35921, // L75, instant, 1.0s CD (group 1), range 0, single-target, targets=Self
                [Order(17)] Twinblood = 35922, // L75, instant, 1.0s CD (group 2), range 0, single-target, targets=Self
                [Order(18)] Bloodbath = 7542, // L12, instant, 90.0s CD (group 46), range 0, single-target, targets=self
                [Order(19)] Feint = 7549, // L22, instant, 90.0s CD (group 47), range 10, single-target, targets=hostile
                [Order(20)] TrueNorth = 7546, // L50, instant, 45.0s CD (group 45/50) (2 charges), range 0, single-target, targets=self
                [Order(21)] Braver = 200, // LB1, 2.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(22)] Bladedance = 201, // LB2, 3.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(23)] WorldSwallower = 34866, // LB3, 4.5s cast, range 8, single-target, targets=Hostile
            }   
            public enum PVP : uint
            {
                SteelFangs = 39157,
                HuntersSting = 39159,
                BarbarousSlice = 39161,
                PiercingFangs = 39158,
                SwiftskinsSting = 39160,
                RavenousBite = 39163,
                SanguineFeast = 39167,
                Bloodcoil = 39166,
                UncoiledFury = 39168,
                SerpentsTail = 39183,
                FirstGeneration = 39169,
                SecondGeneration = 39170,
                ThirdGeneration = 39171,
                FourthGeneration = 39172,
                Ouroboros = 39173,
                DeathRattle = 39174,
                TwinfangBite = 39175,
                TwinbloodBite = 39176,
                UncoiledTwinfang = 39177,
                UncoiledTwinblood = 39178,
                FirstLegacy = 39179,
                SecondLegacy = 39180,
                ThirdLegacy = 39181,
                FourthLegacy = 39182,
                Slither = 39184,
                SnakeScales = 39185,
                Backlash = 39186,
                RattlingCoil = 39189
            }
        }

        namespace DRG
        {
            public enum GCD : uint
            {
                TrueThrust = 75, // L1, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                VorpalThrust = 78, // L4, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                PiercingTalon = 90, // L15, instant, GCD (0 charges), range 20, single-target, targets=Hostile
                Disembowel = 87, // L18, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                FullThrust = 84, // L26, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                DoomSpike = 86, // L40, instant, GCD (0 charges), range 10, AOE 10+R width 4 rect, targets=Hostile
                ChaosThrust = 88, // L50, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                FangAndClaw = 3554, // L56, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                WheelingThrust = 3556, // L58, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                SonicThrust = 7397, // L62, instant, GCD (0 charges), range 10, AOE 10+R width 4 rect, targets=Hostile
                Drakesbane = 36952, // L64, instant, GCD (0 charges), range 3, single-target, targets=Hostile, animLock=???
                CoerthanTorment = 16477, // L72, instant, GCD (0 charges), range 10, AOE 10+R width 4 rect, targets=Hostile
                RaidenThrust = 16479, // L76, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                DraconianFury = 25770, // L82, instant, GCD (0 charges), range 10, AOE 10+R width 4 rect, targets=Hostile
                ChaoticSpring = 25772, // L86, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                HeavensThrust = 25771, // L86, instant, GCD (0 charges), range 3, single-target, targets=Hostile
                LanceBarrage = 36954, // L96, instant, GCD (0 charges), range 3, single-target, targets=Hostile, animLock=???
                SpiralBlow = 36955, // L96, instant, GCD (0 charges), range 3, single-target, targets=Hostile, animLock=???
            }
            public enum oGCD : uint
            {
                [Order(0)]  LifeSurge = 83, // L6, instant, 40.0s CD (group 14/70) (1-2 charges), range 0, single-target, targets=Self
                [Order(1)]  LanceCharge = 85, // L30, instant, 60.0s CD (group 9) (0 charges), range 0, single-target, targets=Self
                [Order(2)]  Jump = 92, // L30, instant, 30.0s CD (group 7) (0 charges), range 20, single-target, targets=Hostile, animLock=0.800s?
                [Order(3)]  ElusiveJump = 94, // L35, instant, 30.0s CD (group 5) (0 charges), range 0, single-target, targets=Self, animLock=0.800s?
                [Order(4)]  DragonfireDive = 96, // L50, instant, 120.0s CD (group 20) (0 charges), range 20, AOE 5 circle, targets=Hostile, animLock=0.800s?
                [Order(5)]  Geirskogul = 3555, // L60, instant, 60.0s CD (group 10) (0 charges), range 15, AOE 15+R width 4 rect, targets=Hostile
                [Order(6)]  BattleLitany = 3557, // L52, instant, 120.0s CD (group 21) (0 charges), range 0, AOE 30 circle, targets=Self
                [Order(7)]  MirageDive = 7399, // L68, instant, 1.0s CD (group 0) (0 charges), range 20, single-target, targets=Hostile
                [Order(8)]  Nastrond = 7400, // L70, instant, 2.0s CD (group 3) (0 charges), range 15, AOE 15+R width 4 rect, targets=Hostile
                [Order(9)]  HighJump = 16478, // L74, instant, 30.0s CD (group 7) (0 charges), range 20, single-target, targets=Hostile, animLock=0.800s?
                [Order(10)] Stardiver = 16480, // L80, instant, 30.0s CD (group 6) (0 charges), range 20, AOE 5 circle, targets=Hostile, animLock=1.500s?
                [Order(11)] WyrmwindThrust = 25773, // L90, instant, 10.0s CD (group 4) (0 charges), range 15, AOE 15+R width 4 rect, targets=Hostile
                [Order(12)] WingedGlide = 36951, // L45, instant, 60.0s CD (group 19/71), range 20, single-target, targets=Hostile, animLock=???
                [Order(13)] RiseOfTheDragon = 36953, // L92, instant, 1.0s CD (group 1) (0 charges), range 20, AOE 5 circle, targets=Hostile, animLock=???
                [Order(14)] Starcross = 36956, // L100, instant, 1.0s CD (group 2) (0 charges), range 3, AOE 5 circle, targets=Hostile, animLock=???
                [Order(15)] Bloodbath = 7542, // L12, instant, 90.0s CD (group 46), range 0, single-target, targets=self
                [Order(16)] Feint = 7549, // L22, instant, 90.0s CD (group 47), range 10, single-target, targets=hostile
                [Order(17)] TrueNorth = 7546, // L50, instant, 45.0s CD (group 45/50) (2 charges), range 0, single-target, targets=self
                [Order(18)] Braver = 200, // LB1, 2.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(19)] Bladedance = 201, // LB2, 3.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(20)] DragonsongDive = 4242, // LB3, 4.5s cast (0 charges), range 8, single-target, targets=Hostile, animLock=3.700s?
            }   
            public enum PVP : uint
            {
                WheelingThrustCombo = 56,
                RaidenThrust = 29486,
                FangAndClaw = 29487,
                WheelingThrust = 29488,
                ChaoticSpring = 29490,
                Geirskogul = 29491,
                HighJump = 29493,
                ElusiveJump = 29494,
                WyrmwindThrust = 29495,
                HorridRoar = 29496,
                HeavensThrust = 29489,
                Nastrond = 29492,
                Purify = 29056,
                Guard = 29054,
                Drakesbane = 41449,
                Starcross = 41450
            }
        }       
                            
        namespace RPR
        {
            public enum GCD : uint
            {
                Slice = 24373, // L1, instant, GCD, range 3, single-target, targets=Hostile
                WaxingSlice = 24374, // L5, instant, GCD, range 3, single-target, targets=Hostile
                ShadowofDeath = 24378, // L10, instant, GCD, range 3, single-target, targets=Hostile
                Harpe = 24386, // L15, 1.3s cast, GCD, range 25, single-target, targets=Hostile
                SpinningScythe = 24376, // L25, instant, GCD, range 0, AOE 5 circle, targets=Self
                InfernalSlice = 24375, // L30, instant, GCD, range 3, single-target, targets=Hostile
                WhorlofDeath = 24379, // L35, instant, GCD, range 0, AOE 5 circle, targets=Self
                NightmareScythe = 24377, // L45, instant, GCD, range 0, AOE 5 circle, targets=Self
                Guillotine = 24384, // L70, instant, GCD, range 8, AOE 8+R ?-degree cone, targets=Hostile
                Gibbet = 24382, // L70, instant, GCD, range 3, single-target, targets=Hostile
                Gallows = 24383, // L70, instant, GCD, range 3, single-target, targets=Hostile
                GrimReaping = 24397, // L80, instant, GCD, range 8, AOE 8+R ?-degree cone, targets=Hostile
                CrossReaping = 24396, // L80, instant, GCD, range 3, single-target, targets=Hostile
                VoidReaping = 24395, // L80, instant, GCD, range 3, single-target, targets=Hostile
                SoulSow = 24387, // L82, 5.0s cast, GCD, range 0, single-target, targets=Self
                HarvestMoon = 24388, // L82, instant, GCD, range 25, AOE 5 circle, targets=Hostile
                PlentifulHarvest = 24385, // L88, instant, GCD, range 15, AOE 15+R width 4 rect, targets=Hostile
                Communio = 24398, // L90, 1.3s cast, GCD, range 25, AOE 5 circle, targets=Hostile
                ExecutionersGibbet = 36970, // L96, instant, GCD, range 3, single-target, targets=Hostile, animLock=???
                ExecutionersGallows = 36971, // L96, instant, GCD, range 3, single-target, targets=Hostile, animLock=???
                ExecutionersGuillotine = 36972, // L96, instant, GCD, range 8, AOE 8+R ?-degree cone, targets=Hostile, animLock=???
                Perfectio = 36973, // L100, instant, GCD, range 25, AOE 5 circle, targets=Hostile, animLock=???
            }
            public enum oGCD : uint
            {
                [Order(0)]  SoulSlice = 24380, // L60, instant, 30.0s CD (group 8/57) (1-2 charges), range 3, single-target, targets=Hostile
                [Order(1)]  SoulScythe = 24381, // L65, instant, 30.0s CD (group 8/57) (1-2 charges), range 0, AOE 5 circle, targets=Self
                [Order(2)]  BloodStalk = 24389, // L50, instant, 1.0s CD (group 0), range 3, single-target, targets=Hostile
                [Order(3)]  UnveiledGibbet = 24390, // L70, instant, 1.0s CD (group 0), range 3, single-target, targets=Hostile
                [Order(4)]  UnveiledGallows = 24391, // L70, instant, 1.0s CD (group 0), range 3, single-target, targets=Hostile
                [Order(5)]  GrimSwathe = 24392, // L55, instant, 1.0s CD (group 0), range 8, AOE 8+R ?-degree cone, targets=Hostile
                [Order(6)]  Gluttony = 24393, // L76, instant, 60.0s CD (group 12), range 25, AOE 5 circle, targets=Hostile
                [Order(7)]  Enshroud = 24394, // L80, instant, 15.0s CD (group 3), range 0, single-target, targets=Self
                [Order(8)]  LemuresSlice = 24399, // L86, instant, 1.0s CD (group 0), range 3, single-target, targets=Hostile
                [Order(9)]  LemuresScythe = 24400, // L86, instant, 1.0s CD (group 0), range 8, AOE 8+R ?-degree cone, targets=Hostile
                [Order(10)] HellsIngress = 24401, // L20, instant, 20.0s CD (group 4), range 0, single-target, targets=Self, animLock=0.800s?
                [Order(11)] HellsEgress = 24402, // L20, instant, 20.0s CD (group 4), range 0, single-target, targets=Self, animLock=0.800s?
                [Order(12)] ArcaneCrest = 24404, // L40, instant, 30.0s CD (group 6), range 0, single-target, targets=Self
                [Order(13)] ArcaneCircle = 24405, // L72, instant, 120.0s CD (group 21), range 0, AOE 30 circle, targets=Self
                [Order(14)] Regress = 24403, // L74, instant, 1.0s CD (group 1), range 30, ???, targets=Area, animLock=0.800s?
                [Order(15)] Sacrificium = 36969, // L92, instant, 1.0s CD (group 2), range 25, AOE 5 circle, targets=Hostile, animLock=???
                [Order(16)] Bloodbath = 7542, // L12, instant, 90.0s CD (group 46), range 0, single-target, targets=self
                [Order(17)] Feint = 7549, // L22, instant, 90.0s CD (group 47), range 10, single-target, targets=hostile
                [Order(18)] TrueNorth = 7546, // L50, instant, 45.0s CD (group 45/50) (2 charges), range 0, single-target, targets=self
                [Order(19)] Braver = 200, // LB1, 2.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(20)] Bladedance = 201, // LB2, 3.0s cast, range 8, single-target, targets=hostile, castAnimLock=3.860
                [Order(21)] TheEnd = 24858, // LB3, 4.5s cast, range 8, single-target, targets=Hostile, animLock=3.700s?
            }   
            public enum PVP : uint
            {
                Slice = 29538,
                WaxingSlice = 29539,
                InfernalSlice = 29540,
                HarvestMoon = 29545,
                PlentifulHarvest = 29546,
                GrimSwathe = 29547,
                LemuresSlice = 29548,
                DeathWarrant = 29549,
                ArcaneCrest = 29552,
                HellsIngress = 29550,
                Regress = 29551,
                Communio = 29554,
                TenebraeLemurum = 29553
            }
        }       
    }           
}
