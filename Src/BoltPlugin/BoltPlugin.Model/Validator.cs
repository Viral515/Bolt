namespace BoltPlugin.Model
{
    /// <summary>
    /// Класс для базовой валидации значений.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Проверяет входит ли значение в заданный диапазон.
        /// </summary>
        /// <param name="value">Значение для проверки.</param>
        /// <param name="min">Миниммум.</param>
        /// <param name="max">Максимум.</param>
        /// <returns>Возвращает true если значение входит в диапазон, иначе false.</returns>
        public static bool IsValueInRange(double value, double min, double max)
        {
            return min <= value && value <= max;
        }

        /// <summary>
        /// Проверяет не превышает ли значение заданную границу.
        /// </summary>
        /// <param name="value">Значение для проверки.</param>
        /// <param name="max">Максимум.</param>
        /// <returns>Возвращает true если значение меньше максимума, иначе false.</returns>
        public static bool IsValueLess(double value, double max)
        {
            return value < max;
        }
    }
}
