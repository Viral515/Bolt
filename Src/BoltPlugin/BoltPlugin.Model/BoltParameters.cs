namespace BoltPlugin.Model
{
    using System;

    /// <summary>
    /// Содержит параметры для модели болта.
    /// </summary>
    public class BoltParameters
    {
        /// <summary>
        /// Минимальный размер номинального диаметра резьбы.
        /// </summary>
        private const double MinThreadDiameter = 6;

        /// <summary>
        /// Максимальный размер номинального диаметра резьбы.
        /// </summary>
        private const double MaxThreadDiameter = 48;

        /// <summary>
        /// Минимальный размер "под ключ".
        /// </summary>
        private const double MinTurnkeySize = 10;

        /// <summary>
        /// Максимальный размер "под ключ".
        /// </summary>
        private const double MaxTurnkeySize = 75;

        /// <summary>
        /// Минимальная высота головки.
        /// </summary>
        private const double MinBoltHeadHeight = 4;

        /// <summary>
        /// Максимальная высота головки.
        /// </summary>
        private const double MaxBoltHeadHeight = 30;

        /// <summary>
        /// Минимальная длина болта.
        /// </summary>
        private const double MinBoltLength = 8;

        /// <summary>
        /// Максимальная длина болта.
        /// </summary>
        private const double MaxBoltLength = 300;

        /// <summary>
        /// Минимальная длина резьбы.
        /// </summary>
        private const double MinThreadLength = 6;

        /// <summary>
        /// Максимальная длина резьбы.
        /// </summary>
        private const double MaxThreadLength = 300;

        /// <summary>
        /// Номинальный диаметр резьбы.
        /// </summary>
        private double _threadDiameter;

        /// <summary>
        /// Размер "под ключ".
        /// </summary>
        private double _turnkeySize;

        /// <summary>
        /// Высота головки.
        /// </summary>
        private double _boltHeadHeight;

        /// <summary>
        /// Длина болта.
        /// </summary>
        private double _boltLength;

        /// <summary>
        /// Длина резьбы.
        /// </summary>
        private double _threadLength;

        /// <summary>
        /// Свойство для номинального диаметра резьбы.
        /// </summary>
        public double ThreadDiameter
        {
            get => this._threadDiameter;
            set
            {
                if (Validator.IsValueInRange(value, MinThreadDiameter, MaxThreadDiameter))
                {
                    _threadDiameter = value;
                }
                else
                {
                    throw new Exception("Диаметр резьбы должен быть в диапазоне 6-48 мм.");
                }
            }
        }

        /// <summary>
        /// Свойство для размера "под ключ".
        /// </summary>
        public double TurnkeySize
        {
            get => this._turnkeySize;
            set
            {
                if (Validator.IsValueInRange(value, MinTurnkeySize, MaxTurnkeySize))
                {
                    _turnkeySize = value;
                }
                else
                {
                    throw new Exception("Размер 'под ключ' должен" +
                                        " быть в диапазоне 10-75 мм.");
                }
            }
        }

        /// <summary>
        /// Свойство для высоты головки.
        /// </summary>
        public double BoltHeadHeight
        {
            get => this._boltHeadHeight;
            set
            {
                if (Validator.IsValueInRange(value, MinBoltHeadHeight, MaxBoltHeadHeight)
                    && Validator.IsValueLess(value, _boltLength))
                {
                    _boltHeadHeight = value;
                }
                else
                {
                    throw new Exception("Высота головки должна быть в диапазоне " +
                                        "4-30 мм, и не должна превышать длину болта L.");
                }
            }
        }

        /// <summary>
        /// Свойство для длины болта.
        /// </summary>
        public double BoltLength
        {
            get => this._boltLength;
            set
            {
                if (Validator.IsValueInRange(value, MinBoltLength, MaxBoltLength))
                {
                    _boltLength = value;
                }
                else
                {
                    throw new Exception("Длина болта должна быть " +
                                        "в диапазоне 8-300 мм.");
                }
            }
        }

        /// <summary>
        /// Свойство для длины резьбы.
        /// </summary>
        public double ThreadLength
        {
            get => this._threadLength;
            set
            {
                if (Validator.IsValueInRange(value, MinThreadLength, MaxThreadLength)
                    && Validator.IsValueLess(value, _boltLength))
                {
                    _threadLength = value;
                }
                else
                {
                    throw new Exception("Длина резьбы должна быть в диапазоне 6-300 мм," +
                        " и не должна превышать длину болта L.");
                }
            }
        }
    }
}
