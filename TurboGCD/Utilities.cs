using Dalamud.Interface.Textures;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Reflection;

namespace TurboGCD
{
    public static class Utilities
    {
        public static ISharedImmediateTexture GetIcon(uint iconId)
        {
            try
            {
                return Services.Textures.GetFromGameIcon(new GameIconLookup(iconId));
            }
            catch (System.Exception e)
            {
                Services.Log.Fatal($"{e.Message}\n{e.StackTrace}");
                return null;
            }
        }

        public static ISharedImmediateTexture GetJobIcon(JobID jobId)
        {
            var iconID = 62100u + (uint)jobId;

            // Outside of bounds, either DoL, DoH, or we messed up.
            if (iconID < 62101u || iconID > 62142u)
                iconID = 62145u;
            // Adventurer
            if (jobId == 0u)
                iconID = 62146u;
            return GetIcon(iconID);
        }
        public static ISharedImmediateTexture GetJobIconSimple(JobID jobId)
        {
            var iconID = 62000 + (uint)jobId;

            // Outside of bounds, either DoL, DoH, or we messed up.
            if (iconID < 62001u || iconID > 62042u)
                iconID = 62045u;
            // Adventurer
            if (jobId == 0u)
                iconID = 62046u;
            return GetIcon(iconID);
        }

        //This will check if its a class (so gladiator, marauder and stuff) and return it as Job (paladin, warrior)
        public static JobID SanitizeJob(JobID jobID)
        {
            uint value = (uint)jobID;
            if (value == 0 || value > 9)
                return jobID;
            return (JobID)(value + 18u);
        }

        public static ISharedImmediateTexture GetRoleIcon(JobID jobId)
        {
            jobId = SanitizeJob(jobId);
            uint iconId = 0;
            switch (jobId)
            {
                case JobID.PLD: //PLD
                case JobID.WAR: //WAR                                                  
                case JobID.DRK: //DRK                                                  
                case JobID.GNB: //GNB                                                  
                    iconId = 62581;
                    break;

                case JobID.WHM: //WHM                                                  
                case JobID.SCH: //SCH                                                  
                case JobID.AST: //AST                                                  
                case JobID.SGE: //SGE
                    iconId = 62582;
                    break;

                case JobID.MNK: //MNK                                                  
                case JobID.DRG: //DRG                                                  
                case JobID.NIN: //NIN                                                  
                case JobID.SAM: //SAM                                                  
                case JobID.RPR:
                case JobID.VPR: //VPR
                    iconId = 62584;
                    break;

                case JobID.BRD: //BRD                                                  
                case JobID.MCH: //MCH                                                  
                case JobID.DNC: //DNC                                                  
                    iconId = 62586;
                    break;

                case JobID.BLM: //BLM                                                  
                case JobID.SMN: //ARC                                                  
                case JobID.RDM: //RDM                                                  
                case JobID.PCT: //PCT                                                  
                    iconId = 62587;
                    break;
                default:
                    iconId = 62576;
                    break;
            }
            return GetIcon(iconId);
        }


        public static T[] OrderedByDeclarationEnum<T>() where T : Enum//
        {
            var enumType = typeof(T);
            var values = Enum.GetValues(enumType).Cast<T>().ToArray();
            var names = Enum.GetNames(enumType);
            var oderType = typeof(OrderAttribute);
            int[] enumPositions = Array.ConvertAll(names, n =>
            {
                try
                {
                    var att = (OrderAttribute)enumType.GetField(n)?.GetCustomAttributes(oderType, false)?[0];
                    return att?.Order ?? 0;
                }
                catch(Exception ex)
                {
                    Services.PrintInfo($"Error for enum {enumType.Name} with value {n}");
                }
                return 0;
            });
            Array.Sort(enumPositions, values);
            return values;
        }
    }

    public sealed class OrderAttribute : Attribute
    {
        public readonly int Order;
        public OrderAttribute(int order)
        {
            Order = order;
        }
    }
}

public sealed class ContractResolverWithPrivates : CamelCasePropertyNamesContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var prop = base.CreateProperty(member, memberSerialization);

        if (!prop.Writable)
        {
            var property = member as System.Reflection.PropertyInfo;
            if (property != null)
            {
                var hasPrivateSetter = property.GetSetMethod(true) != null;
                prop.Writable = hasPrivateSetter;
            }
        }
        return prop;
    }
}
