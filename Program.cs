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

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Bem-vindo ao Jogo da Forca!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Adivinhe a palavra secreta.");
                Console.ForegroundColor = ConsoleColor.White;

                while (true)
                {
                    Console.WriteLine();

                    // Mostra as letras já descobertas
                    Console.Write("\nPalavra: ");
                    Console.ForegroundColor = ConsoleColor.Yellow; // Muda a cor dos ______ nas letras
                    foreach (char letra in letrasDescobertas)
                    {
                        Console.Write(letra + " ");
                    }
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
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
                        Console.Write("Você errou! Tentativas restantes: ");
                        Console.ForegroundColor = ConsoleColor.Red; // mudou a cor das tentativas para vermelho
                        Console.WriteLine($"{maximoErros - erros}.");
                        Console.ForegroundColor = ConsoleColor.White; // voltar para o branco
                        if (erros == maximoErros)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nVocê perdeu!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" A palavra secreta era: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{palavraSecreta}\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                    }
                    else
                    {
                        // Verifica se o jogador descobriu todas as letras da palavra
                        if (new string(letrasDescobertas) == palavraSecreta)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\n\nParabéns! Você acertou a palavra secreta: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{palavraSecreta}\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Deseja jogar novamente?");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" (y/n): ");
                Console.ForegroundColor = ConsoleColor.White;
                string resposta = Console.ReadLine().ToLower();

                if (resposta != "y")
                {
                    jogarNovamente = false;
                    
                }
                Console.Clear(); // apagar o resto das msgs

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
