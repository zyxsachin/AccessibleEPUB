See the end of this message for details on invoking 
just-in-time (JIT) debugging instead of this dialog box.

************** Exception Text **************
System.ArgumentOutOfRangeException: StartIndex cannot be less than zero.
Parameter name: startIndex
   at System.String.Substring(Int32 startIndex, Int32 length)
   at System.String.Substring(Int32 startIndex)
   at AccessibleEPUB.Form1.updateHeaderList()
   at AccessibleEPUB.Form1.parameterOpenFile(String parameter)
   at AccessibleEPUB.Form1.Form1_Shown(Object sender, EventArgs e)
   at System.Windows.Forms.Form.OnShown(EventArgs e)
   at System.Windows.Forms.Form.CallShownEvent()
   at System.Windows.Forms.Control.InvokeMarshaledCallbackDo(ThreadMethodEntry tme)
   at System.Windows.Forms.Control.InvokeMarshaledCallbackHelper(Object obj)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Windows.Forms.Control.InvokeMarshaledCallback(ThreadMethodEntry tme)
   at System.Windows.Forms.Control.InvokeMarshaledCallbacks()


************** Loaded Assemblies **************
mscorlib
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3221.0 built by: NET472REL1LAST_C
    CodeBase: file:///C:/Windows/Microsoft.NET/Framework/v4.0.30319/mscorlib.dll
----------------------------------------
AccessibleEPUB
    Assembly Version: 0.1.9.0
    Win32 Version: 0.1.9.0
    CodeBase: file:///C:/Program%20Files%20(x86)/SZS/SZS%20AccessibleEPUB/AccessibleEPUB.exe
----------------------------------------
System.Windows.Forms
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3221.0 built by: NET472REL1LAST_C
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/System.Windows.Forms/v4.0_4.0.0.0__b77a5c561934e089/System.Windows.Forms.dll
----------------------------------------
System
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3190.0 built by: NET472REL1LAST_C
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/System/v4.0_4.0.0.0__b77a5c561934e089/System.dll
----------------------------------------
System.Drawing
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3056.0 built by: NET472REL1
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/System.Drawing/v4.0_4.0.0.0__b03f5f7f11d50a3a/System.Drawing.dll
----------------------------------------
ICSharpCode.AvalonEdit
    Assembly Version: 5.0.3.0
    Win32 Version: 5.0.3.0
    CodeBase: file:///C:/Program%20Files%20(x86)/SZS/SZS%20AccessibleEPUB/ICSharpCode.AvalonEdit.DLL
----------------------------------------
PresentationFramework
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3221.0
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/PresentationFramework/v4.0_4.0.0.0__31bf3856ad364e35/PresentationFramework.dll
----------------------------------------
WindowsBase
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3221.0 built by: NET472REL1LAST_C
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/WindowsBase/v4.0_4.0.0.0__31bf3856ad364e35/WindowsBase.dll
----------------------------------------
System.Core
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3221.0 built by: NET472REL1LAST_C
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/System.Core/v4.0_4.0.0.0__b77a5c561934e089/System.Core.dll
----------------------------------------
PresentationCore
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3221.0 built by: NET472REL1LAST_C
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_32/PresentationCore/v4.0_4.0.0.0__31bf3856ad364e35/PresentationCore.dll
----------------------------------------
System.Xaml
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3221.0 built by: NET472REL1LAST_C
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/System.Xaml/v4.0_4.0.0.0__b77a5c561934e089/System.Xaml.dll
----------------------------------------
GlobalHotKey
    Assembly Version: 1.1.0.0
    Win32 Version: 1.1.0.0
    CodeBase: file:///C:/Program%20Files%20(x86)/SZS/SZS%20AccessibleEPUB/GlobalHotKey.DLL
----------------------------------------
Geckofx-Core
    Assembly Version: 45.0.34.0
    Win32 Version: 45.0.34.0
    CodeBase: file:///C:/Program%20Files%20(x86)/SZS/SZS%20AccessibleEPUB/Geckofx-Core.DLL
----------------------------------------
System.Configuration
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3056.0 built by: NET472REL1
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/System.Configuration/v4.0_4.0.0.0__b03f5f7f11d50a3a/System.Configuration.dll
----------------------------------------
System.Xml
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3056.0 built by: NET472REL1
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/System.Xml/v4.0_4.0.0.0__b77a5c561934e089/System.Xml.dll
----------------------------------------
PresentationCore.resources
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3056.0 built by: NET472REL1
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/PresentationCore.resources/v4.0_4.0.0.0_fr_31bf3856ad364e35/PresentationCore.resources.dll
----------------------------------------
WindowsFormsIntegration
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3056.0 built by: NET472REL1
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/WindowsFormsIntegration/v4.0_4.0.0.0__31bf3856ad364e35/WindowsFormsIntegration.dll
----------------------------------------
Geckofx-Winforms
    Assembly Version: 45.0.34.0
    Win32 Version: 45.0.34.0
    CodeBase: file:///C:/Program%20Files%20(x86)/SZS/SZS%20AccessibleEPUB/Geckofx-Winforms.DLL
----------------------------------------
System.IO.Compression.FileSystem
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3056.0
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/System.IO.Compression.FileSystem/v4.0_4.0.0.0__b77a5c561934e089/System.IO.Compression.FileSystem.dll
----------------------------------------
System.IO.Compression
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3056.0 built by: NET472REL1
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/System.IO.Compression/v4.0_4.0.0.0__b77a5c561934e089/System.IO.Compression.dll
----------------------------------------
Accessibility
    Assembly Version: 4.0.0.0
    Win32 Version: 4.7.3056.0 built by: NET472REL1
    CodeBase: file:///C:/WINDOWS/Microsoft.Net/assembly/GAC_MSIL/Accessibility/v4.0_4.0.0.0__b03f5f7f11d50a3a/Accessibility.dll
----------------------------------------

************** JIT Debugging **************
To enable just-in-time (JIT) debugging, the .config file for this
application or computer (machine.config) must have the
jitDebugging value set in the system.windows.forms section.
The application must also be compiled with debugging
enabled.

For example:

<configuration>
    <system.windows.forms jitDebugging="true" />
</configuration>

When JIT debugging is enabled, any unhandled exception
will be sent to the JIT debugger registered on the computer
rather than be handled by this dialog box.


