// dllmain.cpp : Определяет точку входа для приложения DLL.
#include "stdafx.h"
#include <cstdlib> 
#include <stdio.h>
#include "Lusbapi.h"
#pragma comment(lib, "Lusbapi.lib")
#define _WINAPI __declspec(dllexport) __stdcall

static HINSTANCE hInstance;

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  fdwReason,
                       LPVOID lpReserved
                     ) {
	if (fdwReason == DLL_PROCESS_ATTACH)
		// сохраним идентификатор программного модуля
		hInstance = hModule;
	return TRUE;
}

// ==================================================
// ================== ОБЩИЕ МЕТОДЫ ==================
// ==================================================

extern "C" DWORD _WINAPI _GetDllVersion(void) {
	return GetDllVersion();
}
extern "C" LPVOID _WINAPI _CreateLInstance(PCHAR const DeviceName) {
	return CreateLInstance(DeviceName);
}
extern "C" BOOL _WINAPI _OpenLDevice(ILUSBBASE * pModule, WORD VirtualSlot) {
	return pModule->OpenLDevice(VirtualSlot);
}
extern "C" BOOL _WINAPI _GetModuleName(ILUSBBASE * pModule, PCHAR const ModuleName) {
	return pModule->GetModuleName(ModuleName);
}
extern "C" BOOL _WINAPI GetUsbSpeed(ILUSBBASE * pModule, BYTE * const UsbSpeed) {
	return pModule->GetUsbSpeed(UsbSpeed);
}
extern "C" BOOL _WINAPI LowPowerMode(ILUSBBASE * pModule, BOOL LowPowerFlag) {
	return pModule->LowPowerMode(LowPowerFlag);
}
extern "C" BOOL _WINAPI GetLastErrorInfo(ILUSBBASE * pModule, LAST_ERROR_INFO_LUSBAPI * const LastErrorInfo) {
	return pModule->GetLastErrorInfo(LastErrorInfo);
}

// ==================================================
// ============== МЕТОДЫ МОДУЛЯ E2010 ===============
// ==================================================

extern "C" BOOL _WINAPI E2010_OpenLDevice(ILE2010 * pModule, WORD VirtualSlot) {
	return pModule->OpenLDevice(VirtualSlot);
}
extern "C" BOOL _WINAPI E2010_CloseLDevice(ILE2010 * pModule) {
	return pModule->CloseLDevice();
}
extern "C" BOOL _WINAPI E2010_ReleaseLInstance(ILE2010 * pModule) {
	return pModule->ReleaseLInstance();
}
extern "C" HANDLE _WINAPI E2010_GetModuleHandle(ILE2010 * pModule) {
	return pModule->GetModuleHandle();
}
extern "C" BOOL _WINAPI E2010_GetModuleName(ILE2010 * pModule, PCHAR const ModuleName) {
	BOOL r = pModule->GetModuleName(ModuleName);
	printf("Module name = %s", ModuleName);
	return r;
}
extern "C" BOOL _WINAPI E2010_GetUsbSpeed(ILE2010 * pModule, BYTE * const UsbSpeed) {
	return pModule->GetUsbSpeed(UsbSpeed);
}
extern "C" BOOL _WINAPI E2010_LowPowerMode(ILE2010 * pModule, BOOL LowPowerFlag) {
	return pModule->LowPowerMode(LowPowerFlag);
}
extern "C" BOOL _WINAPI E2010_GetLastErrorInfo(ILE2010 * pModule, LAST_ERROR_INFO_LUSBAPI * const LastErrorInfo) {
	return pModule->GetLastErrorInfo(LastErrorInfo);
}
extern "C" BOOL _WINAPI E2010_LOAD_MODULE(ILE2010 * pModule, PCHAR const FileName) {
	return pModule->LOAD_MODULE(FileName);
}
extern "C" BOOL _WINAPI E2010_TEST_MODULE(ILE2010 * pModule, WORD TestModeMask) {
	return pModule->TEST_MODULE(TestModeMask);
}
extern "C" BOOL _WINAPI E2010_GET_ADC_PARS(ILE2010 * pModule, ADC_PARS_E2010 * const AdcPars) {
	return pModule->GET_ADC_PARS(AdcPars);
}
extern "C" BOOL _WINAPI E2010_SET_ADC_PARS(ILE2010 * pModule, ADC_PARS_E2010 * const AdcPars) {
	return pModule->SET_ADC_PARS(AdcPars);
}
extern "C" BOOL _WINAPI E2010_START_ADC(ILE2010 * pModule) {
	return pModule->START_ADC();
}
extern "C" BOOL _WINAPI E2010_STOP_ADC(ILE2010 * pModule) {
	return pModule->STOP_ADC();
}
extern "C" BOOL _WINAPI E2010_GET_DATA_STATE(ILE2010 * pModule, DATA_STATE_E2010 * const DataState) {
	return pModule->GET_DATA_STATE(DataState);
}
extern "C" BOOL _WINAPI E2010_ReadData(ILE2010 * pModule, IO_REQUEST_LUSBAPI * const ReadRequest) {
	return pModule->ReadData(ReadRequest);
}
extern "C" BOOL _WINAPI E2010_DAC_SAMPLE(ILE2010 * pModule, SHORT * const DacData, WORD DacChannel) {
	return pModule->DAC_SAMPLE(DacData, DacChannel);
}
extern "C" BOOL _WINAPI E2010_ENABLE_TTL_OUT(ILE2010 * pModule, BOOL EnableTtlOut) {
	return pModule->ENABLE_TTL_OUT(EnableTtlOut);
}
extern "C" BOOL _WINAPI E2010_TTL_IN(ILE2010 * pModule, WORD * const TtlIn) {
	return pModule->TTL_IN(TtlIn);
}
extern "C" BOOL _WINAPI E2010_TTL_OUT(ILE2010 * pModule, WORD TtlOut) {
	return pModule->TTL_OUT(TtlOut);
}
extern "C" BOOL _WINAPI E2010_ENABLE_FLASH_WRITE(ILE2010 * pModule, BOOL IsUserFlashWriteEnabled) {
	return pModule->ENABLE_FLASH_WRITE(IsUserFlashWriteEnabled);
}
extern "C" BOOL _WINAPI E2010_READ_FLASH_ARRAY(ILE2010 * pModule, USER_FLASH_E2010 * const UserFlash) {
	return pModule->READ_FLASH_ARRAY(UserFlash);
}
extern "C" BOOL _WINAPI E2010_WRITE_FLASH_ARRAY(ILE2010 * pModule, USER_FLASH_E2010 * const UserFlash) {
	return pModule->WRITE_FLASH_ARRAY(UserFlash);
}
extern "C" BOOL _WINAPI E2010_GET_MODULE_DESCRIPTION(ILE2010 * pModule, MODULE_DESCRIPTION_E2010 * const ModuleDescription) {
	return pModule->GET_MODULE_DESCRIPTION(ModuleDescription);
}
extern "C" BOOL _WINAPI E2010_SAVE_MODULE_DESCRIPTION(ILE2010 * pModule, MODULE_DESCRIPTION_E2010 * const ModuleDescription) {
	return pModule->SAVE_MODULE_DESCRIPTION(ModuleDescription);
}

