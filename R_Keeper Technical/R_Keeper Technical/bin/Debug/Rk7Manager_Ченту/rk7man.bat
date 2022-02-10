REM RK7Man update and start
cd Rk7Manager_Ченту
SET PRELOADPATH=.\PRELOAD
if /%1 == / goto defini
SET CASHINIPATH=%1
goto now_run
:defini
SET CASHINIPATH=.\rk7man.ini
:now_run

preload.exe %CASHINIPATH%
for %%c in (%PRELOADPATH%\*.dll) do del /F %%~nc.bak
for %%c in (%PRELOADPATH%\*.dll) do ren %%~nc.dll *.bak

if not EXIST rk7copy.exe goto nork7copy

rk7copy %PRELOADPATH% .\ /S /C
goto continue

:nork7copy
echo rk7copy.exe not found
xcopy %PRELOADPATH% .\ /S /C /R /Y

:continue
rmdir %PRELOADPATH% /S /Q
start FSupdate.exe /console sch
start "" rk7man.exe %CASHINIPATH%
