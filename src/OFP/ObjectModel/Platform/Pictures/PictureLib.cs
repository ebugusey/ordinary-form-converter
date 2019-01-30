using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.Platform.Pictures
{

    public static class PictureLib
    {
        private static readonly Dictionary<int, StdPicture<int>> _numericValues;
        private static readonly Dictionary<Guid, StdPicture<Guid>> _guidValues;

        private static readonly Dictionary<Identifier, StdPicture<int>> _numericValueByName;
        private static readonly Dictionary<Identifier, StdPicture<Guid>> _guidValuesByName;

        static PictureLib()
        {
            var numeric = GetAllValues<int>().ToList();
            var guids = GetAllValues<Guid>().ToList();

            _numericValues = numeric.ToDictionary(v => v.Value);
            _guidValues = guids.ToDictionary(v => v.Value);

            _numericValueByName = numeric.ToDictionary(v => (Identifier)v.Name);
            _guidValuesByName = guids.ToDictionary(v => (Identifier)v.Name);
        }

        public static bool TryGetPicture(int value, out StdPicture<int> picture)
        {
            return _numericValues.TryGetValue(value, out picture);
        }

        public static bool TryGetPicture(Guid value, out StdPicture<Guid> picture)
        {
            return _guidValues.TryGetValue(value, out picture);
        }

        public static bool TryGetPicture(Identifier name, out PictureFromLib picture)
        {
            bool result;
            if (_numericValueByName.TryGetValue(name, out var numeric))
            {
                picture = numeric;
                result = true;
            }
            else if (_guidValuesByName.TryGetValue(name, out var guid))
            {
                picture = guid;
                result = true;
            }
            else
            {
                picture = default;
                result = false;
            }

            return result;
        }

        private static IEnumerable<StdPicture<T>> GetAllValues<T>() where T : struct
        {
            var values =
                from field in typeof(PictureLib).GetFields(BindingFlags.Public | BindingFlags.Static)
                where field.FieldType == typeof(StdPicture<T>)
                select (StdPicture<T>)field.GetValue(null);

            return values;
        }

        /// <summary>
        /// Выбрать.
        /// </summary>
        public static readonly StdPicture<int> Select = new StdPicture<int>(
            name: nameof(Select),
            value: -1);

        /// <summary>
        /// ВыбратьТип.
        /// </summary>
        public static readonly StdPicture<int> ChooseType = new StdPicture<int>(
            name: nameof(ChooseType),
            value: -14);

        /// <summary>
        /// ЗатенитьФлажки.
        /// </summary>
        public static readonly StdPicture<int> GrayedAll = new StdPicture<int>(
            name: nameof(GrayedAll),
            value: -12);

        /// <summary>
        /// Календарь.
        /// </summary>
        public static readonly StdPicture<int> Calendar = new StdPicture<int>(
            name: nameof(Calendar),
            value: -5);

        /// <summary>
        /// Калькулятор.
        /// </summary>
        public static readonly StdPicture<int> Calculator = new StdPicture<int>(
            name: nameof(Calculator),
            value: -6);

        /// <summary>
        /// Лупа.
        /// </summary>
        public static readonly StdPicture<int> Magnifier = new StdPicture<int>(
            name: nameof(Magnifier),
            value: -7);

        /// <summary>
        /// Очистить.
        /// </summary>
        public static readonly StdPicture<int> Clear = new StdPicture<int>(
            name: nameof(Clear),
            value: -2);

        /// <summary>
        /// ПереместитьВверх.
        /// </summary>
        public static readonly StdPicture<int> MoveUp = new StdPicture<int>(
            name: nameof(MoveUp),
            value: -3);

        /// <summary>
        /// ПереместитьВлево.
        /// </summary>
        public static readonly StdPicture<int> MoveLeft = new StdPicture<int>(
            name: nameof(MoveLeft),
            value: -8);

        /// <summary>
        /// ПереместитьВниз.
        /// </summary>
        public static readonly StdPicture<int> MoveDown = new StdPicture<int>(
            name: nameof(MoveDown),
            value: -4);

        /// <summary>
        /// ПереместитьВправо.
        /// </summary>
        public static readonly StdPicture<int> MoveRight = new StdPicture<int>(
            name: nameof(MoveRight),
            value: -9);

        /// <summary>
        /// Печать.
        /// </summary>
        public static readonly StdPicture<int> Print = new StdPicture<int>(
            name: nameof(Print),
            value: -13);

        /// <summary>
        /// СнятьФлажки.
        /// </summary>
        public static readonly StdPicture<int> UncheckAll = new StdPicture<int>(
            name: nameof(UncheckAll),
            value: -11);

        /// <summary>
        /// УстановитьФлажки.
        /// </summary>
        public static readonly StdPicture<int> CheckAll = new StdPicture<int>(
            name: nameof(CheckAll),
            value: -10);
        /// <summary>
        /// АктивироватьЗадачу.
        /// </summary>
        public static readonly StdPicture<Guid> ActivateTask = new StdPicture<Guid>(
            name: nameof(ActivateTask),
            value: new Guid("093dd4ed-e03c-4fc6-a95a-01f51379cccf"));

        /// <summary>
        /// АктивныеПользователи.
        /// </summary>
        public static readonly StdPicture<Guid> ActiveUsers = new StdPicture<Guid>(
            name: nameof(ActiveUsers),
            value: new Guid("47f01799-7968-4f44-9acc-fe1bdde8beb2"));

        /// <summary>
        /// БизнесПроцесс.
        /// </summary>
        public static readonly StdPicture<Guid> BusinessProcess = new StdPicture<Guid>(
            name: nameof(BusinessProcess),
            value: new Guid("509c4a7f-6406-4388-bb8c-bc81fb5131aa"));

        /// <summary>
        /// БизнесПроцессОбъект.
        /// </summary>
        public static readonly StdPicture<Guid> BusinessProcessObject = new StdPicture<Guid>(
            name: nameof(BusinessProcessObject),
            value: new Guid("a24cff7f-a1a5-4403-af82-a7b31852cde9"));

        /// <summary>
        /// ВводНаОсновании.
        /// </summary>
        public static readonly StdPicture<Guid> InputOnBasis = new StdPicture<Guid>(
            name: nameof(InputOnBasis),
            value: new Guid("01ec9d9a-7497-4d88-b93f-066c633a4866"));

        /// <summary>
        /// ВидРасчета.
        /// </summary>
        public static readonly StdPicture<Guid> CalculationType = new StdPicture<Guid>(
            name: nameof(CalculationType),
            value: new Guid("80837aab-ad67-4811-9d83-88344439c721"));

        /// <summary>
        /// ВложеннаяТаблица.
        /// </summary>
        public static readonly StdPicture<Guid> NestedTable = new StdPicture<Guid>(
            name: nameof(NestedTable),
            value: new Guid("52b637e5-f95f-4c70-9a72-2a4b5a9df449"));

        /// <summary>
        /// ВнешнийИсточникДанных.
        /// </summary>
        public static readonly StdPicture<Guid> ExternalDataSource = new StdPicture<Guid>(
            name: nameof(ExternalDataSource),
            value: new Guid("3a32aa35-c679-4c5b-91bd-72ae038e5bb4"));

        /// <summary>
        /// ВнешнийИсточникДанныхКуб.
        /// </summary>
        public static readonly StdPicture<Guid> ExternalDataSourceCube = new StdPicture<Guid>(
            name: nameof(ExternalDataSourceCube),
            value: new Guid("fad46a2b-2e56-47cc-b90c-3c2d4b061937"));

        /// <summary>
        /// ВнешнийИсточникДанныхКубТаблицаИзмерения.
        /// </summary>
        public static readonly StdPicture<Guid> ExternalDataSourceCubeDimensionTable = new StdPicture<Guid>(
            name: nameof(ExternalDataSourceCubeDimensionTable),
            value: new Guid("32b63e58-c1fa-4f59-b874-bf4a077f816e"));

        /// <summary>
        /// ВнешнийИсточникДанныхТаблица.
        /// </summary>
        public static readonly StdPicture<Guid> ExternalDataSourceTable = new StdPicture<Guid>(
            name: nameof(ExternalDataSourceTable),
            value: new Guid("5b612c21-e223-4997-9e61-86f7a67ec945"));

        /// <summary>
        /// ВнешнийИсточникДанныхФункция.
        /// </summary>
        public static readonly StdPicture<Guid> ExternalDataSourceFunction = new StdPicture<Guid>(
            name: nameof(ExternalDataSourceFunction),
            value: new Guid("2954e819-f3fc-40de-9769-292efce9a355"));

        /// <summary>
        /// ВосстановитьЗначения.
        /// </summary>
        public static readonly StdPicture<Guid> RestoreValues = new StdPicture<Guid>(
            name: nameof(RestoreValues),
            value: new Guid("a7707ed1-39b0-418f-974d-4d500d27a9c6"));

        /// <summary>
        /// Вперед.
        /// </summary>
        public static readonly StdPicture<Guid> Forward = new StdPicture<Guid>(
            name: nameof(Forward),
            value: new Guid("f874b0cc-db1d-4577-8c77-d4ba206eb05d"));

        /// <summary>
        /// ВыборКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionSelection = new StdPicture<Guid>(
            name: nameof(DataCompositionSelection),
            value: new Guid("2c732bfa-f734-48bc-a18b-7554db8a3888"));

        /// <summary>
        /// ВыборКомпоновкиДанныхНедоступный.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionSelectionDisabled = new StdPicture<Guid>(
            name: nameof(DataCompositionSelectionDisabled),
            value: new Guid("a0b879df-db58-4cba-b76e-9bbc4391f3d9"));

        /// <summary>
        /// ВыбратьВерхнийУровень.
        /// </summary>
        public static readonly StdPicture<Guid> ChooseTopLevel = new StdPicture<Guid>(
            name: nameof(ChooseTopLevel),
            value: new Guid("38a5a658-ec2b-4ddf-8088-c6d2169d3181"));

        /// <summary>
        /// ВыбратьЗначение.
        /// </summary>
        public static readonly StdPicture<Guid> ChooseValue = new StdPicture<Guid>(
            name: nameof(ChooseValue),
            value: new Guid("2f130057-bb2a-4e22-bba5-e108fac26940"));

        /// <summary>
        /// ВыбратьИзСписка.
        /// </summary>
        public static readonly StdPicture<Guid> ChooseFromList = new StdPicture<Guid>(
            name: nameof(ChooseFromList),
            value: new Guid("7168f070-087c-448e-ae3a-6740f424076a"));

        /// <summary>
        /// ВывестиСписок.
        /// </summary>
        public static readonly StdPicture<Guid> OutputList = new StdPicture<Guid>(
            name: nameof(OutputList),
            value: new Guid("c2e2d966-5b7f-4699-903b-28a6f50d5471"));

        /// <summary>
        /// ВыполнитьЗадачу.
        /// </summary>
        public static readonly StdPicture<Guid> ExecuteTask = new StdPicture<Guid>(
            name: nameof(ExecuteTask),
            value: new Guid("003024ed-fa25-42ac-9f53-f5014e383801"));

        /// <summary>
        /// ГеографическаяСхема.
        /// </summary>
        public static readonly StdPicture<Guid> GeographicalSchema = new StdPicture<Guid>(
            name: nameof(GeographicalSchema),
            value: new Guid("a9152be7-62cf-4523-be34-a23f018f497e"));

        /// <summary>
        /// ГрафическаяСхема.
        /// </summary>
        public static readonly StdPicture<Guid> GraphicalSchema = new StdPicture<Guid>(
            name: nameof(GraphicalSchema),
            value: new Guid("e96de06b-fa83-48cf-b033-190a249855c9"));

        /// <summary>
        /// Дебет.
        /// </summary>
        public static readonly StdPicture<Guid> Debit = new StdPicture<Guid>(
            name: nameof(Debit),
            value: new Guid("196622f7-0941-435b-992b-722f3082adf4"));

        /// <summary>
        /// ДебетКредит.
        /// </summary>
        public static readonly StdPicture<Guid> DebitCredit = new StdPicture<Guid>(
            name: nameof(DebitCredit),
            value: new Guid("ed067d76-b144-4d00-bb36-d1833dd1350c"));

        /// <summary>
        /// Дендрограмма.
        /// </summary>
        public static readonly StdPicture<Guid> Dendrogram = new StdPicture<Guid>(
            name: nameof(Dendrogram),
            value: new Guid("4bf9fbb5-53c5-4b09-bab2-d69bbfab945b"));

        /// <summary>
        /// Диаграмма.
        /// </summary>
        public static readonly StdPicture<Guid> Chart = new StdPicture<Guid>(
            name: nameof(Chart),
            value: new Guid("f3c1376a-d2ee-46c4-9e44-aa2f7dae31c4"));

        /// <summary>
        /// ДиаграммаГанта.
        /// </summary>
        public static readonly StdPicture<Guid> GanttChart = new StdPicture<Guid>(
            name: nameof(GanttChart),
            value: new Guid("fa67cb81-8d56-4534-90bd-b62fb0dbf5f0"));

        /// <summary>
        /// ДобавитьВИзбранное.
        /// </summary>
        public static readonly StdPicture<Guid> AddToFavorites = new StdPicture<Guid>(
            name: nameof(AddToFavorites),
            value: new Guid("1001ae3e-9289-4303-9699-3c0c17e20e61"));

        /// <summary>
        /// ДобавитьЭлементСписка.
        /// </summary>
        public static readonly StdPicture<Guid> AddListItem = new StdPicture<Guid>(
            name: nameof(AddListItem),
            value: new Guid("2a0c2238-cb59-4473-ada6-352b60f3c0a9"));

        /// <summary>
        /// Документ.
        /// </summary>
        public static readonly StdPicture<Guid> Document = new StdPicture<Guid>(
            name: nameof(Document),
            value: new Guid("894afc03-9904-465d-b671-f555ffb9b21c"));

        /// <summary>
        /// ДокументОбъект.
        /// </summary>
        public static readonly StdPicture<Guid> DocumentObject = new StdPicture<Guid>(
            name: nameof(DocumentObject),
            value: new Guid("2209b937-6f41-4153-b1ac-ef7e170ad3a7"));

        /// <summary>
        /// ЖурналДокументов.
        /// </summary>
        public static readonly StdPicture<Guid> DocumentJournal = new StdPicture<Guid>(
            name: nameof(DocumentJournal),
            value: new Guid("e51185a4-d915-45b8-b201-1c46cc2d8104"));

        /// <summary>
        /// ЖурналРегистрации.
        /// </summary>
        public static readonly StdPicture<Guid> EventLog = new StdPicture<Guid>(
            name: nameof(EventLog),
            value: new Guid("723765ab-0b92-4745-a621-1ba0f77c92c9"));

        /// <summary>
        /// ЖурналРегистрацииПоПользователю.
        /// </summary>
        public static readonly StdPicture<Guid> EventLogByUser = new StdPicture<Guid>(
            name: nameof(EventLogByUser),
            value: new Guid("4fddea39-5129-4b4c-83fe-4e443cd61940"));

        /// <summary>
        /// ЗагрузитьНастройкиОтчета.
        /// </summary>
        public static readonly StdPicture<Guid> LoadReportSettings = new StdPicture<Guid>(
            name: nameof(LoadReportSettings),
            value: new Guid("283ecabd-aaed-41d1-ad46-6cca91c29120"));

        /// <summary>
        /// Задача.
        /// </summary>
        public static readonly StdPicture<Guid> Task = new StdPicture<Guid>(
            name: nameof(Task),
            value: new Guid("37cf7cc0-abad-4385-b597-6fd2d8dc085a"));

        /// <summary>
        /// ЗадачаОбъект.
        /// </summary>
        public static readonly StdPicture<Guid> TaskObject = new StdPicture<Guid>(
            name: nameof(TaskObject),
            value: new Guid("b9e2dae2-b205-4442-aee5-802cd82f5199"));

        /// <summary>
        /// ЗакончитьРедактирование.
        /// </summary>
        public static readonly StdPicture<Guid> EndEdit = new StdPicture<Guid>(
            name: nameof(EndEdit),
            value: new Guid("ed0bec43-4633-416c-8c08-0384ca444e32"));

        /// <summary>
        /// Закрыть.
        /// </summary>
        public static readonly StdPicture<Guid> Close = new StdPicture<Guid>(
            name: nameof(Close),
            value: new Guid("1377931c-5744-4948-bade-cb35117b5f63"));

        /// <summary>
        /// Заменить.
        /// </summary>
        public static readonly StdPicture<Guid> Replace = new StdPicture<Guid>(
            name: nameof(Replace),
            value: new Guid("6cb69e7f-fe19-4f64-bfb5-1a4fad6c2ef9"));

        /// <summary>
        /// Записать.
        /// </summary>
        public static readonly StdPicture<Guid> Write = new StdPicture<Guid>(
            name: nameof(Write),
            value: new Guid("894cf65b-4109-4533-a1d7-c87b1fcc80a3"));

        /// <summary>
        /// ЗаписатьИЗакрыть.
        /// </summary>
        public static readonly StdPicture<Guid> WriteAndClose = new StdPicture<Guid>(
            name: nameof(WriteAndClose),
            value: new Guid("e6fc55a0-3d58-4b15-bdd3-717453929598"));

        /// <summary>
        /// ЗаписатьИзменения.
        /// </summary>
        public static readonly StdPicture<Guid> WriteChanges = new StdPicture<Guid>(
            name: nameof(WriteChanges),
            value: new Guid("f62488ee-f90c-47f7-929d-f42ec11a1e63"));

        /// <summary>
        /// ЗафиксироватьТаблицу.
        /// </summary>
        public static readonly StdPicture<Guid> FixTable = new StdPicture<Guid>(
            name: nameof(FixTable),
            value: new Guid("5182f57f-e834-4d11-9c9f-4aedc002b6e9"));

        /// <summary>
        /// ИерархическийПросмотр.
        /// </summary>
        public static readonly StdPicture<Guid> HierarchicalView = new StdPicture<Guid>(
            name: nameof(HierarchicalView),
            value: new Guid("a119150f-6c0c-4a94-97b0-5f08d7ebd6f5"));

        /// <summary>
        /// Изменить.
        /// </summary>
        public static readonly StdPicture<Guid> Change = new StdPicture<Guid>(
            name: nameof(Change),
            value: new Guid("97b2cc97-d5c6-45fb-9824-9d6d73db21fe"));

        /// <summary>
        /// ИзменитьФорму.
        /// </summary>
        public static readonly StdPicture<Guid> CustomizeForm = new StdPicture<Guid>(
            name: nameof(CustomizeForm),
            value: new Guid("6511326b-20c3-4bf8-8503-c2c2c9072c6c"));

        /// <summary>
        /// ИзменитьЭлементСписка.
        /// </summary>
        public static readonly StdPicture<Guid> ChangeListItem = new StdPicture<Guid>(
            name: nameof(ChangeListItem),
            value: new Guid("da0c4924-973c-4ef0-9dcf-f1fc3307e5e2"));

        /// <summary>
        /// Измерение.
        /// </summary>
        public static readonly StdPicture<Guid> Dimension = new StdPicture<Guid>(
            name: nameof(Dimension),
            value: new Guid("c78c9f3d-e92c-4f38-bb72-d8bd7fa5dbe3"));

        /// <summary>
        /// ИсторияОтборов.
        /// </summary>
        public static readonly StdPicture<Guid> FilterHistory = new StdPicture<Guid>(
            name: nameof(FilterHistory),
            value: new Guid("8729a534-9f88-47b0-8d6b-ec213689580d"));

        /// <summary>
        /// Картинка.
        /// </summary>
        public static readonly StdPicture<Guid> Picture = new StdPicture<Guid>(
            name: nameof(Picture),
            value: new Guid("64837726-d2a2-4682-a788-737423e80013"));

        /// <summary>
        /// Константа.
        /// </summary>
        public static readonly StdPicture<Guid> Constant = new StdPicture<Guid>(
            name: nameof(Constant),
            value: new Guid("e93f538e-dfaf-4a91-a9b6-c053555bcf60"));

        /// <summary>
        /// КонструкторЗапроса.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizard = new StdPicture<Guid>(
            name: nameof(QueryWizard),
            value: new Guid("1f046bc2-d6c5-46a3-a459-b2c0508f86fb"));

        /// <summary>
        /// КонструкторЗапросаВложенныйЗапрос.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizardNestedQuery = new StdPicture<Guid>(
            name: nameof(QueryWizardNestedQuery),
            value: new Guid("c5501b77-0070-46e3-8ebd-f04a61eb9a73"));

        /// <summary>
        /// КонструкторЗапросаВременнаяТаблица.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizardTempTable = new StdPicture<Guid>(
            name: nameof(QueryWizardTempTable),
            value: new Guid("64ca52ee-f1a3-468f-8055-311935077515"));

        /// <summary>
        /// КонструкторЗапросаГруппаВременныхТаблиц.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizardTempTablesGroup = new StdPicture<Guid>(
            name: nameof(QueryWizardTempTablesGroup),
            value: new Guid("49369551-39dc-4adb-8795-5ab619c6c2bd"));

        /// <summary>
        /// КонструкторЗапросаЗаменитьТаблицу.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizardReplaceTable = new StdPicture<Guid>(
            name: nameof(QueryWizardReplaceTable),
            value: new Guid("a9481ba4-dc85-4112-9c50-f9f340a61298"));

        /// <summary>
        /// КонструкторЗапросаОписаниеВременнойТаблицы.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizardTempTableDescription = new StdPicture<Guid>(
            name: nameof(QueryWizardTempTableDescription),
            value: new Guid("6b322d7c-3fa2-437d-b311-fd70c4c7ed46"));

        /// <summary>
        /// КонструкторЗапросаОтображатьТаблицыИзменений.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizardShowChangesTables = new StdPicture<Guid>(
            name: nameof(QueryWizardShowChangesTables),
            value: new Guid("270de5f0-f2df-4845-9fde-30b1ec486217"));

        /// <summary>
        /// КонструкторЗапросаПараметрыТаблицы.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizardTableParameters = new StdPicture<Guid>(
            name: nameof(QueryWizardTableParameters),
            value: new Guid("fe740df0-d828-4241-a12f-7414e12302e8"));

        /// <summary>
        /// КонструкторЗапросаСоздатьВложенныйЗапрос.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizardCreateNestedQuery = new StdPicture<Guid>(
            name: nameof(QueryWizardCreateNestedQuery),
            value: new Guid("18bca3d7-a7a5-41df-a180-4dff9c217f43"));

        /// <summary>
        /// КонструкторЗапросаСоздатьЗапросУничтоженияВременнойТаблицы.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizardCreateTempTableDropQuery = new StdPicture<Guid>(
            name: nameof(QueryWizardCreateTempTableDropQuery),
            value: new Guid("7df3febb-2640-41b7-ad8b-7a23b7ad4aec"));

        /// <summary>
        /// КонструкторЗапросаСоздатьОписаниеВременнойТаблицы.
        /// </summary>
        public static readonly StdPicture<Guid> QueryWizardCreateTempTableDescription = new StdPicture<Guid>(
            name: nameof(QueryWizardCreateTempTableDescription),
            value: new Guid("7604cff7-5cc6-4f88-8d16-504f01b92a3c"));

        /// <summary>
        /// КонструкторНастроекКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionSettingsWizard = new StdPicture<Guid>(
            name: nameof(DataCompositionSettingsWizard),
            value: new Guid("affb1617-24bc-4170-9c84-0902cc3ef206"));

        /// <summary>
        /// Кредит.
        /// </summary>
        public static readonly StdPicture<Guid> Credit = new StdPicture<Guid>(
            name: nameof(Credit),
            value: new Guid("55bc1099-a7df-4d0a-b332-a45f0473b368"));

        /// <summary>
        /// КритерийОтбора.
        /// </summary>
        public static readonly StdPicture<Guid> FilterCriterion = new StdPicture<Guid>(
            name: nameof(FilterCriterion),
            value: new Guid("2ef82795-06fe-4365-bd0c-44b486264620"));

        /// <summary>
        /// Назад.
        /// </summary>
        public static readonly StdPicture<Guid> Back = new StdPicture<Guid>(
            name: nameof(Back),
            value: new Guid("3c904ff7-1195-4a7c-9a38-7b1f6ca49cce"));

        /// <summary>
        /// Найти.
        /// </summary>
        public static readonly StdPicture<Guid> Find = new StdPicture<Guid>(
            name: nameof(Find),
            value: new Guid("ffab30f1-da11-44b5-b34c-24da22badcf4"));

        /// <summary>
        /// НайтиВДереве.
        /// </summary>
        public static readonly StdPicture<Guid> FindInTree = new StdPicture<Guid>(
            name: nameof(FindInTree),
            value: new Guid("38bbcebe-e456-461b-8457-07c9a72344a3"));

        /// <summary>
        /// НайтиВСодержании.
        /// </summary>
        public static readonly StdPicture<Guid> SyncContents = new StdPicture<Guid>(
            name: nameof(SyncContents),
            value: new Guid("3bdc16c8-6a96-4467-9442-a8e4804b3fa2"));

        /// <summary>
        /// НайтиВСписке.
        /// </summary>
        public static readonly StdPicture<Guid> FindInList = new StdPicture<Guid>(
            name: nameof(FindInList),
            value: new Guid("c7cdd3c0-3879-436a-b145-5e2615e9b3e1"));

        /// <summary>
        /// НайтиПоНомеру.
        /// </summary>
        public static readonly StdPicture<Guid> FindByNumber = new StdPicture<Guid>(
            name: nameof(FindByNumber),
            value: new Guid("4eb938cb-7d69-4f3d-ac17-1f20f1212d49"));

        /// <summary>
        /// НайтиПредыдущий.
        /// </summary>
        public static readonly StdPicture<Guid> FindPrevious = new StdPicture<Guid>(
            name: nameof(FindPrevious),
            value: new Guid("e3b38083-0191-4a10-8f5b-51571f2419b4"));

        /// <summary>
        /// НайтиСледующий.
        /// </summary>
        public static readonly StdPicture<Guid> FindNext = new StdPicture<Guid>(
            name: nameof(FindNext),
            value: new Guid("05612131-3e11-49c0-9592-07e6d9318ef7"));

        /// <summary>
        /// НастроитьСписок.
        /// </summary>
        public static readonly StdPicture<Guid> CustomizeList = new StdPicture<Guid>(
            name: nameof(CustomizeList),
            value: new Guid("f04794cb-c198-4172-86c3-649386013c85"));

        /// <summary>
        /// НастройкаСписка.
        /// </summary>
        public static readonly StdPicture<Guid> ListSettings = new StdPicture<Guid>(
            name: nameof(ListSettings),
            value: new Guid("31b93f03-0ba2-4631-a171-0d3a3d2ecc48"));

        /// <summary>
        /// НастройкиОтчета.
        /// </summary>
        public static readonly StdPicture<Guid> ReportSettings = new StdPicture<Guid>(
            name: nameof(ReportSettings),
            value: new Guid("942e0303-a3ec-4fe8-887c-5aea8516d424"));

        /// <summary>
        /// НоваяВложеннаяСхемаКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionNewNestedScheme = new StdPicture<Guid>(
            name: nameof(DataCompositionNewNestedScheme),
            value: new Guid("8ac19694-383a-457a-b050-0a3ee937f5f3"));

        /// <summary>
        /// НоваяГруппа.
        /// </summary>
        public static readonly StdPicture<Guid> NewFolder = new StdPicture<Guid>(
            name: nameof(NewFolder),
            value: new Guid("ea3383df-7098-42f2-ba46-2fc891f799cb"));

        /// <summary>
        /// НоваяГруппировкаКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionNewGroup = new StdPicture<Guid>(
            name: nameof(DataCompositionNewGroup),
            value: new Guid("77180b5e-8faa-4712-a788-e9f8903e3419"));

        /// <summary>
        /// НоваяДиаграммаКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionNewChart = new StdPicture<Guid>(
            name: nameof(DataCompositionNewChart),
            value: new Guid("732f9dd3-5baf-47ff-af7b-edfe16dac2a1"));

        /// <summary>
        /// НоваяТаблицаКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionNewTable = new StdPicture<Guid>(
            name: nameof(DataCompositionNewTable),
            value: new Guid("6c2759b1-2b63-4fa5-8d13-75786c7e1e89"));

        /// <summary>
        /// НовоеОкно.
        /// </summary>
        public static readonly StdPicture<Guid> NewWindow = new StdPicture<Guid>(
            name: nameof(NewWindow),
            value: new Guid("eb47324b-85f9-4172-9315-bba8015d9970"));

        /// <summary>
        /// Обновить.
        /// </summary>
        public static readonly StdPicture<Guid> Refresh = new StdPicture<Guid>(
            name: nameof(Refresh),
            value: new Guid("fc4f29e0-d168-4fe0-8e64-e982fabf2595"));

        /// <summary>
        /// Обработка.
        /// </summary>
        public static readonly StdPicture<Guid> DataProcessor = new StdPicture<Guid>(
            name: nameof(DataProcessor),
            value: new Guid("a6cbfd77-fcf0-40f4-a8de-ee0d3e580fe6"));

        /// <summary>
        /// Остановить.
        /// </summary>
        public static readonly StdPicture<Guid> Stop = new StdPicture<Guid>(
            name: nameof(Stop),
            value: new Guid("1cd7b762-ec6a-4e92-ac9a-1832be228ec3"));

        /// <summary>
        /// ОтборИСортировка.
        /// </summary>
        public static readonly StdPicture<Guid> FilterAndSort = new StdPicture<Guid>(
            name: nameof(FilterAndSort),
            value: new Guid("73af51dd-6cda-48be-a093-5a7161c60c77"));

        /// <summary>
        /// ОтборКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionFilter = new StdPicture<Guid>(
            name: nameof(DataCompositionFilter),
            value: new Guid("d90a7482-9a1d-4d3d-ae96-6db440214d96"));

        /// <summary>
        /// ОтборКомпоновкиДанныхНедоступный.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionFilterDisabled = new StdPicture<Guid>(
            name: nameof(DataCompositionFilterDisabled),
            value: new Guid("d35bd799-1cc3-44d1-8ae3-09755a09d44b"));

        /// <summary>
        /// ОтборПоВиду.
        /// </summary>
        public static readonly StdPicture<Guid> FilterByType = new StdPicture<Guid>(
            name: nameof(FilterByType),
            value: new Guid("0bac63da-5b4e-48af-b593-7c5d29663e83"));

        /// <summary>
        /// ОтборПоТекущемуЗначению.
        /// </summary>
        public static readonly StdPicture<Guid> FilterByCurrentValue = new StdPicture<Guid>(
            name: nameof(FilterByCurrentValue),
            value: new Guid("b1406535-6cc2-4410-95ea-753556e8460f"));

        /// <summary>
        /// ОтключитьОтбор.
        /// </summary>
        public static readonly StdPicture<Guid> ClearFilter = new StdPicture<Guid>(
            name: nameof(ClearFilter),
            value: new Guid("479470e0-ea0f-4266-8549-e2b1e8c06534"));

        /// <summary>
        /// ОткрытьФайл.
        /// </summary>
        public static readonly StdPicture<Guid> OpenFile = new StdPicture<Guid>(
            name: nameof(OpenFile),
            value: new Guid("785362cb-3756-48ed-87d2-292ded17054a"));

        /// <summary>
        /// ОтменаПроведения.
        /// </summary>
        public static readonly StdPicture<Guid> UndoPosting = new StdPicture<Guid>(
            name: nameof(UndoPosting),
            value: new Guid("8ca4ea33-603d-4992-8a41-c7924b5bd40b"));

        /// <summary>
        /// ОтменитьПоиск.
        /// </summary>
        public static readonly StdPicture<Guid> CancelSearch = new StdPicture<Guid>(
            name: nameof(CancelSearch),
            value: new Guid("9e808d29-787b-4825-863a-13c6844ce91d"));

        /// <summary>
        /// Отчет.
        /// </summary>
        public static readonly StdPicture<Guid> Report = new StdPicture<Guid>(
            name: nameof(Report),
            value: new Guid("db817ee1-fd28-4e7f-bb4a-53686b2b153c"));

        /// <summary>
        /// ПараметрыВыводаКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionOutputParameters = new StdPicture<Guid>(
            name: nameof(DataCompositionOutputParameters),
            value: new Guid("ee7c4a5b-2d9b-4087-ae3e-947792085f09"));

        /// <summary>
        /// ПараметрыВыводаКомпоновкиДанныхНедоступные.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionOutputParametersDisabled = new StdPicture<Guid>(
            name: nameof(DataCompositionOutputParametersDisabled),
            value: new Guid("1522a72e-11d1-41e3-ba0e-e0780c4ba543"));

        /// <summary>
        /// ПараметрыДанныхКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionDataParameters = new StdPicture<Guid>(
            name: nameof(DataCompositionDataParameters),
            value: new Guid("a075c3ef-bc4e-4c96-bdad-2245ec09c28e"));

        /// <summary>
        /// Переименовать.
        /// </summary>
        public static readonly StdPicture<Guid> Rename = new StdPicture<Guid>(
            name: nameof(Rename),
            value: new Guid("c8a269ff-5b6d-4f42-9fa6-369d7b492aa7"));

        /// <summary>
        /// ПерейтиВперед.
        /// </summary>
        public static readonly StdPicture<Guid> GoForward = new StdPicture<Guid>(
            name: nameof(GoForward),
            value: new Guid("7562cef7-0e57-4f63-a754-b61128a4f3ae"));

        /// <summary>
        /// ПерейтиККонцу.
        /// </summary>
        public static readonly StdPicture<Guid> GoToEnd = new StdPicture<Guid>(
            name: nameof(GoToEnd),
            value: new Guid("14b24498-e49c-4713-be64-75101d0abfb9"));

        /// <summary>
        /// ПерейтиКНачалу.
        /// </summary>
        public static readonly StdPicture<Guid> GoToBegin = new StdPicture<Guid>(
            name: nameof(GoToBegin),
            value: new Guid("85cc7dd0-44fc-41aa-967f-f52f202ee2e6"));

        /// <summary>
        /// ПерейтиНазад.
        /// </summary>
        public static readonly StdPicture<Guid> GoBack = new StdPicture<Guid>(
            name: nameof(GoBack),
            value: new Guid("892196a9-c94f-4e50-8224-3c0cea4ea6b8"));

        /// <summary>
        /// ПерейтиПоНавигационнойСсылке.
        /// </summary>
        public static readonly StdPicture<Guid> GotoURL = new StdPicture<Guid>(
            name: nameof(GotoURL),
            value: new Guid("3b2a508b-f36e-4e0b-9dc0-70b2b56276a9"));

        /// <summary>
        /// ПереключитьАктивность.
        /// </summary>
        public static readonly StdPicture<Guid> SwitchActivity = new StdPicture<Guid>(
            name: nameof(SwitchActivity),
            value: new Guid("6e3687cf-a8d1-446a-833a-bfaf38516353"));

        /// <summary>
        /// ПеренестиЭлемент.
        /// </summary>
        public static readonly StdPicture<Guid> MoveItem = new StdPicture<Guid>(
            name: nameof(MoveItem),
            value: new Guid("37e91e77-93ce-4c3b-8d30-a9d8cfd3d3b0"));

        /// <summary>
        /// Перечисление.
        /// </summary>
        public static readonly StdPicture<Guid> Enum = new StdPicture<Guid>(
            name: nameof(Enum),
            value: new Guid("80d1a756-13a8-4281-86cc-eaaf84da4cf9"));

        /// <summary>
        /// Перечитать.
        /// </summary>
        public static readonly StdPicture<Guid> Reread = new StdPicture<Guid>(
            name: nameof(Reread),
            value: new Guid("8f29e0e2-d5e6-41e8-a34d-9a0288156322"));

        /// <summary>
        /// ПечатьСразу.
        /// </summary>
        public static readonly StdPicture<Guid> PrintImmediately = new StdPicture<Guid>(
            name: nameof(PrintImmediately),
            value: new Guid("0abdab67-5c90-4296-8168-239d22024d11"));

        /// <summary>
        /// ПланВидовРасчета.
        /// </summary>
        public static readonly StdPicture<Guid> ChartOfCalculationTypes = new StdPicture<Guid>(
            name: nameof(ChartOfCalculationTypes),
            value: new Guid("b58ea40e-819b-4d07-bd9f-5fbf42e01f55"));

        /// <summary>
        /// ПланВидовРасчетаОбъект.
        /// </summary>
        public static readonly StdPicture<Guid> ChartOfCalculationTypesObject = new StdPicture<Guid>(
            name: nameof(ChartOfCalculationTypesObject),
            value: new Guid("64400154-ca4c-4a05-8028-83434fda5bef"));

        /// <summary>
        /// ПланВидовХарактеристик.
        /// </summary>
        public static readonly StdPicture<Guid> ChartOfCharacteristicTypes = new StdPicture<Guid>(
            name: nameof(ChartOfCharacteristicTypes),
            value: new Guid("2bfafd1e-6d07-4609-8010-6c1c605cefd2"));

        /// <summary>
        /// ПланВидовХарактеристикОбъект.
        /// </summary>
        public static readonly StdPicture<Guid> ChartOfCharacteristicTypesObject = new StdPicture<Guid>(
            name: nameof(ChartOfCharacteristicTypesObject),
            value: new Guid("45921467-71f2-4176-97e8-7df1d31d9e87"));

        /// <summary>
        /// ПланОбмена.
        /// </summary>
        public static readonly StdPicture<Guid> ExchangePlan = new StdPicture<Guid>(
            name: nameof(ExchangePlan),
            value: new Guid("544fdbe8-5956-4512-bc62-93b4c022d291"));

        /// <summary>
        /// ПланОбменаОбъект.
        /// </summary>
        public static readonly StdPicture<Guid> ExchangePlanObject = new StdPicture<Guid>(
            name: nameof(ExchangePlanObject),
            value: new Guid("743cc773-12e6-4ee6-9c57-5f5800bac427"));

        /// <summary>
        /// ПланСчетов.
        /// </summary>
        public static readonly StdPicture<Guid> ChartOfAccounts = new StdPicture<Guid>(
            name: nameof(ChartOfAccounts),
            value: new Guid("ccb3d8f7-6da2-4c65-aba6-17b2ffbba78c"));

        /// <summary>
        /// ПланСчетовОбъект.
        /// </summary>
        public static readonly StdPicture<Guid> ChartOfAccountsObject = new StdPicture<Guid>(
            name: nameof(ChartOfAccountsObject),
            value: new Guid("6d4277ee-b29b-4790-8c3c-c4f868311c96"));

        /// <summary>
        /// ПоказатьВСписке.
        /// </summary>
        public static readonly StdPicture<Guid> ShowInList = new StdPicture<Guid>(
            name: nameof(ShowInList),
            value: new Guid("9c96aa25-d656-4b3d-ab3e-81d9718da238"));

        /// <summary>
        /// ПоказатьДанные.
        /// </summary>
        public static readonly StdPicture<Guid> ShowData = new StdPicture<Guid>(
            name: nameof(ShowData),
            value: new Guid("a064544f-6037-48ca-b19f-8ad63e43af23"));

        /// <summary>
        /// ПолучитьНавигационнуюСсылку.
        /// </summary>
        public static readonly StdPicture<Guid> GetURL = new StdPicture<Guid>(
            name: nameof(GetURL),
            value: new Guid("1a4342a5-fa06-4556-8a85-e8738fc25821"));

        /// <summary>
        /// Пользователь.
        /// </summary>
        public static readonly StdPicture<Guid> User = new StdPicture<Guid>(
            name: nameof(User),
            value: new Guid("6ff3ddbd-56e3-4ddf-a5bf-048c1e2dfb2f"));

        /// <summary>
        /// ПользовательБезНеобходимыхСвойств.
        /// </summary>
        public static readonly StdPicture<Guid> UserWithoutNecessaryProperties = new StdPicture<Guid>(
            name: nameof(UserWithoutNecessaryProperties),
            value: new Guid("f16ab927-3ac6-4cdd-bcf1-d8acf005a255"));

        /// <summary>
        /// ПользовательСАутентификацией.
        /// </summary>
        public static readonly StdPicture<Guid> UserWithAuthentication = new StdPicture<Guid>(
            name: nameof(UserWithAuthentication),
            value: new Guid("75a40cc4-c719-4c3f-91ea-fc5787bc34ca"));

        /// <summary>
        /// ПользовательскиеПоляКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionUserFields = new StdPicture<Guid>(
            name: nameof(DataCompositionUserFields),
            value: new Guid("b68eb29c-2372-46e1-b84e-13843899ccf6"));

        /// <summary>
        /// ПоляГруппировкиКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionGroupFields = new StdPicture<Guid>(
            name: nameof(DataCompositionGroupFields),
            value: new Guid("ad8cb448-a6bb-43b4-886a-7d6a8367eef2"));

        /// <summary>
        /// ПоляГруппировкиКомпоновкиДанныхНедоступные.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionGroupFieldsDisabled = new StdPicture<Guid>(
            name: nameof(DataCompositionGroupFieldsDisabled),
            value: new Guid("afbaed82-4b8e-4970-8ac6-97a3bff796d3"));

        /// <summary>
        /// ПометитьНаУдаление.
        /// </summary>
        public static readonly StdPicture<Guid> MarkToDelete = new StdPicture<Guid>(
            name: nameof(MarkToDelete),
            value: new Guid("18492a87-2fe4-44af-b218-304897fed020"));

        /// <summary>
        /// ПорядокКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionOrder = new StdPicture<Guid>(
            name: nameof(DataCompositionOrder),
            value: new Guid("efda7350-6cd7-4416-b188-f5ca9baf66c2"));

        /// <summary>
        /// ПорядокКомпоновкиДанныхНедоступный.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionOrderDisabled = new StdPicture<Guid>(
            name: nameof(DataCompositionOrderDisabled),
            value: new Guid("c8923bc1-6ea9-456b-829f-3f979dc98420"));

        /// <summary>
        /// Предыдущий.
        /// </summary>
        public static readonly StdPicture<Guid> Previous = new StdPicture<Guid>(
            name: nameof(Previous),
            value: new Guid("584b470d-ba34-4b25-9620-8de4066ffeaa"));

        /// <summary>
        /// Провести.
        /// </summary>
        public static readonly StdPicture<Guid> Post = new StdPicture<Guid>(
            name: nameof(Post),
            value: new Guid("20ebc47b-f4d9-439c-acd3-fdc624fbac2a"));

        /// <summary>
        /// ПроизвольноеВыражение.
        /// </summary>
        public static readonly StdPicture<Guid> CustomExpression = new StdPicture<Guid>(
            name: nameof(CustomExpression),
            value: new Guid("f695666a-bad9-49f6-ab7c-5198d7ea4739"));

        /// <summary>
        /// ПросмотрПоВладельцу.
        /// </summary>
        public static readonly StdPicture<Guid> ViewByOwner = new StdPicture<Guid>(
            name: nameof(ViewByOwner),
            value: new Guid("683fc04f-e189-49b7-92a9-f835c36f5fb2"));

        /// <summary>
        /// ПрочитатьИзменения.
        /// </summary>
        public static readonly StdPicture<Guid> ReadChanges = new StdPicture<Guid>(
            name: nameof(ReadChanges),
            value: new Guid("83c8f18d-8701-41f3-bef4-53f88adbb868"));

        /// <summary>
        /// РазвернутьВсе.
        /// </summary>
        public static readonly StdPicture<Guid> ExpandAll = new StdPicture<Guid>(
            name: nameof(ExpandAll),
            value: new Guid("fb7e9fb5-110b-41cb-adc6-753969ae1c81"));

        /// <summary>
        /// РегистрБухгалтерии.
        /// </summary>
        public static readonly StdPicture<Guid> AccountingRegister = new StdPicture<Guid>(
            name: nameof(AccountingRegister),
            value: new Guid("20175a6d-7510-46a8-9077-75a5d0d97802"));

        /// <summary>
        /// РегистрНакопления.
        /// </summary>
        public static readonly StdPicture<Guid> AccumulationRegister = new StdPicture<Guid>(
            name: nameof(AccumulationRegister),
            value: new Guid("70f51581-87b6-41cb-a21b-c9dcdcc7fa93"));

        /// <summary>
        /// РегистрРасчета.
        /// </summary>
        public static readonly StdPicture<Guid> CalculationRegister = new StdPicture<Guid>(
            name: nameof(CalculationRegister),
            value: new Guid("f3b8f300-5a54-4eea-8136-5798413a479c"));

        /// <summary>
        /// РегистрСведений.
        /// </summary>
        public static readonly StdPicture<Guid> InformationRegister = new StdPicture<Guid>(
            name: nameof(InformationRegister),
            value: new Guid("5b87ad1b-d8cc-43c1-b5c4-dc43613c518c"));

        /// <summary>
        /// РегистрСведенийЗапись.
        /// </summary>
        public static readonly StdPicture<Guid> InformationRegisterRecord = new StdPicture<Guid>(
            name: nameof(InformationRegisterRecord),
            value: new Guid("4128e6b6-e4ef-48d4-a523-99dc6b613054"));

        /// <summary>
        /// РегламентноеЗадание.
        /// </summary>
        public static readonly StdPicture<Guid> ScheduledJob = new StdPicture<Guid>(
            name: nameof(ScheduledJob),
            value: new Guid("1970a480-9b38-405e-9d9e-8209f3fad5f1"));

        /// <summary>
        /// РегламентныеЗадания.
        /// </summary>
        public static readonly StdPicture<Guid> ScheduledJobs = new StdPicture<Guid>(
            name: nameof(ScheduledJobs),
            value: new Guid("6206a729-16e5-4e32-b53c-122de4e30c8d"));

        /// <summary>
        /// РедактироватьВДиалоге.
        /// </summary>
        public static readonly StdPicture<Guid> EditInDialog = new StdPicture<Guid>(
            name: nameof(EditInDialog),
            value: new Guid("021c20a0-071b-4a60-8e44-12487adde0c8"));

        /// <summary>
        /// РежимПросмотраСписка.
        /// </summary>
        public static readonly StdPicture<Guid> ListViewMode = new StdPicture<Guid>(
            name: nameof(ListViewMode),
            value: new Guid("549a2c45-4fce-493f-94ee-9a3a4f426551"));

        /// <summary>
        /// РежимПросмотраСпискаДерево.
        /// </summary>
        public static readonly StdPicture<Guid> ListViewModeTree = new StdPicture<Guid>(
            name: nameof(ListViewModeTree),
            value: new Guid("da9ac044-0ff7-4bcf-a441-3187bd1d951f"));

        /// <summary>
        /// РежимПросмотраСпискаИерархическийСписок.
        /// </summary>
        public static readonly StdPicture<Guid> ListViewModeHierarchicalList = new StdPicture<Guid>(
            name: nameof(ListViewModeHierarchicalList),
            value: new Guid("3d4ad3b1-17de-4cf1-a2e4-0c2c83a5b5c2"));

        /// <summary>
        /// РежимПросмотраСпискаСписок.
        /// </summary>
        public static readonly StdPicture<Guid> ListViewModeList = new StdPicture<Guid>(
            name: nameof(ListViewModeList),
            value: new Guid("c757209d-a87f-4410-b1a3-76000178f1f0"));

        /// <summary>
        /// Реквизит.
        /// </summary>
        public static readonly StdPicture<Guid> Attribute = new StdPicture<Guid>(
            name: nameof(Attribute),
            value: new Guid("0c1f7756-6143-4903-a94c-8f22c85e44de"));

        /// <summary>
        /// Ресурс.
        /// </summary>
        public static readonly StdPicture<Guid> Resource = new StdPicture<Guid>(
            name: nameof(Resource),
            value: new Guid("d6eefec0-792a-4720-8933-e2a57f9e312c"));

        /// <summary>
        /// СвернутьВсе.
        /// </summary>
        public static readonly StdPicture<Guid> CollapseAll = new StdPicture<Guid>(
            name: nameof(CollapseAll),
            value: new Guid("27ee3053-952c-49e5-8261-9215098e0e9c"));

        /// <summary>
        /// СводнаяДиаграмма.
        /// </summary>
        public static readonly StdPicture<Guid> PivotChart = new StdPicture<Guid>(
            name: nameof(PivotChart),
            value: new Guid("79bf535f-2256-4ebb-bb8d-c26f3dd1a3de"));

        /// <summary>
        /// Свойства.
        /// </summary>
        public static readonly StdPicture<Guid> Properties = new StdPicture<Guid>(
            name: nameof(Properties),
            value: new Guid("b4c7ab2c-bcda-4468-a28f-5fee93838c4e"));

        /// <summary>
        /// Сегодня.
        /// </summary>
        public static readonly StdPicture<Guid> Today = new StdPicture<Guid>(
            name: nameof(Today),
            value: new Guid("6ca1af75-2aa5-48a6-820d-efa0ccb8f4f1"));

        /// <summary>
        /// Символ.
        /// </summary>
        public static readonly StdPicture<Guid> Char = new StdPicture<Guid>(
            name: nameof(Char),
            value: new Guid("4781692b-60eb-47e4-acfb-2caf0f49e977"));

        /// <summary>
        /// СинтаксическийКонтроль.
        /// </summary>
        public static readonly StdPicture<Guid> CheckSyntax = new StdPicture<Guid>(
            name: nameof(CheckSyntax),
            value: new Guid("dcd23a32-5c7c-43f2-9021-80d98128556f"));

        /// <summary>
        /// СкопироватьОбъект.
        /// </summary>
        public static readonly StdPicture<Guid> CloneObject = new StdPicture<Guid>(
            name: nameof(CloneObject),
            value: new Guid("f6532868-30b9-44ab-803c-78f0f0b06b02"));

        /// <summary>
        /// СкопироватьЭлементСписка.
        /// </summary>
        public static readonly StdPicture<Guid> CloneListItem = new StdPicture<Guid>(
            name: nameof(CloneListItem),
            value: new Guid("448d6f55-d885-496c-870d-d1bd78374745"));

        /// <summary>
        /// Следующий.
        /// </summary>
        public static readonly StdPicture<Guid> Next = new StdPicture<Guid>(
            name: nameof(Next),
            value: new Guid("9cf611dc-2370-4357-910d-a2b49c7a1ec6"));

        /// <summary>
        /// СоздатьГруппу.
        /// </summary>
        public static readonly StdPicture<Guid> CreateFolder = new StdPicture<Guid>(
            name: nameof(CreateFolder),
            value: new Guid("4ab0e87f-7d9b-4aa8-ac4b-680a78522da8"));

        /// <summary>
        /// СоздатьНачальныйОбраз.
        /// </summary>
        public static readonly StdPicture<Guid> CreateInitialImage = new StdPicture<Guid>(
            name: nameof(CreateInitialImage),
            value: new Guid("4d2570b5-205f-413c-b4cc-b2097f61684f"));

        /// <summary>
        /// СоздатьЭлементСписка.
        /// </summary>
        public static readonly StdPicture<Guid> CreateListItem = new StdPicture<Guid>(
            name: nameof(CreateListItem),
            value: new Guid("977e831a-0e73-4d60-af51-091a6fa8612e"));

        /// <summary>
        /// СортироватьСписок.
        /// </summary>
        public static readonly StdPicture<Guid> SortList = new StdPicture<Guid>(
            name: nameof(SortList),
            value: new Guid("fafe4c1f-c265-4220-a0e1-8f82af26b72e"));

        /// <summary>
        /// СортироватьСписокПоВозрастанию.
        /// </summary>
        public static readonly StdPicture<Guid> SortListAsc = new StdPicture<Guid>(
            name: nameof(SortListAsc),
            value: new Guid("91022b99-b610-48ad-954e-a297848081ce"));

        /// <summary>
        /// СортироватьСписокПоУбыванию.
        /// </summary>
        public static readonly StdPicture<Guid> SortListDesc = new StdPicture<Guid>(
            name: nameof(SortListDesc),
            value: new Guid("1fa32fdb-a180-418f-a6eb-db7516b7a30b"));

        /// <summary>
        /// Сортировка.
        /// </summary>
        public static readonly StdPicture<Guid> Sort = new StdPicture<Guid>(
            name: nameof(Sort),
            value: new Guid("a594c8a1-7218-420a-860f-7b493c5e65c4"));

        /// <summary>
        /// СохранитьЗначения.
        /// </summary>
        public static readonly StdPicture<Guid> SaveValues = new StdPicture<Guid>(
            name: nameof(SaveValues),
            value: new Guid("23f940bf-7381-4c2b-85a1-e541ed428042"));

        /// <summary>
        /// СохранитьНастройкиОтчета.
        /// </summary>
        public static readonly StdPicture<Guid> SaveReportSettings = new StdPicture<Guid>(
            name: nameof(SaveReportSettings),
            value: new Guid("b5a0aaba-3a83-4a71-b6f9-24aae1574681"));

        /// <summary>
        /// СохранитьФайл.
        /// </summary>
        public static readonly StdPicture<Guid> SaveFile = new StdPicture<Guid>(
            name: nameof(SaveFile),
            value: new Guid("818ab7d0-4654-4542-bd5e-fd9d1352b5a1"));

        /// <summary>
        /// Справка.
        /// </summary>
        public static readonly StdPicture<Guid> Help = new StdPicture<Guid>(
            name: nameof(Help),
            value: new Guid("b7c81c62-d6ad-4eae-9cea-0e203182db67"));

        /// <summary>
        /// Справочник.
        /// </summary>
        public static readonly StdPicture<Guid> Catalog = new StdPicture<Guid>(
            name: nameof(Catalog),
            value: new Guid("069b8324-7c51-4c73-a6a8-c06d4fc383b5"));

        /// <summary>
        /// СправочникОбъект.
        /// </summary>
        public static readonly StdPicture<Guid> CatalogObject = new StdPicture<Guid>(
            name: nameof(CatalogObject),
            value: new Guid("d971ec77-85e4-4e8d-a20a-8b130eedeb29"));

        /// <summary>
        /// СтандартнаяНастройкаКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionStandardSettings = new StdPicture<Guid>(
            name: nameof(DataCompositionStandardSettings),
            value: new Guid("251aaa98-0127-44c3-a163-6f5ab4367ee2"));

        /// <summary>
        /// СтартБизнесПроцесса.
        /// </summary>
        public static readonly StdPicture<Guid> BusinessProcessStart = new StdPicture<Guid>(
            name: nameof(BusinessProcessStart),
            value: new Guid("9fecbaff-2a05-4da6-9ef1-807e754b928d"));

        /// <summary>
        /// СформироватьОтчет.
        /// </summary>
        public static readonly StdPicture<Guid> GenerateReport = new StdPicture<Guid>(
            name: nameof(GenerateReport),
            value: new Guid("0ce78048-0196-4f80-a781-9829cdb7f43e"));

        /// <summary>
        /// ТабличныйДокументВставитьПримечание.
        /// </summary>
        public static readonly StdPicture<Guid> SpreadsheetInsertComment = new StdPicture<Guid>(
            name: nameof(SpreadsheetInsertComment),
            value: new Guid("03665ff1-3a05-41d1-96d3-04bda2d8ede3"));

        /// <summary>
        /// ТабличныйДокументВставитьРазрывСтраницы.
        /// </summary>
        public static readonly StdPicture<Guid> SpreadsheetInsertPageBreak = new StdPicture<Guid>(
            name: nameof(SpreadsheetInsertPageBreak),
            value: new Guid("26518e18-e364-475a-8026-e41134658b2a"));

        /// <summary>
        /// ТабличныйДокументОтображатьГруппировки.
        /// </summary>
        public static readonly StdPicture<Guid> SpreadsheetShowGroups = new StdPicture<Guid>(
            name: nameof(SpreadsheetShowGroups),
            value: new Guid("702a9e16-0bb6-4efb-af11-10faf1e6ee87"));

        /// <summary>
        /// ТабличныйДокументОтображатьЗаголовки.
        /// </summary>
        public static readonly StdPicture<Guid> SpreadsheetShowHeaders = new StdPicture<Guid>(
            name: nameof(SpreadsheetShowHeaders),
            value: new Guid("46598f81-5f95-4485-9b33-bfe4fd1276d0"));

        /// <summary>
        /// ТабличныйДокументОтображатьПримечания.
        /// </summary>
        public static readonly StdPicture<Guid> SpreadsheetShowComments = new StdPicture<Guid>(
            name: nameof(SpreadsheetShowComments),
            value: new Guid("bc61d1e7-2d40-4e93-8630-cce840bdcf99"));

        /// <summary>
        /// ТабличныйДокументОтображатьСетку.
        /// </summary>
        public static readonly StdPicture<Guid> SpreadsheetShowGrid = new StdPicture<Guid>(
            name: nameof(SpreadsheetShowGrid),
            value: new Guid("3646acb9-a91e-4163-bbe1-2006041cd65d"));

        /// <summary>
        /// ТабличныйДокументТолькоПросмотр.
        /// </summary>
        public static readonly StdPicture<Guid> SpreadsheetReadOnly = new StdPicture<Guid>(
            name: nameof(SpreadsheetReadOnly),
            value: new Guid("2846af8d-af84-47e3-82b9-01b01f960426"));

        /// <summary>
        /// ТабличныйДокументУдалитьПримечание.
        /// </summary>
        public static readonly StdPicture<Guid> SpreadsheetDeleteComment = new StdPicture<Guid>(
            name: nameof(SpreadsheetDeleteComment),
            value: new Guid("7c75b1df-1fdc-471f-aae6-6b7870318cd4"));

        /// <summary>
        /// ТабличныйДокументУдалитьРазрывСтраницы.
        /// </summary>
        public static readonly StdPicture<Guid> SpreadsheetDeletePageBreak = new StdPicture<Guid>(
            name: nameof(SpreadsheetDeletePageBreak),
            value: new Guid("aa96f4bb-cf28-4dad-bc42-5ed53de95c0c"));

        /// <summary>
        /// Удалить.
        /// </summary>
        public static readonly StdPicture<Guid> Delete = new StdPicture<Guid>(
            name: nameof(Delete),
            value: new Guid("08a45a70-c221-4339-b3b1-9f11cb22147d"));

        /// <summary>
        /// УдалитьНепосредственно.
        /// </summary>
        public static readonly StdPicture<Guid> DeleteDirectly = new StdPicture<Guid>(
            name: nameof(DeleteDirectly),
            value: new Guid("60643198-e4b2-4c39-9de1-53cca3fff382"));

        /// <summary>
        /// УдалитьЭлементСписка.
        /// </summary>
        public static readonly StdPicture<Guid> DeleteListItem = new StdPicture<Guid>(
            name: nameof(DeleteListItem),
            value: new Guid("167a160b-fa48-4337-87ab-7e0fe95c4b5a"));

        /// <summary>
        /// УдалитьЭлементСпискаНепосредственно.
        /// </summary>
        public static readonly StdPicture<Guid> DeleteListItemDirectly = new StdPicture<Guid>(
            name: nameof(DeleteListItemDirectly),
            value: new Guid("6cbf8f9a-3d2f-427b-bfce-5e2bc7a8589d"));

        /// <summary>
        /// УправлениеПоиском.
        /// </summary>
        public static readonly StdPicture<Guid> SearchControl = new StdPicture<Guid>(
            name: nameof(SearchControl),
            value: new Guid("fc6a06a8-1308-4385-b1b2-9d302d2054ed"));

        /// <summary>
        /// УровеньВверх.
        /// </summary>
        public static readonly StdPicture<Guid> LevelUp = new StdPicture<Guid>(
            name: nameof(LevelUp),
            value: new Guid("cb34c423-3d6a-4202-a809-3b3f45fb14ab"));

        /// <summary>
        /// УровеньВниз.
        /// </summary>
        public static readonly StdPicture<Guid> LevelDown = new StdPicture<Guid>(
            name: nameof(LevelDown),
            value: new Guid("01743054-d102-4e7c-bf15-5ed7fd84441b"));

        /// <summary>
        /// УсловноеОформлениеКомпоновкиДанных.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionConditionalAppearance = new StdPicture<Guid>(
            name: nameof(DataCompositionConditionalAppearance),
            value: new Guid("984b0a3e-daa2-4a9e-b75c-1f230a6e592a"));

        /// <summary>
        /// УсловноеОформлениеКомпоновкиДанныхНедоступное.
        /// </summary>
        public static readonly StdPicture<Guid> DataCompositionConditionalAppearanceDisabled = new StdPicture<Guid>(
            name: nameof(DataCompositionConditionalAppearanceDisabled),
            value: new Guid("5ff5bf50-1f3c-46b6-b4ef-a4973dd610aa"));

        /// <summary>
        /// УстановитьВремя.
        /// </summary>
        public static readonly StdPicture<Guid> SetTime = new StdPicture<Guid>(
            name: nameof(SetTime),
            value: new Guid("55ef0776-5ee4-4daf-9a9b-70d63643ab8d"));

        /// <summary>
        /// УстановитьИнтервал.
        /// </summary>
        public static readonly StdPicture<Guid> SetDateInterval = new StdPicture<Guid>(
            name: nameof(SetDateInterval),
            value: new Guid("58174855-39be-462e-8723-cb2d95182146"));

        /// <summary>
        /// УстановитьПометкуУдаленияЭлементаСписка.
        /// </summary>
        public static readonly StdPicture<Guid> SetListItemDeletionMark = new StdPicture<Guid>(
            name: nameof(SetListItemDeletionMark),
            value: new Guid("4bf588d5-b8d8-47fd-8f41-eb9b668981ce"));

        /// <summary>
        /// Форма.
        /// </summary>
        public static readonly StdPicture<Guid> Form = new StdPicture<Guid>(
            name: nameof(Form),
            value: new Guid("fc34a694-e99b-4d1c-a526-63f5571bdb09"));

        /// <summary>
        /// ХранилищеНастроек.
        /// </summary>
        public static readonly StdPicture<Guid> SettingsStorage = new StdPicture<Guid>(
            name: nameof(SettingsStorage),
            value: new Guid("6b909f65-95a4-4697-8ca0-c8f331227b9a"));
    }
}
