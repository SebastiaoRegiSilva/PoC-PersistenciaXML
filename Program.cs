class Program
{
    static void Main(string[] args)
    {
        PessoaRepository repositorio = new PessoaRepository();

        Console.WriteLine("1. Adicionar pessoa");
        Console.WriteLine("2. Listar pessoas");
        Console.WriteLine("3. Atualizar pessoa");
        Console.WriteLine("4. Deletar pessoa");
        Console.WriteLine("0. Sair");

        while (true)
        {
            Console.Write("\nEscolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Nome: ");
                    var nome = Console.ReadLine();
                    Console.Write("Idade: ");
                    var idade = int.Parse(Console.ReadLine());
                    repositorio.Adicionar(new PessoaModel { Nome = nome, Idade = idade });
                    Console.WriteLine("Pessoa adicionada!");
                    break;

                case "2":
                    var pessoas = repositorio.ObterTodos();
                    foreach (var pessoa in pessoas)
                    {
                        Console.WriteLine($"Id: {pessoa.Id}, Nome: {pessoa.Nome}, Idade: {pessoa.Idade}");
                    }
                    break;

                case "3":
                    Console.Write("Id da pessoa a atualizar: ");
                    var idAtualizar = int.Parse(Console.ReadLine());
                    Console.Write("Novo Nome: ");
                    var novoNome = Console.ReadLine();
                    Console.Write("Nova Idade: ");
                    var novaIdade = int.Parse(Console.ReadLine());
                    repositorio.Atualizar(new PessoaModel { Id = idAtualizar, Nome = novoNome, Idade = novaIdade });
                    Console.WriteLine("Pessoa atualizada!");
                    break;

                case "4":
                    Console.Write("Id da pessoa a deletar: ");
                    var idDeletar = int.Parse(Console.ReadLine());
                    repositorio.Deletar(idDeletar);
                    Console.WriteLine("Pessoa deletada!");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
