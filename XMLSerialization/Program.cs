using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;
using XMLSerialization.Helpers;

BenchmarkRunner.Run<MemoryBenchmarkerDemo>();

[MemoryDiagnoser]
public class MemoryBenchmarkerDemo
{
    private const int LIMITE = 1000;

    [Benchmark]
    public Produtos SerializeTests()
    {
        var sb = new StringBuilder();
        sb.Append("<Produtos>");
        for (int i = 0; i < LIMITE; i++)
        {
            sb.Append("<Produto><Nome>Produto ");
            sb.Append(i.ToString());
            sb.Append("</Nome></Produto>");
        }
        sb.Append("</Produtos>");

        return sb.ToString().ToObject<Produtos>();
    }

    [Benchmark]
    public string DeserializeTests()
    {
        var produtos = new Produtos();
        produtos.ListaProdutos = new Produto[LIMITE];
        for (int i = 0; i < LIMITE; i++)
        {
            var texto = "teste " + i.ToString();
            produtos.ListaProdutos[i] = new Produto() { Nome = texto };
        }

        return produtos.ToXML();
    }
}