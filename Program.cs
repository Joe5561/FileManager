using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args) {

        while (true) {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar diretório atual");
            Console.WriteLine("2 - Criar diretório");
            Console.WriteLine("3 - Criar arquivo");
            Console.WriteLine("4 - Mover arquivo");
            Console.WriteLine("5 - Excluir arquivo ou diretório");
            Console.WriteLine("6 - Sair");

            string opcao = Console.ReadLine();

            switch (opcao) {
                case "1":
                    ListarDiretorioAtual();
                    break;
                case "2":
                    CriarDiretorio();
                    break;
                case "3":
                    CriarArquivo();
                    break;
                case "4":
                    MoverArquivo();
                    break;
                case "5":
                    ExcluirArquivoOuDiretorio();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    public static void ListarDiretorioAtual() {
        string diretorioAtual = Directory.GetCurrentDirectory();
        Console.WriteLine($"Conteúdo do diretório '{diretorioAtual}':");

        string[] subdiretorios = Directory.GetDirectories(diretorioAtual);
        foreach (string subdiretorio in subdiretorios) {
            Console.WriteLine($"[{subdiretorio}]");
        }

        string[] arquivos = Directory.GetFiles(diretorioAtual);
        foreach (string arquivo in arquivos) {
            Console.WriteLine(arquivo);
        }
    }

    public static void ExcluirArquivoOuDiretorio() {
        Console.WriteLine("Digite o caminho completo do arquivo ou diretório a ser excluído:");
        string caminho = Console.ReadLine();

        if (File.Exists(caminho)) {
            File.Delete(caminho);
            Console.WriteLine($"Arquivo {caminho} excluído com sucesso!");
        } else if (Directory.Exists(caminho)) {
            Directory.Delete(caminho, true);
            Console.WriteLine($"Diretório {caminho} excluído com sucesso!");
        } else {
            Console.WriteLine($"Não foi possível encontrar o arquivo ou diretório {caminho}.");
        }
    }


    public static void ListarDiretorioAtual(string nome) {
        string diretorioAtual = Directory.GetCurrentDirectory();
        Console.WriteLine($"Conteúdo do diretório atual: {diretorioAtual}");

        string[] arquivos = Directory.GetFiles(diretorioAtual);
        Console.WriteLine("Arquivos:");
        foreach (string arquivo in arquivos) {
            Console.WriteLine($"- {Path.GetFileName(arquivo)}");
        }

        string[] subdiretorios = Directory.GetDirectories(diretorioAtual);
        Console.WriteLine("Subdiretórios:");
        foreach (string subdiretorio in subdiretorios) {
            Console.WriteLine($"- {Path.GetFileName(subdiretorio)}");
        }
    }


    static void CriarDiretorio() {
        Console.Write("Digite o nome do diretório a ser criado: ");
        string nomeDiretorio = Console.ReadLine();
        string diretorioAtual = Directory.GetCurrentDirectory();
        string caminhoNovoDiretorio = Path.Combine(diretorioAtual, nomeDiretorio);

        if (Directory.Exists(caminhoNovoDiretorio)) {
            Console.WriteLine($"O diretório '{nomeDiretorio}' já existe.");
        } else {
            Directory.CreateDirectory(caminhoNovoDiretorio);
            Console.WriteLine($"Diretório '{nomeDiretorio}' criado com sucesso.");
        }
    }

    static void CriarArquivo() {
        Console.Write("Digite o nome do arquivo a ser criado: ");
        string nomeArquivo = Console.ReadLine();
        string diretorioAtual = Directory.GetCurrentDirectory();
        string caminhoNovoArquivo = Path.Combine(diretorioAtual, nomeArquivo);

        if (File.Exists(caminhoNovoArquivo)) {
            Console.WriteLine($"O arquivo '{nomeArquivo}' já existe.");
        } else {
            Console.Write("Digite o conteúdo do arquivo: ");
            string conteudoArquivo = Console.ReadLine();
            File.WriteAllText(caminhoNovoArquivo, conteudoArquivo);
            Console.WriteLine($"Arquivo '{nomeArquivo}' criado com sucesso.");
        }
    }

    static void MoverArquivo() {
        Console.Write("Digite o nome do arquivo a ser movido: ");
        string nomeArquivo = Console.ReadLine();
        string diretorioAtual = Directory.GetCurrentDirectory();
        string caminhoOrigemArquivo = Path.Combine(diretorioAtual, nomeArquivo);

        if (!File.Exists(caminhoOrigemArquivo)) {
            Console.WriteLine($"O arquivo '{nomeArquivo}' não foi encontrado no diretório atual.");
        } else {
            Console.Write("Digite o caminho completo do diretório de destino: ");
            string caminhoDestino = Console.ReadLine();

            if (!Directory.Exists(caminhoDestino)) {
                Console.WriteLine($"O diretório de destino '{caminhoDestino}' não foi encontrado.");
            } else {
                string caminhoDestinoArquivo = Path.Combine(caminhoDestino, nomeArquivo);
                File.Move(caminhoOrigemArquivo, caminhoDestinoArquivo);
                Console.WriteLine($"O arquivo '{nomeArquivo}' foi movido para o diretório '{caminhoDestino}'.");
            }
        }
    }
}