@echo off
echo "ɾ����ʼ"
@echo on
@for /d /r %%c in (obj) do @if exist %%c (rd /s /q "%%c" & echo ɾ���ļ���%%c)
@echo off
echo "ɾ�����"
pause

