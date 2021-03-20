@echo off
pushd builds\%1
%~dp0\nunit-summary.exe -o=results.txt
popd