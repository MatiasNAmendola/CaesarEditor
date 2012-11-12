@echo off
echo "删除开始"
@echo on
@for /d /r %%c in (obj) do @if exist %%c (rd /s /q "%%c" & echo 删除文件夹%%c)
@echo off
echo "删除完毕"
pause

