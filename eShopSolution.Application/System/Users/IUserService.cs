using eShopSolution.ViewModels.System.Users;
using System.Threading.Tasks;
using eShopSolution.ViewModels.Common;

namespace eShopSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);

        Task<PagedResult<UserVm>> GetUsersPaging(GetUserPagingRequest request);
    }
}