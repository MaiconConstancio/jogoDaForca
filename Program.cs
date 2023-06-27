using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jogoDaForca
{
    internal class Program
    {
               
        static void Main(string[] args)
        {
            Console.Title = "                                                  Jogo da Forca - feito por MAICON CONSTANCIO ";

            bool jogarNovamente = true;

            while (jogarNovamente)
            {
                string[] palavras = { "banana", "laranja", "abacaxi", "morango", "carambola", "bacuri", "framboesa" };
                Random random = new Random();
                string palavraSecreta = palavras[random.Next(0, palavras.Length)];
                int maximoErros = 5;
                int erros = 0;
                char[] letrasDescobertas = new char[palavraSecreta.Length];

                for (int i = 0; i < letrasDescobertas.Length; i++)
                {
                    letrasDescobertas[i] = '_';
                }

                Console.WriteLine("Bem-vindo ao Jogo da Forca!");
                Console.WriteLine("Adivinhe a palavra secreta.");

                while (true)
                {
                    Console.WriteLine();

                    // Mostra as letras já descobertas
                    Console.Write("Palavra: ");
                    foreach (char letra in letrasDescobertas)
                    {
                        Console.Write(letra + " ");
                    }

                    Console.WriteLine();
                    Console.Write("Digite uma letra: ");
                    char letraDigitada = Console.ReadKey().KeyChar;

                    bool acertou = false;

                    // Verifica se a letra digitada faz parte da palavra secreta
                    for (int i = 0; i < palavraSecreta.Length; i++)
                    {
                        if (palavraSecreta[i] == letraDigitada)
                        {
                            letrasDescobertas[i] = letraDigitada;
                            acertou = true;
                        }
                    }

                    if (!acertou)
                    {
                        erros++;
                        Console.WriteLine();
                        Console.WriteLine("Você errou! Tentativas restantes: " + (maximoErros - erros));

                        if (erros == maximoErros)
                        {
                            Console.WriteLine("Você perdeu! A palavra secreta era: " + palavraSecreta);
                            break;
                        }
                    }
                    else
                    {
                        // Verifica se o jogador descobriu todas as letras da palavra
                        if (new string(letrasDescobertas) == palavraSecreta)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Parabéns! Você acertou a palavra secreta: " + palavraSecreta);
                            break;
                        }
                    }
                }

                Console.WriteLine();
                Console.Write("Deseja jogar novamente? (s/n): ");
                string resposta = Console.ReadLine().ToLower();

                if (resposta != "s")
                {
                    jogarNovamente = false;
                }

                Console.Clear();
            }

            
            Console.ForegroundColor = ConsoleColor.Cyan; // Mudou de cor para ciano
            Console.WriteLine($"Espero ter feito seu dia feliz! tudo de bom ^-^");
            Console.ForegroundColor = ConsoleColor.Red; // Mudou de cor para Vermelho
            Console.WriteLine("Programa encerrando altomaticamente em 7 segundos!");
            Thread.Sleep(7000); // tempo
            Environment.Exit(0); // fechar janela
        }

    }
}
