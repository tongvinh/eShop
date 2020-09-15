using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Languages;

namespace eShopSolution.Application.System.Languages
{
    public interface ILanguageServices
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();
    }
}