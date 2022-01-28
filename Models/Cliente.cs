namespace MinimalApiSqlSever.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string? Nome { get; set; }

        public string? Cpf { get; set; }

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public string? Complemento { get; set; }

        public string? Cep { get; set; }

        public string? Cidade { get; set; }

        public string? Uf { get; set; }
    }
}
