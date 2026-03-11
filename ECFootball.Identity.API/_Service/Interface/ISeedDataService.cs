namespace ECFootball.Identity.API._Service.Interface
{
    public interface ISeedDataService
    {
        Task SeedRolesAsync();
        Task SeedAdminUserAsync();
    }
}
