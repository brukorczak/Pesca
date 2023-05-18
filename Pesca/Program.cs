using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesca
{
    class Program
    {
        static void Main(string[] args)
        {
            //variaveis
            int numJogadores, peixes, numPeixes, linha, coluna, tentativas;
            int maiorPontuacao = 0, pontuacao = 0;
            string vencedor = "nome", empate;

            //entradas
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------- PESCARIA ---------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nAviso: Não repita os locais de pesca -_- ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("BOM JOGO!! :))");
            Console.WriteLine("\n");

            //Matrizes
            String[,] lago = new String[5, 10];
            Random posicaoPeixe = new Random();

            //Criar lago
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    lago[i, j] = "0";
                    Console.Write(" [ " + i + "," + j + " ] ");
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");

            Console.WriteLine("Insira a quantidade de jogadores: ");
            numJogadores = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a quantidade de peixes no lago: ");
            peixes = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a quantidade de tentativas de cada jogador: ");
            tentativas = int.Parse(Console.ReadLine());

            //Matrizes
            int[] pontos = new int[numJogadores];
            string[] nome = new string[numJogadores];

            Console.WriteLine("\n");
            //Nome do jogador
            for (int i = 0; i < numJogadores; i++)
            {
                Console.WriteLine("Qual o nome do " + (i + 1) + "º jogador: ");
                nome[i] = Console.ReadLine();
            }

            numPeixes = peixes;

            //Colocar Peixe no Lago
            for (int i = 0; i < numPeixes; i++)
            {
                linha = posicaoPeixe.Next(5);
                coluna = posicaoPeixe.Next(10);
                if (lago[linha, coluna] != "Peixe")
                {
                    lago[linha, coluna] = "Peixe";
                }
                else
                {
                    numPeixes++;
                }
            }

            //Lançar a isca no lago
            for (int i = 0; i < tentativas; i++)
            {
                for (int j = 0; j < numJogadores; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n------------ " + (i + 1) + "º Tentativa do " + nome[j] + " ------------");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Insira a linha: ");
                    linha = int.Parse(Console.ReadLine());

                    Console.WriteLine("Insira a coluna: ");
                    coluna = int.Parse(Console.ReadLine());

                    if (linha >= 0 && linha < 5 && coluna >= 0 && coluna < 10)
                    {
                        if (lago[linha, coluna] == "Peixe")
                        {
                            lago[linha, coluna] = "0";
                            pontos[j] += 1;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(":) Você pescou um peixe");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Peixes restantes: " + (peixes -= 1));
                            Console.WriteLine("Pontos: " + pontos[j]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Errou :( sem peixes por perto");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Peixes restantes: " + peixes);
                            Console.WriteLine("Pontos: " + pontos[j]);

                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Linha ou coluna inválida. Insira valores dentro dos limites da matriz.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            Console.WriteLine("\n----------------------------------------------------------------------------------------\n");

            //vencedor          
            for (int i = 0; i < numJogadores; i++)
            {
                if (pontos[i] > maiorPontuacao)
                {
                    maiorPontuacao = pontos[i];
                    vencedor = nome[i];
                }
            }

            //se empatou
            for (int i = 0; i < numJogadores; i++)
            {
                if (maiorPontuacao == pontos[i])
                {
                    pontuacao++;
                }
            }

            //diz quem ganhou
            if (pontuacao == 1)
            {
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-* " + "Parabéns " + vencedor + ", você venceu 🎉" + " *-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            }
            else if (maiorPontuacao == 0)
            {
                Console.WriteLine("Quem ganhou foi o pesqueiro");
            }
            else
            {
                Console.WriteLine("Empate");
            }
            Console.ReadLine();
        }
    }
}
