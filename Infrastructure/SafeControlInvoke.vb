Imports System
Imports System.Windows.Forms
Imports System.Diagnostics.CodeAnalysis

Namespace Mbark.UI

Public Delegate Sub SubOfNoArgs()

Public Delegate Sub SubOf1Arg _
	(Of ArgType) ( _
	ByVal value As ArgType)

Public Delegate Sub SubOf2Args _
	(Of ArgType1, ArgType2) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2)

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Sub SubOf3Args _
	(Of ArgType1, ArgType2, ArgType3) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3)

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Sub SubOf4Args _
	(Of ArgType1, ArgType2, ArgType3, ArgType4) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4)

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Sub SubOf5Args _
	(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5)

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Sub SubOf6Args _
	(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6)

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Sub SubOf7Args _
	(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6, _
	ByVal value7 As ArgType7)

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Sub SubOf8Args _
	(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7, ArgType8) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6, _
	ByVal value7 As ArgType7, _
	ByVal value8 As ArgType8)


Public Delegate Function FunctionOfNoArgs(Of ReturnType)() As ReturnType

Public Delegate Function FunctionOf1Arg _
	(Of ReturnType, ArgType) ( _
	ByVal value As ArgType) As ReturnType
	
<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Function FunctionOf2Args _
	(Of ReturnType, ArgType1, ArgType2) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2) As ReturnType
	
<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Function FunctionOf3Args _
	(Of ReturnType, ArgType1, ArgType2, ArgType3) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3) As ReturnType
	
<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Function FunctionOf4Args _
	(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4) As ReturnType
	
<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Function FunctionOf5Args _
	(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5) As ReturnType
	
<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Function FunctionOf6Args _
	(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6) As ReturnType
	
<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Function FunctionOf7Args _
	(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6, _
	ByVal value7 As ArgType7) As ReturnType
	
<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Delegate Function FunctionOf8Args _
	(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7, ArgType8) ( _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6, _
	ByVal value7 As ArgType7, _
	ByVal value8 As ArgType8) As ReturnType
	

Public Module CrossThreadControlInvoke

Public Sub SafeInvokeNoArgSub( _
	ByVal control As Control, _
	ByVal method As SubOfNoArgs)
	If control Is Nothing Then Throw New ArgumentNullException("control")
	If control.InvokeRequired Then
    	control.Invoke(method)
	Else
    	method.Invoke()
	End If
End Sub

Public Sub SafeInvoke1ArgSub _
	(Of ArgType) ( _
	ByVal control As Control, _
	ByVal method As SubOf1Arg(Of ArgType), _
	ByVal value As ArgType) 
	If control Is Nothing Then Throw new ArgumentNullException("control")
	If control.InvokeRequired Then
		control.Invoke(method, New Object() {value})
	Else
		method.Invoke(value)
	End If
End Sub

Public Sub SafeInvoke2ArgSub _
	(Of ArgType1, ArgType2) ( _
	ByVal control As Control, _
	ByVal method As SubOf2Args(Of ArgType1, ArgType2), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2) 
	If control Is Nothing Then Throw new ArgumentNullException("control")
	If control.InvokeRequired Then
		control.Invoke(method, New Object() {value1, value2})
	Else
		method.Invoke(value1, value2)
	End If
End Sub

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Sub SafeInvoke3ArgSub _
	(Of ArgType1, ArgType2, ArgType3) ( _
	ByVal control As Control, _
	ByVal method As SubOf3Args(Of ArgType1, ArgType2, ArgType3), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3) 
	If control Is Nothing Then Throw new ArgumentNullException("control")
	If control.InvokeRequired Then
		control.Invoke(method, New Object() {value1, value2, value3})
	Else
		method.Invoke(value1, value2, value3)
	End If
