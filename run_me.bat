@echo off

@title ====== 同步 InjectFix ======

SET SrcUnityProj=E:\Git\InjectFix-Ni\Source\UnityProj
SET DstUnityProj=F:\DeadEmpire-Git-DEV\DeadEmpire-DEV
SET DstUnityProj2=F:\DeadEmpire-Git\DeadEmpire

call sync.bat %SrcUnityProj% %DstUnityProj%
call sync.bat %SrcUnityProj% %DstUnityProj2%


pause