// Функции упрощения работы с модулем
extern "C" LPVOID _WINAPI E2010_CreateAdcPars() {
	ADC_PARS_E2010 * ap;
	ap = (ADC_PARS_E2010*)malloc(sizeof(ADC_PARS_E2010));
	return ap;
}
extern "C" LPVOID _WINAPI E2010_GET_ADC_PARS_Extended(ILE2010 * pModule) {
	ADC_PARS_E2010 * ap = (ADC_PARS_E2010 *)E2010_CreateAdcPars();
	E2010_GET_ADC_PARS(pModule, ap);
	return ap;
}
extern "C" void _WINAPI E2010_SetAdcCorrectionEnabled(ADC_PARS_E2010 * ap, BOOL AdcCorrectionEnabled) {
	ap->IsAdcCorrectionEnabled = AdcCorrectionEnabled;
}
extern "C" void _WINAPI E2010_SetSynchroStartSourceInternal(ADC_PARS_E2010 * ap) {
	ap->SynchroPars.StartSource = INT_ADC_START_E2010;
}
extern "C" void _WINAPI E2010_SetSynchroStartSourceInternalWithTrans(ADC_PARS_E2010 * ap) {
	ap->SynchroPars.StartSource = INT_ADC_START_WITH_TRANS_E2010;
}
extern "C" void _WINAPI E2010_SetSynchroStartSourceExternal(ADC_PARS_E2010 * ap) {
	ap->SynchroPars.StartSource = EXT_ADC_START_ON_RISING_EDGE_E2010;
}
extern "C" void _WINAPI E2010_SetSynchroClockSourceInternal(ADC_PARS_E2010 * ap) {
	ap->SynchroPars.StartSource = INT_ADC_CLOCK_E2010;
}
extern "C" void _WINAPI E2010_SetSynchroClockSourceInternalWithTrans(ADC_PARS_E2010 * ap) {
	ap->SynchroPars.StartSource = INT_ADC_CLOCK_WITH_TRANS_E2010;
}
extern "C" void _WINAPI E2010_SetSynchroStartDelay(ADC_PARS_E2010 * ap, DWORD StartDelay) {
	ap->SynchroPars.StartDelay = StartDelay;
}
extern "C" void _WINAPI E2010_SetSynchroStopAfterNKadrs(ADC_PARS_E2010 * ap, DWORD StopAfterNKadrs) {
	ap->SynchroPars.StopAfterNKadrs = StopAfterNKadrs;
}
extern "C" void _WINAPI E2010_SetSynchroAdModeNoAnalog(ADC_PARS_E2010 * ap) {
	ap->SynchroPars.SynchroAdMode = NO_ANALOG_SYNCHRO_E2010;
}
extern "C" void _WINAPI E2010_SetSynchroAdModeAnalog(ADC_PARS_E2010 * ap) {
	ap->SynchroPars.SynchroAdMode = ANALOG_SYNCHRO_ON_HIGH_LEVEL_E2010;
}
extern "C" void _WINAPI E2010_SetSynchroAdChannel(ADC_PARS_E2010 * ap, WORD SynchroAdChannel) {
	ap->SynchroPars.SynchroAdChannel = SynchroAdChannel;
}
extern "C" void _WINAPI E2010_SetSynchroAdPorog(ADC_PARS_E2010 * ap, SHORT SynchroAdPorog) {
	ap->SynchroPars.SynchroAdPorog = SynchroAdPorog;
}
extern "C" void _WINAPI E2010_SetBlockDataMarkerEnabled(ADC_PARS_E2010 * ap, BYTE IsBlockDataMarkerEnabled) {
	ap->SynchroPars.IsBlockDataMarkerEnabled = IsBlockDataMarkerEnabled;
}
extern "C" void _WINAPI E2010_SetChannelsQuantity(ADC_PARS_E2010 * ap, WORD ChannelsQuantity) {
	ap->ChannelsQuantity = ChannelsQuantity;
	for (int i = 0x0; i < ap->ChannelsQuantity; i++) ap->ControlTable[i] = (WORD)(i);
}
extern "C" void _WINAPI E2010_SetAdcRate(ADC_PARS_E2010 * ap, double AdcRate) {
	ap->AdcRate = AdcRate;
}
extern "C" void _WINAPI E2010_SetInterKadrDelay(ADC_PARS_E2010 * ap, double InterKadrDelay) {
	ap->InterKadrDelay = InterKadrDelay;
}
extern "C" void _WINAPI E2010_ConfigureInputChannels(ILE2010 * pModule, ADC_PARS_E2010 * ap, WORD AdcInputRange) {
	MODULE_DESCRIPTION_E2010 ModuleDescription;
	if (!pModule->GET_MODULE_DESCRIPTION(&ModuleDescription)) return;

	// сконфигурим входные каналы
	for (int i = 0x0; i < ADC_CHANNELS_QUANTITY_E2010; i++)
	{
		ap->InputRange[i] = AdcInputRange;  			// входной диапазон
		ap->InputSwitch[i] = ADC_INPUT_SIGNAL_E2010;	// источник входа - сигнал
	}
	// передаём в структуру параметров работы АЦП корректировочные коэффициенты АЦП
	for (int i = 0x0; i < ADC_INPUT_RANGES_QUANTITY_E2010; i++) {
		for (int j = 0x0; j < ADC_CHANNELS_QUANTITY_E2010; j++)
		{
			// корректировка смещения
			ap->AdcOffsetCoefs[i][j] = ModuleDescription.Adc.OffsetCalibration[j + i * ADC_CHANNELS_QUANTITY_E2010];
			// корректировка масштаба
			ap->AdcScaleCoefs[i][j] = ModuleDescription.Adc.ScaleCalibration[j + i * ADC_CHANNELS_QUANTITY_E2010];
		}
	}
}
extern "C" double _WINAPI E2010_GetKadrRate(ADC_PARS_E2010 * ap) {
	return ap->KadrRate;
}

