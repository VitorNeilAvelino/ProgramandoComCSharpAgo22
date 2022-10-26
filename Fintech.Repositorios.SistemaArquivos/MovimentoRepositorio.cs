using Fintech.Dominio.Entidades;
using Fintech.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fintech.Repositorios.SistemaArquivos
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        private const string DiretorioBase = "Dados";

        public MovimentoRepositorio(string caminho)
        {
            Caminho = caminho;
        }

        public string Caminho { get; private set; }

        public void Inserir(Movimento movimento)
        {
            var registro = $"{movimento.Guid}|{movimento.Conta.Agencia.Numero}|{movimento.Conta.Numero}|" +
                $"{movimento.Data}|{(int)movimento.Operacao}|{movimento.Valor}";

            if (!Directory.Exists(DiretorioBase))
            {
                Directory.CreateDirectory(DiretorioBase);
            }

            File.AppendAllText($"{DiretorioBase}\\Movimento.txt", registro + Environment.NewLine);
        }

        public List<Movimento> Selecionar(int numeroAgencia, int numeroConta)
        {
            Thread.Sleep(5000);

            var movimentos = new List<Movimento>();

            foreach (var linha in File.ReadAllLines(Caminho))
            {
                if (linha == string.Empty) continue;

                var propriedades = linha.Split('|');

                var guid = new Guid(propriedades[0]);
                //var guid = (Guid)propriedades[0];
                var propriedadeNumeroAgencia = Convert.ToInt32(propriedades[1]);
                var propriedadeNumeroConta = Convert.ToInt32(propriedades[2]);
                var data = Convert.ToDateTime(propriedades[3]);
                //var operacao = (Operacao)Convert.ToInt32(propriedades[4]);
                Enum.TryParse(propriedades[4], out Operacao operacao);
                var valor = Convert.ToDecimal(propriedades[5]);

                if (numeroAgencia == propriedadeNumeroAgencia && numeroConta == propriedadeNumeroConta)
                {
                    var movimento = new Movimento(valor, operacao);
                    movimento.Data = data;
                    movimento.Guid = guid;

                    movimentos.Add(movimento);
                }
            }

            return movimentos;
        }

        public async Task<List<Movimento>> SelecionarAsync(int numeroAgencia, int numeroConta)
        {
            //await Task.Delay(5000);

            var movimentos = new List<Movimento>();

            foreach (var linha in await File.ReadAllLinesAsync(Caminho))
            {
                if (linha == string.Empty) continue;

                var propriedades = linha.Split('|');

                var guid = new Guid(propriedades[0]);
                //var guid = (Guid)propriedades[0];
                var propriedadeNumeroAgencia = Convert.ToInt32(propriedades[1]);
                var propriedadeNumeroConta = Convert.ToInt32(propriedades[2]);
                var data = Convert.ToDateTime(propriedades[3]);
                //var operacao = (Operacao)Convert.ToInt32(propriedades[4]);
                Enum.TryParse(propriedades[4], out Operacao operacao);
                var valor = Convert.ToDecimal(propriedades[5]);

                if (numeroAgencia == propriedadeNumeroAgencia && numeroConta == propriedadeNumeroConta)
                {
                    var movimento = new Movimento(valor, operacao);
                    movimento.Data = data;
                    movimento.Guid = guid;

                    movimentos.Add(movimento);
                }
            }

            return movimentos;
        }

        public void Atualizar(Movimento movimento)
        {
            var registro = $"{movimento.Guid}|{movimento.Conta.Agencia.Numero}|{movimento.Conta.Numero}|" +
                $"{movimento.Data}|{(int)movimento.Operacao}|{movimento.Valor}";

            var linhas = File.ReadAllLines(Caminho);
            var numeroLinha = 0;

            foreach (var linha in linhas)
            {
                var propriedades = linha.Split('|');

                numeroLinha++;

                if (propriedades[0] == movimento.Guid.ToString())
                {
                    break;
                }
            }    

            linhas[numeroLinha - 1] = registro;
            
            File.WriteAllLines(Caminho, linhas);
        }        

        public void Excluir(Guid guid)
        {
            string linha;
            string novaLinha = "";

            var texto = File.OpenText(Caminho);

            while ((linha = texto.ReadLine()) != null)
            {
                var propriedades = linha.Split('|');

                if (propriedades[0] != guid.ToString())
                {
                    novaLinha += linha + Environment.NewLine;
                }
            }

            texto.Close();

            File.WriteAllText(Caminho, novaLinha);
        }
    }
}