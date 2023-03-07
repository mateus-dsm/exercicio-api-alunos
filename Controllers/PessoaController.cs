using Microsoft.AspNetCore.Mvc;
using System;

namespace ExercicioAPI1.Controllers
{
    [ApiController]
    [Route("/api/person")]
    public class PessoaController : ControllerBase
    {
        private List<Pessoa> _pessoas;

        public PessoaController()
        {
            _pessoas = new List<Pessoa>();
        }

        [HttpPost]
        public IActionResult Post(Pessoa pessoa)
        {
            if (pessoa.IsValid) 
            {
                foreach (var pessoaExistente in _pessoas)
                    if (pessoaExistente.Id == pessoa.Id)
                        return BadRequest("Esse Id já está cadastrado!");

                _pessoas.Add(pessoa);
                return Ok(pessoa); 
            }
            return BadRequest(string.Join(",", pessoa.Validations));
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string nome, [FromQuery]string cidade)
        {
            if(_pessoas.Count == 0) return NoContent();
            return Ok(_pessoas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            foreach(var pessoa in _pessoas)
                if(pessoa.Id == id) return Ok(pessoa);

            return NotFound();
        }

        [HttpPut]
        public IActionResult Put(Pessoa novaPessoa)
        {
            if (!novaPessoa.IsValid)
                return BadRequest(string.Join(",", novaPessoa.Validations));

            foreach(var pessoa in _pessoas)
                if(pessoa.Id == novaPessoa.Id)
                {
                    _pessoas.Remove(pessoa);
                    _pessoas.Add(novaPessoa); 
                    return Ok(novaPessoa);
                }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            foreach(var pessoa in _pessoas)
                if(pessoa.Id == id)
                {
                    _pessoas.Remove(pessoa);
                    return Ok(pessoa);
                }

            return NotFound();
        }
    }
}
