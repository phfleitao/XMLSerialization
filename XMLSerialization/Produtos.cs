using System.Xml.Serialization;

[Serializable]
//[XmlRoot("Produtos")]
public class Produtos
{
    //[XmlElement("Produto")]
    [XmlArray("Produtos")]
    [XmlArrayItem("Produto")]
    public Produto[] ListaProdutos { get; set; }
    
    [XmlElement("Obrigatrio")]
    public bool Obrigatrio { get; set; }
}

public class Produto
{
    [XmlElement("Nome")]
    public string Nome { get; set; }
}
