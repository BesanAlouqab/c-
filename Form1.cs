using System;
using System.Windows.Forms;

namespace GuessTheNumber
{
    public partial class GameForm : Form
    {
        // Declare variables
        private int targetNumber;
        private int previousGuess = -1;

        public GameForm()
        {
            InitializeComponent();
        }

        // Method to initialize or reset the game
        private void StartNewGame()
        {
            Random rand = new Random();
            targetNumber = rand.Next(1, 1001);  // Random number between 1 and 1000
            previousGuess = -1;
            txtGuess.Enabled = true;  // Enable the guess input box
            txtGuess.Clear();  // Clear any previous guess
            txtGuess.Focus();  // Focus on the input box
            lblInstructions.Text = "I have a number between 1 and 1000—can you guess my number? Please enter your first guess.";
            this.BackColor = System.Drawing.Color.LightGray;  // Reset form background color
            lblFeedback.Text = "";  // Clear feedback label
        }

        // Button click event to guess the number
        private void btnGuess_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtGuess.Text, out int userGuess))
            {
                if (userGuess == targetNumber)
                {
                    MessageBox.Show("Correct!");
                    this.BackColor = System.Drawing.Color.Green;  // Change background to green
                    txtGuess.Enabled = false;  // Disable the input box
                    lblFeedback.Text = "Correct! You guessed the number.";
                }
                else
                {
                    if (previousGuess != -1)
                    {
                        // Compare the current guess with the previous one to provide warmer/colder feedback
                        int previousDifference = Math.Abs(previousGuess - targetNumber);
                        int currentDifference = Math.Abs(userGuess - targetNumber);

                        if (currentDifference < previousDifference)
                        {
                            this.BackColor = System.Drawing.Color.Red;  // Warmer
                            lblFeedback.Text = "Warmer! Guess again.";
                        }
                        else
                        {
                            this.BackColor = System.Drawing.Color.Blue;  // Colder
                            lblFeedback.Text = "Colder! Guess again.";
                        }
                    }
                    else
                    {
                        // No previous guess, so just give initial feedback
                        lblFeedback.Text = userGuess > targetNumber ? "Too High!" : "Too Low!";
                        this.BackColor = System.Drawing.Color.LightGray;  // Default background
                    }
                    previousGuess = userGuess;  // Store current guess as previous guess for next comparison
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }

            txtGuess.Clear();  // Clear the guess input for the next attempt
            txtGuess.Focus();  // Refocus on the TextBox for convenience
        }

        // Button click event to start a new game
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();  // Call method to reset and start a new game
        }

        // Form Load event to initialize the game when the form loads
        private void GameForm_Load(object sender, EventArgs e)
        {
            StartNewGame();  // Start a new game when the application starts
        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {

        }
    }
}
