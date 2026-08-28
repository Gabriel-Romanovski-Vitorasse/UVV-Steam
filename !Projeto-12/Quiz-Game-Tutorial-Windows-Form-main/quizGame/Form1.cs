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

            totalQuestions = 8;



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
                    lblQuestion.Text = "What is the colour of the Sky?";

                    button1.Text = "Blue";
                    button2.Text = "Yellow";
                    button3.Text = "Purple";
                    button4.Text = "Red";

                    correctAnswer = 1;

                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.questions;
                    lblQuestion.Text = "Whats is the name of the main character from Iron Man?";

                    button1.Text = "Tony Stank";
                    button2.Text = "Tony Stark";
                    button3.Text = "Rody";
                    button4.Text = "Peter Quill";

                    correctAnswer = 2;

                    break;
                case 3:

                    pictureBox1.Image = Properties.Resources.fortnite;

                    lblQuestion.Text = "Which Game Publisher Made the game above?";

                    button1.Text = "EA";
                    button2.Text = "Activision";
                    button3.Text = "Square Enix";
                    button4.Text = "Epic Games";

                    correctAnswer = 4;

                    break;
                case 4:

                    pictureBox1.Image = Properties.Resources.questions;

                    lblQuestion.Text = "Which is the captial city of England?";

                    button1.Text = "Birmingham";
                    button2.Text = "London";
                    button3.Text = "Brighton";
                    button4.Text = "liverpool";

                    correctAnswer = 2;

                    break;
                case 5:

                    pictureBox1.Image = Properties.Resources.gears_of_war;

                    lblQuestion.Text = "What is the name of this game";

                    button1.Text = "Gears Of War";
                    button2.Text = "Call of Duty";
                    button3.Text = "Battlefield";
                    button4.Text = "Bionic Commando";

                    correctAnswer = 1;

                    break;
                case 6:

                    pictureBox1.Image = Properties.Resources.halo;

                    lblQuestion.Text = "Whats the main characters name in this game?";

                    button1.Text = "Altair";
                    button2.Text = "Lara Craft";
                    button3.Text = "Master Cheif";
                    button4.Text = "Drake";

                    correctAnswer = 3;

                    break;
                case 7:

                    pictureBox1.Image = Properties.Resources.csgo;

                    lblQuestion.Text = "What is the name of this game";

                    button1.Text = "Counter Strike Go";
                    button2.Text = "Call of Duty";
                    button3.Text = "Battlefield";
                    button4.Text = "Half Life 3";

                    correctAnswer = 1;

                    break;
                case 8:

                    pictureBox1.Image = Properties.Resources.witcher3;

                    lblQuestion.Text = "Who is Geralt looking for in this game?";

                    button1.Text = "Victoria";
                    button2.Text = "Donuts";
                    button3.Text = "Ciri";
                    button4.Text = "Yennefer";

                    correctAnswer = 3;

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
