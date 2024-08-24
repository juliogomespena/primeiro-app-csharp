/*Modelo de lista*/
//List<string> listaNomes = new List<string> { "Julio", "Lorena", "Davi", "Elias", "Valderez", "Beatriz" };

Dictionary<string, List<long>> listaNomes = new();
listaNomes.Add("JULIO", [11981198884, 1145862516]);
listaNomes.Add("LORENA", [11973695363, 1141587854, 11984854878, 1198757845]);
listaNomes.Add("VALDEREZ", []);

void ExibirMenu()
{

    int opcao;

    Console.Clear();

    BoasVindas();

    Console.WriteLine("\nDigite 1 para registrar pessoas.");
    Console.WriteLine("Digite 2 para exibir todas as pessoas registradas.");
    Console.WriteLine("Digite 3 para adicionar telefones aos registros.");
    Console.WriteLine("Digite 4 para buscar telefone de um registro.");
    Console.WriteLine("Digite 0 para sair.\n");

    Console.WriteLine("Escolha a opção desejada: ");
    opcao = int.Parse(Console.ReadLine()!);

    switch (opcao)
    {

        case 1:
            CriarListaPessoas();
            break;

        case 2:
            ExibirPessoas();
            break;

        case 3:
            AdicionarTelefone();
            break;

        case 4:
            BuscarContato();
            break;

        case 0:
            Console.WriteLine("Você escolheu sair.");
            break;

        default:
            Console.WriteLine("Opção inválida");
            Thread.Sleep(700);
            ExibirMenu();
            break;

    }

}

void CriarListaPessoas()
{

    string nomeDaPessoa;

    Console.Clear();

    ExibirTituloDaOpcao("Registrar pessoas:");

    Console.Write("Digite o nome da pessoa: ");
    nomeDaPessoa = Console.ReadLine()!;
    nomeDaPessoa = nomeDaPessoa.ToUpper();
    listaNomes.Add(nomeDaPessoa, []);

    Console.WriteLine($"A pessoa '{nomeDaPessoa}' foi registrada!");

    Thread.Sleep(1300);

    ExibirMenu();
}

void ExibirPessoas()
{

    /* Código para pessoa digitar SIM/NAO para voltar */
    //string voltarParaMenu;
    //bool voltar = false;
    int contagemRegistro = 1;

    Console.Clear();

    ExibirTituloDaOpcao("Lista de pessoas registradas:");

    /*Loop com for para exibir lista*/
    //for(int i = 0; i < listaNomes.Count; i++)
    //{

    //    Console.WriteLine($"Registro {i+1}: {listaNomes[i]}\n");

    //}

    foreach (string nome in listaNomes.Keys)
    {

        if (listaNomes[nome].Count() != 0)
        {

            Console.Write($"Registro {contagemRegistro}: {nome}. Contatos: ");

            for (int i = 0; i < (listaNomes[nome].Count()); i++)
            {

                Console.Write($"{listaNomes[nome][i]} || ");

            }
        }
        else
        {

            Console.Write($"Registro {contagemRegistro}: {nome}. ");

        }

        contagemRegistro++;
        Console.WriteLine("\n\n");

    }
        
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    ExibirMenu();

    /* Código para pessoa digitar SIM/NAO para voltar */

    //while(voltar == false)
    //{

    //    Console.WriteLine("Deseja voltar para o menu inicial? (Sim/Não)");
    //    voltarParaMenu = Console.ReadLine()!;
    //    voltarParaMenu = voltarParaMenu.ToUpper();

    //    if(voltarParaMenu == "SIM")
    //    {

    //        voltar = true;

    //        Console.Clear();

    //        ExibirMenu();

    //    }
    //    else if(voltarParaMenu == "NAO" || voltarParaMenu == "NÃO")
    //    {
    //        Console.WriteLine("");
    //    }
    //    else
    //    {

    //        Console.WriteLine("Opção inválida!\n");

    //    }

    //}

}

