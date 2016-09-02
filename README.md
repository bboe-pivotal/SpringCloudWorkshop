# Cloud Native Application Architectures with Cloud Foundry

## Prework

1. Windows or Mac OSX 
2. Java JDK 1.7+ (_Required_, whether or not the .NET labs will be followed)
3. Install the PCF CLI 
    - Download from https://apps.pcf12.cloud.fe.pivotal.io/tools
4. Firefox or Chrome (Not IE)
5. Recommended but not required, Git CLI from https://git-scm.com/downloads.

## Smoke Test
From the command line:

1. Git clone (or download and unzip from Git) https://github.com/cdelashmutt-pivotal/SpringCloudWorkshop.git 
2. `cd SpringCloudWorkshop/session_04/lab_07/complete/hello-actuator`
3. `gradlew.bat build` ( or `./gradlew build` on MacOSX)
4. `java -jar build/libs/hello-actuator-0.0.1-SNAPSHOT.jar`
5. browse to http://localhost:8080
6. `cf login -a https://api.pcf5.cloud.fe.pivotal.io --skip-ssl-validation` (use student1/f1s3rv)

### Optional
 
1.  A Java IDE is strongly recommended.  Eclipse, STS, or IntelliJ will provide the best experience.
2.  Visual Studio, if you plan to try any of the .NET content.
3.  ASP.NET Core - at least one of the labs will be done using ASP.NET Core.  A completed version of this lab will be available/usable for those that don't want to install ASP.NET 5, and just want to review/push the code to Cloud Foundry.

## Student Guide

You can view the student guide for the class [here](student_guide.adoc).
