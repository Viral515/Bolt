namespace BoltPlugin.View
{
    using System;
    using System.Windows.Forms;
    using BoltPlugin.Model;

    /// <summary>
    /// MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Экземпляр класса BoltBuilder.
        /// </summary>
        private readonly BoltBuilder _boltBuilder = new BoltBuilder();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки "Построить".
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            try
            {
                var boltParameters = new BoltParameters
                {
                    ThreadDiameter = double.Parse(threadDiameterTextBox.Text),
                    TurnkeySize = double.Parse(turnkeySizeTextBox.Text),
                    BoltLength = double.Parse(boltLenghtTextBox.Text),
                    BoltHeadHeight = double.Parse(boltHeadHeightTextBox.Text),
                    ThreadLength = double.Parse(threadLenghtTextBox.Text)
                };
                _boltBuilder.Build(boltParameters);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                MessageBox.Show(msg);
            }
        }
    }
}