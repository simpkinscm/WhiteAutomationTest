/* $Id: CPPCustomComparer.cpp,v 1.2 2008-07-10 08:49:33 amalyy Exp $ [MISCCSID] */
// CPPCustomComparer.cpp : Implementation of DLL Exports.

#include "stdafx.h"
#include "resource.h"
#include "CPPCustomComparer.h"
#include "..\..\..\dat\BitmapCPCustomization\ComponentCategory.h"

class CCPPCustomComparerModule : public CAtlDllModuleT< CCPPCustomComparerModule >
{
public :
	DECLARE_LIBID(LIBID_CPPCustomComparerLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_CPPCUSTOMCOMPARER, "{0E3B144D-B2A2-4E42-90F2-781C30907D1E}")
};

CCPPCustomComparerModule _AtlModule;


// DLL Entry Point
extern "C" BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	hInstance;
    return _AtlModule.DllMain(dwReason, lpReserved); 
}


// Used to determine whether the DLL can be unloaded by OLE
STDAPI DllCanUnloadNow(void)
{
    return _AtlModule.DllCanUnloadNow();
}


// Returns a class factory to create an object of the requested type
STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID* ppv)
{
    return _AtlModule.DllGetClassObject(rclsid, riid, ppv);
}


// DllRegisterServer - Adds entries to the system registry
STDAPI DllRegisterServer(void)
{
    // registers object, typelib and all interfaces in typelib
    HRESULT hr = _AtlModule.DllRegisterServer();

	CComPtr<ICatRegister> spReg;
	hr = spReg.CoCreateInstance(CLSID_StdComponentCategoriesMgr, 0, CLSCTX_INPROC);
	if (FAILED(hr))
		return hr;

	// register component inside QTP category 
	CATID catid = CATID_QTPBitmapComparers;
	hr = spReg->RegisterClassImplCategories(CLSID_BitmapComparer, 1, &catid);
	if (FAILED(hr))
		return hr;

	return hr;
}


// DllUnregisterServer - Removes entries from the system registry
STDAPI DllUnregisterServer(void)
{
	HRESULT hr = _AtlModule.DllUnregisterServer();

	CComPtr<ICatRegister> spReg;
	hr = spReg.CoCreateInstance(CLSID_StdComponentCategoriesMgr, 0, CLSCTX_INPROC);
	if (FAILED(hr))
		return hr;

	// unregister component inside QTP category
	CATID catid = CATID_QTPBitmapComparers;
	hr = spReg->UnRegisterClassImplCategories(CLSID_BitmapComparer, 1, &catid);
	if (FAILED(hr))
		return hr;

	return hr;
}
