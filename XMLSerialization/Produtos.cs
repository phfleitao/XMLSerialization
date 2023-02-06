using System.Xml.Serialization;

[Serializable()]
[XmlRoot("Produtos")]
public class Produtos
{
    [XmlElement("Produto")]
    public Produto[] ListaProdutos { get; set; }
}

public class Produto
{
    [XmlElement("Nome")]
    public string Nome { get; set; }
}
