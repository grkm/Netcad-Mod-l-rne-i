cd /d %~dp0
set "curr_dir=%CD%"
set "source=%curr_dir%\OrnekModul"
set "destination=C:\grkm\OrnekModul"
IF NOT EXIST %destination% md %destination%
xcopy "%source%" "%destination%" /E /I /H /K /Y
C:\Windows\Microsoft.NET\Framework\v4.0.30319\regasm.exe "C:\grkm\OrnekModul\NetcadUzunYazi.dll" /tlb /codebase
set "source=%curr_dir%\OrnekModul-Netcad7-8.MNU"
set "destination=C:\Netcad7\Modul"
IF NOT EXIST %destination% (echo %destination% Netcad 7 Kurulumu Yok) else (xcopy "%source%" "%destination%" /s /y)
set "source=%curr_dir%\OrnekModul-Netcad5.MNU"
set "destination=C:\Netcad\Modul\NCMacro"
IF NOT EXIST %destination% (echo %destination% Netcad 5 Kurulumu Yok) else (xcopy "%source%" "%destination%" /s /y)
set "source=%curr_dir%\OrnekModul-Netcad7-8.MNU"
set "destination=C:\Netcad8\Modul"
IF NOT EXIST %destination% (echo %destination% Netcad 8 Kurulumu Yok) else (xcopy "%source%" "%destination%" /s /y)
pause

