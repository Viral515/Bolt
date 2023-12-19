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
            if (parameters.BoltHeadType == true)
            {
                _kompasConnector.CreateDocument2DHexagon(parameters.TurnkeySize);
                _kompasConnector.CreateExtrusionParam((float)parameters.BoltLength +
                                                      (float)parameters.BoltHeadHeight);
                _kompasConnector.InitializationSketchDefinitionXoy();
                _kompasConnector.CreateDocument2DHexagonAndCircle(
                    parameters.TurnkeySize,
                    parameters.ThreadDiameter);
                _kompasConnector.CreateCutParam(-(float)parameters.BoltLength);
            }
            else
            {
                _kompasConnector.CreateDocument2DCircle(parameters.TurnkeySize);
                _kompasConnector.CreateExtrusionParam(
                    (float)parameters.BoltLength
                    + (float)parameters.BoltHeadHeight);
                _kompasConnector.InitializationSketchDefinitionXoy();
                _kompasConnector.CreateDocument2DCircleAndSquare(
                    parameters.TurnkeySize,
                    parameters.ThreadDiameter);
                _kompasConnector.CreateCutParam(-(float)parameters.BoltLength);
                _kompasConnector.InitializationSketchDefinitionXoy();
                _kompasConnector.CreateDocument2DCircleAndSquare(
                    parameters.ThreadDiameter,
                    parameters.ThreadDiameter);
                _kompasConnector.CreateCutParam(-(float)parameters.BoltLength
                                                + (float)parameters.HeadRestHeight);
                _kompasConnector.CreateChamfer(
                    (float)parameters.BoltHeadHeight,
                    (float)parameters.TurnkeySize / 2,
                    0,
                    (float)parameters.BoltLength + (float)parameters.BoltHeadHeight);
            }

            _kompasConnector.CreateSpiralParam(
                parameters.ThreadLength,
                parameters.ThreadDiameter);
            _kompasConnector.InitializationSketchDefinitionXoz();
            _kompasConnector.CreateDocument2DTriangle(parameters.ThreadDiameter);
            if (parameters.BoltHeadType == true)
            {
                _kompasConnector.CreateCutTParam(true);
            }
            else
            {
                _kompasConnector.CreateCutTParam(false);
            }
        }
    }
}
