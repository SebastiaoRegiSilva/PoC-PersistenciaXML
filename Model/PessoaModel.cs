using System.Xml.Serialization;

public partial class PessoaModel
{
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }
    [XmlElement(ElementName = "Nome")]
    public string Nome { get; set; } = string.Empty;
    [XmlElement(ElementName = "Idade")]
    public int Idade { get; set; }
}