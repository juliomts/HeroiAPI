using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BatalhaController : ControllerBase
    {
        private readonly IFCoreRepository _repo;
        public BatalhaController(IFCoreRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            try
            {
                var batalha = await _repo.GetAllHerois(true);
                    return Ok(batalha);

            }

            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("{id}", Name = "GetBatalha")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id, true);
                return Ok(batalha);

            }

            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }
        [HttpPost]
        public async Task <IActionResult> Post(Batalha model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangeAsync())
                {
                    return Ok("Adicionado com sucesso!");
                }
  
            } 

            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Erro!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Batalha model)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);
                if (batalha != null)
                {
                    _repo.Update(model);
                    if (await _repo.SaveChangeAsync())
                        return Ok("Atualizado com sucesso!");
                }

            }

            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não atualizado!");
        }
    

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);
                if (batalha != null)
                {
                _repo.Delete(batalha);
                if (await _repo.SaveChangeAsync())
                return Ok("Deletado com sucesso!");
                }

            }

            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
            return BadRequest($"Não deletado!");
        }
    }
}
