using System;
using System.Collections.Generic;
using System.Text;

namespace quizGame
{
    public class Pergunta
    {
        public string Enunciado { get; set; }
        public string[] Alternativas { get; set; }
        public int RespostaCorreta { get; set; }
        public System.Drawing.Image Imagem { get; set; }
        public Pergunta(string enunciado, string[] alternativas, int respostaCorreta, System.Drawing.Image imagem = null)
        {
            Enunciado = enunciado;
            Alternativas = alternativas;
            RespostaCorreta = respostaCorreta;
            Imagem = imagem;
        }

    }
}
