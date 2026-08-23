using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    [HttpPost]
    public IActionResult CalcularImc(Pessoa pessoa)
    {
        if (pessoa.altura <= 1)
            return BadRequest("A altura deve ser maior que zero.");

        float imc = pessoa.peso / (pessoa.altura * pessoa.altura);
        return Ok(new { pessoa.nome, imc });
    }

    [HttpGet("consulta-tabela-imc")]
    public IActionResult ConsultaTabelaImc(float imc)
    {
        string descricao;

        if (imc < 18.5) descricao = "Abaixo do peso";
        else if (imc < 25) descricao = "Peso normal";
        else if (imc < 30) descricao = "Sobrepeso";
        else if (imc < 35) descricao = "Obesidade Grau I";
        else if (imc < 40) descricao = "Obesidade Grau II";
        else descricao = "Obesidade Grau III";

        return Ok(descricao);
    }
}