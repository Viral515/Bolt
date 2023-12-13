namespace BoltPlugin.Model
{
    /// <summary>
    /// Builder.
    /// </summary>
    public class BoltBuilder
    {
        /// <summary>
        /// Экземпляр класса KompasConnector.
        /// </summary>
        private readonly KompasConnector _kompasConnector = new KompasConnector();

        /// <summary>
        /// Функция построения болта.
        /// </summary>
        /// <param name="parameters">Параметры болта.</param>
        public void Build(BoltParameters parameters)
        {
            _kompasConnector.OpenKompas();
            _kompasConnector.CreateDocument3D();
            _kompasConnector.CreatePart();
            _kompasConnector.InitializationSketchDefinitionXoy();
            _kompasConnector.CreateDocument2DHexagon(parameters.TurnkeySize);
            _kompasConnector.CreateExtrusionParam((float)parameters.BoltLength +
                                                  (float)parameters.BoltHeadHeight);
            _kompasConnector.InitializationSketchDefinitionXoy();
            _kompasConnector.CreateDocument2DHexagonAndCircle(parameters.TurnkeySize, parameters.ThreadDiameter);
            _kompasConnector.CreateCutParam(-(float)parameters.BoltLength);
            _kompasConnector.CreateSpiralParam(parameters.ThreadLength, parameters.ThreadDiameter);
            _kompasConnector.InitializationSketchDefinitionXoz();
            _kompasConnector.CreateDocument2DTriangle(parameters.ThreadDiameter);
            _kompasConnector.CreateCutTParam();
        }
    }
}
