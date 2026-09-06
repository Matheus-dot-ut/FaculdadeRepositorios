
Stack<string> historico = new Stack<string>();
Stack<string> avancar = new Stack<string>();
string atual = "";
historico.Push(atual); atual = "google.com"; avancar.Clear();
historico.Push(atual); atual = "github.com"; avancar.Clear();
historico.Push(atual); atual = "youtube.com"; avancar.Clear();
Console.WriteLine("Atual: " + atual);
avancar.Push(atual); atual = historico.Pop(); 
Console.WriteLine("Voltou: " + atual);
historico.Push(atual); atual = avancar.Pop();
Console.WriteLine("Avançou: " + atual);

