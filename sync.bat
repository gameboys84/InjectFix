@echo off

@title ====== 同步 InjectFix ======

SET SrcUnityProj=E:\Git\InjectFix-Ni\Source\UnityProj
SET DstUnityProj=F:\DeadEmpire-Git-DEV\DeadEmpire

REM 增量复制
robocopy %SrcUnityProj%\IFixToolKit %DstUnityProj%\Tools\IFixToolKit /E /XX
REM IFix中是代码，部分代码存在差异，请手动合并 
REM robocopy %SrcUnityProj%\Assets\IFix %DstUnityProj%\Assets\IFix /E /XX

REM robocopy %SrcUnityProj%\Assets\Plugins\IFix.Core.dll %DstUnityProj%\Assets\Plugins\IFix.Core.dll /E /XX
xcopy /s /e /y %SrcUnityProj%\Assets\Plugins\IFix.Core.dll %DstUnityProj%\Assets\Plugins\IFix.Core.dll

pause
