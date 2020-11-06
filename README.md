# Hello, this is Web API of Url Shortener!

## Here is a little guide to set up and run Web API successfully on your computer.
Following guide is adapted to Windows operating system.

* If you have not, please install **Visual studio** (https://visualstudio.microsoft.com/vs/) and **Microsoft SQL server** (https://docs.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server?view=sql-server-ver15),
SQL Server Management Studio (https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15) on your computer.

* Clone project on your local device and make sure project directory has a complete access(folder options --> everyone).

* Open project directory with Visual Studio and build it.
* Make sure that project folder is attached to IIS (Internet Information Services Manager) as new website (port should be :3030) and root - project directory path.

* Web API contains web.config file where you should fix connection string to your local database. If it is necessary please make sure SQL server has login with username and password that contains connection string.

🚧 This project is a part! If you would like to get frontend, please click here https://github.com/norak22/url-app !