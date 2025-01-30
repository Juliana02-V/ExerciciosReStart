using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjSuperClean_Juliana.Vaz;

internal class Divisao
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CleanTime { get; set; } // Tempo de limpeza em minutos
    public int CleanInterval { get; set; } // Intervalo de limpeza em dias
    public DateTime UltimaLimpeza { get; set; } // Última data de limpeza
    public DateTime DataPrevistaLimpeza { get; set; } // Data prevista para a próxima limpeza
  


    public void EditarDivisao(string username)
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
                    Console.WriteLine("Qual piso você deseja editar?");
                    for (int i = 0; i < utilizador.Residencia.Pisos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {utilizador.Residencia.Pisos[i].Name}");
                    }

                    // Validar entrada do piso
                    if (!int.TryParse(Console.ReadLine(), out int pisoIndex) || pisoIndex < 1 || pisoIndex > utilizador.Residencia.Pisos.Count)
                    {
                        Console.WriteLine("Entrada inválida. Por favor, insira um número correspondente ao piso.");
                        return;
                    }
                    pisoIndex--; // Ajustar para índice baseado em zero

                    Console.WriteLine("Qual divisão você deseja editar?");
                    for (int i = 0; i < utilizador.Residencia.Pisos[pisoIndex].Divisoes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {utilizador.Residencia.Pisos[pisoIndex].Divisoes[i].Name} (ID: {utilizador.Residencia.Pisos[pisoIndex].Divisoes[i].Id})");
                    }

                    // Validar entrada da divisão
                    if (!int.TryParse(Console.ReadLine(), out int divisaoIndex) || divisaoIndex < 1 || divisaoIndex > utilizador.Residencia.Pisos[pisoIndex].Divisoes.Count)
                    {
                        Console.WriteLine("Entrada inválida. Por favor, insira um número correspondente à divisão.");
                        return;
                    }
                    divisaoIndex--; // Ajustar para índice baseado em zero

                    var divisao = utilizador.Residencia.Pisos[pisoIndex].Divisoes[divisaoIndex];
                    Console.WriteLine($"Você está editando a divisão: {divisao.Name} (ID: {divisao.Id})");

                    // Perguntar ao usuário o novo nome da divisão
                    Console.Write("Digite o novo nome para a divisão: ");
                    string novoNome = Console.ReadLine();

                    // Atualizar o nome da divisão
                    divisao.Name = novoNome;

                    // Atualizar o arquivo JSON com as mudanças
                    string jsonAtualizado = JsonSerializer.Serialize(utilizadores, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(caminhoFicheiro, jsonAtualizado);

                    Console.WriteLine($"Divisão com ID {divisao.Id} foi editada com sucesso para {divisao.Name}.");
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

    public void ApagarDivisao(string username)
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
                    // Perguntar o ID da divisão que o utilizador deseja apagar
                    Console.Write("Digite o ID da divisão que deseja apagar: ");
                    int idDivisao = int.Parse(Console.ReadLine());

                    // Procurar pela divisão
                    bool divisaoEncontrada = false;

                    // Percorrer os pisos e divisões para encontrar a divisão com o ID fornecido
                    foreach (var piso in utilizador.Residencia.Pisos)
                    {
                        var divisao = piso.Divisoes.FirstOrDefault(d => d.Id == idDivisao);
                        if (divisao != null)
                        {
                            // Remover a divisão do piso
                            piso.Divisoes.Remove(divisao);
                            divisaoEncontrada = true;
                            Console.WriteLine($"Divisão com ID {idDivisao} removida com sucesso.");
                            break;
                        }
                    }

                    if (!divisaoEncontrada)
                    {
                        Console.WriteLine("Divisão não encontrada com o ID fornecido.");
                    }

                    // Atualizar o arquivo JSON com as alterações
                    string jsonAtualizado = JsonSerializer.Serialize(utilizadores, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(caminhoFicheiro, jsonAtualizado);
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

    public void AdicionarDivisao(string username)
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
                    // Perguntar em qual piso o utilizador deseja adicionar a divisão
                    Console.WriteLine("Escolha o piso em que deseja adicionar a nova divisão:");
                    for (int i = 0; i < utilizador.Residencia.Pisos.Count; i++)
                    {
                        Console.WriteLine($"{i} - {utilizador.Residencia.Pisos[i].Name}");
                    }

                    // Ler a escolha do utilizador
                    int numeroPisoEscolhido = int.Parse(Console.ReadLine());

                    if (numeroPisoEscolhido >= 0 && numeroPisoEscolhido < utilizador.Residencia.Pisos.Count)
                    {
                        // Encontrar o piso escolhido
                        var pisoEscolhido = utilizador.Residencia.Pisos[numeroPisoEscolhido];

                        // Encontrar o maior ID de divisões já existentes em todos os pisos
                        int maiorIdDivisao = utilizador.Residencia.Pisos
                            .SelectMany(piso => piso.Divisoes)
                            .Max(divisao => divisao.Id);

                        // O ID da nova divisão será o próximo número
                        int novoIdDivisao = maiorIdDivisao + 1;

                        // Perguntar ao utilizador o nome da nova divisão
                        Console.Write($"Digite o nome da nova divisão para o {pisoEscolhido.Name} (máximo 10 caracteres):\t");
                        string nomeDivisao = Console.ReadLine();

                        // Garantir que o nome da divisão não exceda 10 caracteres
                        if (nomeDivisao.Length > 10)
                        {
                            Console.WriteLine("Nome da divisão não pode exceder 10 caracteres. Tente novamente.");
                            nomeDivisao = Console.ReadLine();
                        }

                        // Perguntar o tempo de limpeza em minutos
                        Console.Write($"Digite o tempo de limpeza (em minutos) da divisão {nomeDivisao}:\t");
                        int cleanTime = int.Parse(Console.ReadLine());

                        // Perguntar o intervalo de limpeza esperado em dias
                        Console.Write($"Digite o intervalo de limpeza (em dias) da divisão {nomeDivisao}:\t");
                        int cleanInterval = int.Parse(Console.ReadLine());

                        // Perguntar a data da última limpeza
                        Console.Write($"Digite a data da última limpeza da divisão {nomeDivisao} (formato dd/mm/aaaa):\t");
                        DateTime ultimaLimpeza = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

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

                        // Adicionar a nova divisão ao piso escolhido
                        pisoEscolhido.Divisoes.Add(novaDivisao);

                        // Atualizar o arquivo JSON com as mudanças
                        string jsonAtualizado = JsonSerializer.Serialize(utilizadores, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(caminhoFicheiro, jsonAtualizado);

                        Console.WriteLine($"A divisão '{nomeDivisao}' foi adicionada com sucesso no {pisoEscolhido.Name}.");
                    }
                    else
                    {
                        Console.WriteLine("Piso não encontrado.");
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

    // Método para calcular os dias desde a última limpeza
    public int DiasDesdeUltimaLimpeza()
    {
        if (UltimaLimpeza == DateTime.MinValue) return int.MaxValue; // Nunca foi limpa
        return (DateTime.Now - UltimaLimpeza).Days;

    }

    // Método para calcular os dias desde a data prevista de limpeza
    public int DiasDesdeDataPrevista()
    {
        if (DataPrevistaLimpeza == DateTime.MinValue) return int.MinValue; // Sem previsão
        return (DateTime.Now - DataPrevistaLimpeza).Days;
    }


    // Método para determinar a cor com base nos dias desde a última limpeza
    public ConsoleColor ObterCorLimpeza()
    {
        int diasAtrasados = DiasDesdeDataPrevista(); // Dias desde a data prevista de limpeza
        int diasDesdeUltima = DiasDesdeUltimaLimpeza(); // Dias desde a última limpeza

        if (diasAtrasados > 2)
        {
            return ConsoleColor.Red; // Atraso significativo
        }
        else if (diasAtrasados >= -1 && diasAtrasados <= 2)
        {
            return ConsoleColor.Yellow; // Intervalo crítico
        }
        else if (diasDesdeUltima <= 1 || diasAtrasados < -1)
        {
            return ConsoleColor.Green; // Limpeza recente ou ainda no prazo
        }

        return ConsoleColor.Gray; // Caso padrão
    }

    public int CalcularBarrasLimpeza()
    {
        int diasDesdeUltima = DiasDesdeUltimaLimpeza();
        int diasAtrasados = DiasDesdeDataPrevista();
        int maxBarras = 20;

        if (diasAtrasados > 0)
        {
            // Atraso em relação à data prevista
            return Math.Min(diasAtrasados, maxBarras);
        }
        else
        {
            // Dias desde a última limpeza, dentro do prazo
            return Math.Min(diasDesdeUltima, maxBarras);
        }
    }

    public void ExibirBarraLimpeza()
    {
        int barras = CalcularBarrasLimpeza();
        int diasAtrasados = DiasDesdeDataPrevista();
        int diasDesdeUltima = DiasDesdeUltimaLimpeza();

        // Exibe a quantidade de barras e os dias restantes ou em atraso
        if (diasAtrasados > 0)
        {
            // Exibe um texto explicativo indicando que a limpeza está atrasada
            Console.WriteLine($"{new string('|', barras)}");
        }
        else if (diasAtrasados <= 0 && diasDesdeUltima <= 1)
        {
            // Exibe um texto indicando que a limpeza está dentro do prazo
            Console.WriteLine($"{new string('|', barras)}");
        }
        else
        {
            // Exibe um texto indicando que a limpeza está no intervalo de tempo
            Console.WriteLine($"{new string('|', barras)}");
        }
    }

  
}
