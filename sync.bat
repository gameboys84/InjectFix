@echo off

SET SrcUnityProj=%1
SET DstUnityProj=%2

@title ====== 同步 InjectFix : %DstUnityProj% ======

if "%DstUnityProj%" == "" exit

REM 增量复制 1
robocopy %SrcUnityProj%\IFixToolKit %DstUnityProj%\Tools\IFixToolKit /E /XX
REM IFix中是代码，部分代码存在差异，请手动合并 
REM robocopy %SrcUnityProj%\Assets\IFix %DstUnityProj%\Assets\IFix /E /XX

REM robocopy %SrcUnityProj%\Assets\Plugins\IFix.Core.dll %DstUnityProj%\Assets\Plugins\IFix.Core.dll /E /XX
xcopy /s /e /y %SrcUnityProj%\Assets\Plugins\IFix.Core.dll %DstUnityProj%\Assets\Plugins\IFix.Core.dll

echo Done : %SrcUnityProj% to %DstUnityProj%
