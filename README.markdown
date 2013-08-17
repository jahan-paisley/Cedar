This is a project that I've crafted through wiring best open source frameworks to be a Starter Kit for Enterprise Web Applications for Production or Learning purposes.

 I will try to keep it up to date and improve it incerementally.
   
  
#### How to Build and Run

You need Visual Studio 2012 with the *Nuget Package Manager* extension.   
Packages are not included, but *Nuget Package Restore* features has been enabled, thus *MSBuild* will download all packages.   

For creating the database, create an empty database through [*Sql Server Object Explorer*](http://msdn.microsoft.com/en-us/library/hh272693.aspx).
On the first run, database will be generated.

#### Main Packages
 * Niject \(Logging, Interception, Linfu for dynamix proxy, NLog2 for logging\)
 * EF 6 Beta 1

