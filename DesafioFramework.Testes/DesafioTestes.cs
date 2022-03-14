using DesafioFramework.Core;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace DesafioFramework.Testes
{
    public class DesafioTestes
    {
        [Theory]
        [InlineData(45, new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43 })]
        [InlineData(60, new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 })]
        [InlineData(100, new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
        [InlineData(500, new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499 })]
        public void Desafio_VerificarNumerosPrimos_DeveRetornarValorDeAcordoComParametro(int numeroEntrada, int[] numerosPrimos)
        {
            Desafio desafio = new Desafio(numeroEntrada);

            Assert.Equal(desafio.NumerosPrimos, numerosPrimos);
        }

        [Theory]
        [InlineData(45, new int[] { 1, 3, 5, 9, 15, 45 })]
        [InlineData(60, new int[] { 1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, 60 })]
        [InlineData(100, new int[] { 1, 2, 4, 5, 10, 20, 25, 50, 100 })]
        [InlineData(500, new int[] { 1, 2, 4, 5, 10, 20, 25, 50, 100, 125, 250, 500 })]
        public void Desafio_VerificarNumerosDivisores_DeveRetornarValorDeAcordoComParametro(int numeroEntrada, int[] numerosDivisores)
        {
            Desafio desafio = new Desafio(numeroEntrada);

            Assert.Equal(desafio.NumerosDivisores, numerosDivisores);
        }


        [Theory]
        [InlineData(45, new int[] { 3, 5 })]
        [InlineData(60, new int[] { 2, 3, 5 })]
        [InlineData(100, new int[] { 2, 5 })]
        [InlineData(500, new int[] { 2, 5 })]
        public void Desafio_VerificarDivisoresPrimos_DeveRetornarValorDeAcordoComParametro(int numeroEntrada, int[] divisoresPrimos)
        {
            Desafio desafio = new Desafio(numeroEntrada);

            Assert.Equal(desafio.NumerosDivisoresPrimos, divisoresPrimos);
        }
    }
}
