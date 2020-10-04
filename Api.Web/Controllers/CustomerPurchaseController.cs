using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Services.Services;
using Api.Web.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers
{
    [Authorize]
    [Route("api/v1/customer-purchases")]
    [Produces("application/json")]
    [ApiController]
    public class CustomerPurchaseController : ControllerBase
    {
        private readonly ICustomerPurchaseManager _customerPurchaseManager;
        private readonly ICustomerPurchaseRepository _customerPurchaseRepository;

        public CustomerPurchaseController(ICustomerPurchaseManager customerPurchaseManager, ICustomerPurchaseRepository customerPurchaseRepository)
            => (_customerPurchaseManager, _customerPurchaseRepository) = (customerPurchaseManager, customerPurchaseRepository);

        #region snippet_GetAll

        [HttpGet]
        [ProducesResponseType(typeof(CustomerPurchase), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var purchases = await _customerPurchaseRepository.GetAllAsync();
            return Ok(new { Status = true, Data = purchases });
        }

        #endregion

        #region snippet_GetById

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerPurchase), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [CustomerPurchaseExists]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var purchase = await _customerPurchaseRepository.GetByIdAsync(id);
            return Ok(new { Status = true, Data = purchase});
        }

        #endregion

        #region snippet_Create

        [HttpPost]
        [ProducesResponseType(typeof(CustomerPurchase), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CustomerPurchase customerPurchase)
        {
            await _customerPurchaseManager.CreateAsync(customerPurchase);
            return Created("", new { Status = true, Data = customerPurchase});
        }

        #endregion
    }
}