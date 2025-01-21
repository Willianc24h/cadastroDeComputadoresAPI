using CadastroDeComputadores.models;
using CadastroDeComputadores.Service.CadastroService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeComputadores.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase {
        private readonly ICadastroInterface _cadastroInterface;
        public CadastroController(ICadastroInterface cadastroInterface) {
            _cadastroInterface = cadastroInterface;

        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CadastroModel>>>> GetCadastro() {
            return Ok(await _cadastroInterface.GetCadastro());
        }

        [HttpGet("{Tag}")]
        public async Task<ActionResult<ServiceResponse<CadastroModel>>> GetCadastrobyTag(string Tag) {
            ServiceResponse<CadastroModel> serviceResponse = await _cadastroInterface.GetCadastrobyTag(Tag);
            return Ok(serviceResponse);
         }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CadastroModel>>>> CreateCadastro(CadastroModel newCadastro) {
            return Ok(await _cadastroInterface.CreateCadastro(newCadastro));
        }

        [HttpPut("{Tag}")]
        public async Task<ActionResult<ServiceResponse<CadastroModel>>> UpdateCadastro(string Tag, CadastroModel editCadastro) {
            // Usando o Tag na URL para identificar o item
            ServiceResponse<CadastroModel> serviceResponse = await _cadastroInterface.UpdateCadastro(Tag, editCadastro);
            return Ok(serviceResponse);
        }


        [HttpPut("inativa/{Tag}")]
        public async Task<ActionResult<ServiceResponse<CadastroModel>>> InativaCadastro(string Tag) {
            ServiceResponse<List<CadastroModel>> serviceResponse = await _cadastroInterface.InativaCadastro(Tag);
            return Ok(serviceResponse);
        }


        [HttpDelete("{Tag}")]
        public async Task<ActionResult<ServiceResponse<CadastroModel>>> DeleteCadastro(string Tag) {
            ServiceResponse<List<CadastroModel>> serviceResponse = await _cadastroInterface.DeleteCadastro(Tag);
            return Ok(serviceResponse);
        }

    }
    }