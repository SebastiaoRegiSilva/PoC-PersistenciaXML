using System.Xml.Serialization;

public class PessoaRepository
{
    private readonly string _caminhoArquivo = "dados.xml";

    public PessoaRepository()
    {
        if (!File.Exists(_caminhoArquivo))
            Salvar(new List<PessoaModel>()); // Cria o arquivo inicial vazio.
    }

    public List<PessoaModel> ObterTodos()
    {
        if (!File.Exists(_caminhoArquivo))
            return new List<PessoaModel>();

        var serializer = new XmlSerializer(typeof(List<PessoaModel>));
        try
        {
            using (var stream = new FileStream(_caminhoArquivo, FileMode.Open))
                return (List<PessoaModel>)serializer.Deserialize(stream);
            
        }
        catch
        {
            // Retorna uma lista vazia em caso de erro na desserialização.1
            return new List<PessoaModel>();
        }
    }

    public void Adicionar(PessoaModel pessoa)
    {
        var pessoas = ObterTodos();
        pessoa.Id = pessoas.Any() ? pessoas.Max(p => p.Id) + 1 : 1;
        pessoas.Add(pessoa);
        Salvar(pessoas);
    }

    public void Atualizar(PessoaModel pessoaAtualizada)
    {
        var pessoas = ObterTodos();
        var pessoa = pessoas.FirstOrDefault(p => p.Id == pessoaAtualizada.Id);
        if (pessoa != null)
        {
            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.Idade = pessoaAtualizada.Idade;
            Salvar(pessoas);
        }
    }

    public void Deletar(int id)
    {
        var pessoas = ObterTodos();
        var pessoa = pessoas.FirstOrDefault(p => p.Id == id);
        if (pessoa != null)
        {
            pessoas.Remove(pessoa);
            Salvar(pessoas);
        }
    }

    private void Salvar(List<PessoaModel> pessoas)
    {
        var serializer = new XmlSerializer(typeof(List<PessoaModel>));
        using (var stream = new FileStream(_caminhoArquivo, FileMode.Create))
        {
            serializer.Serialize(stream, pessoas);
        }
    }
}
