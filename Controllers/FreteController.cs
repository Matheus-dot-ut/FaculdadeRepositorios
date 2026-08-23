using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class FreteController : ControllerBase
{
    [HttpPost]
    public IActionResult CalcularFrete(Frete frete)
    {
        if (frete.altura <= 0 || frete.largura <= 0 || frete.comprimento <= 0)
            return BadRequest("Altura, largura e comprimento devem ser maiores que zero.");

        float volume = frete.altura * frete.largura * frete.comprimento;

        float taxaPorCm3 = 0.05f; // ajuste esse valor conforme o enunciado
        float taxaEstado = ObterTaxaEstado(frete.uf);

        float valorFrete = volume * taxaPorCm3 + taxaEstado;

        return Ok(new
        {
            frete.nomeProduto,
            volume,
            valorFrete
        });
    }

    private float ObterTaxaEstado(string uf)
    {
        switch (uf.ToUpper())
        {
            case "SP": return 50.00f;
            case "RJ": return 60.00f;
            case "MG": return 55.00f;
            default: return 70.00f;
        }
    }
}