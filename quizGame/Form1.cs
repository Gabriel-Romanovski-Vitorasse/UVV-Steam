using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace quizGame
{
    public partial class Form1 : Form
    {
        // Lista para armazenar todas as perguntas
        private List<Pergunta> perguntas = new List<Pergunta>();
        private Pergunta perguntaAtual;

        // Controle de fluxo
        private int questionIndex = 0; // Índice da lista (começa em 0)
        private int score = 0;
        private int totalQuestions;

        // Timer e Pontuação
        private int tempoMaximoSegundos = 10;
        private int tempoRestanteMs;
        private const int INTERVALO_TIMER = 100;
        private int pontuacaoTotal = 0;
        private const int PONTOS_BASE = 1000;

        // Ajuda
        private int nextRemoveAvailable = 0;
        private bool removeUsedThisQuestion = false;

        public Form1()
        {
            InitializeComponent();
            ConfigurarTimer();
            CarregarPerguntas();
            IniciarJogo();
        }

        private void ConfigurarTimer()
        {
            timerPergunta.Interval = INTERVALO_TIMER;
            timerPergunta.Tick += TimerPergunta_Tick;
        }

        // Criando e adicionando as perguntas na lista
        private void CarregarPerguntas()
        {
            perguntas = new List<Pergunta>
    {
        new Pergunta(
            "Qual é a cor do céu em um dia ensolarado?",
            new string[] { "Azul", "Amarelo", "Roxo", "Vermelho" },
            1,
            Properties.Resources.questions
        ),
        new Pergunta(
            "Qual é o nome do personagem principal de Homem de Ferro?",
            new string[] { "Tony Stank", "Tony Stark", "Rody", "Peter Quill" },
            2,
            Properties.Resources.questions
        ),
        new Pergunta(
            "Qual empresa publicou o jogo mostrado acima?",
            new string[] { "EA", "Activision", "Square Enix", "Epic Games" },
            4,
            Properties.Resources.fortnite
        ),
        new Pergunta(
            "Qual é a capital da Inglaterra?",
            new string[] { "Birmingham", "Londres", "Brighton", "Liverpool" },
            2,
            Properties.Resources.questions
        ),
        new Pergunta(
            "Qual é o nome do jogo mostrado acima?",
            new string[] { "Gears of War", "Call of Duty", "Battlefield", "Bionic Commando" },
            1,
            Properties.Resources.gears_of_war
        ),
        new Pergunta(
            "Qual é o nome do personagem principal de Halo?",
            new string[] { "Altair", "Lara Croft", "Master Chief", "Drake" },
            3,
            Properties.Resources.halo
        ),
        new Pergunta(
            "Qual é o nome do jogo mostrado acima?",
            new string[] { "Counter-Strike", "Call of Duty", "Battlefield", "Half-Life 3" },
            1,
            Properties.Resources.csgo
        ),
        new Pergunta(
            "Quem Geralt está procurando neste jogo?",
            new string[] { "Victoria", "Donuts", "Ciri", "Yennefer" },
            3,
            Properties.Resources.witcher3
        ),
        new Pergunta(
            "Qual destes materiais é mais resistente no Minecraft?",
            new string[] { "Ferro", "Ouro", "Diamante", "Netherite" },
            4,
            Properties.Resources.minecraft
        ),
        new Pergunta(
            "Qual personagem é conhecido por usar um boné vermelho e ter um irmão chamado Luigi?",
            new string[] { "Sonic", "Mario", "Link", "Kirby" },
            2,
            Properties.Resources.mario
        ),
        new Pergunta(
            "Qual é o nome da princesa frequentemente resgatada por Mario?",
            new string[] { "Zelda", "Peach", "Daisy", "Rosalina" },
            2,
            Properties.Resources.mario
        ),
        new Pergunta(
            "Qual personagem é o protagonista da série The Legend of Zelda?",
            new string[] { "Zelda", "Ganondorf", "Link", "Mario" },
            3,
            Properties.Resources.zelda
        ),
        new Pergunta(
            "Qual empresa desenvolveu a série Grand Theft Auto?",
            new string[] { "Rockstar Games", "Electronic Arts", "Bethesda", "Capcom" },
            1,
            Properties.Resources.gta
        ),
        new Pergunta(
            "Em qual jogo o jogador controla personagens chamados Joel e Ellie?",
            new string[] { "Resident Evil", "The Last of Us", "Days Gone", "Uncharted" },
            2,
            Properties.Resources.tlou
        ),
        new Pergunta(
            "Qual jogo apresenta o personagem Sonic como protagonista?",
            new string[] { "Sonic the Hedgehog", "Crash Bandicoot", "Rayman", "Mega Man" },
            1,
            Properties.Resources.sonic
        )
    };

            totalQuestions = perguntas.Count;
        }

        private void IniciarJogo()
        {
            score = 0;
            pontuacaoTotal = 0;
            questionIndex = 0;
            ExibirPergunta();
        }

        private void ExibirPergunta()
        {
            // Pega a pergunta atual da lista
            perguntaAtual = perguntas[questionIndex];

            // Atualiza a tela de forma genérica
            lblQuestion.Text = perguntaAtual.Enunciado;
            button1.Text = perguntaAtual.Alternativas[0];
            button2.Text = perguntaAtual.Alternativas[1];
            button3.Text = perguntaAtual.Alternativas[2];
            button4.Text = perguntaAtual.Alternativas[3];

            if (perguntaAtual.Imagem != null)
            {
                pictureBox1.Image = perguntaAtual.Imagem;
            }

            // Reseta estado dos botões
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

            removeUsedThisQuestion = false;

            if (questionIndex >= nextRemoveAvailable)
            {
                ajuda.Enabled = true;
            }

            IniciarContagemTempo();
        }

        private void IniciarContagemTempo()
        {
            tempoRestanteMs = tempoMaximoSegundos * 1000;
            pbTempo.Minimum = 0;
            pbTempo.Maximum = tempoRestanteMs;
            pbTempo.Value = tempoRestanteMs;

            timerPergunta.Start();
        }

        private void TimerPergunta_Tick(object sender, EventArgs e)
        {
            tempoRestanteMs -= INTERVALO_TIMER;

            if (tempoRestanteMs > 0)
            {
                pbTempo.Value = tempoRestanteMs;
            }
            else
            {
                pbTempo.Value = 0;
                timerPergunta.Stop();
                ProcessarResposta(false);
            }
        }

        private void ClickAnswerEvent(object sender, EventArgs e)
        {
            timerPergunta.Stop();

            var senderObject = (Button)sender;
            int buttonTag = Convert.ToInt32(senderObject.Tag);

            // Compara a Tag do botão com a resposta correta do objeto Pergunta
            bool acertou = (buttonTag == perguntaAtual.RespostaCorreta);
            ProcessarResposta(acertou);
        }

        private void ProcessarResposta(bool acertou)
        {
            if (acertou)
            {
                score++;
                double percentualRestante = (double)tempoRestanteMs / (tempoMaximoSegundos * 1000);
                pontuacaoTotal += (int)(PONTOS_BASE * percentualRestante);
                string caminhoSomAcerto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "som-acerto.wav");
                SoundPlayer somAcerto = new SoundPlayer("som-acerto.wav");
                somAcerto.Play();

            }
            if (!acertou)
            {
                string caminhoSomErro = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "som-erro.wav");
                SoundPlayer somErro = new SoundPlayer("som-erro.wav");
                somErro.Play();
            }

            questionIndex++;

            if (questionIndex >= totalQuestions)
            {
                FinalizarJogo();
            }
            else
            {
                ExibirPergunta();
            }
        }

        private void FinalizarJogo()
        {
            timerPergunta.Stop();
            int percentage = (int)Math.Round((double)(100 * score) / totalQuestions);
            if (score == 15)
            {
                string caminho15Acerto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "som-aura.wav");
                SoundPlayer somAura = new SoundPlayer("som-aura.wav");
                somAura.Play();
            }

            MessageBox.Show(
                $"Quiz Finalizado!\nAcertos: {score} de {totalQuestions}\n" +
                $"Aproveitamento: {percentage}%\nPontuação Tempo: {pontuacaoTotal} pts",
                "Fim de Jogo"
            );

            IniciarJogo();
        }

        private void ajuda_Click(object sender, EventArgs e)
        {
            if (questionIndex < nextRemoveAvailable)
            {
                int rodadasRestantes = nextRemoveAvailable - questionIndex;
                MessageBox.Show($"Espere mais {rodadasRestantes} rodada(s) para usar a ajuda.");
                return;
            }

            if (removeUsedThisQuestion)
            {
                MessageBox.Show("Você já usou a ajuda nesta pergunta.");
                return;
            }

            Button[] buttons = { button1, button2, button3, button4 };
            Random random = new Random();

            int wrongButton;
            do
            {
                wrongButton = random.Next(0, 4);
            }
            while (wrongButton + 1 == perguntaAtual.RespostaCorreta || !buttons[wrongButton].Enabled);

            buttons[wrongButton].Enabled = false;
            buttons[wrongButton].Text = "X";

            removeUsedThisQuestion = true;
            nextRemoveAvailable = questionIndex + 3;
        }

        private void progressBar1_Click(object sender, EventArgs e) { }
    }
}