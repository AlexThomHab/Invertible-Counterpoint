using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invertible_Counterpoint.Utility;

namespace Invertible_Counterpoint.Services
{
    public static class SuspensionMerge
    {
        // Adjust ranks here if you want a different strictness ordering.
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

            // If either forbids suspensions entirely, that's the winner.
            if (a == SuspensionTreatmentEnum.CannotFormSuspension ||
                b == SuspensionTreatmentEnum.CannotFormSuspension)
                return SuspensionTreatmentEnum.CannotFormSuspension;

            // If either is already the combined "Must + X", keep it.
            if (a == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant ||
                b == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant)
                return SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant;

            // Merge "Must" with "ResolutionIsDissonant" into the combined stricter form.
            bool hasMust = a == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension
                           || b == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension;
            bool hasX = a == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant
                        || b == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant;

            if (hasMust && hasX)
                return SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant;

            // Otherwise pick the stricter by rank.
            return (Rank(a) <= Rank(b)) ? a : b;
        }

        // Convenience: merge 3+ values.
        public static SuspensionTreatmentEnum StrictMost(params SuspensionTreatmentEnum[] values) =>
            values.Aggregate(SuspensionTreatmentEnum.NoteOfResolutionIsFree, StrictMost);
    }

}
