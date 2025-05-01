using System.Text.RegularExpressions;

namespace FluxoCaixa.Utils
{
    public static class CpfCnpjUtils
    {
        public static bool EhCpfOuCnpjValido(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            var digits = Regex.Replace(input, "[^0-9]", "");

            return digits.Length switch
            {
                11 => EhCpfValido(digits),
                14 => EhCnpjValido(digits),
                _ => false
            };
        }

        private static bool EhCpfValido(string cpf)
        {
            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            var mult1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var mult2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var temp = cpf[..9];
            var soma = temp.Select((c, i) => int.Parse(c.ToString()) * mult1[i]).Sum();

            var resto = soma % 11;
            var digito1 = resto < 2 ? 0 : 11 - resto;

            temp += digito1;
            soma = temp.Select((c, i) => int.Parse(c.ToString()) * mult2[i]).Sum();

            resto = soma % 11;
            var digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf.EndsWith($"{digito1}{digito2}");
        }

        private static bool EhCnpjValido(string cnpj)
        {
            if (new string(cnpj[0], cnpj.Length) == cnpj)
                return false;

            var mult1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var mult2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var temp = cnpj[..12];
            var soma = temp.Select((c, i) => int.Parse(c.ToString()) * mult1[i]).Sum();

            var resto = soma % 11;
            var digito1 = resto < 2 ? 0 : 11 - resto;

            temp += digito1;
            soma = temp.Select((c, i) => int.Parse(c.ToString()) * mult2[i]).Sum();

            resto = soma % 11;
            var digito2 = resto < 2 ? 0 : 11 - resto;

            return cnpj.EndsWith($"{digito1}{digito2}");
        }
    }
}
