using System.Windows.Forms;

namespace quizGame
{
    public partial class Form1 : Form
    {
        // variables list for this quiz game
        int correctAnswer;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;

        // Controle do botão de eliminar resposta
        int nextRemoveAvailable = 1;
        bool removeUsedThisQuestion = false;


        public Form1()
        {
            InitializeComponent();

            askQuestion(questionNumber);

            totalQuestions = 15;



        }

        private void ClickAnswerEvent(object sender, EventArgs e)
        {

            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);




            if (buttonTag == correctAnswer)
            {
                score++;


            }

            if (questionNumber == totalQuestions)
            {
                // work out the percentage here
                percentage = (int)Math.Round((double)(100 * score) / totalQuestions);


                MessageBox.Show("Quiz Ended" + Environment.NewLine +
                                "You have answered " + score + " questions correcly" + Environment.NewLine +
                                "Your total percentage is " + percentage + " %" + Environment.NewLine +
                                "Click Ok to play again"

                    );

                score = 0;
                questionNumber = 0;

                askQuestion(questionNumber);
            }

            questionNumber++;

            askQuestion(questionNumber);



        }

        private void askQuestion(int qnum)
        {

            // Reativa as respostas
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

            // Nova pergunta = pode usar o recurso novamente na pergunta
            removeUsedThisQuestion = false;

            // Verifica se o botão de eliminar está disponível
            if (questionNumber >= nextRemoveAvailable)
            {
                ajuda.Enabled = true;
            }
            else
            {
                ajuda.Enabled = false;
            }

            switch (qnum)
            {
                case 1:

                    pictureBox1.Image = Properties.Resources.questions;

                    lblQuestion.Text = "Qual é a cor do céu em um dia ensolarado?";

                    button1.Text = "Azul";
                    button2.Text = "Amarelo";
                    button3.Text = "Roxo";
                    button4.Text = "Vermelho";

                    correctAnswer = 1;

                    break;


                case 2:

                    pictureBox1.Image = Properties.Resources.questions;

                    lblQuestion.Text = "Qual é o nome do personagem principal de Homem de Ferro?";

                    button1.Text = "Tony Stank";
                    button2.Text = "Tony Stark";
                    button3.Text = "Rody";
                    button4.Text = "Peter Quill";

                    correctAnswer = 2;

                    break;


                case 3:

                    pictureBox1.Image = Properties.Resources.fortnite;

                    lblQuestion.Text = "Qual empresa publicou o jogo mostrado acima?";

                    button1.Text = "EA";
                    button2.Text = "Activision";
                    button3.Text = "Square Enix";
                    button4.Text = "Epic Games";

                    correctAnswer = 4;

                    break;


                case 4:

                    pictureBox1.Image = Properties.Resources.questions;

                    lblQuestion.Text = "Qual é a capital da Inglaterra?";

                    button1.Text = "Birmingham";
                    button2.Text = "Londres";
                    button3.Text = "Brighton";
                    button4.Text = "Liverpool";

                    correctAnswer = 2;

                    break;


                case 5:

                    pictureBox1.Image = Properties.Resources.gears_of_war;

                    lblQuestion.Text = "Qual é o nome do jogo mostrado acima?";

                    button1.Text = "Gears of War";
                    button2.Text = "Call of Duty";
                    button3.Text = "Battlefield";
                    button4.Text = "Bionic Commando";

                    correctAnswer = 1;

                    break;


                case 6:

                    pictureBox1.Image = Properties.Resources.halo;

                    lblQuestion.Text = "Qual é o nome do personagem principal de Halo?";

                    button1.Text = "Altair";
                    button2.Text = "Lara Croft";
                    button3.Text = "Master Chief";
                    button4.Text = "Drake";

                    correctAnswer = 3;

                    break;


                case 7:

                    pictureBox1.Image = Properties.Resources.csgo;

                    lblQuestion.Text = "Qual é o nome do jogo mostrado acima?";

                    button1.Text = "Counter-Strike";
                    button2.Text = "Call of Duty";
                    button3.Text = "Battlefield";
                    button4.Text = "Half-Life 3";

                    correctAnswer = 1;

                    break;


                case 8:

                    pictureBox1.Image = Properties.Resources.witcher3;

                    lblQuestion.Text = "Quem Geralt está procurando neste jogo?";

                    button1.Text = "Victoria";
                    button2.Text = "Donuts";
                    button3.Text = "Ciri";
                    button4.Text = "Yennefer";

                    correctAnswer = 3;

                    break;


                case 9:

                    pictureBox1.Image = Properties.Resources.minecraft;

                    lblQuestion.Text = "Qual destes materiais é mais resistente no Minecraft?";

                    button1.Text = "Ferro";
                    button2.Text = "Ouro";
                    button3.Text = "Diamante";
                    button4.Text = "Netherite";

                    correctAnswer = 4;

                    break;


                case 10:

                    pictureBox1.Image = Properties.Resources.mario;

                    lblQuestion.Text = "Qual personagem é conhecido por usar um boné vermelho e ter um irmão chamado Luigi?";

                    button1.Text = "Sonic";
                    button2.Text = "Mario";
                    button3.Text = "Link";
                    button4.Text = "Kirby";

                    correctAnswer = 2;

                    break;


                case 11:

                    pictureBox1.Image = Properties.Resources.mario;

                    lblQuestion.Text = "Qual é o nome da princesa frequentemente resgatada por Mario?";

                    button1.Text = "Zelda";
                    button2.Text = "Peach";
                    button3.Text = "Daisy";
                    button4.Text = "Rosalina";

                    correctAnswer = 2;

                    break;


                case 12:

                    pictureBox1.Image = Properties.Resources.zelda;

                    lblQuestion.Text = "Qual personagem é o protagonista da série The Legend of Zelda?";

                    button1.Text = "Zelda";
                    button2.Text = "Ganondorf";
                    button3.Text = "Link";
                    button4.Text = "Mario";

                    correctAnswer = 3;

                    break;


                case 13:

                    pictureBox1.Image = Properties.Resources.gta;

                    lblQuestion.Text = "Qual empresa desenvolveu a série Grand Theft Auto?";

                    button1.Text = "Rockstar Games";
                    button2.Text = "Electronic Arts";
                    button3.Text = "Bethesda";
                    button4.Text = "Capcom";

                    correctAnswer = 1;

                    break;


                case 14:

                    pictureBox1.Image = Properties.Resources.tlou;

                    lblQuestion.Text = "Em qual jogo o jogador controla personagens chamados Joel e Ellie?";

                    button1.Text = "Resident Evil";
                    button2.Text = "The Last of Us";
                    button3.Text = "Days Gone";
                    button4.Text = "Uncharted";

                    correctAnswer = 2;

                    break;


                case 15:

                    pictureBox1.Image = Properties.Resources.sonic;

                    lblQuestion.Text = "Qual jogo apresenta o personagem Sonic como protagonista?";

                    button1.Text = "Sonic the Hedgehog";
                    button2.Text = "Crash Bandicoot";
                    button3.Text = "Rayman";
                    button4.Text = "Mega Man";

                    correctAnswer = 1;

                    break;
            }





        }




        

        private void ajuda_Click(object sender, EventArgs e)
        {
            // Verifica se o botão está disponível
            if (questionNumber < nextRemoveAvailable)
            {
                MessageBox.Show("Você precisa esperar mais algumas rodadas.");
                return;
            }

            // Verifica se já foi usado nesta pergunta
            if (removeUsedThisQuestion)
            {
                return;
            }

            // Lista dos botões de resposta
            Button[] buttons = { button1, button2, button3, button4 };

            // Procura uma resposta errada para remover
            Random random = new Random();

            int wrongButton;

            do
            {
                wrongButton = random.Next(0, 4);
            }
            while (wrongButton + 1 == correctAnswer ||
                   !buttons[wrongButton].Enabled);

            // Desabilita a resposta errada
            buttons[wrongButton].Enabled = false;
            buttons[wrongButton].Text = "X";

            // Marca que o botão foi usado nesta pergunta
            removeUsedThisQuestion = true;

            // Só poderá usar novamente daqui a 3 perguntas
            nextRemoveAvailable = questionNumber + 3;

            // Desabilita o botão
            ajuda.Enabled = false;
        }
    }
}
