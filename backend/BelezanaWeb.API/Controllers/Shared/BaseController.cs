using AutoMapper;
using BelezanaWeb.Product.Contracts.Services.Shared;
using BelezanaWeb.Product.Contracts.Shared;
using BelezanaWeb.SystemObjects.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Controllers.Shared
{
    public abstract class BaseController<TEntity, TInputViewModel, TOutputViewModel> : Controller where TEntity : IEntity
    {
        private readonly IMapper _mapper;
        private readonly IGenericEntityService<TEntity> _service;

        public BaseController(IGenericEntityService<TEntity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All entities
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerOperation(OperationId = "{entity}GetAll")]
        public IActionResult GetAll([FromQuery] int skip, [FromQuery] int take)
        {
            take = (take <= 0) ? 50 : take;

            IEnumerable<TEntity> entity = _service.FindAll(skip, take);

            IEnumerable<TOutputViewModel> entityView = _mapper.Map<IEnumerable<TOutputViewModel>>(entity);

            return Ok(new SuccessResponseViewModel<IEnumerable<TOutputViewModel>>(entityView));
        }

        /// <summary>
        /// Get one entity
        /// </summary>
        /// <param name="id">entity identifier</param>
        /// <returns>The entity record</returns>
        [HttpGet, Route("{id}")]
        [SwaggerOperation(OperationId = "{entity}GetById")]
        public IActionResult Get(string id)
        {
            TEntity entity = _service.GetOneAsync(id);

            TOutputViewModel entityView = _mapper.Map<TOutputViewModel>(entity);

            return Ok(new SuccessResponseViewModel<TOutputViewModel>(entityView));
        }

        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <param name="model">TEntity item</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] TInputViewModel model, CancellationToken cancellationToken)
        {
            await _service.CreateAsync(_mapper.Map<TEntity>(model), cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Update a entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <param name="model">New data</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] TInputViewModel model, CancellationToken cancellationToken)
        {
            await _service.UpdateAsync(id, _mapper.Map<TEntity>(model), cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <param name="id">entity key</param>
        /// <param name="cancellationToken"></param>
        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
