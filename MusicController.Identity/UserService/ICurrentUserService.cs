namespace MusicController.Identity.UserService
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string UserRole { get; }
    }
}
