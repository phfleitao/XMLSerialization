using XMLSerialization.Helpers;

string xmlString = @"<Produtos><Produto><Nome>Produto 1</Nome></Produto><Produto><Nome>Produto 2</Nome></Produto></Produtos>";

var produtos = xmlString.ToObject<Produtos>();
var produtosXML = produtos.ToXML();

foreach (var produto in produtos.ListaProdutos)
{
    Console.WriteLine(produto.Nome);
}D:\DEV\Workspace\Estudos\Testes e Experime