//extern "C" BOOL _WINAPI ServiceRead(ILE2010 * pModule, SHORT * buffer, DWORD * NumberOfWordsPassed)
//{
//	printf("start read\n");
//	ADC_PARS_E2010 *ap = (ADC_PARS_E2010*)E2010_GET_ADC_PARS_Extended(pModule);
//	BYTE usbSpeed;
//	E2010_GetUsbSpeed(pModule, &usbSpeed);
//	int DataStep = usbSpeed == USB20_LUSBAPI ? 1024 * 1024 : 256 * 1024;
//
//	MODULE_DESCRIPTION_E2010 ModuleDescription;
//	if (!pModule->GET_MODULE_DESCRIPTION(&ModuleDescription)) printf(" GET_MODULE_DESCRIPTION() --> Bad\n");
//	else printf(" GET_MODULE_DESCRIPTION() --> OK\n");
//	printf(" Module E20-10 (S/N %s) is ready ... \n", ModuleDescription.Module.SerialNumber);
//	printf("   Module Info:\n");
//	printf("     Module  Revision   is '%c'\n", ModuleDescription.Module.Revision);
//	printf("     AVR Driver Version is %s (%s)\n", ModuleDescription.Mcu.Version.FwVersion.Version, ModuleDescription.Mcu.Version.FwVersion.Date);
//	printf("     PLD    Version     is %s (%s)\n", ModuleDescription.Pld.Version.Version, ModuleDescription.Pld.Version.Date);
//
//	printf("DataStep = %d\n", DataStep);
//	printf("KadrRate = %8.2f kHz\n", ap->KadrRate);
//
//	OVERLAPPED ReadOv;
//	IO_REQUEST_LUSBAPI IoReq;
//	DATA_STATE_E2010 DataState;
//	SHORT * AdcBuffer = new SHORT[DataStep];
//
//	// инициализация структуры типа OVERLAPPED
//	ZeroMemory(&ReadOv, sizeof(OVERLAPPED));
//	// создаём событие для асинхронного запроса
//	ReadOv.hEvent = CreateEvent(NULL, FALSE, FALSE, NULL);
//	// формируем структуру IoReq
//	IoReq.Buffer = AdcBuffer;
//	IoReq.NumberOfWordsToPass = DataStep;
//	IoReq.NumberOfWordsPassed = 0x0;
//	IoReq.Overlapped = &ReadOv;
//	IoReq.TimeOut = (DWORD)(DataStep / ap->KadrRate + 1000);
//
//	printf("TimeOut = %d ms\n", IoReq.TimeOut);
//
//	// сделаем запрос на очередную порцию данных
//	if (!pModule->ReadData(&IoReq)) { printf("ReadData error\n"); return false; }
//
//	if (!pModule->START_ADC()) { printf("START_ADC error\n"); return false; }
//
//	// ждём завершения операции сбора предыдущей порции данных
//	if (WaitForSingleObject(ReadOv.hEvent, IoReq.TimeOut) == WAIT_TIMEOUT) { printf("timeout\n");  return false; }
//
//	// попробуем получить текущее состояние процесса сбора данных
//	if (!pModule->GET_DATA_STATE(&DataState)) { printf("data state error\n"); return false; }
//	// теперь можно проверить этот признак переполнения внутреннего буфера модуля
//	else if (DataState.BufferOverrun == (0x1 << BUFFER_OVERRUN_E2010)) { printf("buffer overrun\n"); return false; }
//
//	*NumberOfWordsPassed = IoReq.NumberOfWordsPassed;
//	buffer = IoReq.Buffer;
//
//	printf("read ok\n");
//	return true;
//}



