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
    public class HeroiController : ControllerBase
    {
        private readonly IFCoreRepository _repo;
        public HeroiController(IFCoreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var heroi = await _repo.GetAllHerois(true);
                return Ok(heroi);

            }

            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("{id}", Name = "GetHerois")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id, true);
                return Ok(heroi);

            }

            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }
        [HttpGet("{nome}", Name = "GetHeroisNome")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var heroi = await _repo.GetHeroisByNome(nome, true);
                return Ok(heroi);

            }

            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post(Heroi model)
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
        public async Task<IActionResult> Put(int id, Heroi model)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if (heroi != null)
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
                var heroi = await _repo.GetHeroiById(id);
                if (heroi != null)
                {
                    _repo.Delete(heroi);
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