void AdicionarTelefone()
{

    string nomeDaPessoa;
    int contagemRegistro = 1;
    long telefonePessoa;

    Console.Clear();

    ExibirTituloDaOpcao("Adicionar telefone ao registro:");

    foreach (string nome in listaNomes.Keys)
    {

        Console.WriteLine($"Registro {contagemRegistro}: {nome}");
        contagemRegistro++;

    }

    Console.WriteLine("\n\n");

    while (true)
    {

        Console.WriteLine("A qual contato você deseja adicionar um telefone? Para voltar ao menu inicial, digite sair.");
        nomeDaPessoa = Console.ReadLine()!;
        nomeDaPessoa = nomeDaPessoa.ToUpper();

        if (listaNomes.ContainsKey(nomeDaPessoa))
        {

            while(true)
            {

                Console.Write("Digite o telefone com DDD e sem espaços: ");
                telefonePessoa = long.Parse(Console.ReadLine()!);

                listaNomes[nomeDaPessoa].Add(telefonePessoa);

                Console.WriteLine($"O telefone {telefonePessoa} foi adicionado com sucesso.");

                Console.WriteLine("\nDeseja adicionar outro telefone ao mesmo contato? (Sim/Não)");
                string maisUmTelefone = Console.ReadLine()!;
                maisUmTelefone = maisUmTelefone.ToLower();

                if(maisUmTelefone == "nao" || maisUmTelefone == "não")
                {

                    break;

                }
                else 
                {

                    Console.WriteLine("");
                
                }


            }

            break;

        }
        else if(nomeDaPessoa.ToLower() == "sair")
        {

            Thread.Sleep(1000);
            ExibirMenu();

        }
        else
        {

            Console.WriteLine($"A pessoa {nomeDaPessoa} não está registrada!\n");

        }



    }

    Thread.Sleep(1000);
    ExibirMenu();

}

void BuscarContato()
{

    bool novaBusca = true;

    while ( novaBusca )
    {

        string nomeRegistro;
        string fazerNovaBusca;

        Console.Clear();

        ExibirTituloDaOpcao("Buscar contato de um registro: ");

        Console.Write("De qual registro você deseja exibir o contato? ");
        nomeRegistro = Console.ReadLine()!;
        nomeRegistro = nomeRegistro.ToUpper();

        if (listaNomes.ContainsKey(nomeRegistro))
        {

            if (listaNomes[nomeRegistro].Count() > 0)
            {

                Console.Write($"{nomeRegistro}\nContato: ");

                for (int i = 0; i < listaNomes[nomeRegistro].Count; i++)
                {

                    Console.Write($"{listaNomes[nomeRegistro][i]} || ");

                }

            }
            else 
            {

                Console.Write($"{nomeRegistro} não possui contato cadastrado!");

            }

        }
        else
        {

            Console.WriteLine("Registro não encontrado!");

        }

        bool optNovaBusca = true;

        while ( optNovaBusca )
        {

            Console.WriteLine("\n\nDeseja fazer nova buscar?");
            fazerNovaBusca = Console.ReadLine()!.ToUpper();

            switch (fazerNovaBusca)
            {

                case "SIM":
                    optNovaBusca = false;
                    break;

                case "NAO":
                    novaBusca = false;
                    optNovaBusca = false;
                    break;

                case "NÃO":
                    novaBusca = false;
                    optNovaBusca = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;

            }

        }

    }

    Thread.Sleep(1000);
    ExibirMenu();

}

void BoasVindas() //Função que não tem retorno: void
{

    Console.WriteLine(@"█▀▄▀█ █▀▀ █░█   ▄▀█ █▀█ █░░ █ █▀▀ ▄▀█ ▀█▀ █ █░█ █▀█
█░▀░█ ██▄ █▄█   █▀█ █▀▀ █▄▄ █ █▄▄ █▀█ ░█░ █ ▀▄▀ █▄█");
    ExibirTituloDaOpcao("Bem vindo ao meu primeiro aplicativo em C#!");

}

void ExibirTituloDaOpcao(string titulo)
{

    int qtdLetras = titulo.Length;
    string asteriscosTitulo = string.Empty.PadLeft(qtdLetras, '*');
    Console.WriteLine(asteriscosTitulo);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscosTitulo + "\n");

}

ExibirMenu();