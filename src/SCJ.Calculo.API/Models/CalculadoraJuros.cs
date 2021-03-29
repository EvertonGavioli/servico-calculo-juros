using System;
using System.Text;
using ExtensionMethods;

namespace SCJ.Calculo.API.Models
{
    public static class CalculadoraJuros
    {
        private static readonly decimal MaxValorInicial = 99999999999m;
        private static readonly int MaxValorMeses = 1200;

        public static decimal CalcularJurosCompostos(decimal valorInicial, decimal juros, int tempo)
        {
            var result = valorInicial * (decimal)Math.Pow(Convert.ToDouble(1 + juros), tempo);
            return result.TruncateDecimal(2);
        }

        public static string ValidarParametros(decimal valorInicial, int tempo)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (valorInicial < 0 || valorInicial > MaxValorInicial) stringBuilder.AppendLine($"Valor inicial deve estar no intervalo entre 0 e {MaxValorInicial.ToString("N2")};");
            if (tempo < 0 || tempo > MaxValorMeses) stringBuilder.AppendLine($"Tempo em meses deve estar no intervalo entre 0 e {MaxValorMeses};");

            return stringBuilder.ToString();
        }
    }
}
