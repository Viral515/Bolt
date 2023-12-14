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
            { nameof(threadLengthTextBox), true }
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
            CheckСorrectBoltLength();
            CheckСorrectBoltHeadHeight();
            CheckСorrectThreadLength();
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
                toolTip.SetToolTip(
                    threadDiameterTextBox,
                    "Диаметр резьбы должен быть в диапазоне 6-48 мм.");
            }
        }

        private void turnkeySizeTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (_dictionaryErrors["turnkeySizeTextBox"] == false)
            {
                var toolTip = new ToolTip();
                toolTip.ShowAlways = false;
                toolTip.SetToolTip(
                    turnkeySizeTextBox,
                    "Размер 'под ключ' должен быть в диапазоне 10-75 мм.");
            }
        }

        private void boltHeadHeightTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (_dictionaryErrors["boltHeadHeightTextBox"] == false)
            {
                var toolTip = new ToolTip();
                toolTip.ShowAlways = false;
                toolTip.SetToolTip(
                    boltHeadHeightTextBox,
                    "Высота головки должна быть в диапазоне " +
                    "4-30 мм, и не должна превышать длину болта L.");
            }
        }

        private void boltLengthTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (_dictionaryErrors["boltLengthTextBox"] == false)
            {
                var toolTip = new ToolTip();
                toolTip.ShowAlways = false;
                toolTip.SetToolTip(
                    boltLengthTextBox,
                    "Длина болта должна быть в диапазоне 8-300 мм.");
            }
        }

        private void threadLengthTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (_dictionaryErrors["threadLengthTextBox"] == false)
            {
                var toolTip = new ToolTip();
                toolTip.ShowAlways = false;
                toolTip.SetToolTip(
                    threadLengthTextBox,
                    "Длина резьбы должна быть в диапазоне 6-300 мм," +
                    " и не должна превышать длину болта L.");
            }
        }
    }
}