extern "C" LPVOID _WINAPI E2010_GetRequestOverlapped(ILE2010 * pModule, int DataStep, double KadrRate) {
	OVERLAPPED *ReadOv = new OVERLAPPED;
	//DATA_STATE_E2010 DataState;
	SHORT * AdcBuffer = new SHORT[DataStep];
	IO_REQUEST_LUSBAPI* IoReq = new IO_REQUEST_LUSBAPI;

	// инициализация структуры типа OVERLAPPED
	ZeroMemory(ReadOv, sizeof(OVERLAPPED));
	// создаём событие для асинхронного запроса
	ReadOv->hEvent = CreateEvent(NULL, FALSE, FALSE, NULL);
	// формируем структуру IoReq
	IoReq->Buffer = AdcBuffer;
	IoReq->NumberOfWordsToPass = DataStep;
	IoReq->NumberOfWordsPassed = 0x0;
	IoReq->Overlapped = ReadOv;
	IoReq->TimeOut = (DWORD)(DataStep / KadrRate + 1000);

	if (!pModule->ReadData(IoReq)) {
		delete ReadOv;
		delete AdcBuffer;
		delete IoReq;
		return nullptr;
	}

	return IoReq;
}

extern "C" LPVOID _WINAPI E2010_WaitResponse(ILE2010 * pModule, IO_REQUEST_LUSBAPI * IoReq, DWORD * const NumberOfWordsPassed) {
	if (WaitForSingleObject(IoReq->Overlapped->hEvent, IoReq->TimeOut) == WAIT_TIMEOUT) { 
		delete IoReq->Overlapped;
		delete IoReq->Buffer;
		delete IoReq;
		return nullptr; 
	}
	
	CloseHandle(IoReq->Overlapped->hEvent);
	*NumberOfWordsPassed = IoReq->NumberOfWordsToPass;

	return IoReq->Buffer;
}


extern "C" void _WINAPI E2010_ClearBuffer(IO_REQUEST_LUSBAPI * IoReq) {
	delete IoReq->Overlapped;
	delete IoReq->Buffer;
	delete IoReq;
}










