//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using AutoMapper;
//using Ambev.DeveloperEvaluation.WebApi.Common;
//using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;
//// using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;
//// using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.DeleteSaleItem;
//using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;
//// using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
//// using Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;

//namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems;

///// <summary>
///// Controller for managing saleitem operations
///// </summary>
//[ApiController]
//[Route("api/[controller]")]
//public class SaleItemsController : BaseController
//{
//    private readonly IMediator _mediator;
//    private readonly IMapper _mapper;

//    /// <summary>
//    /// Initializes a new instance of SaleItemsController
//    /// </summary>
//    /// <param name="mediator">The mediator instance</param>
//    /// <param name="mapper">The AutoMapper instance</param>
//    public SaleItemsController(IMediator mediator, IMapper mapper)
//    {
//        _mediator = mediator;
//        _mapper = mapper;
//    }

//    /// <summary>
//    /// Creates a new saleitem
//    /// </summary>
//    /// <param name="request">The saleitem creation request</param>
//    /// <param name="cancellationToken">Cancellation token</param>
//    /// <returns>The created saleitem details</returns>
//    [HttpPost]
//    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleItemResponse>), StatusCodes.Status201Created)]
//    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//    public async Task<IActionResult> CreateSaleItem([FromBody] CreateSaleItemRequest request, CancellationToken cancellationToken)
//    {
//        var validator = new CreateSaleItemRequestValidator();
//        var validationResult = await validator.ValidateAsync(request, cancellationToken);

//        if (!validationResult.IsValid)
//            return BadRequest(validationResult.Errors);

//        var command = _mapper.Map<CreateSaleItemCommand>(request);
//        var response = await _mediator.Send(command, cancellationToken);

//        return Created(string.Empty, new ApiResponseWithData<CreateSaleItemResponse>
//        {
//            Success = true,
//            Message = "SaleItem created successfully",
//            Data = _mapper.Map<CreateSaleItemResponse>(response)
//        });
//    }
   
//    // [HttpGet("{id}")]
//    // [ProducesResponseType(typeof(ApiResponseWithData<GetSaleItemResponse>), StatusCodes.Status200OK)]
//    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//    // public async Task<IActionResult> GetSaleItem([FromRoute] Guid id, CancellationToken cancellationToken)
//    // {
//    //     var request = new GetSaleItemRequest { Id = id };
//    //     var validator = new GetSaleItemRequestValidator();
//    //     var validationResult = await validator.ValidateAsync(request, cancellationToken);

//    //     if (!validationResult.IsValid)
//    //         return BadRequest(validationResult.Errors);

//    //     var command = _mapper.Map<GetSaleItemCommand>(request.Id);
//    //     var response = await _mediator.Send(command, cancellationToken);

//    //     return Ok(new ApiResponseWithData<GetSaleItemResponse>
//    //     {
//    //         Success = true,
//    //         Message = "SaleItem retrieved successfully",
//    //         Data = _mapper.Map<GetSaleItemResponse>(response)
//    //     });
//    // }

//    // [HttpDelete("{id}")]
//    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
//    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//    // public async Task<IActionResult> DeleteSaleItem([FromRoute] Guid id, CancellationToken cancellationToken)
//    // {
//    //     var request = new DeleteSaleItemRequest { Id = id };
//    //     var validator = new DeleteSaleItemRequestValidator();
//    //     var validationResult = await validator.ValidateAsync(request, cancellationToken);

//    //     if (!validationResult.IsValid)
//    //         return BadRequest(validationResult.Errors);

//    //     var command = _mapper.Map<DeleteSaleItemCommand>(request.Id);
//    //     await _mediator.Send(command, cancellationToken);

//    //     return Ok(new ApiResponse
//    //     {
//    //         Success = true,
//    //         Message = "SaleItem deleted successfully"
//    //     });
//    // }
//}
