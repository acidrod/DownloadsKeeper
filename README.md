# DownloadsKeeper (About)
This project aims to become a maintainer for the Windows "Downloads" folder, periodically deleting the files that were downloaded within a period defined by the user in the configuration file.

# Installation
To install this console application as a service just download the project, compile it and copy the files from the /bin/debug to the folder of your choise. Open a command prompt (cmd) with administrative permisions and change the directory where the files you just copied are, from here type this command "MainService.exe install start", this command will install the application as a windows service and it will start every time you boot your computer.

If you whould like to change how often the "search for old downloads" is executed you should edit the "MainService.exe.config" file and change the value for the "RunPeriod" key to what ever you like (in miliseconds). The default value (1800000 Ms) is 30 minutes.

This service will also write a log file to your temp folder to a file called "\DownloadsKeeper\FilesDeleted.log" every time a file is deleted, so you can have track of what has been processed.

# Further changes and colaborations
Any colaboration is welcome and if you whould like to change this code fell free to do so by dowloading and reuploading to your own Git repository.

Any suggestion on new features are also welcome, just make sure you are clear and explain the feature with as much detail as posible.
