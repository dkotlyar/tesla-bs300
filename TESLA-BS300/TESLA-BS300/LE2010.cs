using System;
using System.Runtime.InteropServices;

namespace LCARD_E2010
{
 //   // доступные индексы источника сигнала старта сбора данных
 //   enum signalSourceEnum {
 //       INT_ADC_START_E2010, INT_ADC_START_WITH_TRANS_E2010,
 //       EXT_ADC_START_ON_RISING_EDGE_E2010, EXT_ADC_START_ON_FALLING_EDGE_E2010,
 //       //				EXT_ADC_START_ON_HIGH_LEVEL_E2010, EXT_ADC_START_ON_LOW_LEVEL_E2010,		// для Rev.B и выше (пока нет)
 //       INVALID_ADC_START_E2010
 //   };
 //   // доступные индексы источника тактовых импульсов для запуска АЦП
 //   enum taktSourceEnum { INT_ADC_CLOCK_E2010, INT_ADC_CLOCK_WITH_TRANS_E2010, EXT_ADC_CLOCK_ON_RISING_EDGE_E2010, EXT_ADC_CLOCK_ON_FALLING_EDGE_E2010, INVALID_ADC_CLOCK_E2010 };
 //   // возможные типы аналоговой синхронизации ввода данных (для Rev.B и выше)
 //   enum synchroEnum {
 //       NO_ANALOG_SYNCHRO_E2010,            // отсутствие аналоговой синхронизации
 //       ANALOG_SYNCHRO_ON_RISING_CROSSING_E2010, ANALOG_SYNCHRO_ON_FALLING_CROSSING_E2010,  // аналоговая синхронизация по переходу
 //       ANALOG_SYNCHRO_ON_HIGH_LEVEL_E2010, ANALOG_SYNCHRO_ON_LOW_LEVEL_E2010,      // аналоговая синхронизация по уровню
 //       INVALID_ANALOG_SYNCHRO_E2010
 //   };
 //   // возможные типы подключения входного тракта модуля E20-10
 //   enum typeConnectionEnum { ADC_INPUT_ZERO_E2010, ADC_INPUT_SIGNAL_E2010, INVALID_ADC_INPUT_E2010 };
 //   // возможные индексы для управления входным током смещения модуля E20-10 (для Rev.B и выше)
 //   enum inputCurrentOffsetEnum { INPUT_CURRENT_OFF_E2010, INPUT_CURRENT_ON_E2010, INVALID_INPUT_CURRENT_E2010 };
 //   // возможные режимы фиксации факта перегрузки входных каналов при сборе данных (только для Rev.A)
 //   enum overloadEnum { CLIPPING_OVERLOAD_E2010, MARKER_OVERLOAD_E2010, INVALID_OVERLOAD_E2010 };
 //   // доступные номера битов ошибок при выполнении сбора данных с АЦП
 //   enum errorEnum {
 //       // битовое поле BufferOverrun структуры DATA_STATE_E2010
 //       BUFFER_OVERRUN_E2010 = 0x0,     // переполнение внутреннего буфера модуля
 //                                       // битовое поле ChannelsOverFlow структуры DATA_STATE_E2010 (для Rev.B и выше)
 //       OVERFLOW_OF_CHANNEL_1_E2010 = 0x0, OVERFLOW_OF_CHANNEL_2_E2010, // биты локальных признаков переполнения разрядной сетки соответствующего канала
 //       OVERFLOW_OF_CHANNEL_3_E2010, OVERFLOW_OF_CHANNEL_4_E2010,           // за время выполнения одного запроса сбора данных ReadData()
 //       OVERFLOW_E2010 = 0x7                    // бит глобального признака факта переполнения разрядной сетки модуля за всё время сбора данных от момента START_ADC() до STOP_ADC()
 //   };
 //   // возможные опции наличия микросхемы ЦАП для модуля E20-10
 //   enum dacAccessEnum { DAC_INACCESSIBLED_E2010, DAC_ACCESSIBLED_E2010, INVALID_DAC_OPTION_E2010 };
 //   // доступные индексы ревизий модуля E20-10
 //   enum revisionEnum { REVISION_A_E2010, REVISION_B_E2010, INVALID_REVISION_E2010 };
 //   // доступные индексы модификиций модуля E20-10
 //   enum modificationEnum {
 //       BASE_MODIFICATION_E2010,            // полоса входных частот 1.25 МГц
 //       F5_MODIFICATION_E2010,              // полоса входных частот 5.00 МГц
 //       INVALID_MODIFICATION_E2010
 //   };
 //   // доступные битовые константы для задания тестовых режимов работы модуля E20-10
 //   enum testModeEnum { NO_TEST_MODE_E2010, TEST_MODE_1_E2010 };
 //   // константы для работы с модулем
 //   enum constantEnum {
 //       ADC_CHANNELS_QUANTITY_E2010 = 0x4,
 //       MAX_CONTROL_TABLE_LENGTH_E2010 = 256,
 //       ADC_INPUT_RANGES_QUANTITY_E2010 = inputVoltageEnum.INVALID_ADC_INPUT_RANGE_E2010,
 //       ADC_INPUT_TYPES_QUANTITY_E2010 = typeConnectionEnum.INVALID_ADC_INPUT_E2010,
 //       ADC_CALIBR_COEFS_QUANTITY_E2010 = ADC_CHANNELS_QUANTITY_E2010 * ADC_INPUT_RANGES_QUANTITY_E2010,
 //       DAC_CHANNELS_QUANTITY_E2010 = 0x2,
 //       DAC_CALIBR_COEFS_QUANTITY_E2010 = DAC_CHANNELS_QUANTITY_E2010,
 //       TTL_LINES_QUANTITY_E2010 = 0x10,        // кол-во входных и выходных цифровых линий
 //       USER_FLASH_SIZE_E2010 = 0x200,          // размер области пользовательского ППЗУ в байтах
 //       REVISIONS_QUANTITY_E2010 = revisionEnum.INVALID_REVISION_E2010,              // кол-во ревизий модуля
 //       MODIFICATIONS_QUANTITY_E2010 = modificationEnum.INVALID_MODIFICATION_E2010,  // кол-во вариантов исполнения (модификаций) модуля
 //       ADC_PLUS_OVERLOAD_MARKER_E2010 = 0x5FFF,    // признак 'плюс' перегрузки отсчёта с АЦП (только для Rev.A)
 //       ADC_MINUS_OVERLOAD_MARKER_E2010 = 0xA000    // признак 'минус' перегрузки отсчёта с АЦП (только для Rev.A)
 //   };
 //   // структура с параметрами синхронизации ввода данных с АЦП
 //   struct SYNCHRO_PARS_E2010
 //   {
 //       Int16 StartSource;                   // тип и источник сигнала начала сбора данных с АЦП (внутренний или внешний и т.д.)
 //       int StartDelay;                   // задержка старта сбора данных в кадрах отсчётов c АЦП (для Rev.B и выше)
 //       Int16 SynhroSource;                  // источник тактовых импульсов запуска АЦП (внутренние или внешние и т.д.)
 //       int StopAfterNKadrs;              // останов сбора данных после задаваемого здесь кол-ва собранных кадров отсчётов АЦП (для Rev.B и выше)
 //       Int16 SynchroAdMode;                 // режим аналоговой сихронизации: переход или уровень (для Rev.B и выше)
 //       Int16 SynchroAdChannel;              // физический канал АЦП для аналоговой синхронизации (для Rev.B и выше)
 //       short SynchroAdPorog;               // порог срабатывания при аналоговой синхронизации (для Rev.B и выше)
 //       byte IsBlockDataMarkerEnabled;  // маркирование начала блока данных (удобно, например, при аналоговой синхронизации ввода по уровню) (для Rev.B и выше)
 //   };
 //   // структура с параметрами работы АЦП в небезопасном режиме
 //   struct ADC_PARS_E2010_unsafe
 //   {
 //       bool IsAdcCorrectionEnabled;    // управление разрешением автоматической корректировкой получаемых данных на уровне модуля (для Rev.B и выше)
 //       Int16 OverloadMode;             // режим фиксации факта перегрузки входных каналов модуля (только для Rev.A)
 //       Int16 InputCurrentControl;      // управление входным током смещения (для Rev.B и выше)
 //       IntPtr SynchroPars; // параметры синхронизации ввода данных с АЦП
 //       Int16 ChannelsQuantity;         // кол-во активных каналов (размер кадра отсчётов)
 //       IntPtr ControlTable;  // управляющая таблица с активными логическими каналами
 //       IntPtr InputRange;    // индексы диапазонов входного напряжения физических каналов: 3.0В, 1.0В или 0.3В
 //       IntPtr InputSwitch;   // индексы типа подключения физических каналов: земля или сигнал
 //       double AdcRate;         // частота работы АЦП в кГц
 //       double InterKadrDelay;  // межкадровая задержка в мс
 //       double KadrRate;        // частота кадра в кГц
 //       IntPtr AdcOffsetCoefs;  // массив коэффициентов для корректировки смещение отсчётов АЦП: (3 диапазона)*(4 канала) (для Rev.B и выше)
 //       IntPtr AdcScaleCoefs;   // массив коэффициентов для корректировки масштаба отсчётов АЦП: (3 диапазона)*(4 канала) (для Rev.B и выше)
 //   };
 //   // структура с параметрами работы АЦП
 //   struct ADC_PARS_E2010
 //   {
 //       bool IsAdcCorrectionEnabled;    // управление разрешением автоматической корректировкой получаемых данных на уровне модуля (для Rev.B и выше)
 //       Int16 OverloadMode;             // режим фиксации факта перегрузки входных каналов модуля (только для Rev.A)
 //       Int16 InputCurrentControl;      // управление входным током смещения (для Rev.B и выше)
 //       SYNCHRO_PARS_E2010 SynchroPars; // параметры синхронизации ввода данных с АЦП
 //       Int16 ChannelsQuantity;         // кол-во активных каналов (размер кадра отсчётов)
 //       Int16[] ControlTable;  // управляющая таблица с активными логическими каналами
 //       Int16[] InputRange;    // индексы диапазонов входного напряжения физических каналов: 3.0В, 1.0В или 0.3В
 //       Int16[] InputSwitch;   // индексы типа подключения физических каналов: земля или сигнал
 //       double AdcRate;             // частота работы АЦП в кГц
 //       double InterKadrDelay;      // межкадровая задержка в мс
 //       double KadrRate;            // частота кадра в кГц
 //       double[][] AdcOffsetCoefs;	// массив коэффициентов для корректировки смещение отсчётов АЦП: (3 диапазона)*(4 канала) (для Rev.B и выше)
	//	double[][] AdcScaleCoefs;   // массив коэффициентов для корректировки масштаба отсчётов АЦП: (3 диапазона)*(4 канала) (для Rev.B и выше)
	//};
 //   // структура с информацией о текущем состоянии процесса сбора данных
 //   struct DATA_STATE_E2010
 //   {
 //       byte ChannelsOverFlow;          // битовые признаки перегрузки входных аналоговых каналов (для Rev.B и выше)
 //       byte BufferOverrun;             // битовые признаки переполнения внутреннего буфера модуля
 //       int CurBufferFilling;         // заполненность внутреннего буфера модуля Rev.B и выше, в отсчётах
 //       int MaxOfBufferFilling;       // за время сбора максимальная заполненность внутреннего буфера модуля Rev.B и выше, в отсчётах
 //       int BufferSize;                   // размер внутреннего буфера модуля Rev.B и выше, в отсчётах
 //       double CurBufferFillingPercent;     // текущая степень заполнения внутреннего буфера модуля Rev.B и выше, в %
 //       double MaxOfBufferFillingPercent;   // за время сбора максимальная степень заполнения внутреннего буфера модуля Rev.B и выше, в %
 //   };
 //   // структура с параметрами запроса на ввод/вывод данных
 //   struct IO_REQUEST_LUSBAPI
 //   {
 //       IntPtr Buffer;              // указатель на буфер данных
 //       int NumberOfWordsToPass;    // кол-во отсчётов, которые требуется передать
 //       int NumberOfWordsPassed;    // реальное кол-во переданных отсчётов
 //       IntPtr Overlapped;          // для асинхроннного запроса - указатель на структура типа OVERLAPPED
 //       int TimeOut;                // для синхронного запроса - таймаут в мс
 //   };

