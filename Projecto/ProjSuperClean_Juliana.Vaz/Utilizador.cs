using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjSuperClean_Juliana.Vaz
{
    internal class Utilizador
    {
        public string Username { get; set; }
        public Residencia Residencia { get; set; }
        public void ApagarUtilizador(string username)
        {
            string caminhoFicheiro = "utilizadores.json"; // Caminho do arquivo JSON

            if (File.Exists(caminhoFicheiro))
            {
                // Ler o conteúdo do arquivo
                string json = File.ReadAllText(caminhoFicheiro);

                // Deserializar a lista de utilizadores
                var listaUtilizadores = JsonSerializer.Deserialize<List<Utilizador>>(json);

                if (listaUtilizadores != null)
                {
                    // Procurar e remover o utilizador correspondente
                    var utilizadorARemover = listaUtilizadores.FirstOrDefault(u => u.Username == username);

                    if (utilizadorARemover != null)
                    {
                        listaUtilizadores.Remove(utilizadorARemover);

                        // Atualizar o arquivo JSON com a lista modificada
                        string jsonAtualizado = JsonSerializer.Serialize(listaUtilizadores, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(caminhoFicheiro, jsonAtualizado);

                        Console.WriteLine($"Utilizador '{username}' foi apagado com sucesso.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Utilizador '{username}' não foi encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("A lista de utilizadores está vazia ou não foi carregada corretamente.");
                }
            }
            else
            {
                Console.WriteLine("O ficheiro de utilizadores não existe.");
            }
        }
    }
}
