using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Guess_The_Word_Windows_Forms_MOO_ICT
{
    // Made by MOO ICT
    // For educational purpose only
    public partial class Form1 : Form
    {
        List<string> words = new List<string>();
        string newText;
        int i = 0;
        int guessed = 0;
        int qtde = 5;
        int use = 4;

        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void KeyIsPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // ==========================================
                // SE ACERTOU A PALAVRA
                // ==========================================
                if (words[i].ToLower() == textBox1.Text.ToLower())
                {
                    // 1. Toca o som de Acerto
                    string caminhoSomAcerto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "som-acerto.wav");
                    SoundPlayer somAcerto = new SoundPlayer(caminhoSomAcerto);
                    somAcerto.Play();

                    MessageBox.Show("Correct!", "Moo Says: ");
                    textBox1.Text = "";

                    i += 1; // Incrementa a quantidade de acertos

                    // Verifica se ainda tem palavras para jogar
                    if (i < qtde)
                    {
                        newText = Scramble(words[i]);
                        lblWord.Text = newText;
                        lblInfo.Text = "Words: " + (i + 1) + " of " + qtde;
                        guessed = 0;
                        lblGussed.Text = "Guessed: " + guessed + " times.";
                    }
                    // Se não tem mais palavras, venceu o jogo!
                    else
                    {
                        // 2. Toca o som de Aura (Vitória)
                        string caminho15Acerto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "som-aura.wav");
                        SoundPlayer somAura = new SoundPlayer(caminho15Acerto);
                        somAura.Play();

                        lblWord.Text = "You Win, Well done";
                        e.Handled = true;
                        return; // Para a execução aqui
                    }

                    use = 4; // Reseta os usos do random para a próxima palavra
                    label2.Text = $"Total de usos: {use}";
                }
                // ==========================================
                // SE ERROU A PALAVRA
                // ==========================================
                else
                {
                    // 3. Toca o som de Erro
                    string caminhoSomErro = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "som-erro.wav");
                    SoundPlayer somErro = new SoundPlayer(caminhoSomErro);
                    somErro.Play();

                    guessed += 1;
                    lblGussed.Text = "Guessed: " + guessed + " times.";

                    // Limite de erros atingido
                    if (guessed >= (2 * qtde))
                    {
                        MessageBox.Show("You Lose, Try Again", "Moo Says: ");
                        Application.Exit();
                    }
                }

                e.Handled = true;
            }
        }

        private void Setup()
        {
            words = File.ReadLines("words.txt").ToList();
            words = words.OrderBy(x => Guid.NewGuid()).ToList();
            newText = Scramble(words[i]);
            lblWord.Text = newText;
            lblInfo.Text = "Words: " + (i + 1) + " of " + qtde;
            label2.Text = $"Total de usos: {use}";
        }

        private string Scramble(string text)
        {
            return new string(text.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            if (use > 0)
            {
                newText = Scramble(words[i]);
                lblWord.Text = newText;
                use--;
                label2.Text = $"Total de usos: {use}";
            }
            else
            {
                MessageBox.Show("Você não tem mais randoms disponíveis para esta palavra!", "Moo Says: ");
            }
        }

    }
}
