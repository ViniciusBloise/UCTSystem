using System;
namespace UCTS.Entities
{
    public interface IAssignedTravel
    {
        ICar Car { get; set; }
        ITravel Travel { get; set; }
        DateTime AssignedDate { get; set; }
        AssignedTravelStatus Status { get; set; }

    }
    public enum AssignedTravelStatus
    {
        Running,
        Finished,
        Waiting
    }
}
