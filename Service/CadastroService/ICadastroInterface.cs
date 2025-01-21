using CadastroDeComputadores.models;

namespace CadastroDeComputadores.Service.CadastroService {
    public interface ICadastroInterface {
        Task<ServiceResponse<List<CadastroModel>>> GetCadastro();
        Task<ServiceResponse<List<CadastroModel>>> CreateCadastro(CadastroModel newCadastro);

        Task<ServiceResponse<CadastroModel>> GetCadastrobyTag(string Tag);

        Task<ServiceResponse<CadastroModel>> UpdateCadastro(string Tag, CadastroModel editCadastro);

        Task<ServiceResponse<List<CadastroModel>>> DeleteCadastro(string Tag);

        Task<ServiceResponse<List<CadastroModel>>> InativaCadastro(string Tag);
    }
}