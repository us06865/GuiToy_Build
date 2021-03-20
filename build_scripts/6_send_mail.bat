@echo off
pushd builds\%1
rem call %~dp0\postbox.exe username@gmail.com "GuiToy_Build_%1" results.txt
results.txt
popd