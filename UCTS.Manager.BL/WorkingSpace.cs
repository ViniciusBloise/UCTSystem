using System;

namespace UCTS.Manager.BL
{
    public sealed class WorkingSpace
    {
        static readonly Lazy<WorkingSpace> lazy = new Lazy<WorkingSpace>(() => new WorkingSpace());
        private WorkingSpace() { }

        public static WorkingSpace Instance => lazy.Value;
    }
}
