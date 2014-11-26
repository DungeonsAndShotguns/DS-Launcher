DSLauncher.net
==============

A .net Game Launcher for the Dungeon and Shotguns
Gaming community. Mostly used for running and updating
the Client for the DS Minecraft.

If you would like to use any of this code to build your 
own launcher feel free. I will warn you that the code in
this project is not the best. A lot of clean up needs to
be done.

There has been a large toss of old code and addtion of some
new items. We now only use the .net exe to redirect the 
Minecraft luncher and lunch the new Java based auto updater.
This basicly means that the exe is just a high end replacment
for a batch file (this allows us to assing an icon in windows).

The change means that our luncher should now be mono complient
and we should not break when Mojang makes changes to there luncher
or login process.

The old luncher is in the 2.0 branch if you would like to use the old 
code.
