using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AlunoController : ControllerBase
{
    [HttpGet]
    public IActionResult Saudacao(string nome)
    {
        return Ok("Oi " + nome);
    }
    [HttpPost]
    public IActionResult Cadastrar(Aluno aluno)
    {
        return Ok("Castrado com sucesso"); 
    }
}
