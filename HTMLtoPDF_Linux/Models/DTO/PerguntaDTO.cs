using System.Collections.Generic;

namespace Domain.DTO
{
    public class PerguntaDTO
    {
        public PerguntaDTO()
        {
            this.niveis = new List<NivelDTO>();
        }
        public int PerguntaId { get; set; }
        public int? NivelId { get; set; }
        public int? RespostaId { get; set; }
        public int QuizzId { get; set; }
        public string OpcaoA { get; set; }
        public string OpcaoB { get; set; }
        public string OpcaoC { get; set; }
        public string OpcaoD { get; set; }
        public string Descricao { get; set; }
        public string OpcaoCerta { get; set; }
        public virtual NivelDTO Nivel { get; set; }
        public virtual QuizzDTO Quizz { get; set; }
        public virtual RespostaDTO Resposta { get; set; }

        public List<NivelDTO> niveis { get; set; }
       
    }
}
