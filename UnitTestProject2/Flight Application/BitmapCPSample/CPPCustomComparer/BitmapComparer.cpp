/* $Id: BitmapComparer.cpp,v 1.3 2008-07-28 09:57:59 amalyy Exp $ [MISCCSID] */
// BitmapComparer.cpp : Implementation of CBitmapComparer

#include "stdafx.h"
#include "BitmapComparer.h"
#include <atlstr.h>


// CBitmapComparer

// IBitmapCompareConfiguration Methods
STDMETHODIMP CBitmapComparer::GetDefaultConfigurationString(BSTR * pbstrConfiguration)
{
	CComBSTR bsConfig("MaxSurfAreaDiff=140000");
	*pbstrConfiguration = bsConfig.Detach();

	return S_OK;
}

STDMETHODIMP CBitmapComparer::GetHelpFilename(BSTR * pbstrFilename)
{
	CComBSTR bsFilename("..\\samples\\BitmapCPSample\\CPPCustomComparer\\SampleComparerDetails.txt");
	*pbstrFilename = bsFilename.Detach();

	return S_OK;
}

// IVerifyBitmap Methods
STDMETHODIMP CBitmapComparer::CompareBitmaps(IPictureDisp * pExpected, IPictureDisp * pActual, BSTR bstrConfiguration, BSTR * pbstrLog, IPictureDisp * * ppDiff, VARIANT_BOOL * pbMatch)
{
	HRESULT hr = S_OK;

	if (!pExpected || !pActual)
		return S_FALSE;

	CComQIPtr<IPicture> picExp(pExpected);
	CComQIPtr<IPicture> picAct(pActual);

	// Try to get HBITMAP from IPicture
	HBITMAP HbmpExp, HbmpAct;
	hr = picExp->get_Handle((OLE_HANDLE*)&HbmpExp);
	if (FAILED(hr))
		return hr;
	hr = picAct->get_Handle((OLE_HANDLE*)&HbmpAct);
	if (FAILED(hr))
		return hr;

	BITMAP ExpBmp = {0};
	if( !GetObject(HbmpExp, sizeof(ExpBmp), &ExpBmp) )
		return E_FAIL;

	BITMAP ActBmp = {0};
	if( !GetObject(HbmpAct, sizeof(ActBmp), &ActBmp) )
		return E_FAIL;

	CString s, tol;
	tol = bstrConfiguration;
	int EPos = tol.ReverseFind('=');
	tol = tol.Right(tol.GetLength() - EPos - 1);
	int maxSurfaceAreaDiff = _ttoi(tol);

	// fill output parameters
	CComPtr<IPictureDisp> Diff(pActual);
	*ppDiff = Diff;
	int DiffPixelsNumber = abs(ExpBmp.bmHeight * ExpBmp.bmWidth - ActBmp.bmHeight * ActBmp.bmWidth);
	*pbMatch = DiffPixelsNumber <= maxSurfaceAreaDiff;

	s.Format(_T("The number of different pixels is: %d."), DiffPixelsNumber);
	CComBSTR bs (s);
	*pbstrLog = bs.Detach();

	return hr;
}
