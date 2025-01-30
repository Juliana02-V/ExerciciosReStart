using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjSuperClean_Juliana.Vaz;

internal class Residencia
{
    public int DivisaoId { get; set; }
    public List<Piso> Pisos { get; set; } = new List<Piso>();  // Lista de Pisos
    public int proximoId;
    public Residencia()
    {
        Pisos = new List<Piso>();
        proximoId = 1; // O primeiro ID a ser gerado
    }
    Saudacao saudacao = new Saudacao();

    // Método para o utilizador criar a residência
    public void CriarResidencia(string username)
    {
        Console.Write("Quantos pisos tem a sua residência? ");
        int numPisos;

        // Validação para garantir que o usuário insira um número válido de pisos
        while (!int.TryParse(Console.ReadLine(), out numPisos) || numPisos <= 0)
        {
            Console.Write("Por favor, insira um número válido para o número de pisos: ");
        }

        for (int i = 0; i < numPisos; i++)
        {
            string nomePiso = $"Piso {i + 1}";
            var piso = new Piso { Name = nomePiso };
            Pisos.Add(piso);

            Console.Write($"Quantas divisões tem o {nomePiso}? ");
            int numDivisao;

            // Validação para garantir que o número de divisões seja válido
            while (!int.TryParse(Console.ReadLine(), out numDivisao) || numDivisao <= 0)
            {
                Console.Write("Por favor, insira um número válido para o número de divisões: ");
            }

            for (int j = 0; j < numDivisao; j++)
            {
                string nomeDivisao;

                // Valida que o nome da divisão tenha no máximo 10 caracteres e não seja vazio
                do
                {
                    Console.Write($"Digite o nome da {j + 1}ª divisão do {nomePiso} (máximo 10 caracteres): ");
                    nomeDivisao = Console.ReadLine();

                    if (nomeDivisao.Length > 10)
                        Console.Write("Nome da divisão não pode exceder 10 caracteres. Tente novamente: ");

                } while (nomeDivisao.Length > 10 || string.IsNullOrWhiteSpace(nomeDivisao));

                // Perguntar o tempo de limpeza em minutos
                int cleanTime;
                Console.Write($"Digite o tempo de limpeza (em minutos) da divisão {nomeDivisao}: ");
                while (!int.TryParse(Console.ReadLine(), out cleanTime) || cleanTime <= 0)
                {
                    Console.Write("Por favor, insira um número válido para o tempo de limpeza (em minutos): ");
                }

                // Perguntar o intervalo de limpeza esperado em dias
                int cleanInterval;
                Console.Write($"Digite o intervalo de limpeza (em dias) da divisão {nomeDivisao}: ");
                while (!int.TryParse(Console.ReadLine(), out cleanInterval) || cleanInterval <= 0)
                {
                    Console.Write("Por favor, insira um número válido para o intervalo de limpeza (em dias): ");
                }

                // Perguntar a data da última limpeza
                DateTime ultimaLimpeza;
                while (true)
                {
                    Console.Write($"Data da última limpeza da {nomeDivisao} (formato dd/mm/aaaa): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ultimaLimpeza))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Formato de data inválido. Tente novamente: ");
                    }
                }

                // Calcular a data prevista para a próxima limpeza
                DateTime dataPrevista = ultimaLimpeza.AddDays(cleanInterval);

                // Criando a divisão com um ID único e crescente
                var divisao = new Divisao
                {
                    Id = proximoId,
                    Name = nomeDivisao,
                    CleanTime = cleanTime,
                    CleanInterval = cleanInterval,
                    UltimaLimpeza = ultimaLimpeza,
                    DataPrevistaLimpeza = dataPrevista
                };

                piso.Divisoes.Add(divisao);

                // Incrementando o contador para o próximo ID
                proximoId++;
            }
        }
    }

    public void MenuResidencia(string username)
    {
        Console.Clear();

        saudacao.saudacao1();
        bool continuar = true;

        while (continuar)
        {
            Utilizador utilizador = new Utilizador();



            Console.WriteLine("1- Ver Residência.");
            Console.WriteLine("2- Ver Status Residência.");
            Console.WriteLine("3- Editar Residência.");
            Console.WriteLine("4- Registar nova limpeza.");
            Console.WriteLine("5- Remover ultima limpeza.");
            Console.WriteLine("6- Ver limpeza prioritaria.");
            Console.WriteLine("7- Exibir datas futuras.");
            Console.WriteLine("8- Exibir datas prioritarias.");
            Console.WriteLine("9- Eliminar o utilizador");
            Console.WriteLine("10- Fazer Logout");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":


                    VerResidencia(username);
                    break;
                case "2":
                    VerResidencia1(username, dataAtual);
                    break;
                case "3":
                    EditarResidencia(username);
                    break;
                case "4":
                    Console.WriteLine("Digite o ID da divisão para marcar a limpeza:");
                    string idLimpeza = Console.ReadLine();
                    MarcarLimpeza(idLimpeza, username);
                    break;
                case "5":
                    Console.WriteLine("Digite o ID da divisão para marcar a limpeza:");
                    string idLimpeza1 = Console.ReadLine();
                    RemoverUltimaLimpeza(idLimpeza1, username);
                    break;
                case "6":

                    VerLimpezaMaisPrioritaria(username);
                    break;
                case "7":
                    VerResidencia2(username);
                    break;
                case "8":
                  VerTodasDivisoesPorPrioridade(username); 
                    
                    break;
                case "9":
                    utilizador.ApagarUtilizador(username);
                    break;

                case "10":
                    Console.WriteLine("Vai sair da sua conta");
                    Program.Main();

                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

    }

    private void VerResidencia(string username)
    {
        Console.Clear();
        string caminhoFicheiro = "utilizadores.json"; // Caminho do arquivo JSON associado ao username

        if (File.Exists(caminhoFicheiro))
        {
            // Ler o conteúdo do arquivo
            string json = File.ReadAllText(caminhoFicheiro);

            // Deserializar o JSON para uma lista de utilizadores
            var utilizadores = System.Text.Json.JsonSerializer.Deserialize<List<Utilizador>>(json);

            // Procurar o utilizador pelo username
            var utilizador = utilizadores?.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (utilizador != null)
            {

                // Verificar e exibir a residência corretamente
                if (utilizador.Residencia.Pisos.Count > 0)
                {
                    Console.WriteLine($"Residência: {username}");
                    foreach (var piso in utilizador.Residencia.Pisos)
                    {
                        Console.WriteLine($"- {piso.Name}");
                        foreach (var divisao in piso.Divisoes)
                        {
                            Console.WriteLine($"  - {divisao.Id} {divisao.Name}");
                        }
                    }
                }
                else
                {
                    saudacao.saudacao1();
                    Console.WriteLine("A residência não possui pisos ou divisões.");
                }
            }
            else
            {
                saudacao.saudacao1();
                Console.WriteLine("Não existe o arquivo de utilizadores.");
            }
            Console.WriteLine();
        }

    }

    private void EditarResidencia(string username)
    {
        Piso piso = new Piso();
        Divisao divisao = new Divisao();
        saudacao.saudacao1();
        Console.WriteLine("O que você deseja editar?");
        Console.WriteLine("1 - Adicionar piso");
        Console.WriteLine("2 - Apagar piso");
        Console.WriteLine("3 - Editar divisão");
        Console.WriteLine("4 - Apagar divisão");
        Console.WriteLine("5 - Adicionar divisão");

        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                piso.AdicionarPiso(username);
                break;

            case "2":
                piso.RemoverPiso(username);
                break;

            case "3":
                divisao.EditarDivisao(username);
                break;

            case "4":
                divisao.ApagarDivisao(username);
                break;

            case "5":
                divisao.AdicionarDivisao(username);
                break;

            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }

    private void VerResidencia1(string username, DateTime data)
    {
        Console.Clear();
        string caminhoFicheiro = "utilizadores.json"; // Caminho do arquivo JSON associado ao username

        if (File.Exists(caminhoFicheiro))
        {
            // Ler o conteúdo do arquivo
            string json = File.ReadAllText(caminhoFicheiro);

            // Deserializar o JSON para uma lista de utilizadores
            var utilizadores = System.Text.Json.JsonSerializer.Deserialize<List<Utilizador>>(json);

            // Procurar o utilizador pelo username
            var utilizador = utilizadores?.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (utilizador != null)
            {
                // Verificar e exibir a residência corretamente
                if (utilizador.Residencia.Pisos.Count > 0)
                {
                    Console.WriteLine($"Residência: {username}");
                    foreach (var piso in utilizador.Residencia.Pisos)
                    {
                        Console.WriteLine($"- {piso.Name}");
                        piso.ExibirDivisoes(data); // Exibe as divisões com cores e barras
                    }
                }
                else
                {
                    Console.WriteLine("A residência não possui pisos ou divisões.");
                }
            }
            else
            {
                Console.WriteLine("Não existe o arquivo de utilizadores.");
            }
            Console.WriteLine();
        }
    }

    public void VerLimpezaMaisPrioritaria(string username)
    {
        Console.Clear();
        string caminhoFicheiro = "utilizadores.json";

        if (File.Exists(caminhoFicheiro))
        {
            string json = File.ReadAllText(caminhoFicheiro);
            var utilizadores = JsonSerializer.Deserialize<List<Utilizador>>(json);

            if (utilizadores != null)
            {
                var utilizador = utilizadores.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                if (utilizador != null)
                {
                    var todasDivisoes = utilizador.Residencia.Pisos.SelectMany(p => p.Divisoes).ToList();

                    if (todasDivisoes.Count > 0)
                    {
                        // Ordenar por prioridade: dias atrasados em ordem decrescente
                        var divisaoPrioritaria = todasDivisoes
                            .OrderByDescending(d => (DateTime.Now - d.DataPrevistaLimpeza).Days) // Dias atrasados
                            .ThenBy(d => d.DataPrevistaLimpeza) // Caso nenhuma esteja atrasada, menor data prevista
                            .First();

                        int diasAtrasados = (DateTime.Now - divisaoPrioritaria.DataPrevistaLimpeza).Days;
                        string estado = diasAtrasados > 0 ? $"{diasAtrasados} dias atrasados" :
                            diasAtrasados == 0 ? "Data prevista é hoje" :
                            $"Faltam {Math.Abs(diasAtrasados)} dias";

                        Console.WriteLine($"Limpeza mais prioritária:");
                        Console.WriteLine($"(ID: {divisaoPrioritaria.Id} Divisão: {divisaoPrioritaria.Name} )");
                        Console.WriteLine($"Estado: {estado}");
                        Console.WriteLine($"Última limpeza: {divisaoPrioritaria.UltimaLimpeza:dd/MM/yyyy}");
                        Console.WriteLine($"Data prevista: {divisaoPrioritaria.DataPrevistaLimpeza:dd/MM/yyyy}");
                        Console.WriteLine();
                        // Perguntar ao utilizador se deseja registrar uma nova limpeza
                        Console.WriteLine("Deseja registar a limpeza agora? (s/n)");
                        string resposta = Console.ReadLine();

                        if (resposta?.ToLower() == "s")
                        {
                            // Registrar a limpeza com a data atual
                            divisaoPrioritaria.UltimaLimpeza = DateTime.Now;
                            divisaoPrioritaria.DataPrevistaLimpeza = DateTime.Now.AddDays(divisaoPrioritaria.CleanInterval);

                            // Atualizar o arquivo JSON
                            string jsonAtualizado = JsonSerializer.Serialize(utilizadores, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText(caminhoFicheiro, jsonAtualizado);

                            Console.WriteLine("Limpeza registada com sucesso!");
                            Console.WriteLine($"Nova data prevista de limpeza: {divisaoPrioritaria.DataPrevistaLimpeza:dd/MM/yyyy}");
                        }
                        else
                        {
                            Console.WriteLine("A limpeza não foi registada.");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Não há divisões para verificar a prioridade.");
                    }
                }
                else
                {
                    Console.WriteLine("Utilizador não encontrado.");
                }
            }
        }
        else
        {
            Console.WriteLine("O ficheiro de utilizadores não existe.");
        }
    }

    public void MarcarLimpeza(string divisaoId, string username)
    {
        string caminhoFicheiro = "utilizadores.json"; // Caminho do arquivo JSON

        if (File.Exists(caminhoFicheiro))
        {
            // Ler o conteúdo do arquivo
            string json = File.ReadAllText(caminhoFicheiro);

            // Deserializar o JSON para uma lista de utilizadores
            var utilizadores = JsonSerializer.Deserialize<List<Utilizador>>(json);

            if (utilizadores != null)
            {
                // Encontrar o utilizador pelo username
                var utilizador = utilizadores.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                if (utilizador != null)
                {
                    // Procurar a divisão pela ID fornecida (dentro dos pisos e divisões do utilizador)
                    var divisao = utilizador.Residencia.Pisos
                        .SelectMany(p => p.Divisoes)
                        .FirstOrDefault(d => d.Id.ToString() == divisaoId);

                    if (divisao != null)
                    {
                        // Marcar a limpeza
                        divisao.UltimaLimpeza = DateTime.Now;
                        divisao.DataPrevistaLimpeza = DateTime.Now.AddDays(divisao.CleanInterval);

                        Console.WriteLine($"Limpeza registrada na divisão {divisao.Name} com sucesso!");
                        Console.WriteLine($"Última limpeza: {divisao.UltimaLimpeza:dd/MM/yyyy}");
                        Console.WriteLine($"Próxima limpeza prevista para: {divisao.DataPrevistaLimpeza:dd/MM/yyyy}");

                        // Atualizar o arquivo JSON
                        string jsonAtualizado = JsonSerializer.Serialize(utilizadores, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(caminhoFicheiro, jsonAtualizado);
                    }
                    else
                    {
                        Console.WriteLine($"Divisão com ID {divisaoId} não encontrada.");
                    }
                }
                else
                {
                    Console.WriteLine($"Utilizador com username {username} não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Erro ao carregar os utilizadores do arquivo.");
            }
        }
        else
        {
            Console.WriteLine("O arquivo de utilizadores não existe.");
        }
    }

    public void RemoverUltimaLimpeza(string divisaoId, string username)
    {
        string caminhoFicheiro = "utilizadores.json"; // Caminho do arquivo JSON

        if (File.Exists(caminhoFicheiro))
        {
            // Ler o conteúdo do arquivo
            string json = File.ReadAllText(caminhoFicheiro);

            // Deserializar o JSON para uma lista de utilizadores
            var utilizadores = JsonSerializer.Deserialize<List<Utilizador>>(json);

            if (utilizadores != null)
            {
                // Encontrar o utilizador pelo username
                var utilizador = utilizadores.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                if (utilizador != null)
                {
                    // Procurar a divisão pela ID fornecida (dentro dos pisos e divisões do utilizador)
                    var divisao = utilizador.Residencia.Pisos
                        .SelectMany(p => p.Divisoes)
                        .FirstOrDefault(d => d.Id.ToString() == divisaoId);

                    if (divisao != null)
                    {
                        // Remover a última limpeza
                        divisao.UltimaLimpeza = DateTime.MinValue;
                        divisao.DataPrevistaLimpeza = DateTime.MinValue;

                        Console.WriteLine($"Última limpeza removida para a divisão {divisao.Name}.");

                        // Atualizar o arquivo JSON
                        string jsonAtualizado = JsonSerializer.Serialize(utilizadores, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(caminhoFicheiro, jsonAtualizado);
                    }
                    else
                    {
                        Console.WriteLine($"Divisão com ID {divisaoId} não encontrada.");
                    }
                }
                else
                {
                    Console.WriteLine($"Utilizador com username {username} não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Erro ao carregar os utilizadores do arquivo.");
            }
        }
        else
        {
            Console.WriteLine("O arquivo de utilizadores não existe.");
        }
    }

    private DateTime dataAtual = DateTime.Now; // Variável para armazenar a data atual.

    private void VerResidencia2(string username)
    {
        Console.Clear();
        string caminhoFicheiro = "utilizadores.json"; // Caminho do arquivo JSON associado ao username

        if (File.Exists(caminhoFicheiro))
        {
            // Ler o conteúdo do arquivo
            string json = File.ReadAllText(caminhoFicheiro);

            // Deserializar o JSON para uma lista de utilizadores
            var utilizadores = System.Text.Json.JsonSerializer.Deserialize<List<Utilizador>>(json);

            // Procurar o utilizador pelo username
            var utilizador = utilizadores?.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (utilizador != null)
            {
                // Exibir o nome de usuário e a data atual
                Console.WriteLine($"Residência: {username} - Data Atual: {dataAtual.ToShortDateString()}");

                // Verificar e exibir a residência corretamente
                if (utilizador.Residencia.Pisos.Count > 0)
                {
                    // Exibe os pisos e as divisões com base na data atual
                    foreach (var piso in utilizador.Residencia.Pisos)
                    {
                        Console.WriteLine($"- {piso.Name}");

                        // Calcular os dias de atraso para cada divisão
                        foreach (var divisao in piso.Divisoes)
                        {
                            var atraso = (dataAtual - divisao.DataPrevistaLimpeza).Days; // Calcular a diferença em dias
                            var numeroDeBarras = Math.Max(1, atraso / 2); // Exibe pelo menos 1 barra, mas mais conforme o atraso

                            // Exibir a divisão com barras dinâmicas
                            Console.WriteLine($"{divisao.Name}: {new string('|', numeroDeBarras)} (Atraso: {atraso} dias)");
                        }
                    }

                    // Instruções para navegação de data
                    Console.WriteLine("Use as setas para alterar a data (esquerda/direita).");
                    Console.WriteLine("Pressione 'Esc' para voltar ao menu.");

                    bool continuar = true;

                    while (continuar)
                    {
                        var key = Console.ReadKey(intercept: true); // Captura a tecla pressionada sem exibir no console

                        if (key.Key == ConsoleKey.LeftArrow)
                        {
                            // Mover a data para trás (anterior)
                            dataAtual = dataAtual.AddDays(-1);
                            Console.Clear();

                            VerResidencia2(username); // Atualiza a visualização com a nova data e barras
                        }
                        else if (key.Key == ConsoleKey.RightArrow)
                        {
                            // Mover a data para frente (futuro)
                            dataAtual = dataAtual.AddDays(1);
                            Console.Clear();
                            VerResidencia2(username); // Atualiza a visualização com a nova data e barras
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            continuar = false; // Sai do loop e volta ao menu
                        }
                    }

                    // Quando o usuário pressionar 'Esc', voltará ao menu principal
                    Console.Clear();
                    MenuResidencia(username); // Chama a função do menu principal
                }
                else
                {
                    Console.WriteLine("A residência não possui pisos ou divisões.");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    MenuResidencia(username); // Retorna ao menu
                }
            }
            else
            {
                Console.WriteLine("Não existe o arquivo de utilizadores.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                MenuResidencia(username); // Retorna ao menu
            }
        }
        else
        {
            Console.WriteLine("Arquivo 'utilizadores.json' não encontrado.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            MenuResidencia(username); // Retorna ao menu
        }
    }

    public void VerTodasDivisoesPorPrioridade(string username)
    {
        Console.Clear();
        string caminhoFicheiro = "utilizadores.json";

        if (File.Exists(caminhoFicheiro))
        {
            string json = File.ReadAllText(caminhoFicheiro);
            var utilizadores = JsonSerializer.Deserialize<List<Utilizador>>(json);

            if (utilizadores != null)
            {
                var utilizador = utilizadores.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                if (utilizador != null)
                {
                    var todasDivisoes = utilizador.Residencia.Pisos.SelectMany(p => p.Divisoes).ToList();

                    if (todasDivisoes.Count > 0)
                    {
                        // Ordenar por prioridade: dias atrasados em ordem decrescente
                        var divisoesOrdenadas = todasDivisoes
                            .OrderByDescending(d => (DateTime.Now - d.DataPrevistaLimpeza).Days) // Dias atrasados
                            .ThenBy(d => d.DataPrevistaLimpeza) // Caso nenhuma esteja atrasada, menor data prevista
                            .ToList();

                        Console.WriteLine("Todas as divisões ordenadas por prioridade de limpeza:");

                        foreach (var divisao in divisoesOrdenadas)
                        {
                            int diasAtrasados = (DateTime.Now - divisao.DataPrevistaLimpeza).Days;
                            string estado = diasAtrasados > 0 ? $"{diasAtrasados} dias atrasados" :
                                diasAtrasados == 0 ? "Data prevista é hoje" :
                                $"Faltam {Math.Abs(diasAtrasados)} dias";

                            Console.WriteLine($"ID: {divisao.Id}, Divisão: {divisao.Name}");
                            Console.WriteLine($"Estado: {estado}");
                            Console.WriteLine($"Última limpeza: {divisao.UltimaLimpeza:dd/MM/yyyy}");
                            Console.WriteLine($"Data prevista: {divisao.DataPrevistaLimpeza:dd/MM/yyyy}");
                            Console.WriteLine();
                        }

                        // Perguntar ao utilizador se deseja registrar a limpeza de alguma divisão
                        Console.WriteLine("Deseja registar a limpeza de alguma divisão agora? (s/n)");
                        string resposta = Console.ReadLine();

                        if (resposta?.ToLower() == "s")
                        {
                            Console.WriteLine("Qual ID da divisão deseja registrar a limpeza?");
                            int idDivisao = int.Parse(Console.ReadLine());

                            var divisaoParaLimpar = divisoesOrdenadas.FirstOrDefault(d => d.Id == idDivisao);

                            if (divisaoParaLimpar != null)
                            {
                                // Registrar a limpeza com a data atual
                                divisaoParaLimpar.UltimaLimpeza = DateTime.Now;
                                divisaoParaLimpar.DataPrevistaLimpeza = DateTime.Now.AddDays(divisaoParaLimpar.CleanInterval);

                                // Atualizar o arquivo JSON
                                string jsonAtualizado = JsonSerializer.Serialize(utilizadores, new JsonSerializerOptions { WriteIndented = true });
                                File.WriteAllText(caminhoFicheiro, jsonAtualizado);

                                Console.WriteLine("Limpeza registada com sucesso!");
                                Console.WriteLine($"Nova data prevista de limpeza: {divisaoParaLimpar.DataPrevistaLimpeza:dd/MM/yyyy}");
                            }
                            else
                            {
                                Console.WriteLine("ID de divisão não encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma divisão foi registada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há divisões para verificar a prioridade.");
                    }
                }
                else
                {
                    Console.WriteLine("Utilizador não encontrado.");
                }
            }
        }
        else
        {
            Console.WriteLine("O ficheiro de utilizadores não existe.");
        }
    }

}
