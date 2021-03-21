using System.Collections.Generic;

namespace Domain.DTO
{
    public class RelatorioFinalObjectDTO
    {
        public virtual List<PerguntaDTO> Perguntas{get;set;}
        public List<RespostaDTO> Resposta { get; set; }

        public string NomeAluno { get; set; }

        public string NomeQuizz { get; set; }
    }
}