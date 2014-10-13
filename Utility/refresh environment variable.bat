Refreshing System Environment Variables in Windows
It is impossible to simply tell a process to ¡°refresh¡± the system environment variables in Windows. A running process will always have the ones present from when he began executing. 
One thing you CAN do, is simply get the current System Environment using vbscript and set it as temporary variables. After the next login, the variables will be there anyway.

Just create a .vbs file:

Set oShell = WScript.CreateObject("WScript.Shell")
filename = oShell.ExpandEnvironmentStrings("%TEMP%\resetvars.bat")
Set objFileSystem = CreateObject("Scripting.fileSystemObject")
Set oFile = objFileSystem.CreateTextFile(filename, TRUE)

set oEnv=oShell.Environment("System")
for each sitem in oEnv 
    oFile.WriteLine("SET " & sitem)
next
path = oEnv("PATH")

set oEnv=oShell.Environment("User")
for each sitem in oEnv 
    oFile.WriteLine("SET " & sitem)
next

path = path & ";" & oEnv("PATH")
oFile.WriteLine("SET PATH=" & path)
oFile.Close

And a matching batch file:

"%~dp0resetvars.vbs"
call "%TEMP%\resetvars.bat"
del "%TEMP%\resetvars.bat"

By launching the batch file, you¡¯ll get updated temporary variables in your current process.
