using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        //private readonly DefaultContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        // public CreateProductHandler(DefaultContext context,IProductRepository productRepository, IMapper mapper)
        // {            
        //     _context = context;
        //     _productRepository = productRepository;
        //     _mapper = mapper;
        // }

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {            
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingProduct = await _productRepository.GetByIdAsync(command.Id, cancellationToken);
            if (existingProduct != null)
                throw new InvalidOperationException($"Product with ID {command.Id} already exists");

            var Product = _mapper.Map<Product>(command);

            var createdProduct = await _productRepository.CreateAsync(Product, cancellationToken);
            var result = _mapper.Map<CreateProductResult>(createdProduct);
            return result;

        }
    }
}
