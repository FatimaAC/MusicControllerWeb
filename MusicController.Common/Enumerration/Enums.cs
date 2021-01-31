namespace MusicController.Common.Enumerration
{
    public enum Schedule
    {
        Daily = 1,
        AlternativeDay = 2,
        Weekly = 3,
        Yearly = 4
    }
    public enum StatusApiEnum
    {
        InternalServerError = -1,
        Success = 0,
        Failure = 1,
        NotRegister = 2,
        RequriedApproval = 3,
        AlreadyAssignedDevice = 4,
        Empty = 5
    }
}