//#include <conio.h>
//
//#define CHANNELS_QUANTITY			(0x4)
//
//// аварийный выход из программы
//void AbortProgram(const char *ErrorString);
//// функция потока ввода данных с АЦП
//DWORD WINAPI ServiceReadThread(PVOID /*Context*/);
//// функция вывода сообщений с ошибками
//void ShowThreadErrorMessage(void);
//
////------------------------------------------------------------------------
//// основная программа
////------------------------------------------------------------------------
//extern "C" void _WINAPI automatic(ILE2010 *pModule)
//{
//	// идентификатор файла
//	HANDLE hFile;
//	// идентификатор потока сбора данных
//	HANDLE hReadThread;
//	// структура параметров работы АЦП модуля
//	ADC_PARS_E2010 ap;
//	// размер запроса на сбор данных ReadData()
//	DWORD DataStep;
//	// будем собирать NDataBlock блоков по DataStep отсчётов в каждом
//	const WORD NDataBlock = 8;
//	// частота работы АЦП в кГц
//	const double AdcRate = 5000.0;
//	// буфер данных
//	SHORT *AdcBuffer;
//	// структура состояния процесса сбора данных
//	DATA_STATE_E2010 DataState;
//
//	// флажок завершения работы потока сбора данных
//	bool IsReadThreadComplete;
//	// номер ошибки при выполнении сбора данных
//	WORD ReadThreadErrorNumber;
//
//	// экранный счетчик-индикатор
//	DWORD Counter = 0x0, OldCounter = 0xFFFFFFFF;
//
//	WORD i/*, j*/;
//	//	WORD DacSample;
//
//	// сбросим флажок завершения потока ввода данных
//	IsReadThreadComplete = false;
//	// пока ничего не выделено под буфер данных
//	AdcBuffer = NULL;
//	// пока не создан поток ввода данных
//	hReadThread = NULL;
//	// пока откытого файла нет :(
//	hFile = INVALID_HANDLE_VALUE;
//	// сбросим флаг ошибок потока ввода данных
//	ReadThreadErrorNumber = 0x0;
//
////	// получим текущие параметры работы АЦП
//	if (!pModule->GET_ADC_PARS(&ap)) { printf(" GET_ADC_PARS() --> Bad\n"); return; }
//	else printf(" GET_ADC_PARS() --> OK\n");
//		DataStep = 1024 * 1024;			// размер запроса
//
//	// откроем файл для записи получаемых с модуля данных
//	hFile = CreateFile((LPWSTR)"Test.dat", GENERIC_WRITE, 0, NULL, CREATE_ALWAYS,
//		FILE_ATTRIBUTE_NORMAL | FILE_FLAG_SEQUENTIAL_SCAN | FILE_FLAG_WRITE_THROUGH, NULL);
//	if (hFile == INVALID_HANDLE_VALUE) { printf("\n Can't create file 'Test.dat'!\n"); return; }
//
//	//WORD RequestNumber;
//	DWORD FileBytesWritten;
//	// массив OVERLAPPED структур из двух элементов
//	OVERLAPPED ReadOv;
//	// массив структур с параметрами запроса на ввод/вывод данных
//	IO_REQUEST_LUSBAPI IoReq;
//
//	// выделим память под буфер
//	AdcBuffer = new SHORT[1 * DataStep];
//	if (!AdcBuffer) { printf(" Can not allocate memory\n"); return; }
//
//	// остановим работу АЦП и одновременно сбросим USB-канал чтения данных
//	if (!pModule->STOP_ADC()) { ReadThreadErrorNumber = 0x1; IsReadThreadComplete = true; return; }
//
//	// инициализация структуры типа OVERLAPPED
//	ZeroMemory(&ReadOv, sizeof(OVERLAPPED));
//	// создаём событие для асинхронного запроса
//	ReadOv.hEvent = CreateEvent(NULL, FALSE, FALSE, NULL);
//	// формируем структуру IoReq
//	IoReq.Buffer = AdcBuffer;
//	IoReq.NumberOfWordsToPass = DataStep;
//	IoReq.NumberOfWordsPassed = 0x0;
//	IoReq.Overlapped = &ReadOv;
//	IoReq.TimeOut = (DWORD)(DataStep / ap.KadrRate + 1000);
//
//	// делаем предварительный запрос на ввод данных
//	//RequestNumber = 0x0;
//	if (!pModule->ReadData(&IoReq)) { CloseHandle(ReadOv.hEvent); /*CloseHandle(ReadOv[1].hEvent); */ReadThreadErrorNumber = 0x2; IsReadThreadComplete = true; return; }
//
//	// запустим АЦП
//	if (pModule->START_ADC())
//	{
//		// цикл сбора данных
//		for (i = 0; i < NDataBlock; i++)
//		{
//			// сделаем запрос на очередную порцию данных
//			//RequestNumber ^= 0x1;
//			if (!pModule->ReadData(&IoReq)) { ReadThreadErrorNumber = 0x2; break; }
//			if (ReadThreadErrorNumber) break;
//
//			// ждём завершения операции сбора предыдущей порции данных
//			if (WaitForSingleObject(ReadOv.hEvent, IoReq.TimeOut) == WAIT_TIMEOUT) { ReadThreadErrorNumber = 0x3; break; }
//			if (ReadThreadErrorNumber) break;
//
//			// попробуем получить текущее состояние процесса сбора данных
//			if (!pModule->GET_DATA_STATE(&DataState)) { ReadThreadErrorNumber = 0x7; break; }
//			// теперь можно проверить этот признак переполнения внутреннего буфера модуля
//			else if (DataState.BufferOverrun == (0x1 << BUFFER_OVERRUN_E2010)) { ReadThreadErrorNumber = 0x8; break; }
//
//			// запишем полученную порцию данных в файл
//			if (!WriteFile(hFile,													// handle to file to write to
//				IoReq.Buffer,					// pointer to data to write to file
//				2 * DataStep,	 											// number of bytes to write
//				&FileBytesWritten,									// pointer to number of bytes written
//				NULL			  											// pointer to structure needed for overlapped I/O
//			)) {
//				ReadThreadErrorNumber = 0x4; break;
//			}
//
//			if (ReadThreadErrorNumber) break;
//			//else if (kbhit()) { ReadThreadErrorNumber = 0x5; break; }
//			else Sleep(20);
//			Counter++;
//			if (OldCounter != Counter) { printf(" Counter %3u from %3u\r", Counter, NDataBlock); OldCounter = Counter; }
//
//			// для примера вносим задержку - для нарушения целостности получаемых данных
////			if(i == 33) Sleep(1100);
//		}
//
//		//printf("\n Wait last response\n");
//
//		// последняя порция данных
//		//if (!ReadThreadErrorNumber)
//		//{
//		//	//RequestNumber ^= 0x1;
//		//	// ждём окончания операции сбора последней порции данных
//		//	if (WaitForSingleObject(ReadOv[RequestNumber /*^ 0x1*/].hEvent, IoReq[RequestNumber /*^ 0x1*/].TimeOut) == WAIT_TIMEOUT) ReadThreadErrorNumber = 0x3;
//		//	// запишем последнюю порцию данных в файл
//		//	if (!WriteFile(hFile,													// handle to file to write to
//		//		IoReq[RequestNumber ^ 0x1].Buffer,					// pointer to data to write to file
//		//		2 * DataStep,	 											// number of bytes to write
//		//		&FileBytesWritten,									// pointer to number of bytes written
//		//		NULL			  											// pointer to structure needed for overlapped I/O
//		//	)) ReadThreadErrorNumber = 0x4;
//		//	Counter++;
//		//	if (OldCounter != Counter) { printf(" Counter %3u from %3u\r", Counter, NDataBlock); OldCounter = Counter; }
//		//}
//	}
//	else { ReadThreadErrorNumber = 0x6; }
//
//	// остановим работу АЦП
//	// !!!ВАЖНО!!! Если необходима достоверная информация о целостности
//	// ВСЕХ собраных данных, то функцию STOP_ADC() следует выполнять не позднее,
//	// чем через 800 мс после окончания ввода последней порции данных.
//	// Для заданной частоты сбора данных в 5 МГц эта величина определяет время
//	// переполнения внутренненого FIFO буфера модуля, который имеет размер 8 Мб. 
//	if (!pModule->STOP_ADC()) ReadThreadErrorNumber = 0x1;
//	// если нужно - анализируем окончательный признак переполнения внутреннего буфера модуля
//	//if (DataState.BufferOverrun != (0x1 << BUFFER_OVERRUN_E2010))
//	//{
//	//	// попробуем получить окончательный состояние процесса сбора данных
//	//	if (!pModule->GET_DATA_STATE(&DataState)) ReadThreadErrorNumber = 0x7;
//	//	// теперь можно проверить этот признак переполнения внутреннего буфера модуля
//	//	else if (DataState.BufferOverrun == (0x1 << BUFFER_OVERRUN_E2010)) ReadThreadErrorNumber = 0x8;
//	//}
//	// прервём возможно незавершённый асинхронный запрос на приём данных
//	/*if (!CancelIo(ModuleHandle)) { ReadThreadErrorNumber = 0x9; }*/
//	// освободим все идентификаторы событий
//	CloseHandle(ReadOv.hEvent);
//	// небольшая задержка
//	/*Sleep(100);*/
//	// установим флажок завершения работы потока сбора данных
//	/*IsReadThreadComplete = true;*/
//	// теперь можно спокойно выходить из потока
//
//
//	// проверим была ли ошибка выполнения потока сбора данных
//	printf("\n\n");
//	if (ReadThreadErrorNumber) { printf("ReadError %d\n", ReadThreadErrorNumber); }
//	else printf(" The program was completed successfully!!!\n");
//}

