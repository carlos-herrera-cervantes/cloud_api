using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Repository.Repositories;
using MongoDB.Driver;

namespace Api.Services.Services
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly IRepository<PaymentMethod> _paymentMethodRepository;

        public PaymentMethodRepository(IRepository<PaymentMethod> paymentMethodRepository) => _paymentMethodRepository = paymentMethodRepository;

        public async Task<IEnumerable<PaymentMethod>> GetAllAsync() => await _paymentMethodRepository.GetAllAsync();

        public async Task<PaymentMethod> GetByIdAsync(string id) => await _paymentMethodRepository.GetByIdAsync(id);

        public async Task<PaymentMethod> GetOneAsync(Request request) => await _paymentMethodRepository.GetOneAsync(request);
    }
}