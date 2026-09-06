using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private static List<Pessoa> pessoas = new List<Pessoa>();

    #region Metodo Post
    [HttpPost]
        public IActionResult Adiciona([FromBody] List<Pessoa> novaPessoa)
        {
        pessoas.AddRange(novaPessoa);
            return Ok(novaPessoa);
        }





    #endregion

    #region Metodo Put
    [HttpPut("{cpf}")]
    public IActionResult Atualiza(string cpf,[FromBody] Pessoa pessoaAtualizada)
    {
        var pessoa = pessoas.FirstOrDefault(p=>p.cpf==cpf);

        if(pessoa == null)  
        {
            return NotFound();
        }

        pessoa.nome = pessoaAtualizada.nome;
        pessoa.peso = pessoaAtualizada.peso;
        pessoa.altura = pessoaAtualizada.altura;

        return Ok(pessoa);
    }





    #endregion

    #region Metodo Delete 
    [HttpDelete("{cpf}")]
    public IActionResult Remover(string cpf)
    {
        var pessoa = pessoas.FirstOrDefault(p => p.cpf == cpf);

        if(pessoa == null)
        {
            return NotFound();
        }

        pessoas.Remove(pessoa);
            return Ok();
        
    }







    #endregion

    #region Metodo Get
    [HttpGet("{cpf}")]
    public IActionResult BuscaPorCpf(string cpf)
    {
        var pessoa = pessoas.FirstOrDefault(p=>p.cpf==cpf);

        if(pessoa == null)
        {
            return NotFound();
        }

        return Ok(pessoa);
    }

    [HttpGet]
    public IActionResult BuscaTodosDados()
    {
        return Ok(pessoas);
    }

    [HttpGet("imc")]
    public IActionResult BuscoPorIMC()
    {
        var resultado = pessoas.Where(p=>p.CalculoIMC()>= 18 && p.CalculoIMC()<=24).ToList();
        return Ok(resultado);
    }

    [HttpGet("busca_nome/{nome}")]
    public IActionResult BuscaPeloNome(string nome)
    {
       var resultado = pessoas.Where(p => p.nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
        return Ok(resultado);
    }



    #endregion
}