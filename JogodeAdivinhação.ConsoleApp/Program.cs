namespace JogodeAdivinhação.ConsoleApp;

internal class Program
{
    static void Main(string[] args)


    {
        while (true)
        {
            AtalhoMenu();

            Console.Write("Digite sua escolha: ");
            string opcaoDificuldade = Console.ReadLine(); 
            int totalDeTentativas = OpcaoDificuldade(opcaoDificuldade);
            int numeroSecreto = GeradorNumeros();

            for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
            {
                ExibirTentativas(tentativa, totalDeTentativas);

               
                Console.Write("Digite um número entre 1 e 20: ");
                int numeroDigitado = Convert.ToInt32(Console.ReadLine());

                if (numeroDigitado == numeroSecreto)
                {
                    EscrevaParabens();

                    break;
                }

                if (tentativa == totalDeTentativas)
                {
                    TryAgain(numeroSecreto);

                    break;
                }

                else if (numeroDigitado > numeroSecreto)
                {
                    NumberBig();
                }
                else
                {
                    NumberSmall();
                }

                Console.WriteLine("Aperte ENTER para continuar...");
                Console.ReadLine();
            }

            Console.Write("Deseja continuar (s/N)? ");

            string opcaoContinuar = Console.ReadLine().ToUpper();

            if (opcaoContinuar != "S")
                break;
        }
    }

    static void AtalhoMenu()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Jogo de Adivinhação");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Escolha um nível de dificuldade:");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("1 - Fácil (10 tentativas)");
        Console.WriteLine("2 - Normal (5 tentativas)");
        Console.WriteLine("3 - Difícil (3 tentativas)");
        Console.WriteLine("----------------------------------------");        
    }

    static int OpcaoDificuldade(string dificuldade)
    {
        int tentativas = 0;

        if (dificuldade == "1")
            tentativas = 10;
       
        else if (dificuldade == "2")
            tentativas = 5;

        else if (dificuldade == "3")
            tentativas = 3;

        return tentativas;
    }

    static int GeradorNumeros()
    {
        Random geradorDeNumeros = new Random();

        return geradorDeNumeros.Next(1, 21);
    }

    static void ExibirTentativas(int tt01, int tt02)
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Tentativa {tt01} de {tt02}");
        Console.WriteLine("----------------------------------------");

    }

    static void EscrevaParabens()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Parabéns! Você acertou!");
        Console.WriteLine("----------------------------------------");
    }

    static void TryAgain(int secretnumber)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Que pena! Você usou todas as tentativas. O número era {secretnumber}.");
        Console.WriteLine("----------------------------------------");
    }

    static void NumberBig()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("O número digitado é maior que o número secreto.");
        Console.WriteLine("----------------------------------------");
    }

    static void NumberSmall()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("O número digitado é menor que o número secreto.");
        Console.WriteLine("----------------------------------------");
    }
}