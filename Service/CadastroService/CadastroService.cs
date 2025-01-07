using CadastroDeComputadores.DataContext;
using CadastroDeComputadores.models;
using Microsoft.EntityFrameworkCore;


namespace CadastroDeComputadores.Service.CadastroService {
    public class CadastroService : ICadastroInterface {
        private readonly AplicationDbContext _context;

        public CadastroService(AplicationDbContext context) { 
            _context = context;
        }
        
        public async Task<ServiceResponse<List<CadastroModel>>> CreateCadastro(CadastroModel newCadastro) {
            ServiceResponse<List<CadastroModel>> serviceResponse = new ServiceResponse<List<CadastroModel>>();
            try {
                if (newCadastro == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                    
                }

                _context.Add(newCadastro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Cadastro.ToList();

            } catch (Exception ex) {
                serviceResponse.Mensagem = "Cadastro criado com sucesso";
                serviceResponse.Sucesso = false;
                Console.WriteLine(ex.InnerException?.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CadastroModel>>> DeleteCadastro(string Tag) {
            ServiceResponse<List<CadastroModel>> serviceResponse = new ServiceResponse<List<CadastroModel>>();
            try {
                CadastroModel cadastro = _context.Cadastro.FirstOrDefault(x => x.Tag == Tag);

                if (cadastro == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cadastro não encontrado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;

                }
                _context.Cadastro.Remove(cadastro);
                await _context.SaveChangesAsync();
            } catch (Exception ex) {
                serviceResponse.Mensagem = "Deletado com sucesso";
                serviceResponse.Sucesso = false;
                Console.WriteLine(ex.InnerException?.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CadastroModel>>> GetCadastro() {
            ServiceResponse<List<CadastroModel>> serviceResponse = new ServiceResponse<List<CadastroModel>>();

            try {
                serviceResponse.Dados = _context.Cadastro.ToList();

                if(serviceResponse.Dados.Count == 0) {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }

            } catch (Exception ex) { 
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CadastroModel>> GetCadastrobyTag(string Tag) {
            ServiceResponse<CadastroModel> serviceResponse = new ServiceResponse<CadastroModel>();
            try {
                CadastroModel cadastro = _context.Cadastro.FirstOrDefault(x => x.Tag == Tag);
                if (cadastro == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Tag não encontrada";
                    serviceResponse.Sucesso = false;
                }
                serviceResponse.Dados = cadastro;
            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CadastroModel>>> InativaCadastro(string Tag) {
            ServiceResponse<List<CadastroModel>> serviceResponse = new ServiceResponse<List<CadastroModel>>();

            try {
                CadastroModel cadastro = _context.Cadastro.FirstOrDefault(x => x.Tag == Tag);

                if (cadastro == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cadastro não encontrado";
                    serviceResponse.Sucesso= false;
                }
                cadastro.Ativo = false;
                //cadastro.DataDeSaida = DateTime.Now.ToLocalTime();

                _context.Cadastro.Update(cadastro);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Cadastro.ToList();
            } catch(Exception ex) {
                serviceResponse.Mensagem=ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CadastroModel>>> UpdateCadastro(CadastroModel editCadastro) {
            ServiceResponse<List<CadastroModel>> serviceResponse = new ServiceResponse<List<CadastroModel>>();

            try {
                CadastroModel cadastro = _context.Cadastro.AsNoTracking().FirstOrDefault(x => x.Tag == editCadastro.Tag);
                if (cadastro == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cadastro não encontrado";
                    serviceResponse.Sucesso = false;
                }
                //cadastro.DataDeSaida = DateTime.Now.ToLocalTime();

                _context.Cadastro.Update(editCadastro);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Cadastro.ToList();
            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
