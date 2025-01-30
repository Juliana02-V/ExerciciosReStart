using System.Text.Json;
using ProjSuperClean_Juliana.Vaz;
class Program
{
   public  static void Main()

    {
        Console.Clear();
        Saudacao saudacao = new Saudacao();
        Login login = new Login();
        saudacao.saudacao1();

        while (true) // O loop continuará até o usuário sair ou fornecer um valor válido
        {
            Console.WriteLine("1- Login");
            Console.WriteLine("2- Registar");
            
            Console.WriteLine("Escreva 'Sair' para sair.");

            string resposta = Console.ReadLine();

            if (resposta == "1")
            {
                Console.Clear();
                saudacao.saudacao1();
                login.Iniciar();
                break; // Sai do loop após o login
            }
            else if (resposta == "2")
            {
                Console.Clear();
                saudacao.saudacao1();
                Console.WriteLine("Introduza o seu username");
                string username = Console.ReadLine();

                // Verifica se o username é válido
                if (login.ValidarUsername(username))
                {
                    // Verifica se o usuário já existe
                    if (login.UtilizadorExistente(username) == false) // O usuário não existe
                    {
                        login.CriarUtilizador(username); // Cria o novo usuário
                        Console.WriteLine("Utilizador criado com sucesso!");
                        break; // Sai do loop após criar o usuário
                    }
                    else
                    {
                        Console.Clear();
                        saudacao.saudacao1();
                        Console.WriteLine("Utilizador já existe. Tentando novamente...");
                    }
                }
                else
                {
                    Console.Clear();
                    saudacao.saudacao1();
                    Console.WriteLine("Username inválido. Tentando novamente...");
                }
            }
            
            else if (resposta.ToLower() == "sair")
            {
                Console.WriteLine("Obrigada, Vai sair da APP");
                break; // Sai do loop e termina o programa
            }
            else
            {
                Console.WriteLine("Insira um número válido ou escreva 'Sair'");
            }
        }

        Console.ReadKey(); 
    }

}



