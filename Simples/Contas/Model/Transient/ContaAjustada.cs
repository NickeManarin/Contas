namespace Contas.Simples.Model.Transient
{
    public class ContaAjustada : Conta
    {
        public ContaAjustada(Conta conta)
        {
            Nome = conta.Nome;
            Valor = conta.Valor;
            Vencimento = conta.Vencimento;
            Pagamento = conta.Pagamento;
            DiasDeAtraso = (int)(Pagamento - Vencimento).TotalDays;

            ValorAjustado = DiasDeAtraso switch
            {
                > 0 and <= 3 => Valor + (Valor * 0.02m) + (Valor * 0.001m * DiasDeAtraso),
                > 3 and < 5 => Valor + (Valor * 0.03m) + (Valor * 0.002m * DiasDeAtraso),
                > 5 => Valor + (Valor * 0.05m) + (Valor * 0.003m * DiasDeAtraso),
                _ => Valor,
            };
        }
        
        public decimal ValorAjustado { get; set; }
        
        public int DiasDeAtraso { get; set; }
    }
}