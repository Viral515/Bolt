namespace BoltPlugin.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using BoltPlugin.Model;
    using ToolTip = System.Windows.Forms.ToolTip;

    /// <summary>
    /// MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Цвет, если всё правильно.
        /// </summary>
        private readonly Color _correctСolor = Color.White;

        /// <summary>
        /// Цвет, если есть ошибка.
        /// </summary>
        private readonly Color _errorColor = Color.LightPink;

        /// <summary>
        /// Экземпляр класса BoltBuilder.
        /// </summary>
        private readonly BoltBuilder _boltBuilder = new BoltBuilder();

        /// <summary>
        /// Экземпляр класса PhotoFrameParameters.
        /// </summary>
        private readonly BoltParameters _parameters = new BoltParameters();

        /// <summary>
        /// Ошибки валидации.
        /// </summary>
        private readonly Dictionary<string, bool> _dictionaryErrors = new Dictionary<string, bool>()
        {
            { nameof(threadDiameterTextBox), true },
            { nameof(turnkeySizeTextBox), true },
            { nameof(boltHeadHeightTextBox), true },
            { nameof(boltLengthTextBox), true },
            { nameof(threadLengthTextBox), true },
            { nameof(headRestHeightTextBox), true },
        };

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
            CheckСorrectThreadDiameter();
            CheckСorrectTurnkeySize();
            CheckСorrectThreadDiameter();
            CheckСorrectBoltLength();
            CheckСorrectBoltHeadHeight();
            CheckСorrectThreadLength();
            CheckСorrectHeadRestHeight();
            if (hexagonalBoltHeadRadioButton.Checked == true)
            {
                _dictionaryErrors[nameof(threadLengthTextBox)] = true;
            }

            CheckButtonError();
            _boltBuilder.Build(_parameters);
        }

        /// <summary>
        /// Проверка на наличие ошибок для отключения кнопки.
        /// </summary>
        private void CheckButtonError()
        {
            foreach (var error in _dictionaryErrors)
            {
                if (error.Value == false)
                {
                    buildButton.Enabled = false;
                    return;
                }
            }

            buildButton.Enabled = true;
        }

        /// <summary>
        /// Обработчик события изменения текста номинального диаметра резьбы.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void threadDiameterTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckСorrectThreadDiameter();
            CheckСorrectTurnkeySize();
            CheckButtonError();
        }

        /// <summary>
        /// Валидация введенных значений.
        /// </summary>
        private void CheckСorrectThreadDiameter()
        {
            try
            {
                threadDiameterTextBox.BackColor = _correctСolor;
                _parameters.ThreadDiameter = System.Convert.ToDouble(threadDiameterTextBox.Text);
                _dictionaryErrors[nameof(threadDiameterTextBox)] = true;
            }
            catch (Exception)
            {
                threadDiameterTextBox.BackColor = _errorColor;
                _dictionaryErrors[nameof(threadDiameterTextBox)] = false;
            }
        }

        /// <summary>
        /// Обработчик события изменения текста размера под ключ.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void turnkeySizeTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckСorrectTurnkeySize();
            CheckСorrectThreadDiameter();
            CheckButtonError();
        }

        /// <summary>
        /// Валидация введенных значений.
        /// </summary>
        private void CheckСorrectTurnkeySize()
        {
            try
            {
                turnkeySizeTextBox.BackColor = _correctСolor;
                _parameters.TurnkeySize = System.Convert.ToDouble(turnkeySizeTextBox.Text);
                _dictionaryErrors[nameof(turnkeySizeTextBox)] = true;
            }
            catch (Exception)
            {
                turnkeySizeTextBox.BackColor = _errorColor;
                _dictionaryErrors[nameof(turnkeySizeTextBox)] = false;
            }
        }

        /// <summary>
        /// Обработчик события изменения текста высоты шляпки болта.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void boltHeadHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckСorrectBoltHeadHeight();
            CheckButtonError();
        }

        /// <summary>
        /// Валидация введенных значений.
        /// </summary>
        private void CheckСorrectBoltHeadHeight()
        {
            try
            {
                boltHeadHeightTextBox.BackColor = _correctСolor;
                _parameters.BoltHeadHeight = System.Convert.ToDouble(boltHeadHeightTextBox.Text);
                _dictionaryErrors[nameof(boltHeadHeightTextBox)] = true;
            }
            catch (Exception)
            {
                boltHeadHeightTextBox.BackColor = _errorColor;
                _dictionaryErrors[nameof(boltHeadHeightTextBox)] = false;
            }
        }

        /// <summary>
        /// Обработчик события изменения текста длины болта.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void boltLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckСorrectBoltLength();
            CheckСorrectBoltHeadHeight();
            CheckСorrectThreadLength();
            CheckButtonError();
        }

        /// <summary>
        /// Валидация введенных значений.
        /// </summary>
        private void CheckСorrectBoltLength()
        {
            try
            {
                boltLengthTextBox.BackColor = _correctСolor;
                _parameters.BoltLength = System.Convert.ToDouble(boltLengthTextBox.Text);
                _dictionaryErrors[nameof(boltLengthTextBox)] = true;
            }
            catch (Exception)
            {
                boltLengthTextBox.BackColor = _errorColor;
                _dictionaryErrors[nameof(boltLengthTextBox)] = false;
            }
        }

        /// <summary>
        /// Обработчик события изменения текста длины резьбы.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void threadLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckСorrectBoltLength();
            CheckСorrectThreadLength();
            CheckButtonError();
        }

        /// <summary>
        /// Валидация введенных значений.
        /// </summary>
        private void CheckСorrectThreadLength()
        {
            try
            {
                threadLengthTextBox.BackColor = _correctСolor;
                _parameters.ThreadLength = System.Convert.ToDouble(threadLengthTextBox.Text);
                _dictionaryErrors[nameof(threadLengthTextBox)] = true;
            }
            catch (Exception)
            {
                threadLengthTextBox.BackColor = _errorColor;
                _dictionaryErrors[nameof(threadLengthTextBox)] = false;
            }
        }

        private void threadDiameterTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (_dictionaryErrors["threadDiameterTextBox"] == false)
            {
                var toolTip = new ToolTip();
                toolTip.ShowAlways = false;
                string msg = "Диаметр резьбы не должен превышать размер под" +
                             " ключ и обязан быть в диапазоне 6-48 мм.";
                try
                {
                    Convert.ToDouble(threadDiameterTextBox.Text);
                }
                catch (Exception exception)
                {
                    msg = "Строка не должна содержать символы.";
                }

                toolTip.SetToolTip(
                    threadDiameterTextBox,
                    msg);
            }
        }

        private void turnkeySizeTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (_dictionaryErrors["turnkeySizeTextBox"] == false)
            {
                var toolTip = new ToolTip();
                toolTip.ShowAlways = false;
                string msg = "Размер 'под ключ' должен быть больше " +
                             "номинального диаметра резьбы и находится в " +
                             "диапазоне 10-75 мм.";
                try
                {
                    Convert.ToDouble(turnkeySizeTextBox.Text);
                }
                catch (Exception exception)
                {
                    msg = "Строка не должна содержать символы.";
                }

                toolTip.SetToolTip(
                    turnkeySizeTextBox,
                    msg);
            }
        }

        private void boltHeadHeightTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (_dictionaryErrors["boltHeadHeightTextBox"] == false)
            {
                var toolTip = new ToolTip();
                toolTip.ShowAlways = false;
                string msg = "Высота головки должна быть в диапазоне " +
                             "4-30 мм, и не должна превышать длину болта L.";
                try
                {
                    Convert.ToDouble(boltHeadHeightTextBox.Text);
                }
                catch (Exception exception)
                {
                    msg = "Строка не должна содержать символы.";
                }

                toolTip.SetToolTip(
                    boltHeadHeightTextBox,
                    msg);
            }
        }

        private void boltLengthTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (_dictionaryErrors["boltLengthTextBox"] == false)
            {
                var toolTip = new ToolTip();
                toolTip.ShowAlways = false;
                string msg = "Длина болта должна быть в диапазоне 8-300 мм.";
                try
                {
                    Convert.ToDouble(boltLengthTextBox.Text);
                }
                catch (Exception exception)
                {
                    msg = "Строка не должна содержать символы.";
                }

                toolTip.SetToolTip(
                    boltLengthTextBox,
                    msg);
            }
        }

        private void threadLengthTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (_dictionaryErrors["threadLengthTextBox"] == false)
            {
                var toolTip = new ToolTip();
                toolTip.ShowAlways = false;
                string msg = "Длина резьбы должна быть в диапазоне 6-300 мм," +
                             " и не должна превышать длину болта L.";
                try
                {
                    Convert.ToDouble(threadLengthTextBox.Text);
                }
                catch (Exception exception)
                {
                    msg = "Строка не должна содержать символы.";
                }

                toolTip.SetToolTip(
                    threadLengthTextBox,
                    msg);
            }
        }

        private void hexagonalBoltHeadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            headRestHeightLabel.Visible = false;
            headRestHeightTextBox.Visible = false;
            headRestHeightSizeLabel.Visible = false;
            turnkeySizeLabel.Text = "Размер \"под ключ\" S:";
            boltPlanPictureBox.Image = BoltPlugin.View.Properties.Resources.болтЧ;
            _parameters.BoltHeadType = true;
        }

        private void roundedBoltHeadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            headRestHeightLabel.Visible = true;
            headRestHeightTextBox.Visible = true;
            headRestHeightSizeLabel.Visible = true;
            turnkeySizeLabel.Text = "Диаметр головки:";
            boltPlanPictureBox.Image = BoltPlugin.View.Properties.Resources.МебельныйБолтЧ;
            _parameters.BoltHeadType = false;
        }

        private void headRestHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckСorrectHeadRestHeight();
            CheckButtonError();
        }

        private void CheckСorrectHeadRestHeight()
        {
            try
            {
                headRestHeightTextBox.BackColor = _correctСolor;
                _parameters.HeadRestHeight = System.Convert.ToDouble(headRestHeightTextBox.Text);
                _dictionaryErrors[nameof(headRestHeightTextBox)] = true;
            }
            catch (Exception)
            {
                headRestHeightTextBox.BackColor = _errorColor;
                _dictionaryErrors[nameof(headRestHeightTextBox)] = false;
            }
        }

        private void headRestHeightTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (_dictionaryErrors["headRestHeightTextBox"] == false)
            {
                var toolTip = new ToolTip();
                toolTip.ShowAlways = false;
                string msg = "Высота подголовка не должна превышать остаток" +
                             " от разности длины болта и длины резьбы, и должна " +
                             "находится в диапазоне 3-15 мм.";
                try
                {
                    Convert.ToDouble(headRestHeightTextBox.Text);
                }
                catch (Exception exception)
                {
                    msg = "Строка не должна содержать символы.";
                }

                toolTip.SetToolTip(
                    headRestHeightTextBox,
                    msg);
            }
        }
    }
}