End Sub

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Sub SafeInvoke4ArgSub _
	(Of ArgType1, ArgType2, ArgType3, ArgType4) ( _
	ByVal control As Control, _
	ByVal method As SubOf4Args(Of ArgType1, ArgType2, ArgType3, ArgType4), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4) 
	If control Is Nothing Then Throw new ArgumentNullException("control")
	If control.InvokeRequired Then
		control.Invoke(method, New Object() {value1, value2, value3, value4})
	Else
		method.Invoke(value1, value2, value3, value4)
	End If
End Sub

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Sub SafeInvoke5ArgSub _
	(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5) ( _
	ByVal control As Control, _
	ByVal method As SubOf5Args(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5) 
	If control Is Nothing Then Throw new ArgumentNullException("control")
	If control.InvokeRequired Then
		control.Invoke(method, New Object() {value1, value2, value3, value4, value5})
	Else
		method.Invoke(value1, value2, value3, value4, value5)
	End If
End Sub

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Sub SafeInvoke6ArgSub _
	(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6) ( _
	ByVal control As Control, _
	ByVal method As SubOf6Args(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6) 
	If control Is Nothing Then Throw new ArgumentNullException("control")
	If control.InvokeRequired Then
		control.Invoke(method, New Object() {value1, value2, value3, value4, value5, value6})
	Else
		method.Invoke(value1, value2, value3, value4, value5, value6)
	End If
End Sub

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Sub SafeInvoke7ArgSub _
	(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7) ( _
	ByVal control As Control, _
	ByVal method As SubOf7Args(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6, _
	ByVal value7 As ArgType7) 
	If control Is Nothing Then Throw new ArgumentNullException("control")
	If control.InvokeRequired Then
		control.Invoke(method, New Object() {value1, value2, value3, value4, value5, value6, value7})
	Else
		method.Invoke(value1, value2, value3, value4, value5, value6, value7)
	End If
End Sub

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Sub SafeInvoke8ArgSub _
	(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7, ArgType8) ( _
	ByVal control As Control, _
	ByVal method As SubOf8Args(Of ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7, ArgType8), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6, _
	ByVal value7 As ArgType7, _
	ByVal value8 As ArgType8) 
	If control Is Nothing Then Throw new ArgumentNullException("control")
	If control.InvokeRequired Then
		control.Invoke(method, New Object() {value1, value2, value3, value4, value5, value6, value7, value8})
	Else
		method.Invoke(value1, value2, value3, value4, value5, value6, value7, value8)
	End If
End Sub


Public Function SafeInvokeNoArgFunction _
	(Of ReturnType) ( _
	ByVal control As Control, _
	ByVal method As FunctionOfNoArgs(Of ReturnType)) _
	As ReturnType
	If control Is Nothing Then Throw New ArgumentNullException("control")
    Dim returnObject As Object
    If control.InvokeRequired Then
    	returnObject = control.Invoke(method)
    Else
    	returnObject = method.Invoke()
	End If
    Return DirectCast(returnObject, ReturnType)
End Function


Public Function SafeInvoke1ArgFunction _
	(Of ReturnType, ArgType) ( _
	ByVal control As Control, _
	ByVal method As FunctionOf1Arg(Of ReturnType, ArgType), _
	ByVal value As ArgType) _
As ReturnType
	If control Is Nothing Then Throw new ArgumentNullException("control")
	Dim returnObject as Object
	If control.InvokeRequired Then
		returnObject = control.Invoke(method, New Object() {value})
	Else
		returnObject = method.Invoke(value)
	End If
	Return DirectCast(returnObject, ReturnType)
End Function

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Function SafeInvoke2ArgFunction _
	(Of ReturnType, ArgType1, ArgType2) ( _
	ByVal control As Control, _
	ByVal method As FunctionOf2Args(Of ReturnType, ArgType1, ArgType2), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2) _
As ReturnType
	If control Is Nothing Then Throw new ArgumentNullException("control")
	Dim returnObject as Object
	If control.InvokeRequired Then
		returnObject = control.Invoke(method, New Object() {value1, value2})
	Else
		returnObject = method.Invoke(value1, value2)
	End If
	Return DirectCast(returnObject, ReturnType)
End Function

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Function SafeInvoke3ArgFunction _
	(Of ReturnType, ArgType1, ArgType2, ArgType3) ( _
	ByVal control As Control, _
	ByVal method As FunctionOf3Args(Of ReturnType, ArgType1, ArgType2, ArgType3), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3) _
As ReturnType
	If control Is Nothing Then Throw new ArgumentNullException("control")
	Dim returnObject as Object
	If control.InvokeRequired Then
		returnObject = control.Invoke(method, New Object() {value1, value2, value3})
	Else
		returnObject = method.Invoke(value1, value2, value3)
	End If
	Return DirectCast(returnObject, ReturnType)
End Function

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Function SafeInvoke4ArgFunction _
	(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4) ( _
	ByVal control As Control, _
	ByVal method As FunctionOf4Args(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4) _
As ReturnType
	If control Is Nothing Then Throw new ArgumentNullException("control")
	Dim returnObject as Object
	If control.InvokeRequired Then
		returnObject = control.Invoke(method, New Object() {value1, value2, value3, value4})
	Else
		returnObject = method.Invoke(value1, value2, value3, value4)
	End If
	Return DirectCast(returnObject, ReturnType)
End Function

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Function SafeInvoke5ArgFunction _
	(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5) ( _
	ByVal control As Control, _
	ByVal method As FunctionOf5Args(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5) _
As ReturnType
	If control Is Nothing Then Throw new ArgumentNullException("control")
	Dim returnObject as Object
	If control.InvokeRequired Then
		returnObject = control.Invoke(method, New Object() {value1, value2, value3, value4, value5})
	Else
		returnObject = method.Invoke(value1, value2, value3, value4, value5)
	End If
	Return DirectCast(returnObject, ReturnType)
End Function

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Function SafeInvoke6ArgFunction _
	(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6) ( _
	ByVal control As Control, _
	ByVal method As FunctionOf6Args(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6) _
As ReturnType
	If control Is Nothing Then Throw new ArgumentNullException("control")
	Dim returnObject as Object
	If control.InvokeRequired Then
		returnObject = control.Invoke(method, New Object() {value1, value2, value3, value4, value5, value6})
	Else
		returnObject = method.Invoke(value1, value2, value3, value4, value5, value6)
	End If
	Return DirectCast(returnObject, ReturnType)
End Function

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Function SafeInvoke7ArgFunction _
	(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7) ( _
	ByVal control As Control, _
	ByVal method As FunctionOf7Args(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6, _
	ByVal value7 As ArgType7) _
As ReturnType
	If control Is Nothing Then Throw new ArgumentNullException("control")
	Dim returnObject as Object
	If control.InvokeRequired Then
		returnObject = control.Invoke(method, New Object() {value1, value2, value3, value4, value5, value6, value7})
	Else
		returnObject = method.Invoke(value1, value2, value3, value4, value5, value6, value7)
	End If
	Return DirectCast(returnObject, ReturnType)
End Function

<SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> _
Public Function SafeInvoke8ArgFunction _
	(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7, ArgType8) ( _
	ByVal control As Control, _
	ByVal method As FunctionOf8Args(Of ReturnType, ArgType1, ArgType2, ArgType3, ArgType4, ArgType5, ArgType6, ArgType7, ArgType8), _
	ByVal value1 As ArgType1, _
	ByVal value2 As ArgType2, _
	ByVal value3 As ArgType3, _
	ByVal value4 As ArgType4, _
	ByVal value5 As ArgType5, _
	ByVal value6 As ArgType6, _
	ByVal value7 As ArgType7, _
	ByVal value8 As ArgType8) _
As ReturnType
	If control Is Nothing Then Throw new ArgumentNullException("control")
	Dim returnObject as Object
	If control.InvokeRequired Then
		returnObject = control.Invoke(method, New Object() {value1, value2, value3, value4, value5, value6, value7, value8})
	Else
		returnObject = method.Invoke(value1, value2, value3, value4, value5, value6, value7, value8)
	End If
	Return DirectCast(returnObject, ReturnType)
End Function


End Module

End Namespace
