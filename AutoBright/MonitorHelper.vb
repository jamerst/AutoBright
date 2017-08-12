Imports System.Runtime.InteropServices
Imports System.ComponentModel
Public Class MonitorHelper
    Public Shared Function GetPhysicalMonitors() As PHYSICAL_MONITOR()
        Dim PhysicalMonitorList As New List(Of PHYSICAL_MONITOR)
        For Each Scrn As Screen In Screen.AllScreens
            Dim hMonitor As IntPtr = MonitorFromPoint(Scrn.Bounds.Location, MONITOR_DEFAULTTONEAREST)
            Dim NumberOfPhysicalMonitors As UInteger
            GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, NumberOfPhysicalMonitors)
            Dim PhysicalMonitors(CInt(NumberOfPhysicalMonitors) - 1) As PHYSICAL_MONITOR
            GetPhysicalMonitorsFromHMONITOR(hMonitor, NumberOfPhysicalMonitors, PhysicalMonitors)
            PhysicalMonitorList.AddRange(PhysicalMonitors)
        Next
        Return PhysicalMonitorList.ToArray
    End Function

    Public Shared Function DestroyAllPhysicalMonitors(ByVal PhysicalMonitors As PHYSICAL_MONITOR()) As Boolean
        Return DestroyPhysicalMonitors(CUInt(PhysicalMonitors.Length), PhysicalMonitors)
    End Function

    Private Shared Function GetPhysicalMonitorCapabilities(physicalMonitor As PHYSICAL_MONITOR) As UInteger
        Dim dwMonitorCapabilities As UInteger, dwSupportedColorTemperatures As UInteger
        GetMonitorCapabilities(physicalMonitor.hPhysicalMonitor, dwMonitorCapabilities, dwSupportedColorTemperatures)
        Return dwMonitorCapabilities
    End Function

    Public Shared Function GetBrightnessSupport(physicalMonitor As PHYSICAL_MONITOR) As Boolean
        Return (GetPhysicalMonitorCapabilities(physicalMonitor) And MC_CAPS_BRIGHTNESS) = MC_CAPS_BRIGHTNESS
    End Function

    Public Shared Function GetPhysicalMonitorBrightness(physicalMonitor As PHYSICAL_MONITOR) As Double
        Dim dwMinimumBrightness As UInteger, dwCurrentBrightness As UInteger, dwMaximumBrightness As UInteger
        GetMonitorBrightness(physicalMonitor.hPhysicalMonitor, dwMinimumBrightness, dwCurrentBrightness, dwMaximumBrightness)
        Return CDbl(dwCurrentBrightness - dwMinimumBrightness) / CDbl(dwMaximumBrightness - dwMinimumBrightness)
    End Function

    Public Shared Sub SetPhysicalMonitorBrightness(physicalMonitor As PHYSICAL_MONITOR, brightness As Double)
        Dim dwMinimumBrightness As UInteger, dwCurrentBrightness As UInteger, dwMaximumBrightness As UInteger
        If Not GetMonitorBrightness(physicalMonitor.hPhysicalMonitor, dwMinimumBrightness, dwCurrentBrightness, dwMaximumBrightness) Then
            Throw New Win32Exception(Marshal.GetLastWin32Error())
        End If
        If Not SetMonitorBrightness(physicalMonitor.hPhysicalMonitor, CUInt(dwMinimumBrightness + (dwMaximumBrightness - dwMinimumBrightness) * brightness)) Then
            Throw New Win32Exception(Marshal.GetLastWin32Error())
        End If
    End Sub

#Region "Win32Apis"
    Private Const MONITOR_DEFAULTTONEAREST As Integer = &H2
    Private Const MC_CAPS_BRIGHTNESS As Integer = &H2

    <DllImport("user32.dll", SetLastError:=False)>
    Private Shared Function MonitorFromPoint(pt As Point, dwFlags As UInteger) As IntPtr
    End Function

    <DllImport("dxva2.dll", SetLastError:=True)>
    Private Shared Function GetPhysicalMonitorsFromHMONITOR(hMonitor As IntPtr, dwPhysicalMonitorArraySize As UInteger, <Out> pPhysicalMonitorArray As PHYSICAL_MONITOR()) As Boolean
    End Function

    <DllImport("dxva2.dll", SetLastError:=True)>
    Private Shared Function GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor As IntPtr, ByRef pdwNumberOfPhysicalMonitors As UInteger) As Boolean
    End Function

    <DllImport("dxva2.dll", SetLastError:=True)>
    Private Shared Function DestroyPhysicalMonitors(dwPhysicalMonitorArraySize As UInteger, pPhysicalMonitorArray As PHYSICAL_MONITOR()) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure PHYSICAL_MONITOR
        Public hPhysicalMonitor As IntPtr
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)> Public szPhysicalMonitorDescription As String
    End Structure

    <DllImport("dxva2.dll", SetLastError:=True)>
    Private Shared Function GetMonitorCapabilities(hMonitor As IntPtr, ByRef pdwMonitorCapabilities As UInteger, ByRef pdwSupportedColorTemperatures As UInteger) As Boolean
    End Function

    <DllImport("dxva2.dll", SetLastError:=True)>
    Private Shared Function GetMonitorBrightness(hMonitor As IntPtr, ByRef pdwMinimumBrightness As UInteger, ByRef pdwCurrentBrightness As UInteger, ByRef pdwMaximumBrightness As UInteger) As Boolean
    End Function

    <DllImport("dxva2.dll", SetLastError:=True)>
    Private Shared Function SetMonitorBrightness(hMonitor As IntPtr, dwNewBrightness As UInteger) As Boolean
    End Function
#End Region

End Class 'Don't even try to understand this if I were you - handles anything to do with getting or setting brightness. This is BrightnessControl © 2015 Alexander Horn.