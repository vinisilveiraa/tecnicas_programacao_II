using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Fabrica
    {
        public string? Nome { get; set; }
        public ICollection<Maquina> Maquinas { get; set; } = new List<Maquina>();


        public void AdicionarMaquina(Maquina maquina)
        {
            maquina = new Maquina(maquina);
            Maquinas.Add(maquina);
        }

        public void ListarMaquinas()
        {
            
        }

        public void BuscarModelo(Maquina modelo)
        {

        }
    }

    public class Maquina
    {
        private Maquina maquina;

        public Maquina(Maquina maquina)
        {
            this.maquina = maquina;
        }

        public Maquina(string? modelo, string? horaOperacao, Guid numeroSerie, string? obs, Fabrica? fabrica, Operario? operario) 
        {
            modelo = Modelo;
            horaOperacao = HoraOperacao;
            numeroSerie = NumeroSerie;
            obs = Observacao;
            fabrica = Fabrica;
            operario = Operario;
        }

        public string? Modelo { get; set; }
        public string? HoraOperacao { get; set; }
        public Guid NumeroSerie { get; set; }
        public string? Observacao { get; set; }
        public Fabrica? Fabrica { get; set; }
        public ICollection<Operario> Operario { get; set; }

    }

    public class Operario
    {
        public string? Nome { get; set; }
        public Maquina? Maquina { get; set; }

        public async void OperarMaquinaASync()
        {

        }

        public class Equipamento
        {
            public string? Nome { get; set; }
            public DateTime DataFabricacao { get; set; }
        }
    }
