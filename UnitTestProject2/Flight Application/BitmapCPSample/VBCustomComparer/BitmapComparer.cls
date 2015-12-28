VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "BitmapComparer"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Private Declare Function GetObject Lib "gdi32.dll" Alias "GetObjectA" (ByVal hObject As Long, ByVal nCount As Long, ByRef lpObject As Any) As Long

Public Type BITMAP
    bmType As Long
    bmWidth As Long
    bmHeight As Long
    bmWidthBytes As Long
    bmPlanes As Integer
    bmBitsPixel As Integer
    bmBits As Long
End Type

Implements IBitmapCompareConfiguration
Implements IVerifyBitmap

Private Function IBitmapCompareConfiguration_GetDefaultConfigurationString() As String
   IBitmapCompareConfiguration_GetDefaultConfigurationString = "MaxSurfAreaDiff=140000"
End Function

Private Function IBitmapCompareConfiguration_GetHelpFilename() As String
    IBitmapCompareConfiguration_GetHelpFilename = "..\samples\BitmapCPSample\CPPCustomComparer\SampleComparerDetails.txt"
End Function

Private Function IVerifyBitmap_CompareBitmaps(ByVal pExpected As stdole.IPictureDisp, ByVal pActual As stdole.IPictureDisp, ByVal bstrConfiguration As String, ByRef pbstrLog As String, ByRef ppDiff As stdole.IPictureDisp) As Boolean
        
    ' place your comparison logic here
    
    Dim maxSurfaceAreaDiff As Long
    Dim EqualSign As Long
    
    ' parse configuration string
    EqualSign = InStr(bstrConfiguration, "=")
    If EqualSign = 0 Then
        pbstrLog = "Configuration string is invalid."
        Set ppDiff = pActual
        IVerifyBitmap_CompareBitmaps = False
    Else
        Dim sText As String
        sText = Right$(bstrConfiguration, Len(bstrConfiguration) - EqualSign)
    
        maxSurfaceAreaDiff = CLng(sText)

        ' get HBITMAP from IPicture
        Dim hbmpExp, hbmpAct As OLE_HANDLE
        hbmpExp = pExpected.Handle
        hbmpAct = pActual.Handle
        
        ' get real sizes of images
        Dim bmpExp As BITMAP
        Dim bmpAct As BITMAP
        
        GetObject hbmpExp, Len(bmpExp), bmpExp
        GetObject hbmpAct, Len(bmpAct), bmpAct
        
        Dim NumberOfDifferentPixels As Long
        NumberOfDifferentPixels = Abs(bmpExp.bmHeight * bmpExp.bmWidth - bmpAct.bmHeight * bmpAct.bmWidth)
        
        ' fill output parameters
        pbstrLog = "The number of different pixels is: " & NumberOfDifferentPixels
        
        Set ppDiff = pActual
        
        IVerifyBitmap_CompareBitmaps = NumberOfDifferentPixels <= maxSurfaceAreaDiff
    End If
    
End Function



