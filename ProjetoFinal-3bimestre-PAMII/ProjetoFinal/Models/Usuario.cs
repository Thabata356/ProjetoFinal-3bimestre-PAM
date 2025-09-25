using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Models.Enuns;

namespace ProjetoFinal.Models
{
    public class Usuario
    {
        public string RmUsuario { get; set; } = string.Empty;
        public string ChamadosAbertos { get; set; } = string.Empty;
        public string ChamadosConcluidos { get; set; } = string.Empty;
        public string EmailUsuario { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public string SenhaUsuario { get; set; } = string.Empty;
        public string TelefoneUsuario { get; set; } = string.Empty;
        public string CpfUsuario { get; set; } = string.Empty;
        //public string PerfilUsuario { get; set; } = string.Empty; 
        public string TokenUsuario { get; set; } = string.Empty;
        public TipoPerfilEnum TipoPerfil { get; set; }

    }
}
