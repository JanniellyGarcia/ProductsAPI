using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Domain.DataTransferObject;
using ProductsAPI.Domain.Models;
using ProductsAPI.Service.Interfaces;
using Swashbuckle.Swagger.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Description;

namespace ProductsAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productService;
        public ProductController(IProductRepository productRepository)
        {
            _productService = productRepository;
        }

        /// <summary>
        ///     Retorna uma lista de todos os produtos armazenados.
        /// </summary>
        /// <response code="200"> OK</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ProductModel>>> Get()
        {
            List<ProductModel> products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        /// <summary>
        ///     Retorna um determinado produto pelo seu identificador.
        /// </summary>
        /// <param name="id">
        ///     Você deve preencher com o ID de algum produto existente.
        ///     
        ///         Exemplo de ID: 3.
        /// </param>
        /// 
        /// <response code="200">OK</response>
        /// <response code="404"> Not Found: Caso o identificador(Id) informado não exista no banco de dados.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductModel>> GetById(int id)
        {
            try
            {
                ProductModel product = await _productService.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        /// <summary>
        ///     Cria um novo produto no banco de dados.
        /// </summary>
        /// <param name="product"> 
        ///         Preencha o objeto abaixo com as propriedades do produto.
        ///         Obs: A propriedade "price" deve ser um valor decimal. 
        ///     
        ///             Exemplo: 15.50  
        /// </param>
        /// 
        /// <response code="200">OK</response>
        /// <response code="400"> Bad Request</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post([FromBody]ProductRequest product)
        {
            var createdProduct = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, product);
        }

        /// <summary>
        ///     Atualiza uma ou mais propriedades de um produto existente no banco de dados.
        /// </summary>
        /// <param name="product"> 
        ///         Preencha o objeto abaixo com as propriedades do produto.
        ///         Obs: A propriedade "price" deve ser um valor decimal. 
        ///     
        ///             Exemplo: 15.50  
        /// </param>
        /// <param name="id">
        ///     Você deve preencher com o ID de algum produto existente.
        ///     
        ///         Exemplo de ID: 3.
        /// </param>
        /// 
        /// <response code="200">OK</response>
        /// <response code="400"> Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Put([FromBody] ProductRequest product, [Required]int id)
        {
            try
            {
                await _productService.UpdateProductAsync(product, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        /// <summary>
        ///     Deleta um produto existente no banco de dados a partir de seu ID.
        /// </summary>
        /// <param name="id">
        ///     Você deve preencher com o ID de algum produto existente.
        ///     
        ///         Exemplo de ID: 3.
        /// </param>
        /// 
        /// <response code="200">OK</response>
        /// <response code="400"> Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteById(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}

      

       

