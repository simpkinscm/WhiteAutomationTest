/* $Id: BitmapComparer.h,v 1.1 2008-06-13 15:26:51 amalyy Exp $ [MISCCSID] */
// BitmapComparer.h : Declaration of the CBitmapComparer

#pragma once
#include "resource.h"       // main symbols

#include "CPPCustomComparer.h"


// CBitmapComparer

class ATL_NO_VTABLE CBitmapComparer : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CBitmapComparer, &CLSID_BitmapComparer>,
	public IDispatchImpl<IBitmapComparer, &IID_IBitmapComparer, &LIBID_CPPCustomComparerLib, /*wMajor =*/ 1, /*wMinor =*/ 0>,
	public IDispatchImpl<IBitmapCompareConfiguration, &__uuidof(IBitmapCompareConfiguration), &LIBID_BitmapComparerLib, /* wMajor = */ 1, /* wMinor = */ 0>,
	public IDispatchImpl<IVerifyBitmap, &__uuidof(IVerifyBitmap), &LIBID_BitmapComparerLib, /* wMajor = */ 1, /* wMinor = */ 0>
{
public:
	CBitmapComparer()
	{
	}

	DECLARE_REGISTRY_RESOURCEID(IDR_BITMAPCOMPARER)


	BEGIN_COM_MAP(CBitmapComparer)
		COM_INTERFACE_ENTRY(IBitmapComparer)
		COM_INTERFACE_ENTRY2(IDispatch, IBitmapCompareConfiguration)
		COM_INTERFACE_ENTRY(IBitmapCompareConfiguration)
		COM_INTERFACE_ENTRY(IVerifyBitmap)
	END_COM_MAP()


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease() 
	{
	}

public:


	// IBitmapCompareConfiguration Methods
public:
	STDMETHOD(GetDefaultConfigurationString)(BSTR * pbstrConfiguration);
	STDMETHOD(GetHelpFilename)(BSTR * pbstrFilename);

	// IVerifyBitmap Methods
public:
	STDMETHOD(CompareBitmaps)(IPictureDisp * pExpected, IPictureDisp * pActual, BSTR bstrConfiguration, BSTR * pbstrLog, IPictureDisp * * ppDiff, VARIANT_BOOL * pbMatch);
};

OBJECT_ENTRY_AUTO(__uuidof(BitmapComparer), CBitmapComparer)
