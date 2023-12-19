namespace BoltPlugin.Model
{
    using System;
    using Kompas6API5;
    using Kompas6Constants3D;

    /// <summary>
    /// KompasConnector.
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Объект компаса.
        /// </summary>
        private KompasObject KompasObject { get; set; }

        /// <summary>
        /// 3D документ.
        /// </summary>
        private ksDocument3D Document3D { get; set; }

        /// <summary>
        /// Деталь.
        /// </summary>
        private ksPart Part { get; set; }

        /// <summary>
        /// Эскиз.
        /// </summary>
        private ksEntity Sketch { get; set; }

        /// <summary>
        /// Определение эскиза.
        /// </summary>
        private ksSketchDefinition DefinitionSketch { get; set; }

        /// <summary>
        /// 2D документа.
        /// </summary>
        private ksDocument2D Document2D { get; set; }

        /// <summary>
        /// Сущность операции выдавливания.
        /// </summary>
        private ksEntity EntityExtrusion { get; set; }

        /// <summary>
        /// Сущность операции выреза.
        /// </summary>
        private ksEntity EntityCut { get; set; }

        /// <summary>
        /// Сущность операции выреза по траектории.
        /// </summary>
        private ksEntity EntityCutEvolution { get; set; }

        /// <summary>
        /// Сущность построения конической спирали.
        /// </summary>
        private ksEntity EntitySpiral { get; set; }

        /// <summary>
        /// Определение выдавливания.
        /// </summary>
        private ksBossExtrusionDefinition ExtrusionDef { get; set; }

        /// <summary>
        /// Определение выреза.
        /// </summary>
        private ksCutExtrusionDefinition CutDef { get; set; }

        /// <summary>
        /// Определение выреза по траектории.
        /// </summary>
        private ksCutEvolutionDefinition CutEvolutionDefinition { get; set; }

        /// <summary>
        /// Определение объединение по траектории.
        /// </summary>
        private ksBossEvolutionDefinition bossEvolutionDefinition { get; set; }

        /// <summary>
        /// Параметры выдавливания.
        /// </summary>
        private ksExtrusionParam ExtrusionProp { get; set; }

        /// <summary>
        /// Функция открытия Компаса.
        /// </summary>
        public void OpenKompas()
        {
            Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
            KompasObject = (KompasObject)Activator.CreateInstance(type);
            KompasObject.Visible = true;
            KompasObject.ActivateControllerAPI();
        }

        /// <summary>
        /// Функция создания 3D документа.
        /// </summary>
        public void CreateDocument3D()
        {
            Document3D = (ksDocument3D)KompasObject.Document3D();
            Document3D.Create();
        }

        /// <summary>
        /// Функция создания детали.
        /// </summary>
        public void CreatePart()
        {
            Part = Document3D.GetPart((short)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Функция выбора плоскости XOY для создания эскиза.
        /// </summary>
        public void InitializationSketchDefinitionXoy()
        {
            Sketch = Part.NewEntity((short)Obj3dType.o3d_sketch);
            DefinitionSketch = Sketch.GetDefinition();
            DefinitionSketch.SetPlane(Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            Sketch.Create();
        }

        /// <summary>
        /// Функция выбора плоскости XOZ для создания эскиза.
        /// </summary>
        public void InitializationSketchDefinitionXoz()
        {
            Sketch = Part.NewEntity((short)Obj3dType.o3d_sketch);
            DefinitionSketch = Sketch.GetDefinition();
            DefinitionSketch.SetPlane(Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ));
            Sketch.Create();
        }

        /// <summary>
        /// Создание 2D документа шестиугольника.
        /// </summary>
        /// <param name="boltHeadDiameter">Радиус шляпки болта.</param>
        public void CreateDocument2DHexagon(double boltHeadDiameter)
        {
            Document2D = DefinitionSketch.BeginEdit();
            var hexagon = (ksRegularPolygonParam)KompasObject.GetParamStruct(92);
            hexagon.count = 6;
            hexagon.ang = 90;
            hexagon.radius = boltHeadDiameter / 2;
            hexagon.describe = true;
            hexagon.style = 1;
            Document2D.ksRegularPolygon(hexagon);
            DefinitionSketch.EndEdit();
        }

        /// <summary>
        /// Создание 2D документа окружности.
        /// </summary>
        /// <param name="circleDiameter"></param>
        public void CreateDocument2DCircle(double circleDiameter)
        {
            Document2D = DefinitionSketch.BeginEdit();
            Document2D.ksCircle(0, 0, circleDiameter / 2, 1);
            DefinitionSketch.EndEdit();
        }

        /// <summary>
        /// Создание 2D документа окружности.
        /// </summary>
        /// <param name="circleDiameter">Диаметр окружности шляпки.</param>
        /// <param name="threadDiameter">Номинальный диаметр резьбы.</param>
        public void CreateDocument2DCircleAndSquare(
            double circleDiameter,
            double threadDiameter)
        {
            Document2D = DefinitionSketch.BeginEdit();
            var hexagon = (ksRegularPolygonParam)KompasObject.GetParamStruct(92);
            hexagon.count = 4;
            hexagon.ang = 90;
            hexagon.radius = threadDiameter / 2;
            hexagon.describe = true;
            hexagon.style = 1;
            Document2D.ksRegularPolygon(hexagon);
            Document2D.ksCircle(0, 0, circleDiameter / 2, 1);
            DefinitionSketch.EndEdit();
        }

        /// <summary>
        /// Создание 2D документа шестиугольника и окружности.
        /// </summary>
        /// <param name="boltHeadDiameter">Радиус шляпки болта.</param>
        /// <param name="threadDiameter">Диаметр резьбы.</param>
        public void CreateDocument2DHexagonAndCircle(
            double boltHeadDiameter,
            double threadDiameter)
        {
            Document2D = DefinitionSketch.BeginEdit();
            var hexagon = (ksRegularPolygonParam)KompasObject.GetParamStruct(92);
            hexagon.count = 6;
            hexagon.ang = 90;
            hexagon.radius = boltHeadDiameter / 2;
            hexagon.describe = true;
            hexagon.style = 1;
            Document2D.ksRegularPolygon(hexagon);
            Document2D.ksCircle(0, 0, threadDiameter / 2, 1);
            DefinitionSketch.EndEdit();
        }

        /// <summary>
        /// Создание 2D документа треугольника.
        /// </summary>
        /// <param name="threadDiameter">Диаметр резьбы.</param>
        public void CreateDocument2DTriangle(double threadDiameter)
        {
            Document2D = DefinitionSketch.BeginEdit();
            var triangle = (ksRegularPolygonParam)KompasObject.GetParamStruct(92);
            triangle.count = 3;
            triangle.ang = 0;
            triangle.radius = 0.25;
            triangle.describe = true;
            triangle.style = 1;
            triangle.xc = threadDiameter / 2;
            Document2D.ksRegularPolygon(triangle);
            DefinitionSketch.EndEdit();
        }

        /// <summary>
        /// Создание операции выдавливания.
        /// </summary>
        /// <param name="depth">Глубина выдавливания.</param>
        public void CreateExtrusionParam(float depth)
        {
            EntityExtrusion = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ExtrusionDef = (ksBossExtrusionDefinition)EntityExtrusion.GetDefinition();
            ExtrusionProp = (ksExtrusionParam)ExtrusionDef.ExtrusionParam();
            ExtrusionDef.SetSketch(Sketch);
            ExtrusionProp.direction = (short)Direction_Type.dtNormal;
            ExtrusionProp.typeNormal = (short)End_Type.etBlind;
            ExtrusionProp.depthNormal = depth;
            EntityExtrusion.Create();
        }

        /// <summary>
        /// Создание операции выреза.
        /// </summary>
        /// <param name="depth">Глубина выреза.</param>
        public void CreateCutParam(float depth)
        {
            EntityCut = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            CutDef = (ksCutExtrusionDefinition)EntityCut.GetDefinition();
            ExtrusionProp = (ksExtrusionParam)CutDef.ExtrusionParam();
            CutDef.SetSketch(Sketch);
            ExtrusionProp.direction = (short)Direction_Type.dtNormal;
            ExtrusionProp.typeNormal = (short)End_Type.etBlind;
            ExtrusionProp.depthNormal = depth;
            EntityCut.Create();
        }

        /// <summary>
        /// Создание конусообразной спирали.
        /// </summary>
        /// <param name="threadLength">Длина резьбы.</param>
        /// <param name="threadDiameter">Радиус резьбы.</param>
        public void CreateSpiralParam(double threadLength, double threadDiameter)
        {
            EntitySpiral = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_conicSpiral);
            var conicSpiralDefinition = (ksConicSpiralDefinition)EntitySpiral.GetDefinition();
            conicSpiralDefinition.SetPlane((ksEntity)Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            conicSpiralDefinition.turn = threadLength;
            conicSpiralDefinition.step = 1;
            conicSpiralDefinition.initialDiam = threadDiameter;
            conicSpiralDefinition.terminalDiam = threadDiameter;
            EntitySpiral.Create();
        }

        /// <summary>
        /// Создание операции выреза по траектории.
        /// </summary>
        public void CreateCutTParam(bool BoltHeadType)
        {
            if (BoltHeadType == true)
            {
                EntityCutEvolution = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_cutEvolution);
                CutEvolutionDefinition = (ksCutEvolutionDefinition)EntityCutEvolution.GetDefinition();
                CutEvolutionDefinition.cut = true;
                CutEvolutionDefinition.sketchShiftType = 1;
                CutEvolutionDefinition.SetSketch(Part.GetObjectByName(
                    "Эскиз:4",
                    (short)Obj3dType.o3d_sketch,
                    true,
                    true));
                var entityCollection = (ksEntityCollection)CutEvolutionDefinition.PathPartArray();
                entityCollection.Clear();
                entityCollection.Add(Part.GetObjectByName(
                    "Спираль:1",
                    (short)Obj3dType.o3d_cylindricSpiral,
                    true,
                    true));
                EntityCutEvolution.Create();
            }
            else
            {
                EntityCutEvolution = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_bossEvolution);
                bossEvolutionDefinition = (ksBossEvolutionDefinition)EntityCutEvolution.GetDefinition();
                bossEvolutionDefinition.sketchShiftType = 1;
                bossEvolutionDefinition.SetSketch(Part.GetObjectByName(
                    "Эскиз:5",
                    (short)Obj3dType.o3d_sketch,
                    true,
                    true));
                var entityCollection = (ksEntityCollection)bossEvolutionDefinition.PathPartArray();
                entityCollection.Clear();
                entityCollection.Add(Part.GetObjectByName(
                    "Спираль:1",
                    (short)Obj3dType.o3d_cylindricSpiral,
                    true,
                    true));
                EntityCutEvolution.Create();
            }
        }

        /// <summary>
        /// Метод для создания скругления на выбранном ребре.
        /// </summary>
        /// <param name="chamferRadius">Радиус скругления.</param>
        /// <param name="x">Координата ребра по X.</param>
        /// <param name="y">Координата ребра по Y.</param>
        /// <param name="z">Координата ребра по Z.</param>
        public void CreateChamfer(
            double chamferRadius,
            double x,
            double y,
            double z)
        {
            var chamferEntity = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_fillet);
            var chamferDefinition = (ksFilletDefinition)chamferEntity.GetDefinition();

            if (chamferDefinition == null)
            {
                return;
            }

            chamferDefinition.radius = chamferRadius;
            chamferDefinition.tangent = true;
            var entityArray = (ksEntityCollection)chamferDefinition.array();
            var entityCollection = (ksEntityCollection)Part.EntityCollection((short)Obj3dType.o3d_edge);
            entityCollection.SelectByPoint(x, y, z);
            var entityEdge = entityCollection.Last();
            entityArray.Add(entityEdge);
            chamferEntity.Create();
        }
    }
}
