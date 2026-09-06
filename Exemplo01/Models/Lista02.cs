using System.ComponentModel.DataAnnotations;

public class Pessoa
{
    [Required(ErrorMessage ="O nome tem que esta cadastrado")]
    public string nome {get;set;}

    [Required(ErrorMessage ="CPF e obrigatorio o cadastramento")]
    public string cpf {get;set;}
    
    [Required(ErrorMessage ="Peso e obrigatorio ser cadastrado")]
    public double peso {get;set;}

    [Required(ErrorMessage ="A altura e obrigatoria ser cadastrada")]
    public double altura {get;set;}

    public double CalculoIMC()
    {
        return peso/(altura*altura);
    }
}
