using crud_dotnet.Models;
using crud_dotnet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crud_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IuserRepository _repository;
        public UsuarioController(IuserRepository repository)
        {
            _repository = repository;
        }
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.BuscarUsuarios();   
            return usuarios.Any() ? Ok(usuarios) : BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.BuscarUsuario(id);
            return usuario != null ? Ok(usuario) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Usuarios usuario)
        {
            _repository.AddUsuario(usuario);
            return await _repository.SaveChangesAsync() 
                ? Ok("Usuario adicionado com sucesso!!!") 
                : BadRequest("Erro ao adicionar usuário");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuarios usuario)
        {
            var _usuario = await _repository.BuscarUsuario(id);
            if(usuario == null) return NotFound();
            _usuario.Name = usuario.Name ?? usuario.Name;
            _usuario.dataNascimento = usuario.dataNascimento != new DateTime() ? 
             usuario.dataNascimento : _usuario.dataNascimento;
            _repository.AtualizaUsuario(_usuario);
            return await _repository.SaveChangesAsync()
                ? Ok("Usuario Atualizado com sucesso!!!")
                : BadRequest("Erro ao atualizar usuário");

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id, Usuarios usuario)
        {
            var _usuario = await _repository.BuscarUsuario(id);
            if (usuario == null) return NotFound();
            _usuario.Name = usuario.Name ?? usuario.Name;
            _usuario.dataNascimento = usuario.dataNascimento != new DateTime() ?
             usuario.dataNascimento : _usuario.dataNascimento;
            _repository.DeletaUsuario(_usuario);
            return await _repository.SaveChangesAsync()
                ? Ok("Usuario deletado com sucesso!!!")
                : BadRequest("Erro ao deletar usuário");

        }
    }
}
