using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFramework.Core
{
    public class Desafio
    {
        public int NumeroEntrada { get; private set; }
        public IList<int> NumerosPrimos { get; private set; }
        public HashSet<int> NumerosDivisores { get; private set; }

        public IList<int> NumerosDivisoresPrimos
        {
            get
            {
                if (NumerosPrimos == null || NumerosDivisores == null) return null;
                return NumerosDivisores.Intersect(NumerosPrimos).OrderBy(x => x).ToList();
            }
        }

        public Desafio(int numeroEntrada)
        {
            if (numeroEntrada <= 1)
                throw new ArgumentException("Número de entrada deve ser maior que 1");

            NumeroEntrada = numeroEntrada;
            NumerosPrimos = new List<int>();
            NumerosDivisores = new HashSet<int>() { 1 };

            ObterNumerosPrimos();
            DecomporNumero();
        }

        public void DecomporNumero()
        {
            var numero = NumeroEntrada;
            var fatoresDivisores = new List<int>();
            var resultadosDivisao = new List<int>();
            int fator = 2;

            while (numero != 1)
            {
                fator = EscolherProximoFatorDivisor(numero, fator);
                numero = numero / fator;
                resultadosDivisao.Add(numero);
                fatoresDivisores.Add(fator);
            }

            foreach (var fatorDivisor in fatoresDivisores)
            {
                foreach (var divisor in NumerosDivisores.ToList())
                {
                    NumerosDivisores.Add(fatorDivisor * divisor);
                }
            }

            NumerosDivisores = NumerosDivisores.OrderBy(x => x).ToHashSet();
        }

        private int EscolherProximoFatorDivisor(int numero, int ultimoFatorDivisor)
        {
            if (EDivisivel(numero, ultimoFatorDivisor))
                return ultimoFatorDivisor;

            int posicaoProximoFatorDivisor = NumerosPrimos.IndexOf(ultimoFatorDivisor) + 1;
            return EscolherProximoFatorDivisor(numero, NumerosPrimos[posicaoProximoFatorDivisor]);
        }

        private void ObterNumerosPrimos()
        {
            var verificarNumeros = Enumerable.Range(1, NumeroEntrada);
            foreach (var verificaNumero in verificarNumeros)
            {
                if (ENumeroPrimo(verificaNumero))
                    NumerosPrimos.Add(verificaNumero);
            }

            NumerosPrimos = NumerosPrimos.OrderBy(x => x).ToList();
        }

        private bool ENumeroPrimo(int numero)
        {
            if (numero <= 1) return false;
            for (int i = 2; i * i <= numero; i++)
            {
                if (EDivisivel(numero, i))
                    return false;
            }
            return true;
        }

        private bool EDivisivel(int numero, int divisor)
        {
            try
            {
                if (numero % divisor == 0)
                    return true;
            }
            catch (DivideByZeroException ex)
            {
                return false;
            }

            return false;
        }
    }
}
