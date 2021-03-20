@echo off
For /f "tokens=2-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
For /f "tokens=1-3 delims=/:" %%a in ("%TIME%") do (set mytime=%%a%%b%%c)
set build_num="%mydate%_%mytime%"

pushd %~dp0
call build_scripts\1_clean_up.bat
call build_scripts\2_run_msbuild.bat
IF NOT %ERRORLEVEL% == 0 goto ERROR
call build_scripts\3_copy_binaries.bat %build_num%
IF NOT %ERRORLEVEL% == 0 goto ERROR
call build_scripts\4_run_tests.bat %build_num%
IF NOT %ERRORLEVEL% == 0 goto ERROR
call build_scripts\5_parse_results.bat %build_num%
IF NOT %ERRORLEVEL% == 0 goto ERROR
call build_scripts\6_send_mail.bat %build_num%
IF NOT %ERRORLEVEL% == 0 goto ERROR
popd
echo.
echo Done.
goto END

:ERROR
popd
echo ERROR!
goto END

:END
