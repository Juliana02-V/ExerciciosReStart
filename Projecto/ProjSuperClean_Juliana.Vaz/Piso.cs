using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjSuperClean_Juliana.Vaz;

internal class Piso
{
    public string Name { get; set; }
    public List<Divisao> Divisoes { get; set; } = new List<Divisao>();


    public Piso()
    {
        Divisoes = new List<Divisao>();
    }

    public void RemoverPiso(string username)
    {
        string caminhoFicheiro = "utilizadores.json"; // Caminho do arquivo JSON

        // Carregar os utilizadores a partir do arquivo JSON
        if (File.Exists(caminhoFicheiro))
        {
            string json = File.ReadAllText(caminhoFicheiro);
            var utilizadores = JsonSerializer.Deserialize<List<Utilizador>>(json);

            if (utilizadores != null)
            {
                // Procurar o utilizador pelo username
                var utilizador = utilizadores.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                if (utilizador != null)
                {
                    // Solicitar o nome do piso a ser removido
                    Console.WriteLine("Digite o nome do piso que você deseja remover:");
                    for (int i = 0; i < utilizador.Residencia.Pisos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {utilizador.Residencia.Pisos[i].Name}");
                    }

                    // O usuário escolhe o piso pelo nome
                    int pisoIndex = int.Parse(Console.ReadLine()) - 1;

                    if (pisoIndex >= 0 && pisoIndex < utilizador.Residencia.Pisos.Count)
                    {
                        // Remover o piso selecionado
                        utilizador.Residencia.Pisos.RemoveAt(pisoIndex);

                        // Atualizar o arquivo JSON com as mudanças
                        string jsonAtualizado = JsonSerializer.Serialize(utilizadores, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(caminhoFicheiro, jsonAtualizado);

                        Console.WriteLine("Piso removido com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Piso inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Utilizador não encontrado.");
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

    public void AdicionarPiso(string username)
    {
        string caminhoFicheiro = "utilizadores.json"; // Caminho do arquivo JSON

        if (File.Exists(caminhoFicheiro))
        {
            string json = File.ReadAllText(caminhoFicheiro);
            var utilizadores = JsonSerializer.Deserialize<List<Utilizador>>(json);

            if (utilizadores != null)
            {
                // Procurar o utilizador pelo username
                var utilizador = utilizadores.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                if (utilizador != null)
                {
                    // Encontrar o maior ID das divisões já existentes
                    int maiorIdDivisao = utilizador.Residencia.Pisos
                        .SelectMany(piso => piso.Divisoes)
                        .Max(divisao => divisao.Id);

                    // O novo ID das divisões será o maior ID + 1
                    int novoIdDivisao = maiorIdDivisao + 1;

                    // Gerar o nome do novo piso (incrementando o número)
                    int novoPisoNumero = utilizador.Residencia.Pisos.Count; // O próximo piso será o número da quantidade atual de pisos
                    string nomePiso = $"Piso {novoPisoNumero}";

                    // Criar o novo piso
                    var novoPiso = new Piso
                    {
                        Name = nomePiso
                    };

                    // Perguntar ao utilizador quantas divisões deseja criar para o novo piso
                    int numDivisoes = 0;
                    while (numDivisoes <= 0)
                    {
                        Console.Write($"Quantas divisões o {nomePiso} terá?\t");
                        if (!int.TryParse(Console.ReadLine(), out numDivisoes) || numDivisoes <= 0)
                        {
                            Console.WriteLine("Entrada inválida. Por favor, insira um número maior que 0.");
                        }
                    }

                    // Criar as divisões para o novo piso
                    for (int i = 0; i < numDivisoes; i++)
                    {
                        string nomeDivisao;
                        while (true)
                        {
                            Console.Write($"Digite o nome da {i + 1}ª divisão do {nomePiso} (máximo 10 caracteres):\t");
                            nomeDivisao = Console.ReadLine();
                            if (nomeDivisao.Length <= 10)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Nome da divisão não pode exceder 10 caracteres. Tente novamente.");
                            }
                        }

                        // Perguntar o tempo de limpeza em minutos
                        int cleanTime;
                        while (true)
                        {
                            Console.Write($"Digite o tempo de limpeza (em minutos) da divisão {nomeDivisao}:\t");
                            if (int.TryParse(Console.ReadLine(), out cleanTime) && cleanTime >= 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Por favor, insira um número válido para o tempo de limpeza.");
                            }
                        }

                        // Perguntar o intervalo de limpeza esperado em dias
                        int cleanInterval;
                        while (true)
                        {
                            Console.Write($"Digite o intervalo de limpeza (em dias) da divisão {nomeDivisao}:\t");
                            if (int.TryParse(Console.ReadLine(), out cleanInterval) && cleanInterval >= 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Por favor, insira um número válido para o intervalo de limpeza.");
                            }
                        }

                        // Perguntar a data da última limpeza
                        DateTime ultimaLimpeza;
                        while (true)
                        {
                            Console.Write($"Digite a data da última limpeza da divisão {nomeDivisao} (formato dd/mm/aaaa):\t");
                            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ultimaLimpeza))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Data inválida. Por favor, insira uma data no formato dd/mm/aaaa.");
                            }
                        }

                        // Calcular a data prevista para a próxima limpeza
                        DateTime dataPrevista = ultimaLimpeza.AddDays(cleanInterval);

                        // Criando a nova divisão com todas as propriedades
                        var novaDivisao = new Divisao
                        {
                            Id = novoIdDivisao,
                            Name = nomeDivisao,
                            CleanTime = cleanTime,
                            CleanInterval = cleanInterval,
                            UltimaLimpeza = ultimaLimpeza,
                            DataPrevistaLimpeza = dataPrevista
                        };

                        // Adicionar a divisão ao piso
                        novoPiso.Divisoes.Add(novaDivisao);

                        // Incrementar o ID para a próxima divisão
                        novoIdDivisao++;
                    }
                }
            }
        }
    }



    // Método para exibir as divisões de um piso com a cor e barras de limpeza
    public void ExibirDivisoes(DateTime data)
    {
        foreach (var divisao in Divisoes)
        {
            Console.Write($" {divisao.Id} - {divisao.Name} ");
            Console.ForegroundColor = divisao.ObterCorLimpeza();
            divisao.ExibirBarraLimpeza();  // Exibe as barras de atraso
            Console.ResetColor();
        }
    }
}
