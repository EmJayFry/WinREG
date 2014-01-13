Imports System
Imports System.Runtime.InteropServices

Imports LogicNP.EZShellExtensions

Namespace WinREGShellExtensions

	Public Class ComReg
		Public Sub New()
		End Sub

		' Your assembly should have one static method marked with the 
		' ComRegisterFunction attribute. The function should return void and take 
		' one parameter whose type is System.Type.
		' 
		' This method is used to register the extension on the system by calling the
		' RegisterExtension method.
		'
		<ComRegisterFunction()> Public Shared Sub Register(ByVal t As System.Type)
			InfoTipExtension.RegisterExtension(GetType(InfoTip))
			ContextMenuExtension.RegisterExtension(GetType(CtxMenu))
			PropertySheetExtension.RegisterExtension(GetType(PropSheet))
		End Sub

		' Your assembly should have one static method marked with the 
		' ComUnregisterFunction attribute. The function should return void and take 
		' one parameter whose type is System.Type.
		' 
		' This method is used to register the extension on the system by calling the
		' UnRegisterExtension method.
		'
		<ComUnregisterFunction()> Public Shared Sub UnRegister(ByVal t As System.Type)
			InfoTipExtension.UnRegisterExtension(GetType(InfoTip))
			ContextMenuExtension.UnRegisterExtension(GetType(CtxMenu))
			PropertySheetExtension.UnRegisterExtension(GetType(PropSheet))
		End Sub

	End Class

End Namespace
