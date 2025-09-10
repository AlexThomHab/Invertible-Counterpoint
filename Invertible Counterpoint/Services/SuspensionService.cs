using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invertible_Counterpoint.Models;
using Invertible_Counterpoint.Utility;

namespace Invertible_Counterpoint.Services
{
    public static class SuspensionService
    {
        public static Interval CombineTwoIntervals(Interval jv0Interval, Interval shiftedIntervalToCompare, int jvIndex,
            int i, bool jvIsNegative)
        {
            if (int.Abs(jvIndex + i) > 7 && shiftedIntervalToCompare.Name == "Second" && jvIsNegative is false)
            {
                shiftedIntervalToCompare.UpperSuspensionTreatmentEnum =
                    SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension;
            }
            if (int.Abs(jvIndex + i) > 7 && shiftedIntervalToCompare.Name == "Second" && jvIsNegative is true)
            {
                shiftedIntervalToCompare.LowerSuspensionTreatmentEnum =
                    SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension;
            }

            jv0Interval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(
                jv0Interval.UpperSuspensionTreatmentEnum, shiftedIntervalToCompare.UpperSuspensionTreatmentEnum);
            jv0Interval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(
                jv0Interval.LowerSuspensionTreatmentEnum, shiftedIntervalToCompare.LowerSuspensionTreatmentEnum);

            return jv0Interval;
        }

        private static int Rank(SuspensionTreatmentEnum x) => x switch
        {
            SuspensionTreatmentEnum.CannotFormSuspension => 0, // strictest
            SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant => 1,
            SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension => 2,
            SuspensionTreatmentEnum.NoteOfResolutionIsDissonant => 3,
            SuspensionTreatmentEnum.NoteOfResolutionIsFree => 4, // softest
            _ => 4
        };

        public static SuspensionTreatmentEnum StrictMost(
            SuspensionTreatmentEnum a,
            SuspensionTreatmentEnum b)
        {
            if (a == b) return a;

            if (a == SuspensionTreatmentEnum.CannotFormSuspension ||
                b == SuspensionTreatmentEnum.CannotFormSuspension)
                return SuspensionTreatmentEnum.CannotFormSuspension;

            if (a == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant ||
                b == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant)
                return SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant;

            bool hasMust = a == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension
                           || b == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension;
            bool hasX = a == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant
                        || b == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant;

            if (hasMust && hasX)
                return SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant;

            return (Rank(a) <= Rank(b)) ? a : b;
        }

        public static SuspensionTreatmentEnum StrictMost(params SuspensionTreatmentEnum[] values) =>
            values.Aggregate(SuspensionTreatmentEnum.NoteOfResolutionIsFree, StrictMost);

        private static Interval CopyInterval(Interval sourceInterval) =>
            new Interval(sourceInterval.Number, sourceInterval.Name, sourceInterval.IsConsonant,
                sourceInterval.UpperSuspensionTreatmentEnum, sourceInterval.LowerSuspensionTreatmentEnum);
        private static SuspensionTreatmentEnum StrictMostSuspensionTreatmentEnum(
            SuspensionTreatmentEnum originalIntervalSuspension,
            SuspensionTreatmentEnum newIntervalSuspension)
        {
            var validTreatments = new[]
            {
                SuspensionTreatmentEnum.CannotFormSuspension,
                SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension,
                SuspensionTreatmentEnum.NoteOfResolutionIsDissonant,
                SuspensionTreatmentEnum.NoteOfResolutionIsFree
            };
            if (originalIntervalSuspension == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension &&
                newIntervalSuspension == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant
                || originalIntervalSuspension == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant &&
                newIntervalSuspension == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension)
            {
                return SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant;
            }

            return (SuspensionTreatmentEnum)Math.Min((int)originalIntervalSuspension, (int)newIntervalSuspension);
        }

    }
}