//------------------------------------------------------------------------
// Поток, в котором осуществляется сбор данных
//------------------------------------------------------------------------
//DWORD WINAPI ServiceReadThread(PVOID /*Context*/)
//{
//	WORD i;
//	WORD RequestNumber;
//	DWORD FileBytesWritten;
//	// массив OVERLAPPED структур из двух элементов
//	OVERLAPPED ReadOv[2];
//	// массив структур с параметрами запроса на ввод/вывод данных
//	IO_REQUEST_LUSBAPI IoReq[2];
//
//	// остановим работу АЦП и одновременно сбросим USB-канал чтения данных
//	if (!pModule->STOP_ADC()) { ReadThreadErrorNumber = 0x1; IsReadThreadComplete = true; return 0x0; }
//
//	// формируем необходимые для сбора данных структуры
//	for (i = 0x0; i < 0x2; i++)
//	{
//		// инициализация структуры типа OVERLAPPED
//		ZeroMemory(&ReadOv[i], sizeof(OVERLAPPED));
//		// создаём событие для асинхронного запроса
//		ReadOv[i].hEvent = CreateEvent(NULL, FALSE, FALSE, NULL);
//		// формируем структуру IoReq
//		IoReq[i].Buffer = AdcBuffer + i * DataStep;
//		IoReq[i].NumberOfWordsToPass = DataStep;
//		IoReq[i].NumberOfWordsPassed = 0x0;
//		IoReq[i].Overlapped = &ReadOv[i];
//		IoReq[i].TimeOut = (DWORD)(DataStep / ap.KadrRate + 1000);
//	}
//
//	// делаем предварительный запрос на ввод данных
//	RequestNumber = 0x0;
//	if (!pModule->ReadData(&IoReq[RequestNumber])) { CloseHandle(ReadOv[0].hEvent); CloseHandle(ReadOv[1].hEvent); ReadThreadErrorNumber = 0x2; IsReadThreadComplete = true; return 0x0; }
//
//	// запустим АЦП
//	if (pModule->START_ADC())
//	{
//		// цикл сбора данных
//		for (i = 0x1; i < NDataBlock; i++)
//		{
//			// сделаем запрос на очередную порцию данных
//			RequestNumber ^= 0x1;
//			if (!pModule->ReadData(&IoReq[RequestNumber])) { ReadThreadErrorNumber = 0x2; break; }
//			if (ReadThreadErrorNumber) break;
//
//			// ждём завершения операции сбора предыдущей порции данных
//			if (WaitForSingleObject(ReadOv[RequestNumber ^ 0x1].hEvent, IoReq[RequestNumber ^ 0x1].TimeOut) == WAIT_TIMEOUT) { ReadThreadErrorNumber = 0x3; break; }
//			if (ReadThreadErrorNumber) break;
//
//			// попробуем получить текущее состояние процесса сбора данных
//			if (!pModule->GET_DATA_STATE(&DataState)) { ReadThreadErrorNumber = 0x7; break; }
//			// теперь можно проверить этот признак переполнения внутреннего буфера модуля
//			else if (DataState.BufferOverrun == (0x1 << BUFFER_OVERRUN_E2010)) { ReadThreadErrorNumber = 0x8; break; }
//
//			// запишем полученную порцию данных в файл
//			if (!WriteFile(hFile,													// handle to file to write to
//				IoReq[RequestNumber ^ 0x1].Buffer,					// pointer to data to write to file
//				2 * DataStep,	 											// number of bytes to write
//				&FileBytesWritten,									// pointer to number of bytes written
//				NULL			  											// pointer to structure needed for overlapped I/O
//			)) {
//				ReadThreadErrorNumber = 0x4; break;
//			}
//
//			if (ReadThreadErrorNumber) break;
//			//else if (kbhit()) { ReadThreadErrorNumber = 0x5; break; }
//			else Sleep(20);
//			Counter++;
//
//			// для примера вносим задержку - для нарушения целостности получаемых данных
////			if(i == 33) Sleep(1100);
//		}
//
//		// последняя порция данных
//		if (!ReadThreadErrorNumber)
//		{
//			RequestNumber ^= 0x1;
//			// ждём окончания операции сбора последней порции данных
//			if (WaitForSingleObject(ReadOv[RequestNumber ^ 0x1].hEvent, IoReq[RequestNumber ^ 0x1].TimeOut) == WAIT_TIMEOUT) ReadThreadErrorNumber = 0x3;
//			// запишем последнюю порцию данных в файл
//			if (!WriteFile(hFile,													// handle to file to write to
//				IoReq[RequestNumber ^ 0x1].Buffer,					// pointer to data to write to file
//				2 * DataStep,	 											// number of bytes to write
//				&FileBytesWritten,									// pointer to number of bytes written
//				NULL			  											// pointer to structure needed for overlapped I/O
//			)) ReadThreadErrorNumber = 0x4;
//			Counter++;
//		}
//	}
//	else { ReadThreadErrorNumber = 0x6; }
//
//	// для примера вносим задержку - для нарушения целостности получаемых данных
////	Sleep(1100);
//
//	// остановим работу АЦП
//	// !!!ВАЖНО!!! Если необходима достоверная информация о целостности
//	// ВСЕХ собраных данных, то функцию STOP_ADC() следует выполнять не позднее,
//	// чем через 800 мс после окончания ввода последней порции данных.
//	// Для заданной частоты сбора данных в 5 МГц эта величина определяет время
//	// переполнения внутренненого FIFO буфера модуля, который имеет размер 8 Мб. 
//	if (!pModule->STOP_ADC()) ReadThreadErrorNumber = 0x1;
//	// если нужно - анализируем окончательный признак переполнения внутреннего буфера модуля
//	if (DataState.BufferOverrun != (0x1 << BUFFER_OVERRUN_E2010))
//	{
//		// попробуем получить окончательный состояние процесса сбора данных
//		if (!pModule->GET_DATA_STATE(&DataState)) ReadThreadErrorNumber = 0x7;
//		// теперь можно проверить этот признак переполнения внутреннего буфера модуля
//		else if (DataState.BufferOverrun == (0x1 << BUFFER_OVERRUN_E2010)) ReadThreadErrorNumber = 0x8;
//	}
//	// прервём возможно незавершённый асинхронный запрос на приём данных
//	if (!CancelIo(ModuleHandle)) { ReadThreadErrorNumber = 0x9; }
//	// освободим все идентификаторы событий
//	for (i = 0x0; i < 0x2; i++) CloseHandle(ReadOv[i].hEvent);
//	// небольшая задержка
//	Sleep(100);
//	// установим флажок завершения работы потока сбора данных
//	IsReadThreadComplete = true;
//	// теперь можно спокойно выходить из потока
//	return 0x0;
//}

