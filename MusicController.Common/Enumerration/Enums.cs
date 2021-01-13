namespace MusicController.Common.Enumerration
{
    public enum Schedule
    {
        Daily = 1,
        AlternativeDay = 2,
        Weekly = 3,
        Monthly = 4,
        Yearly = 5

    }
    public enum StatusApiEnum
    {
        Success = 200,
        Unauthorized=401,
        Empty = 201,
        Error = 203,
        Duplicate = 204,
        InvalidCredentials = 205,
        NoActiveEmailExists = 206,
        EmailSent = 207,
        AccountBlocked = 208,
        InvalidUserName = 209,
        InvalidPassworde = 210,
        UserNameAlreadyExists = 211,
        UserEmailAlreadyExists = 212,
        UserEIDAlreadyExists = 213,
        UserMobileAlreadyExists = 214,
        Failure = 215,
        AccountIsInactive = 216,
        UnAuthorizedRequest = 217,
        TokenExpired = 220,
        ContentInUse = 221,
        RecordNotExist = 222,
        ServerError = 500,
    }
}
