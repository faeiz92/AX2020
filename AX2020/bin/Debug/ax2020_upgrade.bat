taskkill /IM AX2020.exe /F

net use a: /delete /yes
net use a: \\192.168.1.38\AX2020Patch2 /USER:ax2020 ax2020

robocopy a:\bin C:\AX2020-2\bin /S /E /IS

robocopy a:\dll C:\AX2020-2\dll  /S /E /IS

robocopy a:\obj C:\AX2020-2\obj  /S /E /IS

robocopy a:\report C:\AX2020-2\report  /S /E /IS

pause