//------------------------------------------------------------------------
// Отобразим сообщение с ошибкой
//------------------------------------------------------------------------
//void ShowThreadErrorMessage(void)
//{
//	switch (ReadThreadErrorNumber)
//	{
//	case 0x1:
//		printf(" ADC Thread: STOP_ADC() --> Bad\n");
//		break;
//
//	case 0x2:
//		printf(" ADC Thread: ReadData() --> Bad\n");
//		break;
//
//	case 0x3:
//		printf(" ADC Thread: Timeout is occured!\n");
//		break;
//
//	case 0x4:
//		printf(" ADC Thread: Writing data file error!\n");
//		break;
//
//	case 0x5:
//		// если программа была злобно прервана, предъявим ноту протеста
//		printf(" ADC Thread: The program was terminated!\n");
//		break;
//
//	case 0x6:
//		printf(" ADC Thread: START_ADC() --> Bad\n");
//		break;
//
//	case 0x7:
//		printf(" ADC Thread: CHECK_DATA_INTERGRITY() --> Bad\n");
//		break;
//
//	case 0x8:
//		printf(" ADC Thread: Buffer Overrun --> Bad\n");
//		break;
//
//	case 0x9:
//		printf(" ADC Thread: Can't cancel pending input and output (I/O) operations!\n");
//		break;
//
//	default:
//		printf(" Unknown error!\n");
//		break;
//	}
//
//	return;
//}
//
////------------------------------------------------------------------------
//// аварийное завершение программы
////------------------------------------------------------------------------
//void AbortProgram(const char *ErrorString)
//{
//	// подчищаем интерфейс модуля
//	if (pModule)
//	{
//		// освободим интерфейс модуля
//		if (!pModule->ReleaseLInstance()) printf(" ReleaseLInstance() --> Bad\n");
//		else printf(" ReleaseLInstance() --> OK\n");
//		// обнулим указатель на интерфейс модуля
//		pModule = NULL;
//	}
//
//	// освободим память буфера
//	if (AdcBuffer) { delete[] AdcBuffer; AdcBuffer = NULL; }
//	// освободим идентификатор потока сбора данных
//	if (hReadThread) { CloseHandle(hReadThread); hReadThread = NULL; }
//	// освободим идентификатор файла данных
//	if (hFile != INVALID_HANDLE_VALUE) { CloseHandle(hFile); hFile = INVALID_HANDLE_VALUE; }
//
//	// выводим текст сообщения
//	if (ErrorString) printf(ErrorString);
//
//	// прочистим очередь клавиатуры
//	//if (kbhit()) { while (kbhit()) getch(); }
//
//	// если нужно - аварийно завершаем программу
//	//if (AbortionFlag) exit(0x1);
//	// или спокойно выходим из функции   
//	//else return;
//}
