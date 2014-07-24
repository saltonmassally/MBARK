Imports System
Imports System.Windows.Forms

Namespace Mbark.UI

#Region "  Thread-Safe Control.Enabled Getter and Setter"

	' ---
	' This is generated code; edits will be lost.
	
	Public Module SafeControlEnabledGetterAndSetter

	Private Sub SetControlEnabledImplementation(ByVal control As Control, ByVal value As Boolean)
		control.Enabled = value
	End Sub

	''' <summary>
    ''' Provides a thread-safe mechanism for setting the value of a Control.Control property.
    ''' </summary>
    ''' <param name="control">Object to have its Enabled set</param>
    ''' <param name="value">Value assigned to target object's Enabled property</param>
    ''' <remarks>Automatically generated from SafeInvokeWrappers.cst</remarks>
	Public Sub SafeSetControlEnabled(ByVal control As Control, ByVal value As Boolean)
		SafeInvoke2ArgSub(Of Control, Boolean)(control, AddressOf SetControlEnabledImplementation, control, value)
	End Sub
	
	Private Function GetControlEnabledImplementation(ByVal control As Control) As Boolean
		Return control.Enabled
	End Function
	
	
	''' <summary>
    ''' Provides a thread-safe mechanism for getting the value of a Control.Control property.
    ''' </summary>
    ''' <param name="control">Object from which to retrieve Enabled value</param>
    ''' <remarks>Automatically generated from SafeInvokeWrappers.cst</remarks>
	Public Function SafeGetControlEnabled(ByVal control As Control) As Boolean
		Return SafeInvoke1ArgFunction(Of Boolean, Control)(control,  AddressOf GetControlEnabledImplementation, control)
	End Function
	
	End Module
	

#End Region

#Region "  Thread-Safe Control.Text Getter and Setter"

	' ---
	' This is generated code; edits will be lost.
	
	Public Module SafeControlTextGetterAndSetter

	Private Sub SetControlTextImplementation(ByVal control As Control, ByVal value As String)
		control.Text = value
	End Sub

	''' <summary>
    ''' Provides a thread-safe mechanism for setting the value of a Control.Control property.
    ''' </summary>
    ''' <param name="control">Object to have its Text set</param>
    ''' <param name="value">Value assigned to target object's Text property</param>
    ''' <remarks>Automatically generated from SafeInvokeWrappers.cst</remarks>
	Public Sub SafeSetControlText(ByVal control As Control, ByVal value As String)
		SafeInvoke2ArgSub(Of Control, String)(control, AddressOf SetControlTextImplementation, control, value)
	End Sub
	
	Private Function GetControlTextImplementation(ByVal control As Control) As String
		Return control.Text
	End Function
	
	
	''' <summary>
    ''' Provides a thread-safe mechanism for getting the value of a Control.Control property.
    ''' </summary>
    ''' <param name="control">Object from which to retrieve Text value</param>
    ''' <remarks>Automatically generated from SafeInvokeWrappers.cst</remarks>
	Public Function SafeGetControlText(ByVal control As Control) As String
		Return SafeInvoke1ArgFunction(Of String, Control)(control,  AddressOf GetControlTextImplementation, control)
	End Function
	
	End Module
	

#End Region

#Region "  Thread-Safe Label.Text Getter and Setter"

	' ---
	' This is generated code; edits will be lost.
	
	Public Module SafeLabelTextGetterAndSetter

	Private Sub SetLabelTextImplementation(ByVal control As Label, ByVal value As String)
		control.Text = value
	End Sub

	''' <summary>
    ''' Provides a thread-safe mechanism for setting the value of a Label.Label property.
    ''' </summary>
    ''' <param name="control">Object to have its Text set</param>
    ''' <param name="value">Value assigned to target object's Text property</param>
    ''' <remarks>Automatically generated from SafeInvokeWrappers.cst</remarks>
	Public Sub SafeSetLabelText(ByVal control As Label, ByVal value As String)
		SafeInvoke2ArgSub(Of Label, String)(control, AddressOf SetLabelTextImplementation, control, value)
	End Sub
	
	Private Function GetLabelTextImplementation(ByVal control As Label) As String
		Return control.Text
	End Function
	
	
	''' <summary>
    ''' Provides a thread-safe mechanism for getting the value of a Label.Label property.
    ''' </summary>
    ''' <param name="control">Object from which to retrieve Text value</param>
    ''' <remarks>Automatically generated from SafeInvokeWrappers.cst</remarks>
	Public Function SafeGetLabelText(ByVal control As Label) As String
		Return SafeInvoke1ArgFunction(Of String, Label)(control,  AddressOf GetLabelTextImplementation, control)
	End Function
	
	End Module
	

#End Region

#Region "  Thread-Safe Label.Visible Getter and Setter"

	' ---
	' This is generated code; edits will be lost.
	
	Public Module SafeLabelVisibleGetterAndSetter

	Private Sub SetLabelVisibleImplementation(ByVal control As Label, ByVal value As Boolean)
		control.Visible = value
	End Sub

	''' <summary>
    ''' Provides a thread-safe mechanism for setting the value of a Label.Label property.
    ''' </summary>
    ''' <param name="control">Object to have its Visible set</param>
    ''' <param name="value">Value assigned to target object's Visible property</param>
    ''' <remarks>Automatically generated from SafeInvokeWrappers.cst</remarks>
	Public Sub SafeSetLabelVisible(ByVal control As Label, ByVal value As Boolean)
		SafeInvoke2ArgSub(Of Label, Boolean)(control, AddressOf SetLabelVisibleImplementation, control, value)
	End Sub
	
	Private Function GetLabelVisibleImplementation(ByVal control As Label) As Boolean
		Return control.Visible
	End Function
	
	
	''' <summary>
    ''' Provides a thread-safe mechanism for getting the value of a Label.Label property.
    ''' </summary>
    ''' <param name="control">Object from which to retrieve Visible value</param>
    ''' <remarks>Automatically generated from SafeInvokeWrappers.cst</remarks>
	Public Function SafeGetLabelVisible(ByVal control As Label) As Boolean
		Return SafeInvoke1ArgFunction(Of Boolean, Label)(control,  AddressOf GetLabelVisibleImplementation, control)
	End Function
	
	End Module
	

#End Region
End Namespace
