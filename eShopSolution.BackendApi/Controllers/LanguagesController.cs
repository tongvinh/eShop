using System.Threading.Tasks;
using eShopSolution.Application.System.Languages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route(("api/[controller]"))]
    [ApiController]
    [Authorize]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageServices _languageService;

        public LanguagesController(ILanguageServices languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var languages = await _languageService.GetAll();
            return Ok(languages);
        }
    }
}