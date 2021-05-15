using System.Collections.Generic;

namespace Domain.DTO
{
    public class RelatorioFinalObjectDTO
    {
        public RelatorioFinalObjectDTO(){
            Perguntas = new List<PerguntaDTO>();
            Resposta = new List<RespostaDTO>();
        }
        public virtual List<PerguntaDTO> Perguntas{get;set;}
        public List<RespostaDTO> Resposta { get; set; }

        public string NomeAluno { get; set; }

        public string NomeQuizz { get; set; }
    }
}