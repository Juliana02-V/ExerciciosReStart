using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjSuperClean_Juliana.Vaz;

internal class Login
{
    private string ficheiroUtilizador = "utilizadores.json"; // Nome do ficheiro onde os utilizadores serão guardados
    private List<Utilizador> utilizadores;

    public Login()
    {
        // Carrega os utilizadores ao instanciar a classe Login
        utilizadores = CarregarUtilizadores(ficheiroUtilizador);
    }
    // Função para carregar os utilizadores do ficheiro JSON
    private List<Utilizador> CarregarUtilizadores(string ficheiro)
    {
        if (File.Exists(ficheiro))
        {
            string json = File.ReadAllText(ficheiro);
            return JsonSerializer.Deserialize<List<Utilizador>>(json) ?? new List<Utilizador>();
        }
        return new List<Utilizador>();
    }

    // Método para iniciar o fluxo de login
    public void Iniciar()
    {

        Console.WriteLine("Insira o seu username: (Para Sair da App digite Sair)");

        string username = Console.ReadLine();

        if (username.Equals("Sair", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Saindo da aplicação...");

        }
        else
        {
            // Valida o username antes de adicionar
            if (!ValidarUsername(username))
            {
                Console.WriteLine("O username é inválido. Ele deve ter até 8 caracteres, ser alfanumérico e não pode ser vazio.");
            }
            else if (UtilizadorExistente(username))
            {
                Residencia residencia = new Residencia();
                Console.WriteLine();
                residencia.MenuResidencia(username );
            }
            else
            {
                Console.WriteLine("O seu login não existe.Deseja criar? s/n");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() == "s")
                {
                    CriarUtilizador(username);
                }
                else
                {
                    return;
                }
            }
        }
    }
    public void CriarUtilizador(string username)
    {
        Console.Clear();
        Saudacao saudacao = new Saudacao();
        saudacao.saudacao1();

        // Cria um novo utilizador
        Utilizador novoUsuario = new Utilizador { Username = username, Residencia = new Residencia() };

        // Permite ao utilizador criar sua residência
        novoUsuario.Residencia.CriarResidencia(username);

        // Adiciona o novo utilizador à lista de utilizadores
        utilizadores.Add(novoUsuario);

        // Salva a lista de utilizadores no ficheiro JSON
        SalvarUsuarios(ficheiroUtilizador, utilizadores);

        // Chama o Menu Residência
        novoUsuario.Residencia.MenuResidencia(username);
    }

    // Função para validar o nome de utilizador
    public  bool ValidarUsername(string username)
    {
        // Verifica se o username é nulo ou vazio
        if (string.IsNullOrEmpty(username))
        {
            return false;
        }

        // Verifica se o username tem mais de 8 caracteres
        if (username.Length > 8)
        {
            return false;
        }

        // Verifica se o username contém apenas letras e números (usando expressão regular)
        var regex = new Regex("^[a-zA-Z0-9]*$");
        return regex.IsMatch(username);
    }

    // Função para verificar se o nome de utilizador já existe
    public  bool UtilizadorExistente(string username)
    {
        return utilizadores.Exists(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
    }


    // Função para salvar a lista de utilizadores no ficheiro JSON
    private void SalvarUsuarios(string ficheiro, List<Utilizador> usuarios)
    {
        string json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ficheiro, json);
    }



}