    // доступные индексы диапазонов входного напряжения модуля E20-10
    enum E2010_AdcInputRange { _3000mV, _1000mV, _300mV };

    enum E2010_SynchroStartSource
    {
        Internal,
        InternalWithTrans,
        External
    };
    enum E2010_SynchroClockSource
    {
        Internal,
        InternalWithTrans
    };
    enum E2010_SynchroAdMode
    {
        NoAnalog,
        Analog
    }

    class LE2010 : Lusbapi
    {
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_CloseLDevice(IntPtr pModule);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_ReleaseLInstance(IntPtr pModule);
        [DllImport("LusbapiLib.dll")]
        private static extern HandleRef E2010_GetModuleHandle(IntPtr pModule);
        [DllImport("LusbapiLib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern bool E2010_GetModuleName(IntPtr pModule, out IntPtr moduleName);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_GetUsbSpeed(IntPtr pModule, out byte usbSpeed);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_LowPowerMode(IntPtr pModule, bool lowPowerFlag);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_GetLastErrorInfo(IntPtr pModule, LAST_ERROR_INFO_LUSBAPI lastErrorInfo);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_LOAD_MODULE(IntPtr pModule, string fileName);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_TEST_MODULE(IntPtr pModule, Int16 TestModeMask);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_GET_ADC_PARS(IntPtr pModule, out IntPtr adcPars);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_SET_ADC_PARS(IntPtr pModule, IntPtr adcPars);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_START_ADC(IntPtr pModule);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_STOP_ADC(IntPtr pModule);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_GET_DATA_STATE(IntPtr pModule, out IntPtr dataState);
        [DllImport("LusbapiLib.dll")]
        private static extern bool E2010_ReadData(IntPtr pModule, out IntPtr readRequest);

        // Функции работы со структурой ADC_PARS_E2010
        [DllImport("LusbapiLib.dll")]
        private static extern IntPtr E2010_CreateAdcPars();
        [DllImport("LusbapiLib.dll")]
        private static extern IntPtr E2010_GET_ADC_PARS_Extended(IntPtr pModule);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetAdcCorrectionEnabled(IntPtr ap, bool AdcCorrectionEnabled);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroStartSourceInternal(IntPtr ap);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroStartSourceInternalWithTrans(IntPtr ap);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroStartSourceExternal(IntPtr ap);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroClockSourceInternal(IntPtr ap);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroClockSourceInternalWithTrans(IntPtr ap);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroStartDelay(IntPtr ap, int StartDelay);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroStopAfterNKadrs(IntPtr ap, int StopAfterNKadrs);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroAdModeNoAnalog(IntPtr ap);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroAdModeAnalog(IntPtr ap);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroAdChannel(IntPtr ap, int SynchroAdChannel);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetSynchroAdPorog(IntPtr ap, short SynchroAdPorog);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetBlockDataMarkerEnabled(IntPtr ap, byte IsBlockDataMarkerEnabled);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetChannelsQuantity(IntPtr ap, int ChannelsQuantity);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetAdcRate(IntPtr ap, double AdcRate);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_SetInterKadrDelay(IntPtr ap, double InterKadrDelay);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_ConfigureInputChannels(IntPtr pModule, IntPtr ap, int AdcInputRange);
        [DllImport("LusbapiLib.dll")]
        private static extern double E2010_GetKadrRate(IntPtr ap);
        [DllImport("LusbapiLib.dll")]
        private static extern IntPtr E2010_GetRequestOverlapped(IntPtr pModule, int DataStep, double KadrRate);
        [DllImport("LusbapiLib.dll")]
        private static extern IntPtr E2010_WaitResponse(IntPtr pModule, IntPtr IoReq, out int NumberOfWordsPassed);
        [DllImport("LusbapiLib.dll")]
        private static extern void E2010_ClearBuffer(IntPtr IoReq);

        private E2010_AdcInputRange InputRange;
        private int DataStep;
        private double KadrRate;
        private int ChannelsQuantity;

        public LE2010() : base("e2010")
        {
        }

        public IntPtr GetIoReq()
        {
            CheckModule();

            IntPtr IoReq = E2010_GetRequestOverlapped(pModule, DataStep, KadrRate);
            if (IoReq == IntPtr.Zero)
                throw new Exception("GetRequestOverlapped has error");

            return IoReq;
        }

        public short[] WaitResponse(IntPtr IoReq)
        {
            CheckModule();
            
            IntPtr buffer = E2010_WaitResponse(pModule, IoReq, out int NumberOfWordsPassed);
            if (buffer == IntPtr.Zero)
                throw new Exception("WaitResponse has error");

            short[] result = new short[NumberOfWordsPassed];
            Marshal.Copy(buffer, result, 0, NumberOfWordsPassed);

            ClearResponse(IoReq);

            return result;
        }

        public void ClearResponse(IntPtr IoReq)
        {
            E2010_ClearBuffer(IoReq);
        }

        public short[,] SplitToChannels(short[] adc)
        {
            if (adc.Length % this.ChannelsQuantity > 0)
                throw new Exception("Split to channels error");
            
            short[,] split = new short[adc.Length / this.ChannelsQuantity, this.ChannelsQuantity];
            for (int i = 0; i < adc.Length; i++)
            {
                split[i / this.ChannelsQuantity, i % this.ChannelsQuantity] = adc[i];
            }

            return split;
        }

        public void CloseLDevice()
        {
            CheckModule();

            if (!E2010_CloseLDevice(pModule))
                throw new Exception("CloseLDevice has error");

            _openSlot = -1;
        }

        public void ReleaseLInstance()
        {
            if (pModule == null || pModule == IntPtr.Zero)
                return;

            if (!E2010_ReleaseLInstance(pModule))
                throw new Exception("ReleaseLInstance has error");
            pModule = IntPtr.Zero;
        }

        public string GetModuleName()
        {
            CheckModule();

            IntPtr ptr = IntPtr.Zero;
            if (!E2010_GetModuleName(pModule, out ptr))
                throw new Exception("GetModuleName has error");

            //Marshal.PtrToStringAuto(ptr);
            return "";
        }

        public byte GetUsbSpeed()
        {
            CheckModule();

            byte speed;
            if (!E2010_GetUsbSpeed(pModule, out speed))
                throw new Exception("GetUsbSpeed has error");
            return speed;
        }

        public string PrintUsbSpeed()
        {
            byte speed = GetUsbSpeed();
            return speed == 0 ? "Full-Speed Mode (12 Mbit/s)" : "High-Speed Mode (480 Mbit/s)";
        }

        public void LowPowerMode(bool lowPowerFlag)
        {
            CheckModule();

            if (!E2010_LowPowerMode(pModule, lowPowerFlag))
                throw new Exception("LowPowerMode has error");
        }

        public LAST_ERROR_INFO_LUSBAPI GetLastErrorInfo()
        {
            throw new Exception("Method not implemented");
        }

        public void LoadModule()
        {
            CheckModule();

            if (!E2010_LOAD_MODULE(pModule, null))
                throw new Exception("LOAD_MODULE has error");
        }

        public void TestModule()
        {
            CheckModule();

            if (!E2010_TEST_MODULE(pModule, 0))
                throw new Exception("TEST_MODULE has error");
        }

        //public ADC_PARS_E2010 GetAdcPars()
        //{
        //    CheckModule();

        //    ADC_PARS_E2010 ap = new ADC_PARS_E2010();
        //    ADC_PARS_E2010_unsafe ap_unsafe = new ADC_PARS_E2010_unsafe();
        //    IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(ap_unsafe));
        //    Marshal.StructureToPtr(ap_unsafe, ptr, true);
        //    if (!E2010_GET_ADC_PARS(pModule, out ptr))
        //        throw new Exception("GET_ADC_PARS has error");

        //    Marshal.PtrToStructure(ptr, ap_unsafe);
        //    return ap;
        //}

        //public void SetAdcPars(ADC_PARS_E2010 ap)
        //{
        //    CheckModule();

        //    if (!E2010_SET_ADC_PARS(pModule, ap))
        //        throw new Exception("SET_ADC_PARS has error");
        //}

        public void StartAdc()
        {
            CheckModule();

            if (!E2010_START_ADC(pModule))
                throw new Exception("START_ADC has error");
        }

        public void StopAdc()
        {
            CheckModule();

            if (!E2010_STOP_ADC(pModule))
                throw new Exception("STOP_ADC has error");
        }

        //public DATA_STATE_E2010 GetDataState()
        //{
        //    CheckModule();

        //    DATA_STATE_E2010 data = new DATA_STATE_E2010();
        //    IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(data));

        //    if (!E2010_GET_DATA_STATE(pModule, out ptr))
        //        throw new Exception("GET_DATA_STATE has error");
            
        //    return data;
        //}

        //public IO_REQUEST_LUSBAPI ReadData()
        //{
        //    CheckModule();

        //    IO_REQUEST_LUSBAPI data = new IO_REQUEST_LUSBAPI();
        //    IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(data));

        //    if (!E2010_ReadData(pModule, out ptr))
        //        throw new Exception("ReadData has error");

        //    return data;
        //}



        public IntPtr GetAdcPars()
        {
            CheckModule();

            IntPtr ptr = E2010_GET_ADC_PARS_Extended(pModule);

            return ptr;
        }

        public void SetAdcPars(IntPtr ap)
        {
            CheckModule();

            if (!E2010_SET_ADC_PARS(pModule, ap))
                throw new Exception("SET_ADC_PARS has error");
        }

        public void SetAdcParams(IntPtr ap, bool AdcCorrectionEnabled, E2010_SynchroStartSource StartSource, E2010_SynchroClockSource ClockSource, 
            int StartDelay, int StopAfterNKadrs, E2010_SynchroAdMode AdMode, int AdChannel, short AdPorog, byte BlockDataMarkerEnabled, int ChannelsQuantity, double AdcRate, E2010_AdcInputRange AdcInputRange)
        {
            CheckModule();

            E2010_SetAdcCorrectionEnabled(ap, AdcCorrectionEnabled);

            switch (StartSource)
            {
                case E2010_SynchroStartSource.Internal:
                    E2010_SetSynchroStartSourceInternal(ap); break;
                case E2010_SynchroStartSource.InternalWithTrans:
                    E2010_SetSynchroStartSourceInternalWithTrans(ap); break;
                case E2010_SynchroStartSource.External:
                    E2010_SetSynchroStartSourceExternal(ap); break;
                default:
                    throw new Exception("Unknown SynchroStartSource");
            }

            switch (ClockSource)
            {
                case E2010_SynchroClockSource.Internal:
                    E2010_SetSynchroClockSourceInternal(ap); break;
                case E2010_SynchroClockSource.InternalWithTrans:
                    E2010_SetSynchroClockSourceInternalWithTrans(ap); break;
                default:
                    throw new Exception("Unknown SynchroClockSource");
            }

            E2010_SetSynchroStartDelay(ap, StartDelay);
            E2010_SetSynchroStopAfterNKadrs(ap, StopAfterNKadrs);

            switch (AdMode)
            {
                case E2010_SynchroAdMode.NoAnalog:
                    E2010_SetSynchroAdModeNoAnalog(ap); break;
                case E2010_SynchroAdMode.Analog:
                    E2010_SetSynchroAdModeAnalog(ap); break;
                default:
                    throw new Exception("Unknown AdMode");
            }

            E2010_SetSynchroAdChannel(ap, AdChannel);
            E2010_SetSynchroAdPorog(ap, AdPorog);
            E2010_SetBlockDataMarkerEnabled(ap, BlockDataMarkerEnabled);
            E2010_SetChannelsQuantity(ap, ChannelsQuantity);
            E2010_SetAdcRate(ap, AdcRate);

            double InterKadrDelay;
            if (GetUsbSpeed() == 0)
            {
                InterKadrDelay = 0.01;
                this.DataStep = 256;
            }
            else
            {
                InterKadrDelay = 0;
                this.DataStep = 1024 * 1024;
            }
            E2010_SetInterKadrDelay(ap, InterKadrDelay);

            E2010_ConfigureInputChannels(pModule, ap, (int)AdcInputRange);

            this.ChannelsQuantity = ChannelsQuantity;
            this.InputRange = AdcInputRange;
            this.KadrRate = E2010_GetKadrRate(ap);
        }

        public double AdcToVoltage(short adc)
        {
            if (adc < -8000)
                return double.NaN;

            switch (InputRange)
            {
                case E2010_AdcInputRange._3000mV:
                    return (double)adc / 8000 * 3;
                case E2010_AdcInputRange._1000mV:
                    return (double)adc / 8000 * 1;
                case E2010_AdcInputRange._300mV:
                    return (double)adc / 8000 * 0.3;
                default:
                    throw new Exception("Unknown AdcInputRange");
            }
        }
    }
}
